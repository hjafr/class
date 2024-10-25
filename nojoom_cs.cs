using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJafr.main_codes;

/// <summary>
/// <right>نجوم</right>
/// <right>نسخه: 1.0.0</right>
/// <right>تاریخ: 1403.07.11</right>
/// </summary>
namespace HJafr.nojoom
{
    /// <summary><right>هیات و نجوم</right></summary>
    class heiat_nojoom
    {
        /// <summary><right>اوقات شرعی</right></summary>
        public static string[] oghat_shari(int[] time, double longitude, double latitude, double time_zone, int calc_m, int asr_m, int nime_shab_m, int time_f, double[] Custom_double)
        {
            List<string> payani = new List<string>();
            PrayTime p = new PrayTime();

            p.setCalcMethod(calc_m);    //  محاسبه اصلی
            if (calc_m == 7)        //  محاسبه دلخواه
                p.setCustomParams(Custom_double);// new double[] { 16, 0, 4, 0, 14 });
            p.setAsrMethod(asr_m);      //  محاسبه عصر
            //p.setHighLatsMethod(nime_shab_m);       // محاسبه نیمه شب   - نیمه شب نیست...
            p.setTimeFormat(time_f);     //  انواع خروجی ساعت

            string[] pray = p.getDatePrayerTimes(time[0], time[1], time[2],  latitude, longitude, time_zone);        //  محاسبه نمازها
            for (int i = 0; i < pray.LongLength; i++)
                payani.Add(pray[i]);

            string[] pray_2 = p.getDatePrayerTimes(time[0], time[1], time[2] + 1, latitude, longitude, time_zone);      //  نمازهای روزبعد
            payani.Add(nime_shab(pray_2[nime_shab_m], pray[4]));        //  نیمه شب شرعی بنابه نماز صبح یا طلوع روز بعد

            return payani.ToArray();
        }

        /// <summary><right>نیمه شب شرعی</right></summary>
        public static string nime_shab(string sobh_str, string shab_str)
        {
            double sobh = Saat_Code.saat_to_num(sobh_str);
            double shab = Saat_Code.saat_to_num(shab_str);
            return Saat_Code.num_to_saat(Saat_Code.saat_tanzim(Saat_Code.saat_tanzim(sobh - shab) / 2 + shab));     //  فاصله غروب تا نماز صبح یا طلوع، تقسیم بر دو، جمع با غروب - مختصرش میشه این
        }
    }

    /// <summary><right>توابع مخصوص اوقات شرعی</right></summary>
    class PrayTime
    {
        #region Constants
        // Calculation Methods
        public static int Jafari = 0;    // Ithna Ashari
        public static int Karachi = 1;    // University of Islamic Sciences, Karachi
        public static int ISNA = 2;    // Islamic Society of North America (ISNA)
        public static int MWL = 3;    // Muslim World League (MWL)
        public static int Makkah = 4;    // Umm al-Qura, Makkah
        public static int Egypt = 5;    // Egyptian General Authority of Survey
        public static int Custom = 7;    // Custom Setting
        public static int Tehran = 6;    // Institute of Geophysics, University of Tehran

        // Juristic Methods
        public static int Shafii = 0;    // Shafii (standard)
        public static int Hanafi = 1;    // Hanafi

        // Adjusting Methods for Higher Latitudes
        public static int None = 0;    // No adjustment
        public static int MidNight = 1;    // middle of night
        public static int OneSeventh = 2;    // 1/7th of night
        public static int AngleBased = 3;    // angle/60th of night

        // Time Formats
        public static int Time24 = 0;    // 24-hour format
        public static int Time12 = 1;    // 12-hour format
        public static int Time12NS = 2;    // 12-hour format with no suffix
        public static int Floating = 3;    // floating point number

        // Time Names
        public static String[] timeNames = { "Fajr", "Sunrise", "Dhuhr", "Asr", "Sunset", "Maghrib", "Isha" };
        static String InvalidTime = "----";  // The string used for inv
        #endregion

        #region Global Variables
        private int calcMethod = 3;     // caculation method
        private int asrJuristic;        // Juristic method for Asr
        private int dhuhrMinutes = 0;       // minutes after mid-day for Dhuhr
        private int adjustHighLats = 1; // adjusting method for higher latitudes

        private int timeFormat_main = 0;     // time format

        private double lat;        // latitude
        private double lng;        // longitude
        private double timeZone_main;   // time-zone
        private double JDate;      // Julian date

