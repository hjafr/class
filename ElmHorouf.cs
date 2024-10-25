using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJafr.Enums;
using HJafr.data_cls;
using HJafr.math_old_cls;
using HJafr.harf_change_cls;
using HJafr.main_codes;
using HJafr.sarf;

/// <summary>
/// <right>علم حروف</right>
/// <right>نسخه: 2.1.0</right>
/// <right>تاریخ: 1403.07.11</right>
/// </summary>
namespace HJafr.ElmHorouf
{
    /// <summary><right>حساب عدد و تبدیل حرف به عدد</right></summary>
    public class Hesab
    {
        /// <summary><right>محاسبه مقدار عددی یک نوشته</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="dh"><right>دایره عدد</right></param>
        /// <param name="dn"><right>دایره حرف</right></param>
        /// <returns></returns>
        public static int select(string text, D_int dh = D_int.kabir, D_name dn = D_name.ابجد)
        {
            text = Harf_Change.alefbae(text);
            string d = Data.d(dn);
            Hesab a = new Hesab();
            switch (dh)
            {
                default: case D_int.کبیر: return a.کبیر(text, d);
                case D_int.معکوس: return a.معکوس(text, d);
                case D_int.وضعی: return a.وضعی(text, d);
                case D_int.افلاکی: return a.افلاکی(text, d);
                case D_int.صغیر: return a.صغیر(text, d);
                case D_int.بروجی: return a.بروجی(text, d);

                case D_int.عناصری: return a.عناصری(text, d);
                case D_int.کواکبی: return a.کواکبی(text, d);
                case D_int.منازلی: return a.منازلی(text, d);
                case D_int.آحاد: return a.آحاد(text, d);
                case D_int.عشرات: return a.عشرات(text, d);
                case D_int.مآت: return a.مآت(text, d);
                case D_int.الوف: return a.الوف(text, d);

                case D_int.ابجدادریسی: return a.ابجدادریسی(text, d);
                case D_int.ابجدعددوسط: return a.ابجدعددوسط(text, d);
                case D_int.ابجدثانی: return a.ابجدثانی(text, d);
                case D_int.ابجدعلوی: return a.ابجدعلوی(text, d);
                case D_int.ابجدازامیر: return a.ابجدازامیرالمومنین(text, d);
                case D_int.ابجدشعیب: return a.ابجدشعیب(text, d);
                case D_int.ابجدنبوی: return a.ابجدنبوی(text, d);

                case D_int.ابتث_آدم: return a.ابتث_آدم(text, d);
                case D_int.ابتث_امیر: return a.ابتث_امیر(text, d);
                case D_int.ابتث_صادق: return a.ابتث_صادق(text, d);

                case D_int.اهطم_مرتبه: return a.اهطممرتبه(text, d);
                case D_int.اهطم_هجا: return a.اهطمهجا(text, d);
                case D_int.اهطم_فیثاغورث: return a.اهطمفیثاغورث(text, d);
                case D_int.اهطم_دانیال: return a.اهطمدانیال(text, d);
                case D_int.اهطم_وسطی: return a.اهطموسطی(text, d);
                case D_int.اهطم_مثلثات: return a.اهطممثلثات(text, d);
                case D_int.اهطم_تسلط: return a.اهطموسیط(text, d);
                case D_int.اهطم_مراد: return a.اهطموسیطدوم(text, d);

                case D_int.ایقغ_ابجدکبیر: return a.ایقغ_ابجدکبیر(text, d);
                case D_int.ایقغ_یوشع: return a.ایقغ_یوشع(text, d);

                case D_int.فال_1: return a.فال1(text, d);
            }
        }
        /// <summary>
        /// <right>محاسبه مقدارهای عددی آرایه‌ای از نوشته</right>
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="dh"><right>دایره عدد</right></param>
        /// <param name="dn"><right>دایره حرف</right></param>
        /// <returns></returns>
        public static int[] select(string[] text, D_int dh = D_int.kabir, D_name dn = D_name.ابجد)
        {
            int[] payani = new int[text.LongLength];
            for (int x = 0; x < text.LongLength; x++)
                payani[x] = select(text[x], dh, dn);
            return payani;
        }

        /// <summary><right>مداخل اربعه</right></summary>
        public static int[] madakhel_arbae(string text)
        {
            int[] madkhal = new int[4];
            madkhal[0] = select(text);            //  کبیر
            madkhal[1] = select(text, D_int.افلاکی);      //  افلاکی
            madkhal[2] = madkhal_vasit(madkhal[0]);     //  وسیط
            madkhal[3] = tarh_rad_ahad(madkhal[0]);     //  رد به آحاد کامل یا همان صغیر
            return madkhal;
        }

        /// <summary><right>مدخل وسیط یک عدد</right></summary>
        public static int madkhal_vasit(int num) { return (num / 10) + (num % 10); }
        /// <summary><right>رد به آحاد</right></summary>
        public static int rad_be_ahad(int Fnum)
        {
            int num = 0;
            for (int i = 0; i < Fnum.ToString().Length; i++)
                num += Convert.ToInt32(Fnum.ToString().Substring(i, 1));
            return num;
        }
        /// <summary><right>رد به آحاد تا یک رقمی شدن و خروجی دادن همه آن‌ها</right></summary>
        public static int[] rad_be_ahad_kamel(int Fnum)
        {
            List<int> num = new List<int>();
            num.Add(Fnum);
            for (int i = 0; num.Last() > 9; i++)
                num.Add(madkhal_vasit(num.Last()));
            return num.ToArray();
        }

        /// <summary>
        /// <right>رد به آحاد بیشتر از عدد طرح</right>
        /// </summary>
        /// <param name="num"><right>عدد دلخواه</right></param>
        /// <param name="tarh"><right>عدد طرح</right></param>
        /// <returns><right>رد به آحاد تا زمانی که بیشتر از عدد طرح نباشد</right></returns>
        public static int tarh_rad_ahad(int num, int tarh = 9)
        {
            while (num > tarh)
                num = rad_be_ahad(num);
            return num;
        }

        /// <summary><right>تعداد حروف</right></summary>
        public static int tedad_harf(string text) { return Harf_Change.alefbae(text).Length; }
        /// <summary><right>تعداد نقطه</right></summary>
        public static int noghte(string text)
        {
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                string h = text.Substring(i, 1);
                j += ("بجزنفخذضظغ".Contains(h)) ? 1 :
                    ("یقت".Contains(h)) ? 2 :
                    ("شث".Contains(h)) ? 3 : 0;
            }
            return j;
        }

        /// <summary>
        /// <right>محاسبه با اسقاط</right>
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="d"><right>دایره حرف</right></param>
        /// <param name="i"><right>دایره عدد</right></param>
        /// <param name="tarh"><right>عدد طرح</right></param>
        /// <param name="baghi"><right>طرح یا صفر</right></param>
        /// <returns></returns>
        public static int esghat(string text, D_int dh, D_name dn, int tarh, bool baghi)
        {
            int num = 0;
            for (int j = 0; j < text.Length; j++)
                num += Math_Old.tarh_esghat(select(text.Substring(j, 1), dh, dn), tarh, baghi);     //  اسقاط
            return num;
        }

        /// <summary><right>اعمال ریاضی</right></summary>
        /// <param name="num">عدد</param>
        /// <param name="tarh">عدددوم</param>
        /// <param name="amal">عمل</param>
        /// <returns></returns>
        public static int aamal_riazi(int num, int tarh, عمل_ریاضی amal)
        {
            switch (amal)
            {
                default:
                case عمل_ریاضی.جمع: return num + tarh;
                case عمل_ریاضی.تفریق: return num - tarh;
                case عمل_ریاضی.ضرب: return num * tarh;
                case عمل_ریاضی.تقسیم: return num / tarh;
                case عمل_ریاضی.باقیمانده: return num % tarh;
                case عمل_ریاضی.اسقاط: return Math_Old.tarh_esghat(num, tarh);
                case عمل_ریاضی.طرح_اسقاط: return Math_Old.tarh_esghat(num - tarh, tarh);
            }
        }
        public static int aamal_riazi(string text, int tarh, عمل_ریاضی amal) { return aamal_riazi(select(text, D_int.وضعی), tarh, amal); }

