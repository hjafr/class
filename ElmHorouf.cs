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

/// <summary><right></right></summary>
namespace HJafr.ElmHorouf
{
    /// <summary><right>حساب عدد و تبدیل حرف به عدد</right></summary>
    public class hesab
    {
        /// <summary>
        /// <right>محاسبه مقدار عددی یک نوشته</right>
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="dh"><right>دایره عدد</right></param>
        /// <param name="dn"><right>دایره حرف</right></param>
        /// <returns></returns>
        public static int select(string text, d_int dh = d_int.kabir, d_name dn = d_name.ابجد)
        {
            text = harf_change.alefbae(text);
            string d = data.d(dn);
            hesab a = new hesab();
            switch (dh)
            {
                default: case d_int.kabir: return a.کبیر(text, d);
                case d_int.maakoos: return a.معکوس(text, d);
                case d_int.vazi: return a.وضعی(text, d);
                case d_int.aflaki: return a.افلاکی(text, d);
                case d_int.saghir: return a.صغیر(text, d);
                case d_int.borooji: return a.بروجی(text, d);

                case d_int.abjad_edrici: return a.ابجدادریسی(text, d);
                case d_int.abjad_adad_vasat: return a.ابجدعددوسط(text, d);
                case d_int.abjad_thani: return a.ابجدثانی(text, d);
                case d_int.abjad_alavi: return a.ابجدعلوی(text, d);
                case d_int.abjad_az_amir: return a.ابجدیازامیرالمومنین(text, d);
                case d_int.abjad_shoaib: return a.ابجدشعیب(text, d);
                case d_int.abjad_nabavi: return a.ابجدنبوی(text, d);

                case d_int.abtath_adam: return a.ابتثآدم(text, d);
                case d_int.abtath_amir: return a.ابتثامیر(text, d);
                case d_int.abtath_sadegh: return a.ابتثصادق(text, d);

                case d_int.ahtam_martabe: return a.اهطممرتبه(text, d);
                case d_int.ahtam_heja: return a.اهطمهجا(text, d);
                case d_int.ahtam_fithaghooreth: return a.اهطمفیثاغورث(text, d);
                case d_int.ahtam_danial: return a.اهطمدانیال(text, d);
                case d_int.ahtam_vosta: return a.اهطموسطی(text, d);
                case d_int.ahtam_mothalathat: return a.اهطممثلثات(text, d);
                case d_int.ahtam_vasit_1: return a.اهطموسیط(text, d);
                case d_int.ahtam_vasit_2: return a.اهطموسیطدوم(text, d);

                case d_int.ighagh_yooshaa: return a.ایقغیوشع(text, d);

                case d_int.faal_1: return a.فال1(text, d);
            }
        }
        /// <summary>
        /// <right>محاسبه مقدارهای عددی آرایه‌ای از نوشته</right>
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="dh"><right>دایره عدد</right></param>
        /// <param name="dn"><right>دایره حرف</right></param>
        /// <returns></returns>
        public static int[] select(string[] text, d_int dh = d_int.kabir, d_name dn = d_name.ابجد)
        {
            int[] payani = new int[text.LongLength];
            for (int x = 0; x < text.LongLength; x++)
                payani[x] = select(text[x], dh, dn);
            return payani;
        }

        /// <summary>
        /// <right>مداخل اربعه</right>
        /// </summary>
        /// <param name="text">متن ورودی</param>
        /// <returns></returns>
        public static int[] madakhel_arbae(string text)
        {
            int[] madkhal = new int[4];
            madkhal[0] = hesab.select(text);            //  کبیر
            madkhal[1] = hesab.select(text, d_int.aflaki);      //  افلاکی
            madkhal[2] = madkhal_vasit(madkhal[0]);     //  وسیط
            madkhal[3] = tarh_rad_ahad(madkhal[0]);     //  رد به آحاد کامل یا همان صغیر
            return madkhal;
        }

        /// <summary>
        /// <right>مدخل وسیط یک عدد</right>
        /// </summary>
        /// <param name="num">عدد</param>
        /// <returns></returns>
        public static int madkhal_vasit(int num) => (num / 10) + (num % 10);
        /// <summary>
        /// <right>رد به آحاد</right>
        /// </summary>
        /// <param name="Fnum"><right>عدد دلخواه</right></param>
        /// <returns></returns>
        public static int rad_be_ahad(int Fnum)
        {
            int num = 0;
            for (int i = 0; i < Fnum.ToString().Length; i++)
                num += Convert.ToInt32(Fnum.ToString().Substring(i, 1));
            return num;
        }
        /// <summary>
        /// <right>رد به آحاد تا یک رقمی شدن و خروجی دادن همه آن‌ها</right>
        /// </summary>
        /// <param name="Fnum"><right>عدد مورد نظر</right></param>
        /// <returns></returns>
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
        public static int tarh_rad_ahad(int num, int tarh=9)
        {
            while (num > tarh)
                num = rad_be_ahad(num);
            return num;
        }