        private int[] times;
        #endregion

        #region Technical Settings
        private int numIterations = 1;      // number of iterations needed to compute times
        #endregion

        #region Calc Method Parameters
        private double[][] methodParams;
        public PrayTime()
        {
            times = new int[7];
            methodParams = new double[8][];
            methodParams[Jafari] = new double[] { 16, 0, 4, 0, 14 };
            methodParams[Karachi] = new double[] { 18, 1, 0, 0, 18 };
            methodParams[ISNA] = new double[] { 15, 1, 0, 0, 15 };
            methodParams[MWL] = new double[] { 18, 1, 0, 0, 17 };
            methodParams[Makkah] = new double[] { 18.5, 1, 0, 1, 90 };
            methodParams[Egypt] = new double[] { 19.5, 1, 0, 0, 17.5 };
            methodParams[Tehran] = new double[] { 17.7, 0, 4.5, 0, 14 };
            methodParams[Custom] = new double[] { 16, 0, 4, 0, 14 };
        }

        public String[] getPrayerTimes(int year, int month, int day, double latitude, double longitude, double timeZone)        // return prayer times for a given date
         => getDatePrayerTimes(year, month + 1, day, latitude, longitude, timeZone);

        public void setCalcMethod(int methodID) => calcMethod = methodID;        // set the calculation method
        public void setAsrMethod(int methodID)        // set the juristic method for Asr
        {
            if (methodID < 0 || methodID > 1)
                return;
            asrJuristic = methodID;
        }

        public void setFajrAngle(double angle) => setCustomParams(new double[] { angle, -1, -1, -1, -1 });        // set the angle for calculating Fajr
        public void setMaghribAngle(double angle) => setCustomParams(new double[] { -1, 0, angle, -1, -1 });        // set the angle for calculating Maghrib
        public void setIshaAngle(double angle) => setCustomParams(new double[] { -1, -1, -1, 0, angle });        // set the angle for calculating Isha
        public void setDhuhrMinutes(double minutes) => dhuhrMinutes = (int)minutes;        // set the minutes after mid-day for calculating Dhuhr
        public void setMaghribMinutes(double minutes) => setCustomParams(new double[] { -1, 1, minutes, -1, -1 });        // set the minutes after Sunset for calculating Maghrib
        public void setIshaMinutes(double minutes) => setCustomParams(new double[] { -1, -1, -1, 1, minutes });        // set the minutes after Maghrib for calculating Isha
        public void setCustomParams(double[] param)        // set custom values for calculation parameters
        {
            for (int i = 0; i < 5; i++)
                if (param[i] == -1)
                    methodParams[Custom][i] = (param[i] == -1) ? methodParams[calcMethod][i] : param[i];
            calcMethod = Custom;
        }
        public void setHighLatsMethod(int methodID) => adjustHighLats = methodID;        // set adjusting method for higher latitudes
        public void setTimeFormat(int timeFormat) => timeFormat_main = timeFormat;        // set the time format

        public String floatToTime24(double time)        // convert float hours to 24h format
        {
            if (time < 0)
                return InvalidTime;
            time = FixHour(time);// + 0.5 / 60);  // add 0.5 minutes to round
            double hours = Math.Floor(time);
            time = (time - hours) * 60;
            double minutes = Math.Floor(time);
            time = (time - minutes) * 60;
            double secends = Math.Floor(time);
            //string little___ = (time - secends).ToString();
            //string little = little___.Substring(1, little___.Length - 1);
            return twoDigitsFormat(hours) + ":" + twoDigitsFormat(minutes) + ":" + twoDigitsFormat(secends);// + little;
        }

        public String floatToTime12(double time, bool noSuffix)        // convert float hours to 12h format
        {
            if (time < 0)
                return InvalidTime;
            time = FixHour(time);// + 0.5 / 60);  // add 0.5 minutes to round
            double hours = Math.Floor(time);
            time = (time - hours) * 60;
            double minutes = Math.Floor((time - hours) * 60);
            time = (time - minutes) * 60;
            double secends = Math.Floor(time);
            //string little___ = (time - secends).ToString();
            //string little = little___.Substring(1, little___.Length - 1);
            String suffix = hours >= 12 ? " pm" : " am";
            hours = (hours + 12 - 1) % 12 + 1;
            return twoDigitsFormat(hours) + ":" + twoDigitsFormat(minutes) + ":" + twoDigitsFormat(secends) + (noSuffix ? "" : suffix);
        }