        #region حسابهای مختلف
        public int kabir_fun(int j) { return ((j % 9) + 1) * (int)Math.Pow(10, j / 9); }        //  معادله عدد کبیر
        public int kabir_esghat(string text, string d, int tarh, bool baghi = false)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
                num += kabir_fun(d.IndexOf(text.Substring(i, 1))) % tarh;
            return num;
        }

        public int کبیر(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += kabir_fun(j);
            }
            return num;
        }
        public int معکوس(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += kabir_fun(d.Length - 1 - j);
                //  معکوس مکان، با کم کردن از مقدار طول دایره منهای یک بجای 27 برای تطبیق در دایره فارسی یا عبری یا انگلیسی
                //  سپس محاسبه عدد کبیر آن
            }
            return num;
        }
        public int وضعی(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
                num += d.IndexOf(text.Substring(i, 1)) + 1;     //  مکان در دایره + 1
            return num;
        }
        public int افلاکی(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += Math_Old.tarh_esghat(j + 1, 9);      //  اسقاط وضعی با عدد 9
                //  چندین روش می‌توان نوشت که ساده ترین این است
            }
            return num;
        }
        public int صغیر(string text, string d) { return kabir_esghat(text, d, 12, false); }      //  اسقاط کبیر با عدد 12 بدون باقی‌مانده
        public int بروجی(string text, string d) { return kabir_esghat(text, d, 12, true); }      //  اسقاط کبیر با عدد 12 همراه باقی مانده
        public int عناصری(string text, string d) { return kabir_esghat(text, d, 4); }       //  اسقاط کبیر 4
        public int کواکبی(string text, string d) { return kabir_esghat(text, d, 7); }       //  اسقاط کبیر 7
        //public int افلاکی(string text, string d) { return kabir_esghat(text, d, 9);}     //  اسقاط کبیر 9
        //public int بروجی(string text, string d) { return kabir_esghat(text, d, 12);}     //  اسقاط کبیر 12
        public int منازلی(string text, string d) { return kabir_esghat(text, d, 28); }      //  اسقاط کبیر 28
        public int آحاد(string text, string d) { return kabir_esghat(text, d, 8); }     //  اسقاط کبیر 8
        public int عشرات(string text, string d) { return kabir_esghat(text, d, 16); }       //  اسقاط کبیر 16
        public int مآت(string text, string d) { return kabir_esghat(text, d, 24); }     //  اسقاط کبیر 24
        public int الوف(string text, string d) { return kabir_esghat(text, d, 32); }        //  اسقاط کبیر 32

        public int ابجدادریسی(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += (int)Math.Pow(2, (j % 4) + (j / 4));
            }
            return num;
        }
        public int ابجدعددوسط(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                if (j <= 13)
                    num += j + 1;
                else if (j <= 18)
                    num += j - 9;
                else
                    switch (j)
                    {
                        case 19: num += 12; break;
                        case 20: case 21: num += 2; break;
                        case 22: num += 14; break;
                        case 23: case 24: num += 20; break;
                        case 25: num += 29; break;
                        default: num += j + 1; break;
                    }
            }
            return num;
        }
        public int ابجدثانی(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                if (j < 9)
                    switch (j)
                    {
                        case 0: num += 1; break;
                        case 1: num += 4; break;
                        case 2: num += 9; break;
                        case 3: num += 8; break;
                        case 4: num += 20; break;
                        case 5: num += 12; break;
                        case 6: num += 49; break;
                        case 7: num += 16; break;
                        case 8: num += 27; break;
                    }
                else
                    num += (j < 18) ?
                        (j - 8) * 20 :
                        (j - 17) * 200;
            }
            return num;
        }
        public int ابجدعلوی(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                for (int h = 7; h > 0; h--)
                    if (j >= h)
                        j -= h;
                    else
                    {
                        num += j + 1 + 7 - h;
                        break;
                    }
            }
            return num;
        }
        public int ابجدازامیرالمومنین(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                for (int h = 7; h > 0; h--)
                    if (j >= h)
                        j -= h;
                    else
                    {
                        num += j + 8 + 7 - h;
                        break;
                    }
            }
            return num;
        }
        public int ابجدشعیب(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                int k = Math_Old.tarh_esghat(j + 1, 4) * 2 + 7;
                num += (int)(k * Math.Pow(2, j / 4));
            }
            return num;
        }
        public int ابجدنبوی(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += (int)(3 * Math.Pow(2, j % 4) * Math.Pow(2, j / 4));
            }
            return num;
        }

        public int اهطممرتبه(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += (j < 7) ? j + 9 :
                    (j < 14) ? j + 11 :
                    (j < 21) ? j + 22 :
                    j + 51;
            }
            return num;
        }
        public int اهطمهجا(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += (int)Math.Pow(2, j + (j / 7) * (-6));
            }
            return num;
        }
        public int اهطمفیثاغورث(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += Math_Old.tarh_esghat(j + 1, 7) + j / 7;
            }
            return num;
        }
        public int اهطمدانیال(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                try
                {
                    num += 3 * (int)Math.Pow(2, j - 1);
                }
                catch { return 0; }
            }
            return num;
        }
        public int اهطموسطی(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += j + 9 + ((j / 7) * 2);
            }
            return num;
        }
        public int اهطممثلثات(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += 10 * (j + 1);
            }
            return num;
        }
        public int اهطموسیط(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += 100 * (j + 1);
            }
            return num;
        }
        public int اهطموسیطدوم(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                int k = Math_Old.tarh_esghat(j + 1, 7);
                num += 100 * ((j < 7) ? k :
                    (j < 14) ? (k + 2) :
                    (j < 21) ? (k + 5) :
                    (k + 8));
            }
            return num;
        }

        public int ابتث_آدم(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += (j + 1 - 9 * (j / 9)) * (int)Math.Pow(2, j / 9);
            }
            return num;
        }
        public int ابتث_امیر(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                for (int k = 1; k <= j + 1; k++)
                    num += k;
            }
            return num;
        }
        public int ابتث_صادق(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += (j + 1) * 2;
            }
            return num;
        }

        public int ایقغ_ابجدکبیر(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                if (j == 0)
                    num++;
                else
                {
                    int bg = Math_Old.tarh_esghat(j, 3);     //  تکرار رقم مثلا 111 میشود 3
                    if (j < 4)                      //  انجام یک بار حلقه بالا برای 4 حرف اول
                        bg++;
                    int k = 0;
                    for (int h = 0; h < bg; h++)    //  تبدیل به 11 یا 111 یا 1111 شدن
                        k = k * 10 + 1;
                    num += k * ((j - 1) / 3 + 1);   //  ضربدر 2 یا 3 یا... شدن
                }
            }
            return num;
        }
        public int ایقغ_یوشع(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                if (j == 0)
                    num++;
                else
                {
                    int bg = Math_Old.tarh_esghat(j, 3);     //  تکرار رقم مثلا 111 میشود 3
                    if (j < 4)                      //  انجام یک بار حلقه بالا برای 4 حرف اول
                        bg++;
                    int k = 0;
                    for (int h = 0; h < bg; h++)    //  تبدیل به 11 یا 111 یا 1111 شدن
                        k = k * 10 + 1;
                    num += k * ((j - 1) / 3 + 1);   //  ضربدر 2 یا 3 یا... شدن
                }
            }
            return num;
        }


        public int فال1(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += (i != 6) ? Math_Old.tarh_esghat(kabir_fun(j), 7, false) : 7;      //  همگی اسقاط باقیمانده مگر در بار اول
            }
            return num;
        }
        #endregion
    }

    /// <summary><right>استنطاق و تبدیل عدد به حرف</right></summary>
    public class Stentagh
    {
        /// <summary>
        /// <right>استنطاق کبیر نوشته : اصلی</right>
        /// </summary>
        /// <param name="fnum">عدد</param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <returns></returns>
        public static string kabir(string fnum, D_name dn = D_name.ابجد, روش_استنطاق noe = روش_استنطاق.شرقی)
        {
            if (fnum.Substring(0, 1) == "-")        //  عدد منفی
                return "";

            fnum = Math_Harf.num_just(fnum);        //  تبدیل به عدد

            string d = Data.d(dn);
            int flen = fnum.Length;     //  تعداد ارقام

            //  اماده دسته بندی کردن 3 تایی
            if (flen % 3 == 1)
                fnum = "00" + fnum;
            else if (flen % 3 == 2)
                fnum = "0" + fnum;
            flen = fnum.Length;

            string[] numdaste = new string[flen / 3];       //  عدد
            string[] s_tmp = new string[flen / 3];     //  حروف هر دسته
            for (int i = 0; i < flen / 3; i++)
            {
                numdaste[i] = "";
                s_tmp[i] = "";
            }

            // دسته‌بندی
            for (int i = 0, m = (flen / 3) - 1; i < flen; i = i + 3, m--)
                numdaste[m] = fnum.Substring(i, 3);

            #region تبدیل هر دسته به حروف
            for (int i = 0; i < flen / 3; i++)
            {
                string[] J = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    int I = Convert.ToInt32(numdaste[i].Substring(j, 1)) - 1;       //  تبدیل عدد به جایگاه آن در دایره
                    J[j] = (I < 0) ? "" :
                        (
                            //(j == 2) ? ((I != 0) ? d.Substring(I, 1) : (numdaste[i] != "001" || fnum == "001" || (numdaste[i] == "001" && i != flen / 3 - 1)) ? d.Substring(0, 1) : "") :       //  یکان
                            (j == 2) ? ((I != 0) ? d.Substring(I, 1) : (numdaste[i] != "001" || fnum == "001" || i != flen / 3 - 1) ? d.Substring(0, 1) : "") :       //  یکان
                            (j == 1) ? d.Substring(I + 9, 1) :      //  دهگان
                            d.Substring(I + 18, 1)      //  صدگان
                        );
                }
                string temp = J[2] + J[1] + J[0];       //  جمع بندی
                s_tmp[i] = temp;
            }
            #endregion

            #region جمع کردن هر دسته و قرار گیری غین
            string payani = s_tmp[0];
            for (int i = 1; i < flen / 3; i++)
            {
                string hezar = "";      //  نماد هزار : غ در ابجد
                for (int j = 1; j <= i; j++)
                    hezar += d.Substring(27, 1);
                if (s_tmp[i] != "" || (numdaste[i] == "001" && i == flen / 3 - 1))
                {
                    if (noe == روش_استنطاق.قدیم)
                        payani += (s_tmp[i] != "ا" ? s_tmp[i] : "") + hezar;
                    else
                        payani += hezar + s_tmp[i];
                }
            }
            if (noe == روش_استنطاق.غربی)        //  استنطاق شرقی را معکوس می‌کنیم
                payani = Bast.maakoos_102(payani);
            #endregion

            return payani;
        }
        /// <summary>
        /// <right>استنطاق کبیر نوشته آرایه‌ای</right>
        /// </summary>
        /// <param name="fnum">عدد</param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <param name="mod"><right>نوع استنطاق</right></param>
        /// <returns></returns>
        public static string[] kabir(string[] num, D_name dn, روش_استنطاق noe = روش_استنطاق.شرقی)
        {
            string[] payani = new string[num.LongLength];
            for (int i = 0; i < num.LongLength; i++)
                payani[i] = kabir(num[i], dn, noe);
            return payani;
        }
        /// <summary>
        /// <right>استنطاق کبیر نوشته : اصلی</right>
        /// </summary>
        /// <param name="fnum">عدد</param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <returns></returns>
        public static string kabir(int num, D_name dn = D_name.ابجد, روش_استنطاق noe = روش_استنطاق.شرقی) { return kabir(num.ToString(), dn, noe); }
        /// <summary>
        /// <right>استنطاق کبیر نوشته آرایه‌ای</right>
        /// </summary>
        /// <param name="fnum">عدد</param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <param name="mod"><right>نوع استنطاق</right></param>
        /// <returns></returns>
        public static string[] kabir(int[] num, D_name dn, روش_استنطاق noe)
        {
            string[] payani = new string[num.LongLength];
            for (int i = 0; i < num.LongLength; i++)
                payani[i] = kabir(num[i].ToString(), dn, noe);
            return payani;
        }


        /// <summary><right>استنطاق مکانی</right></summary>
        public static string makani(int num, D_name dn = D_name.ابجد) { return Data.d(dn).Substring(Math_Old.tarh_esghat(num, 28) - 1, 1); }
        /// <summary><right>استنطاق مکانی</right></summary>
        public static string makani(int num, string d) { return d.Substring(Math_Old.tarh_esghat(num, 28) - 1, 1); }
        /// <summary><right>استنطاق مکانی</right></summary>
        public static string makani(decimal num, D_name dn = D_name.ابجد) { return makani((int)num, dn); }
        /// <summary><right>استنطاق مکانی</right></summary>
        public static string makani(long num, D_name dn = D_name.ابجد) { return makani((int)num, dn); }
        /// <summary><right>استنطاق مکانی</right></summary>
        public static string[] makani(int[] num, D_name dn = D_name.ابجد)
        {
            string[] payani = new string[num.LongLength];
            for (int i = 0; i < num.LongLength; i++)
                payani[i] = makani(num[i], dn);
            return payani;
        }

        /// <summary><right>استنطاق کبیر، و اگر نداشت مکانی</right></summary>
        public static string kabir_makani(int num, D_name dn)
        {
            return Math_Old.is_kabor(num) ?
                kabir(num.ToString(), dn) :
                makani(num, dn);
        }
        /// <summary><right>استنطاق کبیر تک حرفی</right></summary>
        public static string kabirtak(int num, D_name dn) { return Math_Old.is_kabor(num) ? kabir(num.ToString(), dn) : ""; }

        /// <summary><right>مداخل اربعه</right></summary>
        public static string[] madakhel_arbae(string text) { return kabir(Hesab.madakhel_arbae(text), D_name.ابجد, 0); }
        /// <summary><right>استنطاق مداخل اربعه در یک خط</right></summary>
        public static string madakhel_arbae_one_line(string text) { return string.Join("", madakhel_arbae(text)); }


        /// <summary><right>استنطاق خاص</right></summary>
        public static string[] god_names_fun(int num, string[] name_str, D_int dh = D_int.kabir, D_name dn = D_name.ابجد, bool tarkib = false)
        {
            List<string> payani = new List<string>();
            List<Data_name> names = new List<Data_name>();
            List<Data_name> name_match = new List<Data_name>();

            //  محاسبه عدد هر کلمه و افزودن به داده
            for (int i = 0; i < name_str.Count(); i++)
            {
                Data_name gn = new Data_name();
                gn.text = name_str[i];     //  گرفتن اسم
                gn.num = Hesab.select(gn.text, dh, dn);      //  محاسبه عدد
                names.Add(gn);
            }


            //  بدون ترکیب
            if (!tarkib)
                name_match = names.FindAll(x => x.num == num);      //  یافتن اسم با عدد دلخواه

            //  با ترکیب
            else
            {
                //  عدد مساوی
                for (int i = 0; i < names.Count(); i++)
                {
                    if (names[i].num == num)        //  اگر عدد همان بود
                        name_match.Add(names[i]);

                    if (names[i].num >= num)        //  اگر عدد کمتر نبود باقی بماند
                        names.RemoveAt(i--);        //  ///////////////////////////////     توی تعیین منفی شدن دقت بشه که درست حذف میکنه و درست عدد تعیین میشه یا نه
                }

                //  عدد ترکیبی
                //////////////////////////////////      هنوز کامل نیست
                {
                    List<int> names_num = new List<int>();
                    for (int i = 0; i < names.Count; i++)
                        names_num.Add(names[i].num);
                    List<int> jame_int = Algoritm.jame_list_int(num, names_num);

                    if (jame_int != null)
                    {
                        string str = "";
                        for (int g = 0; g < jame_int.Count; g++)
                        {
                            name_match = names.FindAll(x => x.num == jame_int[g]);      //  یافتن اسم با عدد دلخواه

                            if (g != 0)
                                str += "، ";
                            str += name_match[0].text;
                        }
                    }
                }


            }

            //  تبدیل نهایی کلمات گرفته شده
            for (int i = 0; i < name_match.Count; i++)
                payani.Add(name_match[i].text);

            return payani.ToArray();
        }
    }

    /// <summary><right>اساس و دور</right></summary>
    public class Asas_Dour
    {
        /// <summary>
        /// <right>
        /// اساس و نظیره و غریزه
        /// </right>
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <param name="Gharizeh"><right>غریزه گرفتن</right></param>
        /// <returns></returns>
        public static string asas(string text, D_name dn = D_name.ابجد, bool Gharizeh = false)
        {
            string Nazireh = "";
            string d = Data.d(dn);
            for (int i = 0; i < text.Length; i++)
                if (d.Contains(text.Substring(i, 1)))
                {
                    int j = d.IndexOf(text.Substring(i, 1));        //  جایگاه خود حرف
                    j = (Gharizeh) ? 27 - j : j + 14;       //  فرمول حایگاه حرف نظیره
                    Nazireh += d.Substring(j % 28, 1);      //  اخد نظیره از دایره
                }
            return Nazireh;
        }


        /// <summary>
        /// <right>
        /// جابجایی حروف به عدد دلخواه : ترقی، تنزل، ترفع، مساوات 
        /// </right>
        /// </summary>
        /// <param name="num"><right>عدد دلخواه</right></param>
        /// <param name="text">نوشته</param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <returns></returns>
        public static string[] jabejai(string text, D_name dn = D_name.ابجد)
        {
            string d = Data.d(dn);
            string[] ja = new string[4];
            for (int i = 0; i < text.Length; i++)
                if (d.Contains(text.Substring(i, 1)))
                {
                    int j = d.IndexOf(text.Substring(i, 1));
                    ja[0] += d.Substring(Math_Old.tarh_esghat(j + 1, 28, false), 1);        //  ترقی
                    ja[1] += d.Substring(Math_Old.tarh_esghat(j - 1, 28, false), 1);        //  تنزل
                    ja[2] += d.Substring(Math_Old.tarh_esghat(j + 9, 27, false), 1);        //  ترفع
                    ja[3] += d.Substring(Math_Old.tarh_esghat(j - 9, 27, false), 1);        //  مساوات
                }
            return ja;
        }


        /// <summary>متناظر</summary>
        public static string motenazer(string text, D_name dn_1, D_name dn_2)
        {
            string payani = "";
            string d_1 = Data.d(dn_1);
            string d_2 = Data.d(dn_2);

            for (int i = 0; i < text.Length; i++)
                if (d_1.Contains(text.Substring(i, 1)))
                    payani += d_2.Substring(
                        d_1.IndexOf(text.Substring(i, 1))
                        , 1);

            return payani;
        }


        /// <summary>
        /// دور
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="mod"><right>صغیر 0 - متوسط 1 - کبیر 2</right></param>
        /// <returns></returns>
        public static string[] dour(string text, int mod = 2)
        {
            List<string> payani = new List<string>();
            payani.Add(text);
            payani.AddRange(jabejai(text));
            if (mod > 0)
            {
                payani.Add(asas(text));     //  mod == 1
                if (mod == 2)
                {
                    payani.Add(asas(text, D_name.اهطم, false));
                    payani.Add(asas(text, D_name.ابتث, false));
                    payani.Add(asas(text, D_name.ایقغ, false));
                }
            }
            return payani.ToArray();
        }

        /// <summary>عمل ریاضی</summary>
        public static string aamal_riazi(string text, int num, عمل_ریاضی عمل, D_name dn = D_name.ابجد)
        {
            string d = Data.d(dn);
            string payani = "";
            for (int i = 0; i < text.Length; i++)
                if (d.Contains(text.Substring(i, 1)))
                {
                    int j = d.IndexOf(text.Substring(i, 1));
                    switch (عمل)
                    {
                        case عمل_ریاضی.جمع: payani += d.Substring(Math_Old.tarh_esghat(j + num, 28, false), 1); break;
                        case عمل_ریاضی.تفریق: payani += d.Substring(Math_Old.tarh_esghat(j - num, 28, false), 1); break;
                        case عمل_ریاضی.ضرب: payani += d.Substring(Math_Old.tarh_esghat(j * num, 28, false), 1); break;
                        case عمل_ریاضی.تقسیم: payani += d.Substring(Math_Old.tarh_esghat(j / num, 28, false), 1); break;
                        case عمل_ریاضی.باقیمانده: payani += d.Substring(Math_Old.tarh_esghat(j % num, 28, false), 1); break;
                    }
                }
            return payani;
        }

        /// <summary><right>تواخی، تلفظ</right></summary>
        /// <param name="text">نوشته</param>
        /// <returns><right>حروف مشابه یا اسم حروف با نبود حرف مشابه</right></returns>
        public static string[] tavakhi_talafoz(string text)
        {
            string[] payani = { "", "" };
            for (int i = 0; i < text.Length; i++)
                switch (text.Substring(i, 1))
                {
                    case "ا": payani[0] += "ل"; payani[1] += "ف"; break;
                    case "ب": payani[0] += "ت"; payani[1] += "ث"; break;
                    case "ج": payani[0] += "ح"; payani[1] += "خ"; break;
                    case "د": payani[0] += "ذ"; payani[1] += "-"; break;
                    case "ه": payani[0] += "ا"; payani[1] += "-"; break;
                    case "و": payani[0] += "ا"; payani[1] += "و"; break;
                    case "ز": payani[0] += "ر"; payani[1] += "-"; break;
                    case "ح": payani[0] += "ج"; payani[1] += "خ"; break;
                    case "ط": payani[0] += "ظ"; payani[1] += "-"; break;
                    case "ی": payani[0] += "ا"; payani[1] += "-"; break;
                    case "ک": payani[0] += "ا"; payani[1] += "ف"; break;
                    case "ل": payani[0] += "ا"; payani[1] += "م"; break;
                    case "م": payani[0] += "ی"; payani[1] += "م"; break;
                    case "ن": payani[0] += "و"; payani[1] += "ن"; break;
                    case "س": payani[0] += "ش"; payani[1] += "-"; break;
                    case "ع": payani[0] += "غ"; payani[1] += "-"; break;
                    case "ف": payani[0] += "ق"; payani[1] += "-"; break;
                    case "ص": payani[0] += "ض"; payani[1] += "-"; break;
                    case "ق": payani[0] += "ف"; payani[1] += "-"; break;
                    case "ر": payani[0] += "ز"; payani[1] += "-"; break;
                    case "ش": payani[0] += "س"; payani[1] += "-"; break;
                    case "ت": payani[0] += "ب"; payani[1] += "ث"; break;
                    case "ث": payani[0] += "ب"; payani[1] += "ت"; break;
                    case "خ": payani[0] += "ج"; payani[1] += "ح"; break;
                    case "ذ": payani[0] += "د"; payani[1] += "-"; break;
                    case "ض": payani[0] += "ص"; payani[1] += "-"; break;
                    case "ظ": payani[0] += "ط"; payani[1] += "-"; break;
                    case "غ": payani[0] += "ع"; payani[1] += "-"; break;
                }
            return payani;
        }
    }

    /// <summary><right>تفکیک حروف</right></summary>
    public class Tafkik
    {
        /// <summary><right>شماره عنصر حرف</right></summary>
        public static طبع tabe(string text) { return (طبع)(Data.d(D_name.ابجد).IndexOf(text) % 4); }

        /// <summary><right>همطبع بودن دو حرف</right></summary>
        public static bool hamtabe(string x, string y) { return tabe(x) == tabe(y); }

        /// <summary><right>تفکیک عناصر</right></summary>
        public static string[] onsor(string text)
        {
            string[] payani = new string[4] { "", "", "", "" };
            for (int i = 0; i < text.Length; i++)
                payani[(int)tabe(text.Substring(i, 1))] += text.Substring(i, 1);        //  جایگذاری حرف در خروجی
            return payani;
        }

        /// <summary><right>شدت عناصر</right></summary>
        public static int[] shedatOnsor(string text)
        {
            string d = Data.d(D_name.ابجد);
            int[] payani = new int[4] { 0, 0, 0, 0 };
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                payani[j % 4] += 7 - j / 4;     //  تهیه عدد شدت
            }
            return payani;
        }

        /// <summary><right>تفکیک مزاج : گرم و سرد و خشک و تر</right></summary>
        public static string[] mazaj(string text, شرق_غرب noe = شرق_غرب.شرقی)
        {
            string d = Data.d(D_name.ابجد);
            string[] payani = new string[4] { "", "", "", "" };
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                int tmp = d.IndexOf(harf) % 4;
                switch (tmp)
                {
                    default:
                    case 0:     //  آتش
                        payani[0] += harf;      //  گرم
                        payani[2] += harf;      //  خشک
                        break;

                    case 2:     //  آب
                        payani[1] += harf;      //  سرد
                        payani[3] += harf;      //  تر
                        break;

                    case 1:
                    case 3:
                        if ((noe == شرق_غرب.شرقی && tmp == 1) || (noe == شرق_غرب.غربی && tmp == 3))     //  باد
                        {
                            payani[0] += harf;      //  گرم
                            payani[3] += harf;      //  تر
                        }
                        else        //  خاک
                        {
                            payani[1] += harf;      //  سرد
                            payani[2] += harf;      //  خشک
                        }
                        break;
                }
            }
            return payani;
        }

        /// <summary><right>شدت مزاج : گرم و سرد و خشک و تر</right></summary>
        public static int[] shedatMazaj(string text, شرق_غرب noe = شرق_غرب.شرقی)
        {
            string d = Data.d(D_name.ابجد);
            int[] payani = new int[4] { 0, 0, 0, 0 };
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                switch (j % 4)
                {
                    default:
                    case 0:     //  آتش
                        payani[0] += 7 - j / 4;     //  گرم
                        payani[2] += 7 - j / 4;     //  خشک
                        break;

                    case 2:     //  آب
                        payani[1] += 7 - j / 4;     //  سرد
                        payani[3] += 7 - j / 4;     //  تر
                        break;

                    case 1:
                    case 3:
                        if ((noe == شرق_غرب.شرقی && j % 4 == 1) || (noe == شرق_غرب.غربی && j % 4 == 3))     //  باد
                        {
                            payani[0] += 7 - j / 4;     //  گرم
                            payani[3] += 7 - j / 4;     //  تر
                        }
                        else        //  خاک
                        {
                            payani[1] += 7 - j / 4;     //  سرد
                            payani[2] += 7 - j / 4;     //  خشک
                        }
                        break;
                }
            }
            return payani;
        }

        /// <summary><right>تفکیکی حروف نورانی و ظلمانی</right></summary>
        public static string[] noorani(string text)
        {   //  حروف نورانی: صراطعلیحقنمسکه
            string[] payani = new string[2];
            string d = Data.d(D_name.اهحط_نور);

            //  یافتن حرف نورانی برای آرایه صفر
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) < 14 ? 0 : 1] +=
                    text.Substring(i, 1);

            return payani;
        }

        /// <summary><right>تفکیک وضعی : بنابه زوج و فرد</right></summary>
        public static string[] vazi(string text)
        {
            string d = Data.d(D_name.ابجد);
            string[] payani = new string[2];
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani[d.IndexOf(harf) % 2] += harf;        //  قرار دادن اعداد فرد در اولین ارایه
            }
            return payani;
        }

        /// <summary><right>تفکیک کبیر</right></summary>
        public static string[] kabir(string text)
        {
            string d = Data.d(D_name.ابجد);
            string[] payani = new string[4];
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) / 9] += text.Substring(i, 1);        //  یافتن مرتبه عدد کبیر
            return payani;
        }

        /// <summary><right>اوتاد : حیوان و نبات و معدن</right></summary>
        public static string[] otad(string text)
        {
            string d = Data.d(D_name.ابجد);
            string[] payani = new string[3];
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) % 3] += text.Substring(i, 1);
            return payani;
        }

        /// <summary><right>تفکیک کواکبی</right></summary>
        public static string[] kavakeb(string text)
        {
            string d = Data.d(D_name.ابجد);
            string[] payani = new string[7];
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) % 7] += text.Substring(i, 1);
            return payani;
        }

        /// <summary><right>تفکیک افلاکی</right></summary>
        public static string[] aflak(string text)
        {
            string d = Data.d(D_name.ابجد);
            string[] payani = new string[9];
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) % 9] += text.Substring(i, 1);
            return payani;
        }

        /// <summary><right>تفکیک ملفوظی و مکتوبی و مسروری</right></summary>
        public static string[] malfoozi(string text, bool tartib_2 = false)
        {
            string[] payani = new string[3] { "", "", "" };
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                string esm = Data.esmharf(harf);
                payani[
                    (esm.Length == 2) ? 0 :     //  مسروری
                    (esm.Substring(0, 1) == esm.Substring(2, 1)) ? 1 :      // ملبوبی یا مکتوبی
                    2                                   // ملفوظی
                    ] += harf;
            }
            return !tartib_2 ? payani :
                new string[3] { payani[2], payani[1], payani[0] };
        }

        /// <summary><right>تفکیک حروف تاج، حربه، عمود و کرسی</right></summary>
        public static string[] taj(string text)
        {
            string[] payani = new string[4];
            string d = Data.d(D_name.ابتث);        //  ابتث
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) % 4] += text.Substring(i, 1);
            return payani;
        }

        /// <summary><right>تفکیک حروف شمسی و قمری</right></summary>
        public static string[] shamsi(string text)
        {
            string[] payani = new string[2];
            string d = Data.d(D_name.ابجد);
            for (int i = 0; i < text.Length; i++)
                payani[("شنلزذضظردسثصتط".Contains(text.Substring(i, 1))) ? 0 : 1] += text.Substring(i, 1);
            return payani;
        }

        /// <summary><right>سعد و نحس (تعب) و ممتزج</right></summary>
        public static string[] saad(string text)
        {
            string[] payani = new string[3];
            string d = Data.d(D_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani[
                    ("اتثدذزرهکوشغطظق".Contains(harf)) ? 0 :    //  سعد
                    ("بجحخعلنص".Contains(harf)) ? 1 :               //  نحس یا تعب
                    2       //  ("سمضیف".Contains(harf))            //  ممتزج
                    ] += harf;
            }
            return payani;
        }

        /// <summary><right>تفکیک بنابه ایام هفته</right></summary>
        public static string[] hafteh(string text)
        {
            string[] payani = new string[7];
            string d = Data.d(D_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani[
                    "حخلغنج".Contains(harf) ? 0 :
                    "وتم".Contains(harf) ? 1 :
                    "دهرش".Contains(harf) ? 2 :
                    "ظفیض".Contains(harf) ? 3 :
                    "بصس".Contains(harf) ? 4 :
                    "اکط".Contains(harf) ? 5 :      //  ل
                    6   //"حذث".Contains(harf)
                    ] += harf;
            }
            return payani;
        }

        /// <summary><right>شمال، جنوب، شرق، غرب</right></summary>
        public static string[] shomal_jonoub(string text)
        {
            string[] payani = new string[4];
            string d = Data.d(D_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani[
                    ("جفهشعیض".Contains(harf)) ? 0 :        //  شمال
                    ("کظمبصن".Contains(harf)) ? 1 :         //  جنوب
                    ("اقلغوتحخ".Contains(harf)) ? 2 :           //  شرق
                    3       //  ("طذزثسدر".Contains(harf))      //   غرب
                    ] += harf;
            }
            return payani;
        }

        /// <summary>تواخی</summary>
        public static string[] tavakhi(string text)
        {
            string[] payani = new string[2];
            string d = Data.d(D_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani["اهویکلمن".Contains(harf) ? 1 : 0] += harf;
            }
            return payani;
        }

        /// <summary><right>نقاط و صامات</right></summary>
        public static string[] noghat(string text)
        {
            string[] payani = new string[2];
            string d = Data.d(D_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani["ادهوحطکلمسعصر".Contains(harf) ? 1 : 0] += harf;
            }
            return payani;
        }

        /// <summary><right>خواتیم و متصلات</right></summary>
        public static string[] khavatim(string text)
        {
            string[] payani = new string[2];
            string d = Data.d(D_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani["ادذرزو".Contains(harf) ? 0 : 1] += harf;
            }
            return payani;
        }

        /// <summary><right>جنسیت : مذکر و مؤنث</right></summary>
        public static string[] jensiat(string text)
        {
            string[] payani = new string[2];
            string d = Data.d(D_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani["اجدذصضقکلم".Contains(harf) ? 0 : 1] += harf;
            }
            return payani;
        }
    }

    /// <summary><right>تکسیر و جابجایی حروف</right></summary>
    public class Taksir
    {
        public static string[] taksir_pro(string[] text, bool[] daste_harf, int[] daste_int, ابتدا_انتها[] daste_shomaresh,
            نحودسته[] nahve_daste, ابتدا_انتها[] daste_tartib, ابتدا_انتها tartib_bardasht_az_text,
            int[] start, int[] gam, int[] bardasht, تکسیر_انواع noe)
        {
            List<string> payani_list = new List<string>();
            int len = (int)text.LongLength;     //  تعداد ورودی

            text = Harf_Change.alefbae(text);      //  الفبا
            for (int i = 0; i < len; i++)
                start[i]--;     //  کم کردن یک واحد از خانه شروع

            if (noe == تکسیر_انواع.تکرار)
            {
                //  بدست آوردن ب م م
                int[] bmm_0 = new int[len];
                for (int i = 0; i < len; i++)
                    bmm_0[i] = text[i].Length;        //  طول هر عبارت
                int bmm_1 = Math_Old.bmm(bmm_0);

                //  تکرار هر عبارت به نسبت مورد نیاز
                for (int i = 0; i < len; i++)
                {
                    string str_tmp = "";
                    for (int k = 0; k < bmm_1 / bmm_0[i]; k++)
                        str_tmp += text[i];
                    text[i] = str_tmp;
                }
            }

            if (noe == تکسیر_انواع.زمام)
            {
                payani_list.Add(text[0]);       //  وگرنه متن اصلی به آخر کار منتقل می‌گردد و یکبار حلقه اضافه‌تر انجام می‌شود
            }

            for (int z = 0; z < 1 || (noe == تکسیر_انواع.زمام && z < 1000); z++)
            {
                List<string> line = new List<string>();      //  هر ورودی پس از دسته‌بندی
                List<List<string>> daste = new List<List<string>>();        //  دسته‌ها

                //  دسته‌بندی
                for (int i = 0; i < len; i++)
                {
                    daste.Add(new List<string>());

                    //  تعداد حرفی که باید برداشته شود
                    int get_int = 0;
                    int get_baghi = 0;
                    if (daste_harf[i])      //  بنابه تعداد دسته
                    {
                        get_int = text[i].Length / daste_int[i];
                        get_baghi = text[i].Length % daste_int[i];
                    }
                    else
                        get_int = daste_int[i];

                    //  دسته بندی
                    string str_tmp = text[i];       //  متن اولیه
                    for (int k = 0; str_tmp != ""; k++)
                    {
                        int get_final = get_int + (k <= get_baghi - 1 ? 1 : 0);

                        int get_start = 0;
                        //if (daste_shomaresh[i] == ابتدا_انتها.ابتدا_ابتدا ||
                        //(daste_shomaresh[i] == ابتدا_انتها.ابتدا_انتها && k % 2 == 0) ||
                        //(daste_shomaresh[i] == ابتدا_انتها.انتها_ابتدا && k % 2 == 1))
                        //get_start = 0;      //  برداشت از ابتدا
                        //else
                        if (daste_shomaresh[i] == ابتدا_انتها.انتها_انتها ||
                             (daste_shomaresh[i] == ابتدا_انتها.ابتدا_انتها && k % 2 == 1) ||
                             (daste_shomaresh[i] == ابتدا_انتها.انتها_ابتدا && k % 2 == 0))
                            get_start = Math.Max(str_tmp.Length - get_final, 0);     //  برداشت از آخر : کمتر از صفر نشود

                        daste[i].Add(Code.SubStr(str_tmp, get_start, get_final));       //  رونوشت
                        str_tmp = Code.Remove_Str(str_tmp, get_start, get_final);       //  حذف از متن
                    }
                }

                //  نحوه دسته‌بندی
                for (int i = 0; i < len; i++)
                    if (nahve_daste[i] != نحودسته.ساده_ساده)
                        for (int k = 0; k < daste[i].Count; k++)
                            if (nahve_daste[i] == نحودسته.وارون_وارون ||
                                (nahve_daste[i] == نحودسته.ساده_وارون && k % 2 == 1) ||
                                (nahve_daste[i] == نحودسته.وارون_ساده && k % 2 == 0))
                                daste[i][k] = Bast.maakoos_102(daste[i][k]);        //  معکوس و وارون کردن به شرط قبل

                //  ترتیب دسته‌ها
                //if (daste_tartib[i] != ابتدا_انتها.ابتدا_ابتدا)
                {
                    List<List<string>> daste_tmp = new List<List<string>>();
                    for (int i = 0; i < len; i++)
                    {
                        daste_tmp.Add(new List<string>());
                        for (int k = 0; k < text[i].Length && daste[i].Count > 0; k++)
                        {
                            int del_int = 0;
                            if (daste_tartib[i] == ابتدا_انتها.انتها_انتها ||
                                (daste_tartib[i] == ابتدا_انتها.ابتدا_انتها && k % 2 == 1) ||
                                (daste_tartib[i] == ابتدا_انتها.انتها_ابتدا && k % 2 == 0))
                                del_int = daste[i].Count - 1;       //  آخرین آیتم

                            daste_tmp[i].Add(daste[i][del_int]);      //  برداشت دسته
                            daste[i].Remove(daste[i][del_int]);       //  حذف دسته
                        }
                    }
                    //  جابجایی
                    daste.Clear();
                    daste = new List<List<string>>(daste_tmp);
                    daste_tmp.Clear();
                }

                //  یکجا کردن دسته‌ها
                for (int i = 0; i < len; i++)
                {
                    line.Add("");
                    for (int k = 0; k < daste[i].Count; k++)
                        line[i] += daste[i][k];
                }

                //  مرتب کردن دسته‌ها
                {
                    List<string> line_tmp = new List<string>();
                    switch (tartib_bardasht_az_text)
                    {
                        default:
                        case ابتدا_انتها.ابتدا_ابتدا:
                            line_tmp = new List<string>(line);      //  همان قبلی
                            break;

                        case ابتدا_انتها.انتها_انتها:
                            for (int i = len - 1; i >= 0; i--)      //  از آخر
                                line_tmp.Add(line[i]);
                            break;

                        case ابتدا_انتها.ابتدا_انتها:
                            for (int i = 0; i < len / 2; i++)       //  تا وسط
                            {
                                line_tmp.Add(line[i]);        //  از اول
                                if (i != len - i - 1)   //  اگر این دو عدد یکی نباشد که تکراری نشود
                                    line_tmp.Add(line[len - i - 1]);      //  از آخر
                            }
                            break;

                        case ابتدا_انتها.انتها_ابتدا:
                            for (int i = 0; i < len / 2; i++)       //  تا وسط
                            {
                                line_tmp.Add(line[len - i - 1]);      //  از آخر
                                if (i != len - i - 1)       //  اگر این دو عدد یکی نباشد که تکراری نشود
                                    line_tmp.Add(line[i]);        //  از اول
                            }
                            break;
                    }
                    //  جابجایی
                    line.Clear();
                    line = new List<string>(line_tmp);
                    line_tmp.Clear();
                }

                //  برداشته شده و نشده‌ها
                List<List<bool>> daste_bool = new List<List<bool>>();       //  بول هر حرف
                List<bool> daste_bool_2 = new List<bool>();     //  بول هر عبارت
                for (int i = 0; i < len; i++)
                {
                    daste_bool.Add(new List<bool>());
                    daste_bool_2.Add(true);
                    for (int k = 0; k < line[i].Length; k++)
                        daste_bool[i].Add(true);
                }
                for (int i = 0; i < len; i++)       //  اگر متن خالی بود، منفی شود
                    if (daste_bool[i].Count < 1)            //if (daste_bool[i].Count > 1)
                        daste_bool_2[i] = false;



                //  برداشتن و غیرفعال کردن هر حرف
                string payani = "";
                int[] jay = (int[])start.Clone();
                while (daste_bool_2.Find(x => x == true))       //  اگر در یکی از 
                {
                    for (int i = 0; i < len; i++)
                    {
                        int jay_tmp = jay[i];
                        for (int k = 0; k < bardasht[i] && daste_bool_2[i];)       //  بنابر تعداد برداشت، در صورت برداشتن به مقدار اضافه می‌شود     و اگر از دسته حرفی انتخاب نشده مانده باشد
                        {
                            if (daste_bool[i][jay_tmp])       //  اگر بول حرف درست بود
                            {
                                payani += line[i].Substring(jay_tmp, 1);     //  برداشتن حرف
                                daste_bool[i][jay_tmp] = false;                  //  مشخص کردن برداشته شدن حرف
                                k++;                                                //  یک حرف برداشته شده اضافه شد
                                daste_bool_2[i] = daste_bool[i].Find(x => x == true);       //  بروزرسانی بول‌ها
                            }
                            jay_tmp++;       //  افزودن عدد جایگاه
                            if (jay_tmp >= line[i].Length)        //  اگر عدد از متن خارج شد
                            {
                                if (noe == تکسیر_انواع.منقطع)     //  منقطع
                                    daste_bool_2[i] = false;        //  پایان کار عبارت
                                else                                        //  یکپارچه و چند دوری
                                    jay_tmp = 0;                         //  آمدن از اول
                            }
                        }
                        jay[i] = Math_Old.tarh_esghat(jay[i] + gam[i], line[i].Length, false);      //  افزودن گام  و تنظیم آن که بیشتر نشود
                    }
                }
                if (payani_list.Count != 0 && payani_list[0] == payani)
                    break;
                payani_list.Add(payani);        //  افزودن به لیست خروجی
                text[0] = payani;
            }
            return payani_list.ToArray();
        }

        public static string taksir_pro_once(string text, bool daste_harf, int daste_int, ابتدا_انتها daste_shomaresh,
        نحودسته nahve_daste, ابتدا_انتها daste_tartib, int start, int gam, int bardasht, تکسیر_انواع noe)
        {
            return
            taksir_pro(new string[1] { text }, new bool[1] { daste_harf }, new int[1] { daste_int }, new ابتدا_انتها[1] { daste_shomaresh },
                new نحودسته[1] { nahve_daste }, new ابتدا_انتها[1] { daste_tartib }, ابتدا_انتها.ابتدا_ابتدا,
                new int[1] { start }, new int[1] { gam }, new int[1] { bardasht }, noe)[0];
        }



        /// <summary><right>تکسیر تا زمام</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="teksir"><right>تکسیر بودن نه غریزه</right></param>
        /// <param name="moakhar"><right>مؤخر و صدر بودن</right></param>
        /// <param name="space"><right>فاصله داشتن</right></param>
        /// <param name="get_num"><right>تعداد بار اول</right></param>
        /// <param name="y"><right>تعداد بارهای بعد</right></param>
        /// <returns></returns>
        public static string[] zomam(string text, bool teksir, bool moakhar, bool space, int get_num = 1)
        {
            //text = harf_change.alefbae(text);
            List<string> taksir = new List<string>();
            taksir.Add(text);
            int k = 1;

            if (teksir)     //  تکسیر
                for (; taksir[0] != taksir[k - 1] || k == 1; k++)
                    taksir.Add(taksir_sadr(taksir[k - 1], moakhar, space, get_num));

            else        //  غریزه
                for (; taksir[0] != taksir[k - 1] || k == 1; k++)
                    taksir.Add(taksir_gharizeh(taksir[k - 1], moakhar, space, get_num));

            taksir.RemoveRange(--k, 1);     //  حذف مورد آخر

            return Harf_Change.space(taksir.ToArray(), space);
        }

        /// <summary><right>
        /// یکبار تکسیر
        /// </right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="teksir"><right>تکسیر بودن نه غریزه</right></param>
        /// <param name="moakhar"><right>مؤخر و صدر بودن</right></param>
        /// <param name="space"><right>فاصله داشتن</right></param>
        /// <param name="get_num"><right>تعداد بار اول</right></param>
        /// <param name="y"><right>تعداد بارهای بعد</right></param>
        /// <returns></returns>
        public static string zomam_once(string text, bool teksir, bool moakhar, bool space, int get_num = 1)
        {
            return (teksir) ?
                taksir_sadr(text, moakhar, space, get_num) :       //  تکسیر
                taksir_gharizeh(text, moakhar, space, get_num);        //  غریزه
        }

        /// <summary>
        /// تکسیر
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="moakhar"><right>مؤخر و صدر بودن</right></param>
        /// <param name="space"><right>فاصله داشتن</right></param>
        /// <param name="get_num"><right>تعداد بار اول</right></param>
        /// <param name="y"><right>تعداد بارهای بعد</right></param>
        /// <returns></returns>
        public static string taksir_sadr(string text, bool moakhar, bool space, int get_num = 1)
        {
            string taksir = "";
            get_num = Math.Max(1, get_num);

            for (int i = 0, m = -1, n = 0; i < text.Length; i++)
            {
                for (int j = 0; j < get_num && i < text.Length; j++, i++)
                    taksir += text.Substring(
                        moakhar ?
                        text.Length - ++n :     //  از آخر
                        ++m                         //  از اول
                        , 1);
                i--;
                moakhar = !moakhar;
            }

            return space ? taksir : Harf_Change.space(taksir, space);
        }

        /// <summary><right>
        /// تکسیر غریزه
        /// </right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="moakhar"><right>مؤخر و صدر بودن</right></param>
        /// <param name="space"><right>فاصله داشتن</right></param>
        /// <param name="get_num"><right>تعداد بار اول</right></param>
        /// <param name="y"><right>تعداد بارهای بعد</right></param>
        /// <returns></returns>
        public static string taksir_gharizeh(string text, bool moakhar, bool space, int get_num = 1)
        {
            string taksir = "";
            get_num = Math.Max(1, get_num);
            string[] gharizeh = new string[2] { "", "" };

            for (int i = 0, n = 0; i < text.Length; i += get_num, n++)
                gharizeh[n % 2] += Code.SubStr(text, i, get_num);

            gharizeh[0] = Bast.maakoos_102(gharizeh[0]);        //  معکوس کردن بخش اول
            taksir = gharizeh[1] + gharizeh[0];     //  جمع بخش اول و دوم
            if (!moakhar)
                taksir = Bast.maakoos_102(taksir);      //  در حالت عادی مؤخر و صدر است و نیازی به معکوس کردن ندارد

            return space ? taksir : Harf_Change.space(taksir, space);
        }


        /// <summary>
        /// امتزاج
        /// </summary>
        /// <param name="text">نوشته‌های برای امتزاج با یکدیگر</param>
        /// <param name="gam_tmp"><right>گام: اگر نال باشد پیشفرض گام‌ها عدد یک خواهد بود</right></param>
        /// <param name="tekrar"><right>تکرار نوشته‌ها تا برابر شوند</right></param>
        /// <returns></returns>
        public static string emtezaj(string[] text, int[] gam_tmp = null, int tekrar = 0)
        {
            string str = "";
            string payani = "";
            int[] first = new int[text.LongLength];

            text = Harf_Change.alefbae(text);       //  تنظیم متن‌ها

            //  تنظیم گام
            int[] gam = new int[text.LongLength];
            if (gam_tmp == null || gam_tmp.LongLength < 1)
                gam_tmp = new int[1] { 1 };
            for (int i = 0; i < text.LongLength; i++)
                gam[i] = gam_tmp[i % gam_tmp.LongLength];       //  اگر گام ها کمتر از نوشته ها از اول دوباره میگیرد

            int len = 0;
            int balatarin = 0;
            switch (tekrar)
            {   //  بی‌تکرار
                default:
                case 0:
                    {
                        for (int k = 0; str != "" || k == 0; k++)
                        {
                            str = "";
                            for (int i = 0; i < text.LongLength; i++)
                            {
                                str += Code.SubStr(text[i], first[i], gam[i]);         //  عملیات اصلی
                                first[i] += gam[i];     //  رد شدن از آنچه گرفته شد
                            }
                            payani += str;      //  افزودن به پایانی
                        }
                    }
                    break;

                //  با تکرار تا پایان
                case 1:
                    {
                        //  بدست آوردن اندازه حلقه
                        for (int i = 0; i < text.LongLength; i++)
                        {
                            int len_tmp = Math.Max(len, text[i].Length / gam[i]);
                            if (len != len_tmp)
                            {
                                len = Math.Max(len, text[i].Length / gam[i]);       //  تغییر اندازه
                                balatarin = i;      //  بالاترین آرایه
                            }
                        }

                        //  حلقه‌های گرفتن حروف
                        for (int k = 0; k < len; k++)
                        {
                            str = "";
                            for (int i = 0; i < text.LongLength; i++)
                            {
                                str += Code.SubStr(text[i], first[i], gam[i], balatarin != i);      //  عملیات اصلی
                                first[i] += gam[i];     //  رد شدن از آنچه گرفته شد
                            }
                            payani += str;      //  افزودن به پایانی
                        }
                    }
                    break;

                //  با تکرار تا برابری
                case 2:
                    {
                        //  بدست آوردن اندازه حلقه
                        int[] len_tmp = new int[gam.LongLength];
                        for (int i = 0; i < text.LongLength; i++)
                            len_tmp[i] = text[i].Length / gam[i];       //  طول هر عبارت
                        len = Math_Old.kmm(len_tmp);        //  مخرج مشترک عبارات

                        //  حلقه‌های گرفتن حروف
                        for (int k = 0; k < len; k++)
                        {
                            str = "";
                            for (int i = 0; i < text.LongLength; i++)
                            {
                                str += Code.SubStr(text[i], first[i], gam[i], true);      //  عملیات اصلی
                                first[i] += gam[i];     //  رد شدن از آنچه گرفته شد
                            }
                            payani += str;      //  افزودن به پایانی
                        }
                    }
                    break;
            }
            return payani;
        }
        public static string emtezaj(string[] text, int[] gam_tmp, bool tekrar) { return emtezaj(text, gam_tmp, Convert.ToInt32(tekrar)); }

        /// <summary>
        /// لقط
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="start"><right>خانه شروع</right></param>
        /// <param name="gam">گام</param>
        /// <param name="tedad"><right>تعداد حرف برداشتی</right></param>
        /// <param name="noe"><right>منفصل، متصل حذقی، متصل باتکرار</right></param>
        /// <param name="one_dour"><right>یک دور بودن لقط و رسیدن به خانه شروع</right></param>
        /// <returns></returns>
        public static string laght(string text, int start, int gam, int tedad, اتصال_لقط noe, bool one_dour = false)
        {
            string payani = "";
            switch (noe)
            {
                case اتصال_لقط.منفصل:
                    {
                        int i = start;

                        for (; i < text.Length; i += gam + tedad - 1)
                            payani += Code.SubStr(text, i, tedad);

                        i -= text.Length;

                        if (one_dour)    //  یک دور
                            for (; i < start; i += gam + tedad - 1)
                                payani += Code.SubStr(text, i, tedad);
                    }
                    break;


                case اتصال_لقط.متصل_حذفی:
                    //  در لقط متصل تعداد همیشه برابر یک است -------------------------------------------------
                    {
                        for (int i = start; text.Length > 1; i += gam - 1)
                        {
                            while (i >= text.Length)     //  بازگشت به اول نوشته
                                i -= text.Length;
                            payani += text.Substring(i, 1);
                            text = text.Remove(i, 1);
                        }
                        payani += text;
                    }
                    break;


                case اتصال_لقط.متصل_باتکرار:
                    //  در لقط متصل تعداد همیشه برابر یک است -------------------------------------------------
                    {
                        bool[] bol = new bool[text.Length];
                        for (int i = 0; i < text.Length; i++)
                            bol[i] = true;
                        bool edame = true;

                        for (int i = start; edame && i < text.Length; i += gam)
                        {
                            if (bol[i])     // انتخاب همان حرف
                            {
                                payani += text.Substring(i, 1);
                                bol[i] = false;
                            }
                            else            //  انتخاب حرف استفاده نشده بعدی
                            {
                                for (int j = i; j < text.Length; j++)
                                {
                                    if (bol[j])
                                    {
                                        payani += text.Substring(j, 1);
                                        bol[j] = false;
                                        break;
                                    }
                                    if (j + 1 >= text.Length)   //  بازگشت به ابتدا
                                        j -= text.Length;
                                }
                            }
                            for (int j = 0; j < text.Length; j++)   //  ادامه دادن
                                if (bol[j])
                                    break;
                                else if (j == text.Length - 1)
                                    edame = false;

                            while (i + gam >= text.Length)     //  بازگشت به اول نوشته
                                i -= text.Length;
                        }
                    }
                    break;
            }
            return payani;
        }

        /// <summary><right>سیر صعودی نزولی یا به عکس</right></summary>
        /// <param name="text">متن های دلخواه که باید حروفشان برابر باشد</param>
        /// <param name="k">عدد متن دلخواه برای شروع</param>
        /// <param name="nozool">شروع سیر به نزول نه صعود</param>
        /// <returns></returns>
        public static string seir_nozool_sood(string[] text, int k, bool nozool)
        {
            //  برابر بودن همه نوشته ها
            for (int i = 1; i < text.LongLength; i++)
                if (text[0].Length != text[i].Length)
                    return null;
            //  تنظیم عدد مقیاس
            if (k < 0)
                k = 0;
            else if (k >= text.LongLength)
                k = (int)text.LongLength;

            string payani = "";
            for (int i = 0; i < text[0].Length; i++)
            {
                payani += text[k].Substring(i, 1);      //  اخذ حرف

                k += nozool ? 1 : -1;       //  جابجایی عدد ملاک
                if (k < 0)
                {
                    k++;
                    nozool = !nozool;
                }
                else if (k == text.LongLength)
                {
                    k--;
                    nozool = !nozool;
                }
            }
            return payani;
        }


        /// <summary><right>امتزاج حروف تفکیک ملفوظی</right></summary>
        public static string mazj_masroori_malfoozi(string text) { return emtezaj(Tafkik.malfoozi(text, true), null, false); }

        /// <summary><right>تکسیر تملیک</right></summary>
        public static List<string> taksir_tamlik(string text, int gam, bool azAkhar = true)
        {
            List<string> payani = new List<string>();
            payani.Add(text);       //  اولین خط خودش است

            while (text == payani.Last() && payani.Count > 1)
                payani.Add(
                    payani.Last().Substring(azAkhar ? text.Length - gam - 1 : gam) +
                    payani.Last().Substring(0, azAkhar ? text.Length - gam : gam));

            payani.RemoveAt(payani.Count - 1);      //  حذف خط آخر که تکراری خط اول است

            return payani;
        }



    }

    /// <summary>بسط</summary>
    public class Bast
    {
        /// <summary><right>بسط ملفوظی به تعداد دور دلخواه</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="dor"><right>تعداد دور</right></param>
        /// <returns></returns>
        public static string malfoozi_100(string text, int dor = 1)
        {
            if (dor < 1) dor = 1;
            for (int i = 0; i < dor; i++)
            {
                string x = "";
                for (int j = 0; j < text.Length; j++)
                    if (text.Substring(j, 1) != " ")
                        x += Data.esmharf(text.Substring(j, 1), true);      //  گرفتن اسم حرف
                text = x;
            }
            return text;
        }

        /// <summary><right>بینه با تعداد دور دلخواه</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="dor"><right>تعداد دور</right></param>
        /// <returns></returns>
        public static string bayene_101(string text, int dor = 1)
        {
            for (int i = 0; i < dor; i++)
            {
                string x = "";
                for (int j = 0; j < text.Length; j++)
                    if (text.Substring(j, 1) != " ")
                        x += Data.esmharf(text.Substring(j, 1)).Substring(1) + " ";     //  گرفتن حروف اسم حرف بجز حرف اول آن
                text = x;
            }
            return text;
        }

        /// <summary><right>بسط معکوس : معکوس کردن نوشته</right></summary>
        public static string maakoos_102(string text)
        {
            string x = "";
            for (int i = text.Length - 1; i >= 0; i--)
                x += text.Substring(i, 1);
            return x;
        }

        /// <summary><right>حذف مکرر</right></summary>
        public static string hazfmokarar_103(string text)
        {
            string payani = "";
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                if (!payani.Contains(harf))     //  اگر در متن خروجی نبود اضافه می‌شود
                    payani += harf;
            }
            return payani;
        }
        /// <summary><right>حذف آرایه‌های تکراری از لیست</right></summary>
        public static List<string> hazfmokarar_list_103(List<string> text)
        {
            List<string> payani = new List<string>();
            for (int i = 0; i < text.LongCount(); i++)
                if (!payani.Contains(text[i]))
                    payani.Add(text[i]);
            return payani;
        }

        /// <summary><right>تضعیف و تنصیف</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="dh"><right>دایره عدد</right></param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <param name="Zarb"><right>ضرب کردن</right></param>
        /// <param name="num"><right>مضروب، عددی که ضرب می‌شود</right></param>
        /// <returns></returns>
        public static string tansif_tazif_104_105(string text, D_int dh = D_int.kabir, D_name dn = D_name.ابجد, bool Zarb = true, int num = 2)
        {
            int x = Hesab.select(text, dh, dn);
            return Stentagh.kabir((Zarb ? x * num : x / num).ToString(), dn);
        }


        /// <summary><right>بسط موازی</right></summary>
        /// <param name="text_1">متن1</param>
        /// <param name="text_2">متن2</param>
        /// <param name="dh"><right>دایره عدد</right></param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <param name="nafs"><right>شروع از نفس حرف در شمارش</right></param>
        /// <returns></returns>
        public static string movazi_106(string text_1, string text_2, D_int dh = D_int.وضعی, D_name dn = D_name.ابجد)
        {
            string payani = "";
            for (int i = 0; i < text_1.Length; i++)
            {
                string harf = text_2.Substring(i % text_2.Length, 1);
                int harf_int = Hesab.select(harf, dh, dn);
                payani += Code.SubStr(text_1, i + harf_int, 1, true);
            }
            return payani;
        }

        /// <summary><right>بسط طرح سته</right></summary>
        /// <param name="text">متن</param>
        /// <param name="nafs"><right>شروع از نفس حرف در شمارش</right></param>
        /// <returns></returns>
        public static string tarh_sete_107(string text, int tarh) { return Taksir.laght(text, tarh - 1, tarh, 1, اتصال_لقط.متصل_حذفی); }

        /// <summary><right>تبدیل طبع</right></summary>
        public static string tabdil_tabe_108(string text, تبدیل_طبع tabdil = تبدیل_طبع.ترفع_منقطع)
        {
            string payani = "";
            string d = Data.d();
            string[] onsor_harf = Tafkik.onsor(d);

            for (int i = 0; i < text.Length; i++)
            {
                string str = text.Substring(i, 1);
                int rotbe = d.IndexOf(str) / 4;     //  تهیه رتبۀ حرف در بیهن طبعش
                طبع tabe = Tafkik.tabe(str);        //  طبع حرف
                طبع tabe_new = tabe;         //  طبع جدید که باید بدست بیاد

                switch (tabdil)
                {
                    case تبدیل_طبع.ترفع_منقطع:
                        switch (tabe)
                        {
                            //case طبع.آتش: tabe_new = طبع.آتش; break;
                            case طبع.باد: tabe_new = طبع.آتش; break;
                            case طبع.آب: tabe_new = طبع.باد; break;
                            case طبع.خاک: tabe_new = طبع.آب; break;
                        }
                        break;

                    case تبدیل_طبع.ترفع_چرخشی:
                        switch (tabe)
                        {
                            case طبع.آتش: tabe_new = طبع.خاک; break;
                            case طبع.باد: tabe_new = طبع.آتش; break;
                            case طبع.آب: tabe_new = طبع.باد; break;
                            case طبع.خاک: tabe_new = طبع.آب; break;
                        }
                        break;

                    case تبدیل_طبع.تنزل_منقطع:
                        switch (tabe)
                        {
                            case طبع.آتش: tabe_new = طبع.باد; break;
                            case طبع.باد: tabe_new = طبع.آب; break;
                            case طبع.آب: tabe_new = طبع.خاک; break;
                                //case طبع.خاک: tabe_new = طبع.خاک; break;
                        }
                        break;

                    case تبدیل_طبع.تنزل_چرخشی:
                        switch (tabe)
                        {
                            case طبع.آتش: tabe_new = طبع.باد; break;
                            case طبع.باد: tabe_new = طبع.آب; break;
                            case طبع.آب: tabe_new = طبع.خاک; break;
                            case طبع.خاک: tabe_new = طبع.آتش; break;
                        }
                        break;

                    case تبدیل_طبع.مقوی_مربی:
                        switch (tabe)
                        {
                            case طبع.آتش: tabe_new = طبع.باد; break;
                            case طبع.باد: tabe_new = طبع.آتش; break;
                            case طبع.آب: tabe_new = طبع.خاک; break;
                            case طبع.خاک: tabe_new = طبع.آب; break;
                        }
                        break;

                    case تبدیل_طبع.مقوی_به_مربی:
                        switch (tabe)
                        {
                            case طبع.آتش: tabe_new = طبع.باد; break;
                            //case طبع.باد: tabe_new = طبع.آتش; break;
                            case طبع.آب: tabe_new = طبع.خاک; break;
                                //case طبع.خاک: tabe_new = طبع.آب; break;
                        }
                        break;

                    case تبدیل_طبع.مربی_به_مقوی:
                        switch (tabe)
                        {
                            //case طبع.آتش: tabe_new = طبع.باد; break;
                            case طبع.باد: tabe_new = طبع.آتش; break;
                            //case طبع.آب: tabe_new = طبع.خاک; break;
                            case طبع.خاک: tabe_new = طبع.آب; break;
                        }
                        break;

                    case تبدیل_طبع.تناقض:
                        switch (tabe)
                        {
                            case طبع.آتش: tabe_new = طبع.آب; break;
                            case طبع.باد: tabe_new = طبع.خاک; break;
                            case طبع.آب: tabe_new = طبع.آتش; break;
                            case طبع.خاک: tabe_new = طبع.باد; break;
                        }
                        break;

                    case تبدیل_طبع.تناقض_تخفیف:
                        switch (tabe)
                        {
                            case طبع.آتش: tabe_new = طبع.آب; break;
                            case طبع.باد: tabe_new = طبع.خاک; break;
                                //case طبع.آب: tabe_new = طبع.آتش; break;
                                //case طبع.خاک: tabe_new = طبع.باد; break;
                        }
                        break;

                    case تبدیل_طبع.تناقض_تشدید:
                        switch (tabe)
                        {
                            //case طبع.آتش: tabe_new = طبع.آب; break;
                            //case طبع.باد: tabe_new = طبع.خاک; break;
                            case طبع.آب: tabe_new = طبع.آتش; break;
                            case طبع.خاک: tabe_new = طبع.باد; break;
                        }
                        break;

                    case تبدیل_طبع.معکوس:
                        switch (tabe)
                        {
                            case طبع.آتش: tabe_new = طبع.خاک; break;
                            case طبع.باد: tabe_new = طبع.آب; break;
                            case طبع.آب: tabe_new = طبع.باد; break;
                            case طبع.خاک: tabe_new = طبع.آتش; break;
                        }
                        break;

                    case تبدیل_طبع.معکوس_تخفیف:
                        switch (tabe)
                        {
                            case طبع.آتش: tabe_new = طبع.خاک; break;
                            case طبع.باد: tabe_new = طبع.آب; break;
                                //case طبع.آب: tabe_new = طبع.باد; break;
                                //case طبع.خاک: tabe_new = طبع.آتش; break;
                        }
                        break;

                    case تبدیل_طبع.معکوس_تشدید:
                        switch (tabe)
                        {
                            //case طبع.آتش: tabe_new = طبع.خاک; break;
                            //case طبع.باد: tabe_new = طبع.آب; break;
                            case طبع.آب: tabe_new = طبع.باد; break;
                            case طبع.خاک: tabe_new = طبع.آتش; break;
                        }
                        break;



                    case تبدیل_طبع.آتش: tabe_new = طبع.آتش; break;
                    case تبدیل_طبع.باد: tabe_new = طبع.باد; break;
                    case تبدیل_طبع.آب: tabe_new = طبع.آب; break;
                    case تبدیل_طبع.خاک: tabe_new = طبع.خاک; break;
                }
                payani += onsor_harf[(int)tabe_new].Substring(rotbe, 1);        //  گرفتن حرف همرتبه از طبع جدید
            }
            return payani;
        }

        public static string moshabeh_109(string text, bool BaNafs)
        {
            string payani = "";
            string[] moshabeh = new string[]
                        {
                            "اکلمنوهی",
                            "بتث",
                            "جحخ",
                            "دذ",
                            "رز",
                            "سش",
                            "صض",
                            "طظ",
                            "عغ",
                            "فق",
                        };

            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                int makan = Array.IndexOf(moshabeh, harf);

                if (makan == 0)
                    payani += harf;
                else if (makan > 0)
                {
                    if (BaNafs)     //  با خود حرف مشابه
                        payani += moshabeh[makan];
                    else        //  بدون حرف مشابه
                        payani += moshabeh[makan].Replace(harf, "");
                }
                //else if (makan < 0)
                //payani += "";
            }

            return payani;
        }





        //  بسطهای چند منظوره


        public static string تنویر(string text, نورانی noor)
        {
            string payani = "";
            string d = Data.d(D_name.اهحط_نور);        //  دایره نورانی

            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                switch (noor)
                {
                    default:
                    case نورانی.تنویر:
                        payani += (d.IndexOf(harf) >= 14) ?       //  اگر از  14 حرف دوم که ظلمانی هستند بود
                            d.Substring(d.IndexOf(harf) - 14, 1) :
                            harf;
                        break;

                    case نورانی.تظلیم:
                        payani += (d.IndexOf(harf) < 14) ?       //  اگر از  14 حرف اول که نورانی هستند بود
                            d.Substring(d.IndexOf(harf) + 14, 1) :
                            harf;
                        break;

                    case نورانی.معکوس:
                        payani += d.Substring(d.IndexOf(harf) + 14, 1);     //  کلا برعکس
                        break;
                }
            }
            return payani;
        }






        /// <summary><right>کسورات</right></summary>
        public static string kosoorat(string text, int end_num = 10)
        {
            string payani = "";
            for (int i = 0; i < text.Length; i++)
            {
                int harf = Hesab.select(text.Substring(i, 1));
                for (int k = 1; k <= end_num; k++)
                    if (harf % k == 0)
                        payani += Stentagh.kabir((harf / k).ToString())[0];
            }
            return payani;
        }



        /// <summary><right>بطون اسماء</right></summary>
        /// <param name="text">اسماء</param>
        /// <param name="batn"><right>بطن دلخواه</right></param>
        /// <param name="mod"><right>نحوه محاسبه</right></param>
        /// <returns></returns>
        public static List<int[]> batn_asma(string[] text, int batn, int mod = 0)
        {
            List<int[]> payani = new List<int[]>();
            int start = (int)text.LongLength;

            if (batn != 0)     //  بطن یک تغییر نمی‌خواهد
                for (int i = 0; i < start; i++)
                {
                    //text[i] = harf_change.alefbae(text[i]);
                    switch (batn)
                    {
                        case 1: text[i] = string.Join("", Taksir.zomam(text[i], true, true, false)); break;     //  مکسر
                        case 2: text[i] = malfoozi_100(text[i]); break;       //  زبر و بینه
                        case 3: text[i] = Adad.عددعربی(Hesab.select(text[i]).ToString()); break;     //  عدد عربی
                        case 4: text[i] = hazfmokarar_103(text[i]); break;      //  حذف مکرر
                        case 5: text[i] = hazfmokarar_103(malfoozi_100(text[i])); break;      //  حذف مکرر ملفوظی
                        case 6: text[i] = Adad.عددفارسی(Hesab.select(text[i]).ToString()); break;     //  عدد فارسی
                    }
                }

            //  محاسبه ورودی‌ها
            for (int i = 0; i < start; i++)
            {
                payani.Add(new int[4]);
                payani[i][0] = Hesab.select(text[i]);
                payani[i][1] = Hesab.select(text[i], D_int.افلاکی);
                payani[i][2] = Hesab.madkhal_vasit(payani[i][0]);
                payani[i][3] = payani[i][2];        //  رد به آحاد صغیر آخر کار محاسبه می‌شود
            }

            switch (mod)
            {
                #region case 0 : به ترتیب
                default:
                case 0:
                    for (int i = 0; i < 4; i++)
                    {
                        //  فاتحه، واسطه، خاتمه
                        for (int k = 0; k < start; k++)
                        {
                            if (i == 0) payani.Add(new int[4]);
                            payani[start + k][i] = payani[k][i] + payani[(k + 1 == start) ? 0 : k][i];
                        }
                        //  نتایج
                        for (int k = 0; k < start; k++)
                        {
                            if (i == 0) payani.Add(new int[4]);
                            payani[start * 2 + k][i] = payani[k][i] + payani[(k + 1 == start) ? 0 : k][i];
                        }
                    }
                    //  جمع اصول
                    payani.Add(new int[4]);
                    for (int i = 0; i < 4; i++)
                        for (int k = 0; k < start; k++)
                            payani[start * 3][i] += payani[k][i];
                    //  رد به آحاد تا آخر
                    for (int i = 0; i < payani.LongCount(); i++)
                        payani[i][3] = Hesab.tarh_rad_ahad(payani[i][3]);
                    break;
                #endregion

                #region case 1 : همه حالات
                case 1:

                    List<List<int>> int_list_1 = Algoritm.jaygasht(0, start - 1, 2, 2);
                    List<List<int>> int_list_2 = Algoritm.jaygasht(start, start + int_list_1.Count - 1, 2, 2);
                    for (int i = 0; i < 4; i++)
                    {
                        //  فاتحه، واسطه، خاتمه
                        for (int k = 0; k < int_list_1.Count; k++)
                        {
                            if (i == 0) payani.Add(new int[4]);
                            payani[start + k][i] = payani[int_list_1[k][0]][i] + payani[int_list_1[k][1]][i];
                        }
                        //  نتایج
                        for (int k = 0; k < int_list_2.Count; k++)
                        {
                            if (i == 0) payani.Add(new int[4]);
                            payani[start + int_list_1.Count + k][i] = payani[int_list_2[k][0]][i] + payani[int_list_2[k][1]][i];
                        }
                    }
                    //  جمع اصول
                    payani.Add(new int[4]);
                    for (int i = 0; i < 4; i++)
                        for (int k = 0; k < start; k++)
                            payani[start + int_list_1.Count + int_list_2.Count][i] += payani[k][i];
                    //  رد به آحاد تا آخر
                    for (int i = 0; i < payani.LongCount(); i++)
                        payani[i][3] = Hesab.tarh_rad_ahad(payani[i][3]);

                    break;
                    #endregion
            }

            return payani;
        }
    }

    /// <summary><right>بسط خاص</right></summary>
    public class Bast_khas
    {
        public static string عددی_حروف(string text)
        {
            //  هر اسم حرف + حساب ابجد + استنطاق
            string payani = "";
            for (int i = 0; i < text.Length; i++)
                payani += Stentagh.kabir(
                    Hesab.select(
                        Data.esmharf(text.Substring(i, 1))));
            return payani;
        }

        //  همۀ اسم حرفها + حساب ابجد + استنطاق
        public static string عددی_اعداد_حروف(string text)
        {
            return Stentagh.kabir(Hesab.select(Data.esmharf(text)));
        }

        public static string ملفوظی(string text)
        {
            return Bast.malfoozi_100(text);
        }

        public static string طبیعی(string text)
        {
            return Bast.tabdil_tabe_108(text, تبدیل_طبع.مقوی_مربی);
        }

        public static string تضاعف(string text)
        {
            string payani = "";
            for (int i = 0; i < text.Length; i++)
                payani += Stentagh.kabir(
                    2 * Hesab.select(
                        Data.esmharf(text.Substring(i, 1))));      //  گرفتن اسم حرف

            return payani;
        }

        public static string ترفع_عددی(string text)
        {
            string payani = "";
            for (int i = 0; i < text.Length; i++)
                payani += Stentagh.kabir(
                    10 * Hesab.select(text.Substring(i, 1)));

            return payani;
        }

        public static string ترفع_حروفی(string text)
        {
            return Asas_Dour.jabejai(text)[0];
        }

        public static string ترفع_طبیعی(string text)
        {
            return Bast.tabdil_tabe_108(text, تبدیل_طبع.ترفع_منقطع);
        }

        public static string تجمع(string text1, string text2)
        {
            string payani = "";
            int len = Math.Max(text1.Length, text2.Length);

            for (int i = 0; i < len; i++)
            {
                string str = Code.SubStr(text1, i, 1) + Code.SubStr(text2, i, 1);
                payani += Stentagh.kabir(
                    Hesab.select(str));
            }

            return payani;
        }

        public static string تضارب(string text)
        {
            string payani = "";
            for (int i = 0; i < text.Length; i++)
            {
                int a = Hesab.select(Code.SubStr(text, i, 1));
                int b = Hesab.select(Code.SubStr(text, i + 1, 1));
                payani += Stentagh.kabir(a * b);
            }

            return payani;
        }

        public static string تکثیر(string text)
        {
            return Bast.kosoorat(text, 10);
        }

        public static string طبیعی_مربی(string text)
        {
            return Bast.tabdil_tabe_108(text, تبدیل_طبع.مقوی_به_مربی);
        }

        public static string طبیعی_مقوی(string text)
        {
            return Bast.tabdil_tabe_108(text, تبدیل_طبع.مربی_به_مقوی);
        }

        public static string تفارد(string text)
        {
            string payani = "";
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                switch (harf)
                {
                    default: payani += harf; break;
                    case "ا": payani += "ه"; break;
                    case "ه": payani += "و"; break;
                    case "و": payani += "ی"; break;
                    case "ی": payani += "ک"; break;
                    case "ک": payani += "ل"; break;
                    case "ل": payani += "م"; break;
                    case "م": payani += "ن"; break;
                    case "ن": payani += "ا"; break;
                }
            }

            return payani;
        }

        //  بسط اتصال مخصوص حروف متصله نه خواتیم
        public static string اتصال_خاص(string text)
        {
            string payani = "";
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani += harf;
                if (!"ادذرزو".Contains(harf))
                {
                    string[] a = Asas_Dour.jabejai(harf, D_name.ابتث);
                    payani += a[1] + a[0];
                }
            }
            return payani;
        }

        public static string[] طوالع(string text) { return Taksir.taksir_tamlik(text, 1).ToArray(); }
        public static string[] اعوان_واموال(string text) { return Taksir.taksir_tamlik(text, 2).ToArray(); }
        public static string[] قران_واخوان(string text) { return Taksir.taksir_tamlik(text, 3).ToArray(); }
        public static string[] تملیک(string text) { return Taksir.taksir_tamlik(text, 4).ToArray(); }
        public static string[] احباب(string text) { return Taksir.taksir_tamlik(text, 5).ToArray(); }
        public static string[] عبید(string text) { return Taksir.taksir_tamlik(text, 6).ToArray(); }
        public static string[] تزویج(string text) { return Taksir.taksir_tamlik(text, 7).ToArray(); }
        public static string[] توارث(string text) { return Taksir.taksir_tamlik(text, 8).ToArray(); }
        public static string[] تسافروتعلیم(string text) { return Taksir.taksir_tamlik(text, 9).ToArray(); }
        public static string[] تشاغل(string text) { return Taksir.taksir_tamlik(text, 10).ToArray(); }
        public static string[] آمال(string text) { return Taksir.taksir_tamlik(text, 11).ToArray(); }
        public static string[] تضاد(string text) { return Taksir.taksir_tamlik(text, 12).ToArray(); }


        //  بسوط منحوسه
        public static string[] تعکیس(string text) { return Taksir.taksir_tamlik(text, 1, false).ToArray(); }

        public static string[] تقلیب(string text)       ///////////////////////////////////////////////////////////////////////////
        {
            string[] payani = new string[1];

            return payani;
        }

        public static string تناقض(string text)
        {
            return Bast.tabdil_tabe_108(text, تبدیل_طبع.تناقض);
        }

        public static string عکس_عددی(string text)
        {
            string a = Hesab.select(text).ToString();       //  ابجد کبیر
            a = Bast.maakoos_102(a);        //  معکوس
            return a;
        }

        public static string تناصف_عددی(string text)
        {
            return Stentagh.kabir(Hesab.select(text) / 2);     //  استنطاق نصف ابجد کبیر
        }
        public static string تناصف_حرفی(string text)//////////////////////////////
        {

            return "";
        }

        public static string تنزل_عددی(string text)
        {
            return Stentagh.kabir(Hesab.madkhal_vasit(Hesab.select(text)));      //  استنطاق مدخل مجموعی
        }

        public static string تنزل_حرفی(string text)
        {
            return Bast.tabdil_tabe_108(text, تبدیل_طبع.تنزل_منقطع);
        }

        public static string تصغیر_عددی(string text)
        {
            return Stentagh.kabir(Hesab.rad_be_ahad(Hesab.select(text)));
        }

        public static string تصغیر_حرفی(string text)
        {
            return Bast.tabdil_tabe_108(text, تبدیل_طبع.خاک);
        }
        public static string تخفیف_عددی(string text)
        {
            string payani = "";
            for (int i = 0; i < text.Length; i++)
                payani += Stentagh.kabir(       //  استنطاق
                    Hesab.select(                       //  ابجد کبیر
                    Bast.bayene_101(text.Substring(i, 1))       //  بینه هر حرف
                    ));
            return payani;
        }

        public static string تخفیف_طبعی(string text)
        {
            return Bast.tabdil_tabe_108(text, تبدیل_طبع.تناقض_تخفیف);
        }

        public static string تظلیم(string text)
        {
            return Bast.تنویر(text, نورانی.تظلیم);
        }

        public static string تنویر(string text)
        {
            return Bast.تنویر(text, نورانی.تنویر);
        }

        public static string تعمیم(string text)     ////////////////////////////////////////////////////
        {
            /////////////////       عکس بسطهای نحس      ///////////////////////
            return "";
        }

        public static string تصریف(string text)     ///////////////////////////////////////////////////////////
        {
            return "";
        }

        public static string تدویر(string text, int num, D_name dn)
        {
            string payani = "";
            string d = Data.d(dn);
            for (int i = 0; i < text.Length; i++)
            {
                int a = Math_Old.tarh_esghat(
                    d.IndexOf(text.Substring(i, 1)) + num,
                    28, false);
                payani += d.Substring(a, 1);
            }
            return payani;
        }

        public static string تمازج(string text1, string text2)
        {
            return Taksir.emtezaj(new string[] { text1, text2 }, null, 0);
        }

        public static string عزیزی_مقوی(string text)
        {
            return Bast.tabdil_tabe_108(text, تبدیل_طبع.مربی_به_مقوی);
        }

        public static string تزاوج_تشابه(string text)
        {
            return Bast.moshabeh_109(text, false);
        }

        public static string تقوی(string text, int noe)
        {
            /// noe
            /// 0: ظاهر در باطن
            /// 1: ظاهر در ظاهر
            /// 2: باطن در باطن

            string payani = "";
            for (int i = 0; i < text.Length; i++)
            {
                int kabir = Hesab.select(text.Substring(i, 1));
                int makani = Hesab.select(text.Substring(i, 1), D_int.وضعی);
                switch (noe)
                {
                    default:
                    case 0: payani += Stentagh.kabir(kabir * makani); break;
                    case 1: payani += Stentagh.kabir(kabir ^ 2); break;
                    case 2: payani += Stentagh.kabir(makani ^ 2); break;
                }
            }
            return payani;
        }
















    }

    /// <summary>رمز</summary>
    public class Ramz
    {
        /// <summary><right>رمز گذاری</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="code">رمز شدن</param>
        /// <param name="numdaste"><right>نحوه دسته‌بندی</right></param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <returns></returns>
        public static string kasri(string text, bool code, int numdaste = 0, D_name dn = D_name.ابجد)
        {
            string payani = "";
            string[] daste = Daste(numdaste, dn);
            if (code)
            {
                text = Harf_Change.alefbae(text);
                while (text != "")
                {
                    for (int j = 0; j < daste.LongLength; j++)
                        if (daste[j].Contains(text.Substring(0, 1)))
                        {
                            if (payani != "")
                                payani += " و ";

                            payani += (daste[j].IndexOf(text.Substring(0, 1)) + 1).ToString() + "/" + (j + 1).ToString();
                            break;
                        }
                    text = text.Remove(0, 1);
                }
            }
            else
            {
                int index = text.IndexOf("/");
                while (index > 0 && index < text.Length - 1)
                {
                    string a = text.Substring(index - 1, 1);
                    string b = text.Substring(index + 1, 1);
                    if (Math_Harf.num_true(a) && Math_Harf.num_true(b))
                    {
                        int x = Convert.ToInt32(a) - 1;
                        int y = Convert.ToInt32(b) - 1;
                        if (y >= 0 && x >= 0)
                            payani += ((y < daste.LongLength & x < daste[y].Length) ?
                                daste[y].Substring(x, 1) + " " : "- ");

                        text = text.Remove(0, index + 2);
                    }
                    index = text.IndexOf("/");
                }
            }
            return payani;
        }

        /// <summary><right>روش ابجد کبیر : ورودی نباید با الفبا تغییر کند</right></summary>
        public static string abjad_kabir(string text, bool code, D_name dn = D_name.ابجد)
        {
            string payani = "";
            if (code)
            {
                text = Harf_Change.alefbae(text);
                for (int i = 0; i < text.Length; i++)
                    payani = Hesab.select(text[i].ToString(), dn: dn) + payani;
            }
            else
            {
                text = Math_Harf.num_change(text).Replace(" ", "");     //  تبدیل اعداد
                if (!Math_Harf.num_true(text))
                    return "";      //  اگر فقط عدد نبود

                List<string> num = new List<string>();
                for (int i = 0, k = -1; i < text.Length; i++)
                {   //  جدا کردن اعداد
                    if (text[i] != '0')
                    {
                        num.Add(text[i].ToString());
                        k++;
                    }
                    else
                        num[k] += "0";
                }
                for (int i = 0; i < num.Count; i++)
                    payani = Stentagh.kabir(num[i], dn)[0] + " " + payani;     //  استنطاق
            }
            return payani;
        }

        /// <summary><right>رمزگذاری ایقغی</right></summary>
        public static string Igahg(string text)
        {
            string payani = "";
            string d = Data.d(D_name.ایقغ);
            while (text != "")
            {
                if (d.Contains(text.Substring(0, 1)))
                    payani = ((d.IndexOf(text[0]) - 1) / 3 + 1).ToString() + payani;
                text = text.Remove(0, 1);
            }
            return payani;
        }

        /// <summary>
        /// دسته‌بندی
        /// </summary>
        /// <param name="numdaste"><right>نحوه دسته‌بندی</right></param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <returns></returns>
        static string[] Daste(int numdaste, D_name dn = D_name.ابجد)
        {
            string[] payani = new string[8];
            string d = Data.d(dn);
            switch (numdaste)
            {
                case 0:     //43344433
                            //payani = new string[8] { d.Substring(0, 4), d.Substring(4, 3), d.Substring(7, 3), d.Substring(10, 4), d.Substring(14, 4), d.Substring(18, 4), d.Substring(22, 3), d.Substring(25, 3) }; break;
                    for (int i = 0, k = 0; i < 8; i++)
                    {
                        int g = (i == 0 || i == 3 || i == 4 || i == 5) ? 4 : 3;
                        payani[i] = d.Substring(k, g);
                        k += g;
                    }
                    break;

                default:
                case 1:     //4333333333
                    for (int i = 0, k = 0; i < 8; i++)
                    {
                        int g = (i == 0) ? 4 : 3;
                        payani[i] = d.Substring(k, g);
                        k += g;
                    }
                    break;

                case 2:     //4444444
                    for (int i = 0, k = 0; i < 8; i++, k += 4)
                        payani[i] = d.Substring(k, 4);
                    break;

                case 3:     //43434343
                    for (int i = 0, k = 0; i < 8; i++)
                    {
                        int g = (i % 2 == 0) ? 4 : 3;
                        payani[i] = d.Substring(k, g);
                        k += g;
                    }
                    break;

                case 4:     //34343434
                    for (int i = 0, k = 0; i < 8; i++)
                    {
                        int g = (i % 2 == 0) ? 3 : 4;
                        payani[i] = d.Substring(k, g);
                        k += g;
                    }
                    break;
            }
            return payani;
        }
    }


    /// <summary><right>متغیر ترکیبی از رشته و عدد</right></summary>
    public class Data_name
    {
        public string text { get; set; }
        public int num { get; set; }
    }
}