        /// <summary>
        /// <right>تعداد حروف</right>
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <returns></returns>
        public static int tedad_harf(string text) => harf_change.alefbae(text).Length;
        /// <summary>
        /// <right>تعداد نقطه، ناطق، صامت</right>
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <returns></returns>
        public static int[] noghte(string text)
        {
            // j[0] = تعداد نقطه
            // j[1] = ناطق
            // j[2] = صامت

            int[] j = new int[3];
            for (int i = 0; i < text.Length; i++)
            {
                string h = text.Substring(i, 1);
                if ("ادهوحطکلمسعصر".Contains(h))        //  صامات
                    j[2]++;
                else
                {
                    j[1]++;     //  ناطق
                    j[0] += ("بجزنفخذضظغ".Contains(h)) ? 1 :
                        ("یقت".Contains(h)) ? 2 :
                        3;      //  تعداد نقطه
                }
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
        public static int esghat(string text, d_int dh, d_name dn, int tarh, bool baghi)
        {
            int num = 0;
            for (int j = 0; j < text.Length; j++)
                num += math_old.tarh_esghat(select(text.Substring(j, 1), dh, dn), tarh, baghi);     //  اسقاط
            return num;
        }

        #region حسابهای مختلف
        public int kabir_fun(int j) => ((j % 9) + 1) * (int)Math.Pow(10, j / 9);        //  معادله عدد کبیر
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
                num += math_old.tarh_esghat(j + 1, 9);      //  اسقاط وضعی با عدد 9
                //  چندین روش می‌توان نوشت که ساده ترین این است
            }
            return num;
        }
        public int صغیر(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += math_old.tarh_esghat(kabir_fun(j), 12, false);       //  اسقاط کبیر با عدد 12 بدون باقی مانده
            }
            return num;
        }
        public int بروجی(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += math_old.tarh_esghat(kabir_fun(j), 12, true);        //  اسقاط کبیر با عدد 12 همراه باقی مانده
            }
            return num;
        }

        public int ابجدادریسی(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1)) + 1;
                num += (j < 4) ?
                    (j % 4) + 1 :
                    (int)Math.Pow(2, (j % 4) + (j / 4));
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
        public int ابجدیازامیرالمومنین(string text, string d)
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
                int k = math_old.tarh_esghat(j + 1, 4) * 2 + 7;
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
                num += math_old.tarh_esghat(j + 1, 7) + j / 7;
            }
            return num;
        }
        public int اهطمدانیال(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += 3 * ((j < 4) ?
                    (j + 1) :
                    (int)Math.Pow(2, j - 1));
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
                int k = math_old.tarh_esghat(j + 1, 7);
                num += 100 * ((j < 7) ? k :
                    (j < 14) ? (k + 2) :
                    (j < 21) ? (k + 5) :
                    (k + 8));
            }
            return num;
        }

        public int ابتثآدم(string text, string d)
        {
            if (d.Substring(0, 4) == "ابتث")
            {
                d = d.Substring(0, 27) + "ﻻی";
                text = text.Replace("لا", "ﻻ");
            }
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += (j + 1 - 9 * (j / 9)) * (int)Math.Pow(2, j / 9);
            }
            return num;
        }
        public int ابتثامیر(string text, string d)
        {
            if (d.Substring(0, 4) == "ابتث")
            {
                d = d.Substring(0, 27) + "ﻻی";
                text = text.Replace("لا", "ﻻ");
            }
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                for (int k = 1; k <= j + 1; k++)
                    num += k;
            }
            return num;
        }
        public int ابتثصادق(string text, string d)
        {
            if (d.Substring(0, 4) == "ابتث")
            {
                d = d.Substring(0, 27) + "ﻻی";
                text = text.Replace("لا", "ﻻ");
            }
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                num += (j + 1) * 2;
            }
            return num;
        }

        public int ایقغیوشع(string text, string d)
        {
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                if (j == 0)
                    num++;
                else
                {
                    int bg = math_old.tarh_esghat(j, 3);     //  تکرار رقم مثلا 111 میشود 3
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
                num += (i != 6) ? math_old.tarh_esghat(kabir_fun(j), 7, false) : 7;      //  همگی اسقاط باقیمانده مگر در بار اول
            }
            return num;
        }
        #endregion
    }

    /// <summary><right>استنطاق و تبدیل عدد به حرف</right></summary>
    public class stentagh
    {
        /// <summary>
        /// <right>استنطاق کبیر نوشته : اصلی</right>
        /// </summary>
        /// <param name="fnum">عدد</param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <returns></returns>
        public static string[] kabir(string fnum, d_name dn = d_name.ابجد)
        {
            string d = data.d(dn);
            int flen = fnum.Length;

            //  اماده دسته بندی کردن 3 تایی
            if (flen % 3 == 1)
                fnum = "00" + fnum;
            else if (flen % 3 == 2)
                fnum = "0" + fnum;
            flen = fnum.Length;

            string[] numdaste = new string[flen / 3];       //  عدد
            string[] s1 = new string[flen / 3];     //  اصل
            string[] s2 = new string[flen / 3];     //  عکس
            string[] s3 = new string[flen / 3];     //  خودم
            for (int i = 0; i < flen / 3; i++)
            {
                numdaste[i] = "";
                s1[i] = "";
                s2[i] = "";
                s3[i] = "";
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
                    int I = Convert.ToInt32(numdaste[i].Substring(j, 1)) - 1;
                    J[j] = (I < 0) ? "" :
                        (
                            (j == 2) ? ((I != 0) ? d.Substring(I, 1) : (numdaste[i] != "001" || fnum == "001" || (numdaste[i] == "001" && i != flen / 3 - 1)) ? d.Substring(0, 1) : "") :       //  یکان
                            (j == 1) ? d.Substring(I + 9, 1) :      //  دهگان
                            d.Substring(I + 18, 1)      //  صدگان
                        );
                }
                string temp = J[2] + J[1] + J[0];       //  جمع بندی
                s1[i] = temp;
                s2[i] = temp;
                s3[i] = temp;
            }
            #endregion

            #region جمع کردن هر دسته و قرار گیری غین
            string[] payani = { s1[0], s2[0], s3[0] };
            for (int i = 1; i < flen / 3; i++)
            {
                string hezar = "";      //  نماد هزار : غ در ابجد
                for (int j = 1; j <= i; j++)
                    hezar += d.Substring(27, 1);
                if (s1[i] != "" || (numdaste[i] == "001" && i == flen / 3 - 1))
                {
                    payani[0] += (s1[i] != "ا" ? s1[i] : "") + hezar;
                    payani[1] = s2[i] + hezar + payani[1];
                    payani[2] += hezar + s3[i];
                }
            }
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
        public static string[] kabir(string[] fnum, d_name dn, int mod)
        {
            string[] payani = new string[fnum.LongLength];
            for (int i = 0; i < fnum.LongLength; i++)
                payani[i] = kabir(fnum[i], dn)[mod];
            return payani;
        }

        /// <summary><right>استنطاق مکانی</right></summary>
        public static string makani(int num, d_name dn = d_name.ابجد) => data.d(dn).Substring(math_old.tarh_esghat(num, 28) - 1, 1);
        /// <summary><right>استنطاق مکانی</right></summary>
        public static string makani(int num, string d) => d.Substring(math_old.tarh_esghat(num, 28) - 1, 1);
        /// <summary><right>استنطاق مکانی</right></summary>
        public static string makani(decimal num, d_name dn = d_name.ابجد) => makani((int)num, dn);
        /// <summary><right>استنطاق مکانی</right></summary>
        public static string makani(long num, d_name dn = d_name.ابجد) => makani((int)num, dn);
        /// <summary><right>استنطاق مکانی</right></summary>
        public static string[] makani(int[] num, d_name dn = d_name.ابجد)
        {
            string[] payani = new string[num.LongLength];
            for (int i = 0; i < num.LongLength; i++)
                payani[i] = makani(num[i], dn);
            return payani;
        }

        /// <summary><right>استنطاق کبیر، و اگر نداشت مکانی</right></summary>
        public static string kabir_makani(int num, d_name dn) =>
            math_old.is_kabor(num) ?
            kabir(num.ToString(), dn)[0] :
            makani(num, dn);
        /// <summary><right>استنطاق کبیر تک حرفی</right></summary>
        public static string kabirtak(int num, d_name dn) => math_old.is_kabor(num) ? kabir(num.ToString(), dn)[0] : "";

    }

    /// <summary><right>اساس و دور</right></summary>
    public class asas_dour
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
        public static string asas(string text, d_name dn = d_name.ابجد, bool Gharizeh = false)
        {
            string Nazireh = "";
            string d = data.d(dn);
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
        /// جابجایی حروف : ترقی، تنزل، ترفع، مساوات 
        /// </right>
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <returns></returns>
        public static string[] jabejai(string text, d_name dn = d_name.ابجد)
        {
            string d = data.d(dn);
            string[] ja = new string[4];
            for (int i = 0; i < text.Length; i++)
                if (d.Contains(text.Substring(i, 1)))
                {
                    int j = d.IndexOf(text.Substring(i, 1));
                    ja[0] += d.Substring(math_old.tarh_esghat(j + 1, 28, false), 1);        //  ترقی
                    ja[1] += d.Substring(math_old.tarh_esghat(j - 1, 28, false), 1);        //  تنزل
                    ja[2] += d.Substring(math_old.tarh_esghat(j + 9, 27, false), 1);        //  ترفع
                    ja[3] += d.Substring(math_old.tarh_esghat(j - 9, 27, false), 1);        //  مساوات
                }
            return ja;
        }
        /// <summary>
        /// <right>
        /// جابجایی دلخواه بنابه عدد دلخواه
        /// </right>
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="num"><right>عدد دلخواه</right></param>
        /// <param name="mod"><right>نوع جابجایی با علامات + - * /</right></param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <returns></returns>
        public static string jabejai_num(string text, int num, string mod, d_name dn = d_name.ابجد)
        {
            string payani = "";
            switch (mod)
            {
                default:
                case "+":
                    for (int i = 0; i < text.Length; i++)
                        payani += stentagh.makani(hesab.select(text.Substring(i, 1), d_int.vazi, dn) + num, dn);
                    break;

                case "-":
                    for (int i = 0; i < text.Length; i++)
                        payani += stentagh.makani(hesab.select(text.Substring(i, 1), d_int.vazi, dn) - num, dn);
                    break;

                case "*":
                    for (int i = 0; i < text.Length; i++)
                        payani += stentagh.kabir_makani(hesab.select(text.Substring(i, 1), d_int.vazi, dn) * num, dn);
                    break;

                case "/":
                    for (int i = 0; i < text.Length; i++)
                        payani += stentagh.kabir_makani(hesab.select(text.Substring(i, 1), d_int.vazi, dn) / num, dn);
                    break;
            }
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
                    payani.Add(asas(text, d_name.اهطم, false));
                    payani.Add(asas(text, d_name.ابتث, false));
                    payani.Add(asas(text, d_name.ایقغ, false));
                }
            }
            return payani.ToArray();
        }

        /// <summary>
        /// <right>
        /// تواخی، تلفظ
        /// </right>
        /// </summary>
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
    public class tafkik
    {
        /// <summary><right>شماره عنصر حرف</right></summary>
        public static int tabe(string text) => data.d(d_name.ابجد).IndexOf(text) % 4;

        /// <summary><right>همطبع بودن دو حرف</right></summary>
        public static bool hamtabe(string x, string y) => tabe(x) == tabe(y);

        /// <summary><right>تفکیک عناصر</right></summary>
        public static string[] onsor(string text)
        {
            string d = data.d(d_name.ابجد);
            string[] payani = new string[4] { "", "", "", "" };
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) % 4] += text.Substring(i, 1);        //  جایگذاری حرف در خروجی
            return payani;
        }

        /// <summary><right>شدت عناصر</right></summary>
        public static int[] shedatOnsor(string text)
        {
            string d = data.d(d_name.ابجد);
            int[] payani = new int[4] { 0, 0, 0, 0 };
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                payani[j % 4] += 7 - j / 4;     //  تهیه عدد شدت
            }
            return payani;
        }

        /// <summary><right>تفکیک مزاج : گرم و سرد و خشک و تر</right></summary>
        public static string[] mazaj(string text)
        {
            string d = data.d(d_name.ابجد);
            string[] payani = new string[4] { "", "", "", "" };
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                switch (d.IndexOf(harf) % 4)
                {
                    case 0:     //  آتش
                        payani[0] += harf;      //  گرم
                        payani[2] += harf;      //  خشک
                        break;
                    case 1:     //  باد
                        payani[0] += harf;      //  گرم
                        payani[3] += harf;      //  تر
                        break;
                    case 2:     //  آب
                        payani[1] += harf;      //  سرد
                        payani[3] += harf;      //  تر
                        break;
                    case 3:     //  خاک
                        payani[1] += harf;      //  سرد
                        payani[2] += harf;      //  خشک
                        break;
                }
            }
            return payani;
        }

        /// <summary><right>شدت مزاج : گرم و سرد و خشک و تر</right></summary>
        public static int[] shedatMazaj(string text)
        {
            string d = data.d(d_name.ابجد);
            int[] payani = new int[4] { 0, 0, 0, 0 };
            for (int i = 0; i < text.Length; i++)
            {
                int j = d.IndexOf(text.Substring(i, 1));
                switch (j % 4)
                {
                    case 0:     //  آتش
                        payani[0] += 7 - j / 4;     //  گرم
                        payani[2] += 7 - j / 4;     //  خشک
                        break;
                    case 1:     //  باد
                        payani[0] += 7 - j / 4;     //  گرم
                        payani[3] += 7 - j / 4;     //  تر
                        break;
                    case 2:     //  آب
                        payani[1] += 7 - j / 4;     //  سرد
                        payani[3] += 7 - j / 4;     //  تر
                        break;
                    case 3:     //  خاک
                        payani[1] += 7 - j / 4;     //  سرد
                        payani[2] += 7 - j / 4;     //  خشک
                        break;
                }
            }
            return payani;
        }

        /// <summary><right>تفکیکی حروف نورانی و ظلمانی</right></summary>
        public static string[] noorani(string text)
        {
            string[] payani = new string[2];
            for (int i = 0; i < text.Length; i++)
                payani[Convert.ToInt32(
                    !("صراطعلیحقنمسکه".Contains(text.Substring(i, 1)))
                    )] += text.Substring(i, 1);     //  یافتن حرف نورانی برای آرایه صفر
            return payani;
        }

        /// <summary><right>تفکیک وضعی : بنابه زوج و فرد</right></summary>
        public static string[] vazi(string text)
        {
            string d = data.d(d_name.ابجد);
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
            string d = data.d(d_name.ابجد);
            string[] payani = new string[4];
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) / 9] += text.Substring(i, 1);        //  یافتن مرتبه عدد کبیر
            return payani;
        }

        /// <summary><right>اوتاد : حیوان و نبات و معدن</right></summary>
        public static string[] otad(string text)
        {
            string d = data.d(d_name.ابجد);
            string[] payani = new string[3];
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) % 3] += text.Substring(i, 1);
            return payani;
        }

        /// <summary><right>تفکیک کواکبی</right></summary>
        public static string[] kavakeb(string text)
        {
            string d = data.d(d_name.ابجد);
            string[] payani = new string[7];
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) % 7] += text.Substring(i, 1);
            return payani;
        }

        /// <summary><right>تفکیک افلاکی</right></summary>
        public static string[] aflak(string text)
        {
            string d = data.d(d_name.ابجد);
            string[] payani = new string[9];
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) % 9] += text.Substring(i, 1);
            return payani;
        }

        /// <summary><right>تفکیک ملفوظی و مکتوبی و مسروری</right></summary>
        public static string[] malfoozi(string text,bool tartib_2=false)
        {
            string[] payani = new string[3] { "", "", "" };
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                string esm = data.esmharf(harf);
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
            string d = data.d(d_name.ابتث);        //  ابتث
            for (int i = 0; i < text.Length; i++)
                payani[d.IndexOf(text.Substring(i, 1)) % 4] += text.Substring(i, 1);
            return payani;
        }

        /// <summary><right>تفکیک حروف شمسی و قمری</right></summary>
        public static string[] shamsi(string text)
        {
            string[] payani = new string[2];
            string d = data.d(d_name.ابجد);
            for (int i = 0; i < text.Length; i++)
                payani[("شنلزذضظردسثصتط".Contains(text.Substring(i, 1))) ? 0 : 1] += text.Substring(i, 1);
            return payani;
        }

        /// <summary><right>سعد و نحس (تعب) و ممتزج</right></summary>
        public static string[] saad(string text)
        {
            string[] payani = new string[3];
            string d = data.d(d_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani[
                    ("اتثدذزرهکوشغطظق".Contains(harf)) ? 0 :    //  سعد
                    ("بجحخعلنص".Contains(harf)) ? 1 :               //  نحس یا تعب
                    0       //  ("سمضیف".Contains(harf))            //  ممتزج
                    ] += harf;
            }
            return payani;
        }

        /// <summary><right>تفکیک بنابه ایام هفته</right></summary>
        public static string[] hafteh(string text)
        {
            string[] payani = new string[7];
            string d = data.d(d_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                switch (harf)
                {
                    case "ح": case "خ": case "ل": case "غ": case "ن": case "ج": payani[0] += harf; break;
                    case "و": case "ت": case "م": payani[1] += harf; break;
                    case "د": case "ه": case "ر": case "ش": payani[2] += harf; break;
                    case "ظ": case "ف": case "ی": case "ض": payani[3] += harf; break;
                    case "ب": case "ص": case "س": payani[4] += harf; break;
                    case "ا": case "ک": case "ط": payani[5] += harf; break;      //  case "ل":
                    case "ع": case "ذ": case "ث": payani[6] += harf; break;
                }
            }
            return payani;
        }

        /// <summary><right>شمال، جنوب، شرق، غرب</right></summary>
        public static string[] shomal_jonoub(string text)
        {
            string[] payani = new string[4];
            string d = data.d(d_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani[
                    ("جفهشعیض".Contains(harf)) ? 0 :        //  شمال
                    ("کظمبصن".Contains(harf)) ? 1 :         //  جنوب
                    ("اقلغوتحخ".Contains(harf)) ? 2 :           //  شرق
                    3       //  ("طذزثسدر".Contains(harf))      /   غرب
                    ] += harf;
            }
            return payani;
        }


        /// <summary>تواخی</summary>
        public static string[] tavakhi(string text)
        {
            string[] payani = new string[2];
            string d = data.d(d_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                payani[Convert.ToInt32("اهویکلمن".Contains(harf))] += harf;
            }
            return payani;
        }
    }

    /// <summary><right>تکسیر و جابجایی حروف</right></summary>
    public class taksir
    {
        /// <summary><right>
        /// تکسیر تا زمام
        /// </right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="teksir"><right>تکسیر بودن نه غریزه</right></param>
        /// <param name="moakhar"><right>مؤخر و صدر بودن</right></param>
        /// <param name="space"><right>فاصله داشتن</right></param>
        /// <param name="x"><right>تعداد بار اول</right></param>
        /// <param name="y"><right>تعداد بارهای بعد</right></param>
        /// <returns></returns>
        public static string[] zomam(string text, bool teksir, bool moakhar, bool space, int x = 1, int y = 1)
        {
            //text = harf_change.alefbae(text);
            List<string> taksir = new List<string>();
            taksir.Add(text);
            int k = 1;

            if (teksir)     //  تکسیر
                for (; taksir[0] != taksir[k - 1] || k == 1; k++)
                    taksir.Add(taksir_sadr(taksir[k - 1], moakhar, space, x, y));

            else        //  غریزه
                for (; taksir[0] != taksir[k - 1] || k == 1; k++)
                    taksir.Add(taksir_gharizeh(taksir[k - 1], moakhar, space, x, y));

            taksir.RemoveRange(--k, 1);     //  حذف مورد آخر

            return harf_change.space(taksir.ToArray(), space);
        }

        /// <summary><right>
        /// یکبار تکسیر
        /// </right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="teksir"><right>تکسیر بودن نه غریزه</right></param>
        /// <param name="moakhar"><right>مؤخر و صدر بودن</right></param>
        /// <param name="space"><right>فاصله داشتن</right></param>
        /// <param name="x"><right>تعداد بار اول</right></param>
        /// <param name="y"><right>تعداد بارهای بعد</right></param>
        /// <returns></returns>
        public static string zomam_once(string text, bool teksir, bool moakhar, bool space, int x = 1, int y = 1) => (teksir) ?
            taksir_sadr(text, moakhar, space, x, y) :       //  تکسیر
            taksir_gharizeh(text, moakhar, space, x, y);        //  غریزه

        /// <summary>
        /// تکسیر
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="moakhar"><right>مؤخر و صدر بودن</right></param>
        /// <param name="space"><right>فاصله داشتن</right></param>
        /// <param name="x"><right>تعداد بار اول</right></param>
        /// <param name="y"><right>تعداد بارهای بعد</right></param>
        /// <returns></returns>
        public static string taksir_sadr(string text, bool moakhar, bool space, int x = 1, int y = 1)
        {
            string taksir = "";
            bool aval = true;       //  طبق این جای صدر و مؤخر مشخص می‌شود

            for (int i = 0, m = -1, n = 0; i < text.Length; i++)
            {
                if (i == 0)     //  بار اول
                    if (moakhar)    //  مؤخر
                    {
                        for (int j = 0; j < x && i < text.Length; j++, i++)
                            taksir += text.Substring(text.Length - ++n, 1);
                        i--;
                    }
                    else        //  صدر
                    {
                        for (int j = 0; j < x && i < text.Length; j++, i++)
                            taksir += text.Substring(++m, 1);
                        i--;
                        aval = false;
                    }

                else    //  بارهای بعد
                {
                    if (aval)
                    {
                        for (int j = 0; j < y && i < text.Length; j++, i++)
                            taksir += text.Substring(++m, 1);
                        i--;
                        aval = false;
                    }
                    else
                    {
                        for (int j = 0; j < y && i < text.Length; j++, i++)
                            taksir += text.Substring(text.Length - ++n, 1);
                        i--;
                        aval = true;
                    }
                }
            }

            return space ? taksir : harf_change.space(taksir, space);
        }

        /// <summary><right>
        /// تکسیر غریزه
        /// </right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="moakhar"><right>مؤخر و صدر بودن</right></param>
        /// <param name="space"><right>فاصله داشتن</right></param>
        /// <param name="x"><right>تعداد بار اول</right></param>
        /// <param name="y"><right>تعداد بارهای بعد</right></param>
        /// <returns></returns>
        public static string taksir_gharizeh(string text, bool moakhar, bool space, int x = 1, int y = 1)
        {
            string taksir = "";
            string[] gharizeh = new string[2] { "", "" };

            for (int i = 0, n = 0; i < text.Length; i += y, n++)
            {
                if (i == 0)     //  بار اول
                {
                    gharizeh[0] += text.Substring(i, x);
                    i = x - y;
                }
                else
                    gharizeh[n % 2] += code.SubStr(text, i, y);
            }
            gharizeh[0] = bast.maakoos(gharizeh[0]);        //  معکوس کردن بخش اول

            taksir = gharizeh[1] + gharizeh[0];     //  جمع بخش اول و دوم
            if (!moakhar)
                taksir = bast.maakoos(taksir);      //  در حالت عادی مؤخر و صدر است و نیازی به معکوس کردن ندارد

            return space ? taksir : harf_change.space(taksir, space);
        }


        /// <summary>
        /// امتزاج
        /// </summary>
        /// <param name="text">نوشته‌های برای امتزاج با یکدیگر</param>
        /// <param name="gam_tmp"><right>گام: اگر نال باشد پیشفرض گام‌ها عدد یک خواهد بود</right></param>
        /// <param name="tekrar"><right>تکرار نوشته‌ها تا برابر شوند</right></param>
        /// <returns></returns>
        public static string emtezaj(string[] text, int[] gam_tmp, bool tekrar)
        {
            string str = "";
            string payani = "";
            int[] first = new int[text.LongLength];

            //  تنظیم گام
            int[] gam = new int[text.LongLength];
            if (gam_tmp.LongLength < 1)
                gam_tmp = new int[1] { 1 };
            for (int i = 0; i < text.LongLength; i++)
                gam[i] = gam_tmp[i % gam_tmp.LongLength];       //  اگر گام ها کمتر از نوشته ها از اول دوباره میگیرد

            if (!tekrar)
                for (int k = 0; str != "" || k == 0; k++)
                {
                    str = "";
                    for (int i = 0; i < text.LongLength; i++)
                    {
                        str += code.SubStr(text[i], first[i], gam_tmp[i]);         //  عملیات اصلی
                        first[i] += gam_tmp[i];     //  رد شدن از آنچه گرفته شد
                    }
                    payani += str;
                }
            else
            {

            }
            return payani;
        }

        /// <summary>
        /// لقط
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="start"><right>خانه شروع</right></param>
        /// <param name="gam">گام</param>
        /// <param name="tedad"><right>تعداد حرف برداشتی</right></param>
        /// <param name="monfasel"><right>منفصل بودن لقط نه متصل</right></param>
        /// <param name="hazf"><right>حذفی بودن لقط</right></param>
        /// <param name="one_dour"><right>یک دور بودن لقط و رسیدن به خانه شروع</right></param>
        /// <returns></returns>
        public static string laght(string text, int start, int gam, int tedad, bool monfasel, bool hazf = false, bool one_dour = false)
        {
            string a = "";
            if (monfasel)       //  لقط منفصل
            {
                int i = start;

                for (; i < text.Length; i += gam + tedad - 1)
                    a += code.SubStr(text, i, tedad);

                i -= text.Length;

                if (one_dour)    //  یک دور
                    for (; i < start; i += gam + tedad - 1)
                        a += code.SubStr(text, i, tedad);
            }
            else
            {   //  لقط متصل
                //  در لقط متصل تعداد همیشه برابر یک است
                if (hazf)
                {
                    for (int i = start; text.Length > 1; i += gam - 1)
                    {
                        while (i >= text.Length)     //  بازگشت به اول نوشته
                            i -= text.Length;
                        a += text.Substring(i, 1);
                        text = text.Remove(i, 1);
                    }
                    a += text;
                }
                else
                {
                    bool[] bol = new bool[text.Length];
                    for (int i = 0; i < text.Length; i++)
                        bol[i] = true;
                    bool edame = true;

                    for (int i = start; edame && i < text.Length; i += gam)
                    {
                        if (bol[i])     // انتخاب همان حرف
                        {
                            a += text.Substring(i, 1);
                            bol[i] = false;
                        }
                        else            //  انتخاب حرف استفاده نشده بعدی
                        {
                            for (int j = i; j < text.Length; j++)
                            {
                                if (bol[j])
                                {
                                    a += text.Substring(j, 1);
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
            }
            return a;
        }


        /// <summary><right>امتزاج حروف تفکیک ملفوظی</right></summary>
        public static string mazj_masroori_malfoozi(string text) => emtezaj(tafkik.malfoozi(text, true), null, false);
    }

    /// <summary>بسط</summary>
    public class bast
    {
        /// <summary><right>بسط ملفوظی به تعداد دور دلخواه</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="dor"><right>تعداد دور</right></param>
        /// <returns></returns>
        public static string malfoozi(string text, int dor = 1)
        {
            if (dor < 1) dor = 1;
            for (int i = 0; i < dor; i++)
            {
                string x = "";
                for (int j = 0; j < text.Length; j++)
                    if (text.Substring(j, 1) != " ")
                        x += data.esmharf(text.Substring(j, 1)) + " ";      //  گرفتن اسم حرف
                text = x;
            }
            return text;
        }

        /// <summary><right>بینه با تعداد دور دلخواه</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="dor"><right>تعداد دور</right></param>
        /// <returns></returns>
        public static string bayene(string text, int dor = 1)
        {
            for (int i = 0; i < dor; i++)
            {
                string x = "";
                for (int j = 0; j < text.Length; j++)
                    if (text.Substring(j, 1) != " ")
                        x += data.esmharf(text.Substring(j, 1)).Substring(1) + " ";     //  گرفتن حروف اسم حرف بجز حرف اول آن
                text = x;
            }
            return text;
        }

        /// <summary><right>بسط معکوس : معکوس کردن نوشته</right></summary>
        public static string maakoos(string text)
        {
            string x = "";
            for (int i = text.Length - 1; i >= 0; i--)
                x += text.Substring(i, 1);
            return x;
        }

        /// <summary><right>حذف مکرر</right></summary>
        public static string hazfmokarar(string text)
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
        public static List<string> hazfmokarar_list(List<string> text)
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
        public static string tansif_tazif(string text, d_int dh, d_name dn, bool Zarb, int num = 2)
        {
            int x = hesab.select(text, dh, dn);
            return stentagh.kabir((Zarb ? x * num : x / num).ToString(), dn)[0];
        }



        /// <summary><right>کسورات</right></summary>
        public static string kosoorat(string text, int end_num = 10)
        {
            string payani = "";
            for (int i = 0; i < text.Length; i++)
            {
                int harf = hesab.select(text.Substring(i, 1));
                for (int k = 1; k <= end_num; k++)
                    if (harf % k == 0)
                        payani += stentagh.kabir((harf / k).ToString())[0];
            }
            return payani;
        }

        /// <summary><right>بسط موازی</right></summary>
        /// <param name="text_1">متن1</param>
        /// <param name="text_2">متن2</param>
        /// <param name="dh"><right>دایره عدد</right></param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <param name="nafs"><right>شروع از نفس حرف در شمارش</right></param>
        /// <returns></returns>
        public static string movazi(string text_1, string text_2, d_int dh = d_int.vazi, d_name dn = d_name.ابجد, bool nafs = false)
        {
            string payani = "";
            for (int i = 0; i < text_1.Length; i++)
            {
                string harf = text_2.Substring(i % text_2.Length, 1);
                int harf_int = hesab.select(harf, dh, dn);
                payani += code.SubStr(text_1, i + harf_int - Convert.ToInt32(nafs), 1, true);
            }

            return payani;
        }

        /// <summary><right>بسط طرح سته</right></summary>
        /// <param name="text">متن</param>
        /// <param name="nafs"><right>شروع از نفس حرف در شمارش</right></param>
        /// <returns></returns>
        public static string[] tarh_sete(string text, bool nafs = false)
        {
            string[] payani = new string[6];
            text = harf_change.alefbae(text);
            int[] tarh = new int[6] { 4, 7, 9, 12, 28, 30 };

            for (int i = 0; i < 6; i++)
                payani[i] = taksir.laght(text, tarh[i] - 1, tarh[i] - Convert.ToInt32(nafs), 1, true);

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
                        case 1: text[i] = string.Join("", taksir.zomam(text[i], true, true, false)); break;     //  مکسر
                        case 2: text[i] = malfoozi(text[i]); break;       //  زبر و بینه
                        case 3: text[i] = adad.عددعربی(text[i]); break;     //  عدد عربی
                        case 4: text[i] = hazfmokarar(text[i]); break;      //  حذف مکرر
                        case 5: text[i] = hazfmokarar(malfoozi(text[i])); break;      //  حذف مکرر ملفوظی
                        case 6: text[i] = adad.عددفارسی(text[i]); break;     //  عدد فارسی
                    }
                }

            //  محاسبه ورودی‌ها
            for (int i = 0; i < start; i++)
            {
                payani.Add(new int[4]);
                payani[i][0] = hesab.select(text[i]);
                payani[i][1] = hesab.select(text[i], d_int.aflaki);
                payani[i][2] = hesab.madkhal_vasit(payani[i][0]);
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
                        payani[i][3] = hesab.tarh_rad_ahad(payani[i][3]);
                    break;
                #endregion

                #region case 1 : همه حالات
                case 1:

                    List<List<int>> int_list_1 = algoritm.jaygasht(0, start - 1, 2, 2);
                    List<List<int>> int_list_2 = algoritm.jaygasht(start, start + int_list_1.Count - 1, 2, 2);
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
                        payani[i][3] = hesab.tarh_rad_ahad(payani[i][3]);

                    break;
                #endregion

                #region case 2 : مدل سیدحمید
                case 2:
                    int len = (int)text.LongLength;
                    for (int i = 0; payani.Count <= len * 3 + 1; i++)
                        payani.Add(new int[4]);

                    for (int i = 0; i < 4; i++)
                        for (int k = 0; k < len; k++)
                            payani[k + len][i] = payani[(k + 1 != len) ? 0 : k][i] + payani[k + 1][i];      //  فاتحه و واسطه و خاتمه

                    for (int i = 0; i < 4; i++)
                        for (int k = len; k < len * 2; k++)
                            payani[k + len * 2][i] = payani[(k + 1 != len * 2) ? len : k][i] + payani[k + 1][i];        //  نتایج

                    for (int i = 0; i < 4; i++)
                        for (int k = 0; k < len; k++)
                            payani[len * 3][i] += payani[k][i];      //  جمع اصول

                    for (int i = 0; i < len * 3 + 1; i++)
                        payani[i][3] = hesab.tarh_rad_ahad(payani[i][3]);      //  رد به آحاد تا آخر
                    break;
                    #endregion
            }

            return payani;
        }
    }

    /// <summary>رمز</summary>
    public class ramz
    {
        /// <summary><right>رمز گذاری</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="numdaste"><right>نحوه دسته‌بندی</right></param>
        /// <param name="axs">معکوس</param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <returns></returns>
        public static string code(string text, int numdaste, bool axs, d_name dn = d_name.ابجد)
        {
            string payani = "";
            string[] daste = Daste(numdaste,dn);
            while (text != "")
            {
                for (int j = 0; j < daste.LongLength; j++)
                    if (daste[j].Contains(text.Substring(0, 1)))
                    {
                        if (payani != "")
                            payani += " و ";

                        payani += !axs ?
                            (daste[j].IndexOf(text.Substring(0, 1)) + 1).ToString() + "/" + (j + 1).ToString() :
                            (j + 1).ToString() + "/" + (daste[j].IndexOf(text.Substring(0, 1)) + 1).ToString();
                        break;
                    }
                text = text.Remove(0, 1);
            }
            return payani;
        }

        /// <summary><right>رمز برداری</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="numdaste"><right>نحوه دسته‌بندی</right></param>
        /// <param name="axs">معکوس</param>
        /// <param name="dn"><right>دایره حروف</right></param>
        /// <returns></returns>
        public static string decode(string text, int numdaste, bool axs, d_name dn = d_name.ابجد)
        {
            string payani = "";
            string[] daste = Daste(numdaste,dn);

            int index = text.IndexOf("/");
            while (index > 0 && index < text.Length - 1)
            {
                string a = text.Substring(index - 1, 1);
                string b = text.Substring(index + 1, 1);
                if (math_harf.num_true(a) && math_harf.num_true(b))
                {
                    int x = Convert.ToInt32(a) - 1;
                    int y = Convert.ToInt32(b) - 1;
                    if (y >= 0 && x >= 0)
                        payani +=(!axs)?
                            ((y < daste.LongLength & x < daste[y].Length) ?
                            daste[y].Substring(x, 1) + " " : "- "):
                            ((x < daste.LongLength & y < daste[x].Length) ?
                            daste[x].Substring(y, 1) + " " : "- ");

                    text = text.Remove(0, index + 2);
                }
                index = text.IndexOf("/");
            }
            return payani;
        }

        /// <summary><right>رمزگذاری ایقغی</right></summary>
        public static string Igahg(string text)
        {
            string payani = "";
            string d = data.d(d_name.ایقغ);
            while (text != "")
            {
                if (d.Contains(text.Substring(0, 1)))
                    payani = ((d.IndexOf(text.Substring(0, 1)) - 1) / 3 + 1).ToString() + payani;
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
        static string[] Daste(int numdaste, d_name dn = d_name.ابجد)
        {
            string[] payani = new string[8];
            string d = data.d(dn);
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
}