        public String floatToTime12NS(double time) => floatToTime12(time, true);        // convert float hours to 12h format with no suffix
        #endregion

        #region Compute Prayer Times
        public String[] getDatePrayerTimes(int year, int month, int day, double latitude, double longitude, double timeZone)        // return prayer times for a given date
        {
            lat = latitude;
            lng = longitude;
            timeZone_main = timeZone;
            JDate = JulianDate(year, month, day) - longitude / (15 * 24);

            return computeDayTimes();
        }

        public double[] sunPosition(double jd)        // compute declination angle of sun and equation of time
        {
            double D = jd - 2451545.0;
            double g = FixAngle(357.529 + 0.98560028 * D);
            double q = FixAngle(280.459 + 0.98564736 * D);
            double L = FixAngle(q + 1.915 * dsin(g) + 0.020 * dsin(2 * g));

            double R = 1.00014 - 0.01671 * dcos(g) - 0.00014 * dcos(2 * g);
            double e = 23.439 - 0.00000036 * D;

            double d = darcsin(dsin(e) * dsin(L));
            double RA = darctan2(dcos(e) * dsin(L), dcos(L)) / 15;
            RA = FixHour(RA);
            double EqT = q / 15 - RA;

            return new double[] { d, EqT };
        }

        public double equationOfTime(double jd) => sunPosition(jd)[1];        // compute equation of time
        public double sunDeclination(double jd) => sunPosition(jd)[0];        // compute declination angle of sun

        public double computeMidDay(double t)        // compute mid-day (Dhuhr, Zawal) time
        {
            double T = equationOfTime(JDate + t);
            double Z = FixHour(12 - T);
            return Z;
        }

        public double computeTime(double G, double t)        // compute time for a given angle G
        {
            //System.out.println("G: "+G);

            double D = sunDeclination(JDate + t);
            double Z = computeMidDay(t);
            double V = ((double)1 / 15) * darccos((-dsin(G) - dsin(D) * dsin(lat)) /
                    (dcos(D) * dcos(lat)));
            return Z + (G > 90 ? -V : V);
        }

        public double computeAsr(int step, double t)        // compute the time of Asr
        {   // Shafii: step=1, Hanafi: step=2
            double D = sunDeclination(JDate + t);
            double G = -darccot(step + dtan(Math.Abs(lat - D)));
            return computeTime(G, t);
        }
        #endregion

        #region Compute Prayer Times
        public double[] computeTimes(double[] times)        // compute prayer times at given julian date
        {
            double[] t = dayPortion(times);

            double Fajr = computeTime(180 - methodParams[calcMethod][0], t[0]);
            double Sunrise = computeTime(180 - 0.833, t[1]);
            double Dhuhr = computeMidDay(t[2]);
            double Asr = computeAsr(1 + asrJuristic, t[3]);
            double Sunset = computeTime(0.833, t[4]); ;
            double Maghrib = computeTime(methodParams[calcMethod][2], t[5]);
            double Isha = computeTime(methodParams[calcMethod][4], t[6]);

            return new double[] { Fajr, Sunrise, Dhuhr, Asr, Sunset, Maghrib, Isha };
        }

        public double[] adjustHighLatTimes(double[] times)        // adjust Fajr, Isha and Maghrib for locations in higher latitudes
        {
            double nightTime = GetTimeDifference(times[4], times[1]); // sunset to sunrise

            // Adjust Fajr
            double FajrDiff = nightPortion(methodParams[calcMethod][0]) * nightTime;
            if (GetTimeDifference(times[0], times[1]) > FajrDiff)
                times[0] = times[1] - FajrDiff;

            // Adjust Isha
            double IshaAngle = (methodParams[calcMethod][3] == 0) ? methodParams[calcMethod][4] : 18;
            double IshaDiff = nightPortion(IshaAngle) * nightTime;
            if (GetTimeDifference(times[4], times[6]) > IshaDiff)
                times[6] = times[4] + IshaDiff;

            // Adjust Maghrib
            double MaghribAngle = (methodParams[calcMethod][1] == 0) ? methodParams[calcMethod][2] : 4;
            double MaghribDiff = nightPortion(MaghribAngle) * nightTime;
            if (GetTimeDifference(times[4], times[5]) > MaghribDiff)
                times[5] = times[4] + MaghribDiff;

            return times;
        }

        public double nightPortion(double angle)        // the night portion used for adjusting times in higher latitudes
        {
            double val = 0;
            if (adjustHighLats == AngleBased)
                val = 1.0 / 60.0 * angle;
            if (adjustHighLats == MidNight)
                val = 1.0 / 2.0;
            if (adjustHighLats == OneSeventh)
                val = 1.0 / 7.0;

            return val;
        }

        public double[] dayPortion(double[] times)
        {
            for (int i = 0; i < times.Length; i++)
                times[i] /= 24;
            return times;
        }

        public String[] computeDayTimes()        // compute prayer times at given julian date
        {
            double[] times = { 5, 6, 12, 13, 18, 18, 18 }; //default times

            for (int i = 0; i < numIterations; i++)
                times = computeTimes(times);

            times = adjustTimes(times);
            return adjustTimesFormat(times);
        }

        public double[] adjustTimes(double[] times)     // adjust times in a prayer time array
        {
            for (int i = 0; i < 7; i++)
                times[i] += timeZone_main - lng / 15;

            times[2] += dhuhrMinutes / 60; //Dhuhr

            if (methodParams[calcMethod][1] == 1) // Maghrib
                times[5] = times[4] + methodParams[calcMethod][2] / 60.0;

            if (methodParams[calcMethod][3] == 1) // Isha
                times[6] = times[5] + methodParams[calcMethod][4] / 60.0;

            if (adjustHighLats != None)
                times = adjustHighLatTimes(times);
            return times;
        }

        public String[] adjustTimesFormat(double[] times)
        {
            String[] formatted = new String[times.Length];

            if (timeFormat_main == Floating)
                for (int i = 0; i < times.Length; ++i)
                    formatted[i] = times[i] + "";
            else
                for (int i = 0; i < 7; i++)
                    if (timeFormat_main == Time12)
                        formatted[i] = floatToTime12(times[i], true);
                    else if (timeFormat_main == Time12NS)
                        formatted[i] = floatToTime12NS(times[i]);
                    else
                        formatted[i] = floatToTime24(times[i]);
            return formatted;
        }
        #endregion

        #region Misc Functions
        public double GetTimeDifference(double c1, double c2) => FixHour(c2 - c1);        // compute the difference between two times
        public String twoDigitsFormat(double num) => (num < 10) ? "0" + num : num + "";         // add a leading 0 if necessary
        #endregion

        #region Julian Date Functions
        public double JulianDate(int year, int month, int day)      // calculate julian date from a calendar date
        {
            if (month <= 2)
            {
                year -= 1;
                month += 12;
            }
            double A = Math.Floor(year / 100.0);
            double B = 2 - A + Math.Floor(A / 4);

            double JD = Math.Floor(365.25 * (year + 4716)) + Math.Floor(30.6001 * (month + 1)) + day + B - 1524.5;
            return JD;
        }
        #endregion

        #region Time-Zone Functions
        public bool UseDayLightaving(int year, int month, int day)        // detect daylight saving in a given date
        => TimeZone.CurrentTimeZone.IsDaylightSavingTime(new DateTime(year, month, day));
        #endregion

        #region Trigonometric Functions
        public double dsin(double d) => Math.Sin(DegreeToRadian(d));         // degree sin
        public double dcos(double d) => Math.Cos(DegreeToRadian(d));         // degree cos
        public double dtan(double d) => Math.Tan(DegreeToRadian(d));         // degree tan
        public double darcsin(double x) => RadianToDegree(Math.Asin(x));         // degree arcsin
        public double darccos(double x) => RadianToDegree(Math.Acos(x));         // degree arccos
        public double darctan(double x) => RadianToDegree(Math.Atan(x));         // degree arctan
        public double darctan2(double y, double x) => RadianToDegree(Math.Atan2(y, x));         // degree arctan2
        public double darccot(double x) => RadianToDegree(Math.Atan(1 / x));         // degree arccot

        public double RadianToDegree(double radian) => (radian * 180.0) / Math.PI;         // Radian to Degree
        public double DegreeToRadian(double degree) => (degree * Math.PI) / 180.0;         // degree to radian

        public double FixAngle(double angel) => FixDaraje(angel, false);
        public double FixHour(double daraje) => FixDaraje(daraje, true);
        public double FixDaraje(double daraje, bool hour)
        {
            double x = hour ? 24.0 : 360.0;
            daraje = daraje - x * (Math.Floor(daraje / x));
            daraje = daraje < 0 ? daraje + x : daraje;
            return daraje;
        }
        #endregion
    }
}
