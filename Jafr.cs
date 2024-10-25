using System;
using System.Collections.Generic;
using System.Linq;
using HJafr.ElmHorouf;
using HJafr.math_old_cls;
using HJafr.harf_change_cls;
using HJafr.Enums;
using HJafr.data_cls;
using HJafr.main_codes;
using HJafr.sarf;

/// <summary>
/// <right>جفر</right>
/// <right>نسخه: 2.0.0</right>
/// <right>تاریخ: 1403.07.11</right>
/// </summary>
namespace HJafr.Jafr_cs
{
    /// <summary>
    /// روش 
    /// </summary>
    public class Jafr_Ravesh
    {
        /// <summary>
        /// محاسبه جفر نادعلی
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="mod">روش محاسبه</param>
        /// <param name="d_h">شماره دایره حروف</param>
        /// <returns></returns>
        public static string[] nade_ali_jafr(string text, int mod, D_name dn)
        {
            Jafr_Ravesh nadeali = new Jafr_Ravesh();
            string d = Data.d(dn);
            List<string> m = new List<string>();            //  مراحل

            m.Add(Harf_Change.space(Harf_Change.alefbae(text), false));     //  طرح سوال
            m.Add(Bast.hazfmokarar_103(m[0]));          //  حذف مکرر
            m.Add(Taksir.zomam_once(m[1], true, true, false));      //  مؤخر و صدر
            m.Add(Taksir.zomam_once(m[2], true, true, false));      //  مؤخر و صدر

            int[] m__4 = new int[m[1].Length];      //  ابجد افلاکی مراحل قبل
            m.Add("");
            for (int i = 0; i < m[1].Length; i++)
            {
                m__4[i] = Hesab.select(m[1].Substring(i, 1) + m[2].Substring(i, 1) + m[3].Substring(i, 1), D_int.افلاکی);
                m[4] += m__4[i].ToString() + ",";
            }

            m.Add("");
            for (int i = 0; i < m[1].Length; i++)       //  مستحصله
                m[5] += Stentagh.makani(d.IndexOf(m[3].Substring(i, 1)) + m__4[i], dn);

            m.Add(Taksir.zomam_once(m[5], true, true, false));      //  مؤخر و صدر
            m.Add(Jafr_Ravesh.nade_ali_tansif(m.Last()));        //  تنصیف اول
            m.Add(Jafr_Ravesh.nade_ali_tansif(m.Last()));        //  تنصیف دوم   satr 8

            //  روش های متفاوت از این به بعد
            if (mod != 1)
            {
                //  مزج دو مرحله قبل
                int hese_int = (int)Math.Ceiling((decimal)m[1].Length / 2);
                string[] hese = new string[] { m[8].Substring(0, hese_int), m[8].Substring(hese_int) };
                m.Add(Taksir.emtezaj(new string[2] { hese[0], hese[1] }, null, false));
            }

            if (mod == 0)
                m.Add(Bast.hazfmokarar_103(m.Last()));      //  حذف مکرر

            string temp_str = m.Last();     //  مؤخر و صدر
            for (int i = 0; i < 3; i++)
                temp_str = Taksir.zomam_once(temp_str, true, true, false);
            m.Add(temp_str);

            m.Add(Jafr_Ravesh.nade_ali_tansif(m.Last()));        //  تنصیف

            if (mod == 1 || mod == 3)
                m.Add(Asas_Dour.asas(m[m.Count - 2], D_name.ابجد, false));        //  نظیره ابجدی

            return m.ToArray();
        }
        /// <summary>
        /// تنصیف برای جفر نادعلی
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <returns></returns>
        public static string nade_ali_tansif(string text)
        {
            string payani = "";

            for (int i = 0; i < text.Length; i++)
            {
                string h = text.Substring(i, 1);
                int kabir = Hesab.select(h);
                int makani = Hesab.select(h, D_int.وضعی);
                int aflaki = Hesab.select(h, D_int.افلاکی);

                if (kabir == 1)
                    payani += "ا";
                else if (aflaki % 2 == 0 || aflaki == 1)
                    payani += Stentagh.kabir((kabir / 2).ToString())[0];
                else
                    payani += Stentagh.makani(makani - 1);
            }
            return payani;
        }



        /// <summary>
        /// محاسبه جفر سداسی
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <returns></returns>
        public static string[] sodasi_jafr(string text)
        {
            string[] m = new string[15];            //  مراحل

            m[0] = Harf_Change.space(Harf_Change.alefbae(text), false);     //  طرح سوال

            int[] madkhal_int = new int[3] {
                Hesab.select(m[0]),
                Hesab.tedad_harf(m[0]),
                Hesab.noghte(m[0]), };

            string[] madkhal_string = new string[3] {
                Stentagh.kabir(madkhal_int[0].ToString()),
                Stentagh.kabir(madkhal_int[1].ToString()),
                Stentagh.kabir(madkhal_int[2].ToString()), };

            m[1] = "مداخل سه گانه : " + madkhal_int[0] + " | " + madkhal_int[1] + " | " + madkhal_int[2] + "  :  " +
                Harf_Change.space(madkhal_string[0], true) + " | " + Harf_Change.space(madkhal_string[1], true) + " | " + Harf_Change.space(madkhal_string[2], true);

            m[2] = Harf_Change.space(Bast.malfoozi_100(madkhal_string[0] + madkhal_string[1] + madkhal_string[2]), false);
            m[3] = Asas_Dour.asas(m[2]);
            m[4] = Asas_Dour.asas(m[3], D_name.اهطم);

            m[5] = Taksir.laght(m[2], 2, 3, 1, اتصال_لقط.متصل_باتکرار);
            m[6] = Taksir.laght(m[3], 1, 3, 1, اتصال_لقط.متصل_باتکرار);
            m[7] = Taksir.laght(m[4], 0, 3, 1, اتصال_لقط.متصل_باتکرار);
            m[8] = m[5] + m[6] + m[7];
            m[9] = Taksir.zomam_once(m[8], true, false, false);

            string[] dour = Asas_Dour.dour(m[9]);
            m[10] = dour[1];
            m[11] = dour[2];
            m[12] = dour[3];
            m[13] = dour[4];
            m[14] = dour[5];

            return m;
        }



        /// <summary>
        /// محاسبه جفر طرح غالب
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="tarh">عدد طرح</param>
        /// <param name="lafz_bl">لفظی بودن</param>
        /// <param name="taksir_bl">تکسیری بودن</param>
        /// <returns></returns>
        public static string[] tarh_ghaleb_jafr(string text, int tarh, bool lafz_bl, bool taksir_bl)
        {
            List<string> pasokh = new List<string>();
            //string[] pasokh = new string[5];
            int m = 7;
            text = Harf_Change.alefbae(text);       //  سوال
            pasokh.Add(text);
            pasokh.Add(Bast.hazfmokarar_103(text));     //  حذف مکرر
            pasokh.Add(Harf_Change.space(Bast.malfoozi_100(pasokh[1]), false));     //  بسط ملفوظی

            string[] onsor = Tafkik.onsor(pasokh[2]);    //  تفکیک عناصر
            int[] onsor_int = new int[4];       //  کبیر عناصر
            for (int i = 0; i < 4; i++)
            {
                onsor_int[i] = Hesab.select(onsor[i]);
                pasokh.Add(onsor[i]);
                //pasokh.Add((lafz_bl ? onsor_int[i] : onsor[i].Length).ToString() + "," + onsor[i]);
            }
            int ghaleb = (lafz_bl) ?
                Math_Old.big_low(onsor_int, true) :       //  ابجد کبیر
                Math_Old.big_low(onsor, true);      //  تعداد حروف

            int[] m_int = Hesab.rad_be_ahad_kamel(onsor_int[ghaleb]);     //  مداخل
            pasokh.Add("");
            for (int i = 0; i < m_int.LongLength; i++)
                pasokh[m] += Stentagh.kabir(m_int[i].ToString())[0];

            //  مستحضره
            pasokh.Add("");
            int do_int = 0;
            do
            {
                if (taksir_bl)
                    switch (do_int)
                    {
                        case 0: tarh = 4; break;
                        case 1: tarh = 7; break;
                        case 2: tarh = 9; break;
                        case 3: tarh = 12; break;
                        case 4: tarh = 28; break;
                        case 5: tarh = 30; break;
                    }

                pasokh[m + 1] += tarh_ghaleb_mostahzereh(pasokh, pasokh[taksir_bl ? m : 1].Length, m, tarh);
                do_int++;
            }
            while (taksir_bl && do_int < 6);
            //int sdfsdfsadf = pasokh[m + 1].Length;
            // تکسیر
            if (taksir_bl)
            {
                string[] zomam = Taksir.zomam(pasokh[m + 1], true, true, false);
                for (int i = 1; i < zomam.LongLength; i++)
                    pasokh.Add(zomam[i]);
            }

            return pasokh.ToArray();
        }
        /// <summary>
        /// مستحضره طرح غالب
        /// </summary>
        /// <param name="pasokh">پاسخ</param>
        /// <param name="for_len">طول حلقه</param>
        /// <param name="m">شماره ملاک</param>
        /// <param name="tarh">طرح</param>
        /// <param name="d">دایره حروف</param>
        /// <returns></returns>
        static string tarh_ghaleb_mostahzereh(List<string> pasokh, int for_len, int m, int tarh)
        {
            string payani = "";
            for (int i = 0, g = 0; i < for_len; i++, g++)
            {
                int gam = Hesab.select(pasokh[1].Substring(i % pasokh[1].Length, 1) + pasokh[m].Substring(g % pasokh[m].Length, 1), D_int.kabir) % tarh;
                if (gam == 0) gam = tarh;

                int start = 0;
                if (i != 0)
                    start = Harf_Change.space(Bast.malfoozi_100(pasokh[1].Substring(0, i % pasokh[1].Length)), false).Length;

                int x = start + gam - 1;
                while (x >= pasokh[2].Length)
                    x -= pasokh[2].Length;

                payani += Code.SubStr(pasokh[2], x, 1);
            }
            return payani;
        }


        /// <summary>
        /// مستحصله خورشید جفر
        /// </summary>
        /// <param name="text">متن سوال</param>
        /// <param name="manzel">عدد منزل قمر برای دایره لسان الغیب</param>
        /// <param name="kelid_str">10 حرف کلید</param>
        /// <returns></returns>
        public static string[][] khorshid_jafr(string text, int manzel, string kelid_10)
        {
            List<string[]> payani = new List<string[]>();
            string[] xx = new string[11] { "", "", "", "", "", "", "", "", "", "", "" };
            string[] x = (string[])xx.Clone();
            string[] kelid = new string[10];
            for (int i = 0; i < 10; i++)
                kelid[i] = kelid_10.Substring(i, 1);

            //  سوال
            text = Harf_Change.alefbae(text);
            int soal_lines = text.Length / 10 + Convert.ToInt32(text.Length % 10 != 0);
            x[0] = "سوال";
            for (int i = 0; i < soal_lines; i++)
            {
                for (int k = 1; k < 11; k++)
                    x[k] = Code.SubStr(text, i * 10 +k-1, 1);
                payani.Add(x); x = (string[])xx.Clone();
            }

            //  مجموع با حساب ابجد افلاکی
            x[0] = "مجموع ابجد افلاکی";
            for (int k = 1; k < 11; k++)
            {
                string tmp_str = "";
                for (int i = 0; i < soal_lines; i++)
                    tmp_str += payani[i][k];
                x[k] = Hesab.select(tmp_str, D_int.افلاکی).ToString();
            }
            payani.Add(x); x = (string[])xx.Clone();

            //  استنطاق طبق دایره منتخب از لسان الغیب
            string d_manzel = Taksir.laght(Data.d(D_name.ابجد), 0, manzel, 1, 0);
            x[0] = "استنطاق لسان الغیب";
            for (int k = 1; k < 11; k++)
                x[k] = Stentagh.makani(Convert.ToInt32(payani[soal_lines][k]), d_manzel);
            payani.Add(x); x = (string[])xx.Clone();

            //  کلیدها
            x[0] = "کلیدها: حروف غیبی";
            for (int k = 1; k < 11; k++)
                x[k] = kelid[k - 1];
            payani.Add(x); x = (string[])xx.Clone();

            //  عمل
            x[0] = "تشخیص عمل";
            for (int k = 1; k < 11; k++)
            {
                string[] y = Tafkik.onsor(payani[soal_lines + 1][k] + payani[soal_lines + 2][k]);
                x[k] = (payani[soal_lines + 1][k] == payani[soal_lines + 2][k]) ? "=" :        //  دو متماثل
                    (y[0].Length == 0 && y[1].Length == 0) || (y[2].Length == 0 && y[3].Length == 0) ? "+" : "-";       //  طبع موافق و مخالف
            }
            payani.Add(x); x = (string[])xx.Clone();

            //  جمع یا منهای دو عدد
            x[0] = "اعمال بر دو عدد";
            for (int k = 1; k < 11; k++)
            {
                int a = Hesab.select(payani[soal_lines + 1][k], D_int.وضعی);
                int b = Hesab.select(payani[soal_lines + 2][k], D_int.وضعی);
                x[k] = (payani[soal_lines + 3][k] == "=") ? a.ToString() :
                    (payani[soal_lines + 3][k] == "+") ? (a + b).ToString() : Math.Abs(a - b).ToString();
            }
            payani.Add(x); x = (string[])xx.Clone();

            //  استنطاق
            x[0] = "استنطاق";
            for (int k = 1; k < 11; k++)
                x[k] = Stentagh.makani(Convert.ToInt32(payani[soal_lines + 4][k]));
            payani.Add(x); x = (string[])xx.Clone();

            //  نظیره
            x[0] = "نظیره‍";
            for (int k = 1; k < 11; k++)
                x[k] = Asas_Dour.asas(payani[soal_lines + 5][k], D_name.ابجد, false);
            payani.Add(x); x = (string[])xx.Clone();

            return payani.ToArray();
        }

        public static string[][] mostahsele_badooh_lin(string text)
        {
            string[][] payani = new string[114][];

            text = Harf_Change.alefbae(text, false, false, false, true);        //  الفبایی کردن با جایگزاری فاصله
            payani[0] = text.Split(' ');        //  جداسازی کلمات
            payani[1] = Value_Change.int_to_string_array(Hesab.select(payani[0]));     //  ابجد کبیر
            payani[2] = Stentagh.kabir(payani[1], D_name.ابجد, 0);        //  استنطاق

            string first = String.Join("", payani[2]);
            string moakhar_1 = Taksir.zomam_once(first, true, true, false);
            string moakhar_2 = Taksir.zomam_once(moakhar_1, true, true, false);

            payani[3] = Value_Change.string_to_array(first);       //  قرار دادن استنطاق در ردیف اول
            payani[4] = Value_Change.string_to_array(moakhar_1);        //  مؤخر و صدر
            payani[5] = Value_Change.string_to_array(moakhar_2);        //  مؤخر و صدر
            payani[6] = Value_Change.int_to_string_array(Hesab.select(payani[4], D_int.وضعی));        //  عدد وضعی مؤخر
            payani[7] = Value_Change.int_to_string_array(Hesab.select(payani[5], D_int.وضعی));        //  عدد وضعی مؤخر

            payani[8] = new string[payani[3].LongLength];       //  جمع دو مورد قبل
            for (int i = 0; i < payani[3].LongLength; i++)
                payani[8][i] = (Convert.ToInt32(payani[6]) + Convert.ToInt32(payani[7])).ToString();

            {   //  رد به آحاد
                int[] last_int = Value_Change.string_to_int_array(payani[8]);
                int[] num = new int[last_int.LongLength];
                for (int i = 0; i < last_int.LongLength; i++)
                    num[i] = Hesab.rad_be_ahad(last_int[i]);
                payani[9] = Value_Change.int_to_string_array(num);
            }

            payani[10] = Value_Change.int_to_string_array(Hesab.select(payani[4], D_int.وضعی, D_name.اهطم));       //  عدد اهطم وضعی مؤخر

            payani[11] = new string[payani[3].LongLength];       //  جمع دو مورد قبل منهای یک
            for (int i = 0; i < payani[3].LongLength; i++)
                payani[11][i] = (Convert.ToInt32(payani[9]) + Convert.ToInt32(payani[10]) - 1).ToString();

            payani[12] = Stentagh.makani(Value_Change.string_to_int_array(payani[11]), D_name.اهطم);      //  استنطاق اهطمی
            payani[13] = Value_Change.string_to_array(String.Join("", payani[12]));     //  مؤخر و صدر

            return payani;
        }
    }

    /// <summary>
    /// جفر صدیق یا 15 سطری
    /// </summary>
    public class Jafr_15_Satri
    {
        /// <summary>
        /// جفر صدیقی!!!!!!
        /// </summary>
        /// <param name="soal"></param>
        /// <param name="harf_hasel_safheh"></param>
        /// <param name="horoof_safheh"></param>
        /// <returns></returns>
        public static string[,] jafr_sedighi(string soal, string harf_hasel_safheh, string[] horoof_safheh)
        {
            //      تتمه ها مشکل دارند و نیاز به نگارش ویژه است مثل ارایه ای کردن دوتایی
            string[,] satr;
            //for (int i = 0; i < 16; i++)
            //satr[i] = "";
            string f_satr = "";
            int len = 0;

            // سطر 0 : مداخل
            {
                int[] madakhal_int = new int[4];
                madakhal_int[0] = Hesab.select(soal);
                madakhal_int[1] = Hesab.select(soal, D_int.صغیر);
                madakhal_int[2] = Hesab.madkhal_vasit(madakhal_int[0]);
                madakhal_int[3] = Hesab.madkhal_vasit(madakhal_int[1]);

                string satr0 = String.Join(",", madakhal_int) + "," + String.Join(",", Stentagh.kabir(Value_Change.int_to_string_array(madakhal_int), D_name.ابجد, 0));       //  چک شود
                f_satr = Bast.malfoozi_100(Harf_Change.alefbae(satr0));
                len = f_satr.Length;
                satr = new string[16, len];
                satr[0, 0] = satr0;
            }

            for (int i = 0; i < len; i++)       // سطر 1 : اساس
                satr[1, i] = f_satr.Substring(i, 1);

            for (int i = 0; i < len; i++)       // سطر 2 : نظیره
                satr[2, i] = Asas_Dour.asas(satr[1, i], D_name.ابجد, false);

            for (int i = 0; i < len; i++)       // سطر 3 : حاصل نسبت اساس
                satr[3, i] = Tool.nesbat(satr[1, i], (i + 1 < len) ? satr[1, i + 1] : satr[1, 0]);

            for (int i = 0; i < len; i++)       // سطر 4 : حاصل نسبت نظیره
                satr[4, i] = Tool.nesbat(satr[2, i], (i + 1 < len) ? satr[2, i + 1] : satr[2, 0]);

            for (int i = 0; i < len; i++)       // سطر 5 : تتمة اولی
                satr[5, i] = Tool.tateme_fun(satr[3, i], satr[4, i]);

            for (int i = 0; i < len; i++)       // سطر 6 : حاصل اول اساس و نظیره
                satr[6, i] = Tool.nesbat(satr[1, i], satr[2, i]);

            for (int i = 0; i < len; i++)       // سطر 7 : حاصل دوم اساس و نظیره
                satr[7, i] = satr[6, i].Substring(1) + satr[6, i].Substring(0, 1);                  //////////////////////////////////////////////

            for (int i = 0; i < len; i++)     // سطر 8 : تتمة ثانی
                satr[8, i] = Tool.tateme_fun(satr[6, i], satr[7, i]);

            for (int i = 0; i < len; i++)     // سطر 9 : تتمة التتمتین
                satr[9, i] = Tool.tateme_fun(satr[5, i], satr[8, i]);

            for (int i = 0; i < len; i++)       // سطر 10 : حاصل اعداد
                satr[10, i] = stentagh_makhsoos(satr[9, i]);

            for (int i = 0; i < len; i++)       // سطر 11 : قوا
                satr[11, i] = ghova(satr[10, i].Substring(i, 1), satr[11, i].Substring(i, 1));

            for (int i = 0; i < len; i++)       // سطر 12 : حاصل
                satr[12, i] = Stentagh.makani(Hesab.select(satr[11, i].Substring(i, 1) + satr[10, i].Substring(2, 1) + satr[11, i].Substring(i, 1) + harf_hasel_safheh, D_int.صغیر));

            return satr;
        }

        /// <summary>
        /// محاسبه اساس تا سطر دور
        /// </summary>
        /// <param name="text_1">اساس</param>
        /// <returns></returns>
        public static string[,] satr_dour(string[] text_1)
        {
            string[] text = new string[text_1.LongLength + 1];
            for (int i = 0; i < text_1.LongLength; i++)
                text[i] = text_1[i];
            text[text_1.LongLength] = text_1[0];

            string[,] line = new string[9, text_1.LongLength];

            for (int i = 0; i < text_1.LongLength; i++)
            {
                //  نظیره
                string a1 = text[i];
                string a2 = text[i + 1];
                string n1 = Asas_Dour.asas(a1, D_name.ابجد, false);
                string n2 = Asas_Dour.asas(a2, D_name.ابجد, false);
                line[0, i] = n1;

                line[1, i] = Tool.nesbat(a1, a2);      //  نسبت اساس
                line[2, i] = Tool.nesbat(n1, n2);        // نسبت نظیره
                line[3, i] = Tool.tateme_fun(line[1, i], line[2, i]);        // تتمة اولی
                line[4, i] = Tool.nesbat(a1, n1);     // حاصل اول اساس و نظیره
                line[5, i] = Tool.nesbat(a2, n2);     // حاصل دوم اساس و نظیره
                line[6, i] = Tool.tateme_fun(line[4, i], line[5, i]);        // تتمة ثانی
                line[7, i] = Tool.tateme_fun(line[3, i], line[6, i]);        // تتمة التتمتین
                line[8, i] = stentagh_makhsoos(line[7, i]);     //  حاصل اعداد
            }
            return line;
        }
        /// <summary>
        /// محاسبه سطر دور
        /// </summary>
        /// <param name="text_1">اساس</param>
        /// <returns></returns>
        public static string[] satr_dour_8(string[] text_1)
        {
            string[] line = new string[text_1.LongLength];
            string[,] x = satr_dour(text_1);

            for (int i = 0; i < text_1.LongLength; i++)
                line[i] = x[8, i];

            return line;
        }
        /// <summary>
        /// محاسبه اساس تا دور یک خانه
        /// </summary>
        /// <param name="a1">اساس اول</param>
        /// <param name="a2">اساس دوم</param>
        /// <returns></returns>
        public static string[] satr_dour_harf(string a1, string a2)
        {
            string[] line_x = new string[9];
            string[,] line = satr_dour(new string[2] { a1, a2 });
            for (int i = 0; i < 9; i++)
                line_x[i] = line[i, 0];
            return line_x;
        }

        /// <summary>
        /// محاسبه اساس تا سطر دور شاه نعمت الله ولی
        /// </summary>
        /// <param name="text_1">اساس</param>
        /// <returns></returns>
        public static string[,] satr_dour_shah(string[] text_1)
        {
            string[] text = new string[text_1.LongLength + 1];
            for (int i = 0; i < text_1.LongLength; i++)
                text[i] = text_1[i];
            text[text_1.LongLength] = text_1[0];

            string[,] line = new string[9, text_1.LongLength];

            for (int i = 0; i < text_1.LongLength; i++)
            {
                int[] satr = new int[9];

                //  اساس
                string a1 = text[i];
                string a2 = text[i + 1];
                //  نظیره
                string n1 = Asas_Dour.asas(a1, D_name.ابجد, false);
                string n2 = Asas_Dour.asas(a2, D_name.ابجد, false);
                line[0, i] = n1;

                satr[1] = Hesab.select(a1 + a2, D_int.افلاکی);      //  نسبت اساس
                satr[2] = Hesab.select(n1 + n2, D_int.افلاکی);       // نسبت نظیره
                satr[3] = Tool.nesbat(satr[1], satr[2]);      // تتمة اولی
                satr[4] = Hesab.select(a1 + n1, D_int.افلاکی);      // حاصل اول اساس و نظیره
                satr[5] = Hesab.select(a2 + n2, D_int.افلاکی);      // حاصل دوم اساس و نظیره
                satr[6] = Tool.nesbat(satr[4], satr[5]);     // تتمة ثانی
                satr[7] = Tool.tateme_shah(satr[3], satr[6]);        // تتمة التتمتین
                line[8, i] = Stentagh.makani(satr[7]);       // حاصل اعداد
                for (int gg = 1; gg < 8; gg++)
                    line[gg, i] = satr[gg].ToString();
            }
            return line;
        }

        /// <summary>
        /// حروف صفحه : تاریخ و ساعت و طالع و حرف قرآن
        /// </summary>
        /// <param name="tarikh">متن تاریخ</param>
        /// <param name="mah_shamsi">عدد ماه شمسی از صفر</param>
        /// <param name="sun_h">ساعت‌های الان، طلوع و غروب خورشید</param>
        /// <param name="sun_m">دقیقه‌های الان، طلوع و غروب خورشید</param>
        /// <param name="harf_quran">{چهار حرف قرآن</param>
        /// <returns></returns>
        public static string[] harf_safhe_shah(string tarikh, int year, int mah_shamsi, int[] sun_h, int[] sun_m, string harf_quran)
        {
            string[] payani = new string[5];

            //  حرف اول : تاریخ
            {
                int t = Hesab.select(tarikh) + year;
                payani[0] = Stentagh.makani(Hesab.rad_be_ahad(t));
            }

            //  حرف دوم : ساعت
            int h = 0;
            {
                int ss = ((sun_h[0] > sun_h[1] || (sun_h[0] == sun_h[1] && sun_m[0] > sun_m[1])) &&
                    (sun_h[0] < sun_h[2] || (sun_h[0] == sun_h[2] && sun_m[0] < sun_m[2]))) ? 1 : 2;   //  صبح یا شب بودن
                h = sun_h[0] - sun_h[ss];       //  فاصله ساعت
                int m = sun_m[0] - sun_m[ss];       //  فاصله دقیقه
                int[] tanzim = Saat_Code.saat_tanzim_int(new int[2] { h, m });        //  تصحیح ساعت
                h = tanzim[0];
                m = tanzim[1];
                if (m >= 10)    //  اگر دقیقه بیشتر مساوی 10 بود یک ساعت اضافه شود
                    h++;
                payani[1] = Stentagh.makani(h);
            }

            //   حرف سوم : طالع وقت
            {
                int tale = 0;
                int[,] tale_time = new int[12, 2] { { 1, 20 }, { 1, 30 }, { 2, 0 }, { 2, 20 }, { 2, 20 }, { 2, 30 }, { 2, 30 }, { 2, 20 }, { 2, 20 }, { 2, 0 }, { 1, 30 }, { 2, 20 } };
                int[] time = new int[2] { h, 0 };

                for (int mah = mah_shamsi; ;)
                {
                    time = new int[2] { time[0] - tale_time[mah, 0], time[1] - tale_time[mah, 1] };
                    time = Saat_Code.saat_tanzim_int(time, false);
                    if (time[0] > 0 || (time[0] == 0 && time[1] > 0))
                    {
                        mah = (mah + 1) % 12;
                        tale = mah;
                    }
                    else //if (time_2[0]<0)     //  منفی
                        break;
                }
                payani[2] = Stentagh.makani(Hesab.rad_be_ahad(Hesab.select(Data.borj_name((برج)tale))));
            }

            //  حرف چهارم از قرآن
            {
                int quran = Hesab.select(harf_quran, D_int.افلاکی);
                if (quran > 28)
                    quran = Hesab.rad_be_ahad(quran);
                payani[3] = Stentagh.makani(quran);
            }

            //  حرف حاصل
            {
                int p4 = Hesab.select(payani[0] + payani[1] + payani[2] + payani[3], D_int.افلاکی);
                payani[4] = Stentagh.makani(Hesab.rad_be_ahad(p4));
            }

            return payani;
        }


        //  قوا
        /// <summary>
        /// محاسبه قوا
        /// </summary>
        /// <param name="z_str">حرف حاصل اعداد یا دوریه</param>
        /// <param name="x_str">حرف اساس</param>
        /// <returns></returns>
        public static string ghova(string z_str, string x_str)
        {
            string payani = "";
            for (int g = 0; g < x_str.Length; g++)
            {
                string Z = z_str.Substring(g, 1);
                string X = x_str.Substring(g, 1);
                int x = Hesab.select(X, D_int.وضعی);
                int y = x + 14;
                int z = Hesab.select(Z, D_int.وضعی);
                //string Y = stentagh.makani(y, d);

                string[] dour = Asas_Dour.dour(Z);
                int c = 0;

                #region  روش محاسباتی
                {
                    bool edame = true;
                    for (int i = 0; i < 9 && edame; i++)
                    {
                        int tarh = 0;     //  عدد اسقاط
                        switch (i)
                        {
                            case 2: tarh = 4; break;
                            case 3: break;      //tarh = 6; break;
                            case 4: tarh = 7; break;
                            case 5: tarh = 9; break;
                            case 6: tarh = 12; break;
                            case 7: tarh = 28; break;
                            case 8: tarh = 30; break;
                        }

                        for (int j = 0; j < 4 || (i != 0 && j < 8); j++)
                        {
                            int sw = j;
                            if (i == 1)
                            {
                                sw = j / 2;
                                tarh = (j % 2 == 0) ? 1 : -1;       //  اول حرف قبل، دوم حرف بعد
                            }
                            switch (sw)
                            {
                                case 0: c = x + (z - tarh); break;
                                case 1: c = y + (z - tarh); break;
                                case 2: c = x - (z - tarh); break;
                                case 3: c = y - (z - tarh); break;
                            }

                            string str_tmp = Stentagh.makani(c);
                            if (str_tmp == dour[1] || str_tmp == dour[2] || str_tmp == dour[3] || str_tmp == dour[4])
                            {
                                payani += str_tmp;
                                edame = false;
                                break;
                            }
                        }
                    }
                }
                #endregion

                /*else if (lvl == 1)
                #region  جدول کتاب
                {
                    string ghova_str = "بببققققییییغغغججارججررککااااددششبددللششبببههمتتججمممتتججووثثننونننوددثزخخخخسسسسسههههححذذذعحععععوووطططضضضضففففزززییحظییظظصصححححککطاااکقققاطططللربببیررربیییممشجججکشششمکککننددددتتتتللللسسمهههمثثثهمممعععووووخخخخنننففسزززذذذذسسسسصصححححصضضضحعععققظطططفظظظففففرررییااصصاررصصششککککببببققققتترلللللجججرررثثثمممممددددششخختنننخننههتتهذذوسسسذذوووثثثضضززععخضضززضخخظظظففححذذحظذذذغغصصصصططططضضضضااظقققیظیییظظظ";
                    int xx = x % 14;
                    if (xx == 0) xx = 14;
                    payani += ghova_str.Substring((z - 1) * 14 + xx - 1, 1);
                }
                #endregion*/
            }
            return payani;
        }

        /// <summary>
        /// استنطاق مخصوص در جفر صدیقی متعارف
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <returns></returns>
        public static string stentagh_makhsoos(string text)
        {
            int x = Convert.ToInt32(text);
            string z = Stentagh.kabir(text, D_name.ابجد);
            if (z.Length != 1)
            {
                if (x > 28)
                    x = (x % 9) + (x % 10);
                z = Stentagh.makani(x, D_name.ابجد);
            }
            return z;
        }



        public static string مستحصله15سطری(string z, string[] x, string[] y, string[] حروف‌صفحه, int جایگاه‌درجدول)
        {
            string خروجی = "";
            int len = Convert.ToInt32(x.LongLength);
            int[,] بعد = new int[4, len];

            string[,,] مستحصله = new string[2, 8, len];

            int zAnsagh = Hesab.select(z, D_int.افلاکی, D_name.انسغ);


            // اجرای مستحصله برای هر حرف همطبع
            for (int i = 0; i < 4; i++)
            {
                // صحت
                bool[,,,] صحت = new bool[4, 2, len, 9];
                for (int k = 0; k < 4; k++)
                    for (int j = 0; j < len; j++)
                    {
                        صحت[i, 0, j, 0] = Tafkik.hamtabe(حروف‌صفحه[k], x[j]);
                        صحت[i, 1, j, 0] = Tafkik.hamtabe(حروف‌صفحه[k], y[j]);
                    }

                #region ابعاد
                for (int k = 0; k < 2; k++)
                {
                    for (int j = 0; j < len; j++)           // بعد جدولی
                        if (صحت[i, k, j, 0])
                            بعد[0, j] = Math.Abs(جایگاه‌درجدول - j);

                    for (int j = 0; j < len; j++)           // بعد ابجدی
                        if (صحت[i, k, j, 0])
                        {
                            بعد[1, j] = Math.Abs(Hesab.select(z, D_int.افلاکی) - Hesab.select(z, D_int.افلاکی));
                            if (بعد[1, j] > 7)
                                صحت[i, k, j, 0] = false;
                        }

                    for (int j = 0; j < len; j++)           // کسر بعدین
                        if (صحت[i, k, j, 0])
                            بعد[2, j] = Math.Abs(بعد[0, j] - بعد[1, j]);

                    for (int j = 0; j < len; j++)           // جمع بعدین
                        if (صحت[i, k, j, 0])
                            بعد[3, j] = بعد[0, j] + بعد[1, j];
                }
                #endregion

                // استنطاق و حصول مستحصله
                for (int k = 0; k < 2; k++)
                    for (int j = 0; j < len; j++)
                        if (صحت[i, k, j, 0])
                            for (int h = 0; h < 4; h++)
                            {
                                int hh = h * 2;
                                مستحصله[k, hh, j] = Stentagh.makani(بعد[h, j] + zAnsagh - 1, D_name.انسغ);       // با نفس حرف
                                مستحصله[k, hh + 1, j] = Stentagh.makani(بعد[h, j] + zAnsagh, D_name.انسغ);       // بدون نفس حرف
                            }

                #region امتحان //
                for (int k = 0; k < 2; k++)
                {
                    for (int j = 0; j < len; j++)
                    {
                        if (صحت[i, k, j, 0])
                        {
                            for (int h = 0; h < 8; h++)
                            {
                                int بعدانسغی;
                                if (k == 0)
                                    بعدانسغی = Math.Abs(Hesab.select(x[j], D_int.افلاکی, D_name.انسغ) - Hesab.select(حروف‌صفحه[i], D_int.افلاکی, D_name.انسغ));
                                else
                                    بعدانسغی = Math.Abs(Hesab.select(y[j], D_int.افلاکی, D_name.انسغ) - Hesab.select(حروف‌صفحه[i], D_int.افلاکی, D_name.انسغ));

                                {
                                    // توالی
                                    if (مستحصله[k, h, j] == Stentagh.makani(zAnsagh + بعدانسغی - 1, D_name.انسغ)) break;
                                    else
                                    {
                                        if (مستحصله[k, h, j] == Stentagh.makani(zAnsagh - Convert.ToInt32(Math.Abs(بعد[1, j] - بعدانسغی)) + 1, D_name.انسغ)) break;
                                        if (مستحصله[k, h, j] == Stentagh.makani(zAnsagh - بعد[1, j] + بعدانسغی + 1, D_name.انسغ)) break;
                                    }

                                    // خلاف توالی
                                    if (مستحصله[k, h, j] == Stentagh.makani(zAnsagh - بعدانسغی + 1, D_name.انسغ)) break;
                                    else
                                    {
                                        if (مستحصله[k, h, j] == Stentagh.makani(zAnsagh + Convert.ToInt32(Math.Abs(بعد[1, j] - بعدانسغی)) - 1, D_name.انسغ)) break;
                                        if (مستحصله[k, h, j] == Stentagh.makani(zAnsagh + بعد[1, j] + بعدانسغی - 1, D_name.انسغ)) break;
                                    }

                                    صحت[i, k, j, h + 1] = false;
                                }
                            }
                        }
                    }
                }
                #endregion

                // خروجی
                for (int k = 0; k < 2; k++)
                    for (int j = 0; j < len; j++)
                        if (صحت[i, k, j, 0])
                            for (int h = 0; h < 8; h++)
                                if (صحت[i, k, j, h + 1])
                                    خروجی += مستحصله[k, h, j];
            }

            خروجی = Bast.hazfmokarar_103(خروجی);

            return خروجی;
        }
    }

    /// <summary>
    /// جفر جامع
    /// </summary>
    public class Jafr_Jame
    {
        public static string[] jafr_sadegh_1(string soal_text, string tarikh_text, int javab)
        {
            string payani = "";
            soal_text = Harf_Change.alefbae(soal_text);
            tarikh_text = Harf_Change.alefbae(tarikh_text);

            int[] madakhal_soal = new int[5]
            {
                Hesab.select(soal_text,D_int.kabir,D_name.ابجد),
                Hesab.select(soal_text,D_int.افلاکی,D_name.ابجد),
               0,
                Hesab.tedad_harf(soal_text),
                Hesab.noghte(soal_text),
            };
            madakhal_soal[2] = Hesab.tarh_rad_ahad(madakhal_soal[0]);

            int[] madakhal_tarikh = new int[5]
            {
                Hesab.select(tarikh_text,D_int.kabir,D_name.ابجد),
                Hesab.select(tarikh_text,D_int.افلاکی,D_name.ابجد),
                0,
                Hesab.tedad_harf(tarikh_text),
                Hesab.noghte(tarikh_text),
            };
            madakhal_tarikh[2] = Hesab.tarh_rad_ahad(madakhal_tarikh[0]);

            string st_soal = "";
            string st_tarikh = "";
            for (int i = 0; i < 5; i++)
            {
                st_soal += Stentagh.kabir(madakhal_soal[i].ToString(), D_name.ابجد);
                st_tarikh += Stentagh.kabir(madakhal_tarikh[i].ToString(), D_name.ابجد);
            }

            switch (javab)
            {
                case 0:     //  معکوس تاریخ + مزج ملفوظی
                    {
                        string mazj_masror__soal = Taksir.mazj_masroori_malfoozi(st_soal);
                        payani = Harf_Change.space(mazj_masror__soal + Bast.maakoos_102(st_tarikh));
                    }
                    break;


                case 1:
                    {
                        string hazf = "";
                        string tekrari = "";
                        string d = Data.d();
                        string baghi_dayere = "";
                        for (int i = 0; i < st_soal.Length; i++)
                        {   //  بررسی رشته سوال
                            string h = st_soal.Substring(i, 1);
                            if (!hazf.Contains(h))      //  اگر داخل قسمت حذف شده نبود اضافه شود
                                hazf += h;
                            else if (!tekrari.Contains(h))      //  اگر داخل تکراری ها نبود اضافه شود
                                tekrari += h;
                        }
                        for (int i = 0; i < d.Length; i++)
                        {
                            string h = d.Substring(i, 1);
                            if (!hazf.Contains(h))      //  اگر حرف دایره داخل بخش حذف شده نبود بیاید در رشته باقی مانده دایره
                                baghi_dayere += h;
                        }
                    }
                    break;
            }





            return Taksir.zomam(payani, true, true, true);

        }



    }

    public class Mohandesi_Book
    {
        public class ravesh_1_i
        {
            public static string[] ravesh_01(string text, bool hazf)
            {
                List<string> payani = new List<string>();

                payani.Add(text);       //  سوال
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                payani.Add(Bast.kosoorat(payani.Last(), 10));       //  بسط کسورات
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));        //  حذف مکرر
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 1; i < tmp.LongLength; i++)
                    payani.Add(tmp[i]);

                return payani.ToArray();
            }

            public static string[] ravesh_02(string text, bool hazf)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 1; i < tmp.LongLength; i++)
                    payani.Add(tmp[i]);

                return payani.ToArray();
            }

            public static string[] ravesh_03(string text, int tarh_laght, bool hazf)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                payani.Add(Taksir.laght(payani.Last(), tarh_laght - 1, tarh_laght, 1, 0));       //  لقط
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 1; i < tmp.LongLength; i++)
                    payani.Add(tmp[i]);

                return payani.ToArray();
            }

            public static string[] ravesh_04(string text, bool hazf)
            {
                List<string> payani = new List<string>();

                string str = "";
                payani.Add(text);       //  سوال
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(text));     //  حذف مکرر
                for (int i = 0; i < payani.Last().Length; i++)
                    str += Stentagh.makani(Hesab.select(payani.Last().Substring(i, 1), D_int.وضعی) + i + 1);        //  استنطاق مکانی جمع عدد وضعی با جدولی
                payani.AddRange(Taksir.zomam(str, true, true, false));       //  مؤخر و صدر

                return payani.ToArray();
            }

            public static string[] ravesh_05(string text, bool hazf)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                payani.Add(Harf_Change.alefbae(Bast.malfoozi_100(payani.Last())));     //  بسط ملفوظی
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 1; i < tmp.LongLength; i++)
                    payani.Add(tmp[i]);

                return payani.ToArray();
            }

            public static string[] ravesh_06(string text, bool hazf)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                string[] mal = Tafkik.malfoozi(payani.Last());      //  تفکیک ملفوظی
                string[] mal_x = new string[] { mal[2], mal[1], mal[0] };
                payani.AddRange(mal_x);

                payani.Add(Taksir.emtezaj(mal_x, null, false));     //  امتزاج
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 1; i < tmp.LongLength; i++)
                    payani.Add(tmp[i]);

                return payani.ToArray();
            }

            public static string[] ravesh_07(string text, bool hazf)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 0; i < tmp.LongLength; i++)        //  چون باید تعدیل ایقغی هم باشد از صفر شروع میشود
                {
                    string[] jabeja = Asas_Dour.jabejai(tmp[i]);       //  جابجایی برای گرفتن تعدیل ایقغی
                    if (i != 0)
                        payani.Add(tmp[i]);
                    payani.Add(jabeja[2]);
                    payani.Add(jabeja[3]);
                }

                return payani.ToArray();
            }

            public static string[] ravesh_08(string text, bool hazf)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 0; i < tmp.LongLength; i++)        //  چون باید تواخی هم باشد از صفر شروع میشود
                {
                    string[] tavakhi = Asas_Dour.tavakhi_talafoz(tmp[i]);       //  تواخی و تلفظ
                    if (i != 0)
                        payani.Add(tmp[i]);
                    payani.Add(tavakhi[0]);
                    payani.Add(tavakhi[1]);
                }

                return payani.ToArray();
            }

            public static string[] ravesh_09(string text, bool hazf)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 0; i < tmp.LongLength; i++)        //  چون باید ترقی و تنزل هم باشد از صفر شروع میشود
                {
                    string[] jabeja = Asas_Dour.jabejai(tmp[i]);       //  جباجایی برای گرفتن ترقی و تنزل
                    if (i != 0)
                        payani.Add(tmp[i]);
                    payani.Add(jabeja[0]);
                    payani.Add(jabeja[1]);
                }

                return payani.ToArray();
            }

            public static string[] ravesh_10(string text, int tarh_laght, bool hazf)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                string[] mal = Tafkik.malfoozi(payani.Last());      //  تفکیک ملفوظی
                string[] mal_x = new string[] { mal[2], mal[1], mal[0] };
                payani.AddRange(mal_x);

                for (int i = 0; i < mal_x.LongLength; i++)        //  لقط تفکیک بنابر طرح
                {
                    mal_x[i] = Taksir.laght(mal_x[i], 0, tarh_laght, 1, اتصال_لقط.منفصل);//////////////////////////////////////////////////
                    payani.Add(mal_x[i]);
                }
                payani.Add(Taksir.emtezaj(mal_x, null, false));     //  امتزاج
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 1; i < tmp.LongLength; i++)
                    payani.Add(tmp[i]);

                return payani.ToArray();
            }

            public static string[] ravesh_11(string text, bool hazf)
            {
                List<string> payani = new List<string>();
                int[] abjad = new int[3];
                abjad[0] = Hesab.select(text);      //  ابجد کبیر
                abjad[1] = Hesab.rad_be_ahad(abjad[0]);     //  رد به آحاد
                abjad[2] = Hesab.rad_be_ahad(abjad[1]);     //  رد به آحاد
                payani.Add("مداخل سه‌گانه : " + abjad[0] + " : " + abjad[1] + " : " + abjad[2]);
                payani.Add(String.Join("", Stentagh.kabir(abjad.Select(a => a.ToString()).ToArray(), D_name.ابجد, 0)));        //  استنطاق کبیر موارد قبل در کنار هم
                payani.Add(text);       //  سوال
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر سوال
                payani.Add(payani[1] + payani.Last());      //  جمع استنطاق و سوال
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 1; i < tmp.LongLength; i++)
                    payani.Add(tmp[i]);

                return payani.ToArray();
            }

            public static string[] ravesh_12(string text, int tarh_laght, bool hazf)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                string[] num_farsi = new string[payani.Last().Length];
                for (int i = 0; i < payani.Last().Length; i++)
                    num_farsi[i] = Harf_Change.alefbae(Adad.عددفارسی(
                          Hesab.select(payani.Last().Substring(i, 1)).ToString()));

                payani.Add(string.Join("", num_farsi));      //  بسط عددی فارسی از ابجد کبیر
                if (hazf)
                    payani.Add(Bast.hazfmokarar_103(payani.Last()));     //  حذف مکرر
                payani.Add(payani.Last() + payani[hazf ? 1 : 0]);       //  سوال و بسط ملفوظی با هم
                string[] mal = Tafkik.malfoozi(payani.Last());      //  تفکیک ملفوظی
                string[] mal_x = new string[] { mal[2], mal[1], mal[0] };
                payani.AddRange(mal_x);

                for (int i = 0; i < mal_x.LongLength; i++)        //  لقط تفکیک بنابر طرح
                {
                    mal_x[i] = Taksir.laght(mal_x[i], 0, tarh_laght, 1, اتصال_لقط.منفصل);
                    payani.Add(mal_x[i]);
                }
                payani.Add(Taksir.emtezaj(mal_x, null, false));     //  امتزاج
                string[] tmp = Taksir.zomam(payani.Last(), true, true, false);      //  تکسیر مؤخر و صدر
                for (int i = 1; i < tmp.LongLength; i++)
                    payani.Add(tmp[i]);

                return payani.ToArray();
            }

            public static string[] ravesh_13(string text, bool hazf, int[] tarh)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                string[] mal = Tafkik.malfoozi(payani.Last());      //  تفکیک ملفوظی
                string[] mal_x = new string[] { mal[2], mal[1], mal[0] };
                payani.AddRange(mal_x);
                payani.Add(Taksir.emtezaj(mal_x, null, false));     //  امتزاج
                payani.Add(Taksir.zomam_once(payani.Last(), false, true, false));       //  غریزه

                //  شمارش چندباره  بنابه اعداد طرح
                string tmp_str = payani.Last();
                int int_tmp = 0;
                for (int k = 0; k < 4; k++)
                {
                    payani.Add("");
                    for (int i = 0; i < 4 - k; i++)
                    {
                        int tarh_tmp = tarh[i] - 1 + int_tmp;
                        payani[(int)payani.LongCount() - 1] += Code.SubStr(tmp_str, tarh_tmp, 1, true);
                        tmp_str = Code.Remove_Str(tmp_str, tarh_tmp, 1, true);
                        int_tmp += tarh[i] - 1;
                    }
                    if (k + 1 == tarh.LongLength)
                        payani.Add(tmp_str);
                }

                //  کنار هم گذاشتن لقطها
                payani.Add("");
                int laght_int = (int)payani.LongCount() - 1;
                for (int k = 5; k > 0; k--)
                    payani[laght_int] += payani[laght_int - k];

                return payani.ToArray();
            }
        }

        public class ravesh_1_ii
        {
            public static string[] ravesh_1(string text)
            {
                List<string> payani = new List<string>();
                string str = "";
                payani.Add(text);       //  سوال
                for (int i = 0; i < text.Length; i++)       //for (int i = 1; i < text.Length + 1; i++)
                    str += Adad.عددفارسی(Hesab.select(payani.Last().Substring(i, 1)).ToString());     //  بسط عددی عدد کبیر
                payani.Add(Harf_Change.space(str, false));
                payani.Add(Bast.hazfmokarar_103(payani.Last()));       //  حذف مکرر

                return payani.ToArray();
            }

            public static string[] ravesh_2(string text)
            {
                List<string> payani = new List<string>();

                payani.Add(text);
                payani.Add(Taksir.laght(text, 3, 4, 1, اتصال_لقط.منفصل));       //  لقط 4 از 4
                payani.Add(Harf_Change.space(Bast.malfoozi_100(payani.Last()), false));      //  بسط ملفوظی
                payani.Add(Taksir.zomam_once(payani.Last(), true, true, false));        //  مؤخر و صدر
                payani.Add(Asas_Dour.asas(payani.Last(), D_name.ابجد));        //  نظیره ابجدی

                int len_5 = payani.Last().Length / 5 + Convert.ToInt32(payani.Last().Length % 5 > 0);       //  تعداد دسته‌ها

                //  دسته های 5تایی اساس و نظیره
                string[,] str_1 = new string[2, len_5];
                for (int i = 0; i < len_5; i++)
                {
                    str_1[0, i] = Code.SubStr(payani[payani.Count - 2], i * 5, 5);
                    str_1[1, i] = Code.SubStr(payani.Last(), i * 5, 5);
                }

                //  برداشتن حروف زوج اساس و فرد نظیره
                string[] bardasht = new string[len_5];
                for (int i = 0; i < len_5; i++)
                    bardasht[i] = Code.SubStr(str_1[0, i], 1, 1) + Code.SubStr(str_1[0, i], 3, 1) +        //  حروف 2 و 4 اساس
                        Code.SubStr(str_1[1, i], 0, 1) + Code.SubStr(str_1[1, i], 2, 1) + Code.SubStr(str_1[1, i], 4, 1);       //  حروف 1، 3 و 5 نظیره
                payani.Add(string.Join("", bardasht));

                //  جابجایی دسته ها
                string[] jabeja_str = new string[len_5];
                for (int i = 0; i < len_5; i++)
                {
                    jabeja_str[i] = i % 2 == 0 ?
                        bardasht[i + 1 < len_5 ? i + 1 : i] :
                        bardasht[i - 1];
                }
                payani.Add(string.Join("", jabeja_str));

                //  تکسیر خاص
                string[] taksir_str = new string[len_5];
                for (int i = 0; i < len_5; i++)
                    taksir_str[i] = (i % 2 != 0) ?
                        Code.SubStr(jabeja_str[i], 4, 1) + Code.SubStr(jabeja_str[i], 0, 4) :
                        Bast.maakoos_102(Code.SubStr(jabeja_str[i], 1) + Code.SubStr(jabeja_str[i], 0, 1));
                //  دور وسیط
                string[] dour_str = Asas_Dour.dour(string.Join("", taksir_str));
                for (int i = 0; i <= 5; i++)
                    payani.Add(dour_str[i]);

                return payani.ToArray();
            }

            public static string[] ravesh_3(string text)
            {
                List<string> payani = new List<string>();
                int[] mizan = new int[4];
                int rad_be_ahad = Hesab.rad_be_ahad(Hesab.select(text));
                List<int> int_list = new List<int>();

                payani.Add(text);       //  سوال
                payani.Add(Bast.hazfmokarar_103(payani.Last()));       //  حذف مکرر

                {
                    //  حذف مکرر و جمع اعداد و استنطاق آن
                    string str = "";
                    for (int i = 0; i < payani[0].Length; i++)
                    {
                        string h = payani[0].Substring(i, 1);
                        if (!str.Contains(h))
                        {
                            str += h;
                            int_list.Add(Hesab.select(h, D_int.وضعی) + i + 1);
                        }
                        else
                            int_list[payani.Last().IndexOf(h)] += i + 1;        //  جستجوی جای حرفی که قبلا استفاده شده در بخش آرایه
                    }
                    str = "";
                    for (int i = 0; i < payani.Last().Length; i++)       //  استنطاق
                        str += Stentagh.makani(int_list[i]);
                    payani.Add(str);
                }

                //  تفکیک عناصر و میزان آن‌ها و استنطاق
                {
                    string str = "";
                    string[] onsor = Tafkik.onsor(payani.Last());
                    for (int i = 0; i < 4; i++)
                        mizan[i] = Math_Old.tarh_esghat(Hesab.select(onsor[i]), 28);
                    for (int i = 0; i < payani.Last().Length; i++)       //  جمع میزان و عدد وضعی
                        str += Stentagh.makani(int_list[i] + mizan[(int)Tafkik.tabe(payani.Last().Substring(i, 1))]);
                    payani.Add(str);
                }

                //  استنطاق مکانی این عدد :‌جمع عدد جدولی با عدد مکانی قبل ضرب در دو با طرح 28
                {
                    string str = "";
                    for (int i = 0; i < payani.Last().Length; i++)
                        str += Stentagh.makani(Math_Old.tarh_esghat(
                            Hesab.select(payani.Last().Substring(i, 1), D_int.وضعی) * 2, 29) + i + 1);
                    payani.Add(str);
                }

                payani.Add(Taksir.laght(payani.Last(), rad_be_ahad - 1, rad_be_ahad, 1, 0));        //  لقط بنابه عدد رد به آحاد
                payani.Add(Asas_Dour.asas(payani.Last()));      //  نظیره
                string[] z = Asas_Dour.jabejai(payani.Last());      //  همردیف ایقغی
                payani.Add(z[2]);
                payani.Add(z[3]);

                return payani.ToArray();
            }

            public static string[] ravesh_4(string text) { return Jafr_Ravesh.sodasi_jafr(text); }

            public static string[] ravesh_5(string text)
            {
                List<string> payani = new List<string>();
                payani.Add(text);
                payani.Add(Harf_Change.space(
                    Stentagh.kabir(Hesab.select(text).ToString()) +
                    Stentagh.kabir(Hesab.tedad_harf(text).ToString()) +
                    Stentagh.kabir(Hesab.noghte(text).ToString())
                    , false));      //  مداخل سه گانه
                payani.Add(Harf_Change.space(Bast.malfoozi_100(payani.Last()), false));       //  بسط ملفوظی
                payani.Add(Asas_Dour.asas(payani.Last(), D_name.ابجد));      //  نظیره ابجدی
                payani.Add(Asas_Dour.aamal_riazi(payani.Last(), 4,عمل_ریاضی.جمع));       //  ترقی 4 خانه

                {
                    string new_str = "";
                    int[,] num_kabir_varoon = new int[text.Length, 2];
                    for (int i = 0; i < payani.Last().Length; i++)
                    {
                        int new_int = Math_Old.gerd_kabir(Hesab.select(payani[3].Substring(i, 1) + payani[4].Substring(i, 1)) /
                            Math_Old.tarh_esghat((payani.Last().Length - i), 10));        //  جمع کبیر نظیره و ترقی تقسیم بر عدد وارون با طرح 10
                        new_str += Stentagh.kabir(new_int.ToString())[0];
                    }
                    payani.Add(new_str);        //  استنطاق کبیر نزدیکترین عدد
                }
                payani.AddRange(Asas_Dour.dour(Taksir.zomam_once(payani.Last(), true, true, false), 1));        //  تکسیر مؤخر و صد و دور وسیط

                return payani.ToArray();
            }

            public static string[] ravesh_6(string text)
            {
                List<string> payani = new List<string>();
                payani.Add(text);
                payani.Add(Harf_Change.space(
                    Stentagh.kabir(Hesab.select(text).ToString()) +
                    Stentagh.kabir(Hesab.tedad_harf(text).ToString()) +
                    Stentagh.kabir(Hesab.noghte(text).ToString())
                    , false));      //  مداخل سه گانه
                payani.Add(Harf_Change.space(Bast.malfoozi_100(payani.Last()), false));       //  بسط ملفوظی
                {
                    string str = "";
                    for (int i = 0; i < payani.Last().Length; i++)
                        //  مکانی هر حرف و حرف قبل و طرح 28 و جمع با عدد جدولی معکوس
                        str += Stentagh.makani(
                            Math_Old.tarh_esghat(
                                Hesab.select(
                                    payani.Last().Substring(i, 1) +
                                    payani.Last().Substring((i > 0) ? i - 1 : payani.Last().Length - 1, 1)
                                    , D_int.وضعی), 28) +
                                payani.Last().Length - i);
                    payani.Add(str);
                }
                payani.Add(Taksir.zomam_once(payani.Last(), true, true, false));        //  تکسیر مؤخر و صدر
                {
                    string str = "";        //  حرف اول خودش و حرف دوم نظیره تا آخر
                    for (int i = 0; i < payani.Last().Length; i++)
                        str += i % 2 == 0 ? payani.Last().Substring(i, 1) :
                            Asas_Dour.asas(payani.Last().Substring(i, 1));
                    payani.AddRange(Asas_Dour.dour(str, 1));     //  دور وسیط نظیره خاص
                }

                return payani.ToArray();
            }

            public static string[] ravesh_7(string text)
            {
                List<string> payani = new List<string>();
                payani.Add(text);
                payani.Add(Harf_Change.space(
                    Stentagh.kabir(Hesab.select(text).ToString()) +
                    Stentagh.kabir(Hesab.tedad_harf(text).ToString()) +
                    Stentagh.kabir(Hesab.noghte(text).ToString())
                    , false));      //  مداخل سه گانه
                payani.Add(Harf_Change.space(Bast.malfoozi_100(payani.Last()), false));       //  بسط ملفوظی
                payani.Add(Asas_Dour.asas(payani.Last()));      //  نظیره
                {
                    List<int> nesbat_bast = Tool.nesbat(payani[2]);     //  نسبت بین الحروف بسط ملفوظی
                    List<int> nesbat_nazire = Tool.nesbat(payani[3]);     //  نسبت بین الحروف نظیره

                    List<int> nesbat_menha = new List<int>();
                    for (int i = 0; i < nesbat_bast.Count; i++)
                        nesbat_menha.Add(nesbat_bast[i] == nesbat_nazire[i] ? nesbat_bast[i] : Math.Abs(nesbat_bast[i] - nesbat_nazire[i]));       //  منهای دو نسبت قبل

                    List<int> nesbat_jame = Math_Old.jame_aljame(nesbat_menha);      //  جمع الجمع منهای قبل

                    List<int> nesbat_nesbat = new List<int>();     //  نسبت دو نسبت
                    for (int i = 0; i < nesbat_bast.Count; i++)
                        nesbat_nesbat.Add(Tool.nesbat(nesbat_bast[i], nesbat_nazire[i]));

                    List<int> jame_rad = new List<int>();       //  جمع دو مرحله قبل
                    for (int i = 0; i < nesbat_bast.Count; i++)
                        jame_rad.Add(Hesab.rad_be_ahad(nesbat_jame[i] + nesbat_nesbat[i]));

                    string str = "";
                    for (int i = 0; i < nesbat_bast.Count; i++)
                        str += Stentagh.makani(jame_rad[i]);        //  استنطاق مکانی
                    payani.Add(str);
                }
                payani.AddRange(Asas_Dour.dour(Taksir.zomam_once(payani.Last(), true, true, false), 1));        //  تکسیر مؤخر و صد و دور وسیط

                return payani.ToArray();
            }

        }

        public class ravesh_1_iii
        {
            public static string[] ravesh_1(string text)
            {
                List<string> payani = new List<string>();
                payani.Add(text);       //  سوال
                payani.Add(Taksir.zomam_once(payani.Last(), false, true, false));       //  غریزه
                payani.Add(Taksir.zomam_once(payani.Last(), false, true, false));        //  غریزه
                payani.Add(Asas_Dour.aamal_riazi(payani[2], 2,عمل_ریاضی.جمع));       //  مطلوب
                payani.Add(Asas_Dour.aamal_riazi(payani[2], 2,عمل_ریاضی.تفریق));       //  طالب
                payani.Add(Asas_Dour.aamal_riazi(payani[2], 6,عمل_ریاضی.تفریق));       //  طالب طالب طالب
                payani.Add(Asas_Dour.asas(payani[2],D_name.اجهز2));      //  نظیره اجهزی
                payani.Add(Asas_Dour.asas(payani[4],D_name.اجهز2));       //  نظیره اجهزی طالب

                return payani.ToArray();
            }

            public static string[] ravesh_2(string text, string date, int saat, string kokab, string quran_harf)
            {
                List<string> payani = new List<string>();
                int mizan_aflak;
                payani.Add(text);       //  سوال
                payani.Add(Stentagh.madakhel_arbae_one_line(payani.Last()));        //  استنطاق مداخل اربعه 
                payani.Add(Harf_Change.space( Bast.malfoozi_100(payani.Last()),false));       //  بسط ملفوظی
                payani.Add(Asas_Dour.asas(payani.Last()));      //  نظیره
                int len = payani.Last().Length;

                //  سطر حروف صفحه
                {
                    string[] harf = new string[4];      //  چهار حرف صفحه
                    harf[0] = Stentagh.makani(Hesab.rad_be_ahad(Hesab.select(date)));
                    harf[1] = Stentagh.makani(saat);
                    harf[2] = Stentagh.makani(Hesab.rad_be_ahad(Hesab.select(kokab)));
                    harf[3] = Stentagh.makani(Hesab.rad_be_ahad(Hesab.select(quran_harf)));

                    mizan_aflak = Hesab.select(string.Join("", harf), D_int.افلاکی);        //  حساب افلاکی حروف میزان یا همین 4 حرف

                    //  دو بار حروف صفحه معمولی و بعد دو بار حروف صفحه معکوس تا به اندازه حروف نظیره برسد
                    string str = "";
                    for (int i = 0; i < len; i++)
                        str += harf[(i / 8) % 2 == 0 ?
                            i % 4 :
                            3 - (i % 4)
                            ];
                    payani.Add(str);
                }

                int[] satr_1 = new int[len];
                for (int i = 0; i < len; i++)
                {
                    //  جمع بسط ملفوظی و نظیره و حروف صفحه
                    satr_1[i] = Hesab.select(
                        payani[2].Substring(i, 1) +
                        payani[3].Substring(i, 1) +
                        payani[4].Substring(i, 1),
                        D_int.وضعی);
                }

                int[] satr_2 = (int[])satr_1.Clone();       //  سطر پیوند اختصاصی : 4 دسته کردن سطر و جمع هر خانه با خانه قبل در هر دسته و در پایان جمع با میزان افلاکی
                for (int i = 0, k = 0; i < len; i++)
                {
                    k = i % 4;
                    if (k == 0)
                        for (int g = 0; g < i; g++)
                            satr_2[i] += satr_1[g];
                    else
                        for (int g = 0; g < k; g++)
                            satr_2[i] += satr_2[i - g - 1];

                    if (i / 4 == (len - 1) / 4)
                        satr_2[i] += mizan_aflak;
                }

                payani.Add(string.Join("", Stentagh.makani(satr_2)));        //  استنطاق سطر قبل
                payani.AddRange(Asas_Dour.dour(Taksir.zomam_once(payani.Last(), true, true, false)));        //  تکسیر مؤخر و صدر و دور کبیر

                return payani.ToArray();
            }

            public static string[] ravesh_3(string text, string date)
            {
                List<string> payani = new List<string>();

                payani.Add(Stentagh.madakhel_arbae_one_line(text));        //  استنطاق مداخل اربعه سوال
                payani.Add(Taksir.laght(Bast.hazfmokarar_103(text), 0, 4, 1, اتصال_لقط.منفصل));        //  حذف مکرر و لقط 4

                payani.Add(Stentagh.madakhel_arbae_one_line(date));        //  استنطاق مداخل اربعه تاریخ
                payani.Add(Taksir.laght(Bast.hazfmokarar_103(date), 0, 4, 1, اتصال_لقط.منفصل));        //  حذف مکرر و لقط 4

                payani.Add(Taksir.emtezaj(
                    new string[2] { payani[0] + payani[1],
                    payani[2] + payani[3] },
                    null, false));      //  امتزاج : سطر اول

                int len = payani.Last().Length;     //  طول سطر
                int[] satr_1 = new int[len];        //  ابجد وضعی هر حرف
                for (int i = 0; i < len; i++)
                    satr_1[i] = Hesab.select(payani.Last().Substring(i, 1), D_int.وضعی);

                int[] satr_2 = new int[len];        //  ضرب هر خانه در خانه بعد
                for (int i = 0; i < len; i++)
                    satr_2[i] = satr_1[i] * satr_1[
                        (i +1 != len) ? i + 1 : 0];

                int[] satr_3 = new int[len];
                for (int i = 0; i < len; i++)
                    satr_3[i] = satr_2[i] / 28 + satr_2[i] % 28;

                    int[] satr_4 = new int[len];
                for (int i = 0; i < len; i++)
                    satr_4[i] = satr_3[i] +                             //  خانه بالا
                        (i != 0 ? satr_4[i - 1] : 0);      //  خانه قبل و هم سطر

                int[] satr_5 = new int[len];
                for (int i = 0; i < len; i++)
                    satr_5[i] = Math_Old.tarh_esghat(satr_4[i]+len - i, 28);       //  عدد جدولی معکوس و اسقاط 28

                //  سطر طبایع
                int[] onsor = Hesab.select(Tafkik.onsor(payani.Last()));
                for (int i = 0; i < onsor.LongLength; i++)
                    onsor[i] = Hesab.tarh_rad_ahad(onsor[i], 28);      //  استانداردسازی ارقام
                int[] satr_6 = new int[len];
                for (int i = 0; i < len; i++)
                    satr_6[i] =(int) Tafkik.tabe(payani.Last().Substring(i, 1));

                string str = "";
                for (int i = 0; i < len; i++)
                    str += Stentagh.makani(satr_5[i] + onsor[ satr_6[i]]);
                payani.Add(str);        //  استنطاق مکانی جمع دو سطر قبل

                payani.Add(Taksir.zomam_once(payani.Last(), true, true, false));        //  تکسیر مؤخر و صدر
                payani.AddRange(Asas_Dour.dour(Asas_Dour.asas(payani.Last())));        //  نظیره و دور کبیر

                return payani.ToArray();
            }

            public static string[] ravesh_4(string text, string date)
            {
                List<string> payani = new List<string>();

                string[] jadval = new string[16];       //  جدول
                string text_date = text + date;
                for (int i = 0; i < text_date.Length; i++)
                    jadval[i % 16] += text_date.Substring(i, 1);

                //  مقادیر ابجد کل و سطر و ستون
                int kol = Hesab.select(text + date);
                int[] satr = new int[4];
                int[] sotoon = new int[4];
                for (int i = 0; i < 16; i++)
                {
                    int tmp = Hesab.select(jadval[i]);
                    sotoon[i % 4] += tmp;
                    satr[i / 4] += tmp;
                }

                string str = "";
                for (int i = 0; i < 16; i++)
                    str += Stentagh.makani(Hesab.tarh_rad_ahad(
                        kol +                   //  ابجد کامل
                        16 - i +                //  عدد جدولی معکوس
                        sotoon[i % 4] +     //  ستون
                        satr[i / 4]             //  سطر
                        , 28));                 //  عدد استاندارد سازی
                payani.Add(str);

                string[] jabeja = Asas_Dour.jabejai(payani.Last());
                payani.Add(
                    jabeja[3].Substring(0, 4) +     //  مساوات
                    jabeja[1].Substring(4, 4) +     //  تنزل
                    jabeja[2].Substring(8, 4) +     //  ترفع
                    jabeja[0].Substring(12, 4)      //  ترقی
                    );

                str = "";
                for (int i = 0; i < 16; i++)
                    str += payani.Last().Substring((i / 4) + 4 * (3 - i % 4), 1);

                payani.AddRange(Asas_Dour.dour(str));        //  برداشت حروف اول از انتها سپس حروف دوم الی اخر + دور کبیر

                return payani.ToArray();
            }

            public static string[] ravesh_5(string text, int k)
            {
                List<string> payani = new List<string>();
                k--;        //  چون در فرم از یک تا 5 است و باید از صفر تا 4 باشد

                payani.Add(text);       //  سوال
                payani.Add(Stentagh.madakhel_arbae_one_line(payani.Last()));        //  استنطاق مداخل اربعه سوال
                payani.Add(Bast.hazfmokarar_103(text));        //  حذف مکرر
                payani.Add(Taksir.laght(payani[1] + payani[2], 0, 4, 1,0));        //  لقط 4 استنطاق

                int len = payani.Last().Length;
                int[] satr_1 = new int[len];
                for (int i = 0; i < len; i++)
                    satr_1[i] = Hesab.select(payani.Last().Substring(i, 1), D_int.وضعی) +       //  ابجد وضعی
                        len - i;        //  عدد جدولی معکوس

                string str = "";
                for (int i = 0; i < len; i++)
                    str += Stentagh.makani(satr_1[i]);
                payani.Add(str);        //  استنطاق مکانی

                payani.Add(Asas_Dour.asas(payani.Last()));                      //  نظیره ابجد
                payani.Add(Asas_Dour.asas(payani.Last(), D_name.ابتث));      //  نظیره ابتث
                payani.Add(Asas_Dour.asas(payani.Last(), D_name.اهطم));      //  نظیره اهطم
                payani.Add(Asas_Dour.asas(payani.Last(), D_name.ایقغ));      //  نظیره ایقغ

                payani.Add(Taksir.seir_nozool_sood(new string[5]            //  سیر نزولی صعودی
                {
                payani[4],
                payani[5],
                payani[6],
                payani[7],
                payani[8],
                },
                k, false));
                payani.AddRange(Asas_Dour.dour(Taksir.zomam_once(payani.Last(), true, true, false)));        //  تکسیر مؤخر و صدر و دور کبیر

                return payani.ToArray();
            }

            public static string[] ravesh_6(string text, string date)
            {
                List<string> payani = new List<string>();

                payani.Add(Stentagh.madakhel_arbae_one_line(text + date));        //  استنطاق مداخل اربعه سوال
                payani.Add(Bast.hazfmokarar_103(text + date));     //  حذف مکرر سوال + تاریخ

                payani.Add(payani[0] + payani[1]);      //  جمع مداخل و حذف مکرر
                if (payani.Last().Length % 2 == 1)       //  اگر رشته فرد بود
                    payani[2] += Stentagh.makani(payani[2].Length);     //  استنطاق طول رشته و جمع با آن

                payani.Add(Taksir.laght(payani.Last(), 0, 4, 1, 0));        //  لقط 4 استنطاق
                payani.Add(Asas_Dour.asas(payani.Last()));                      //  نظیره ابجد

                int len = payani.Last().Length;
                string str = "";        //  جمع عدد جدولی معکوس با وضعی
                for (int i = 0; i < len; i++)
                    str += Stentagh.makani(
                        Hesab.select(payani.Last().Substring(i, 1), D_int.وضعی) +
                        len - i);
                payani.Add(str);

                payani.AddRange(Asas_Dour.dour(Taksir.zomam_once(payani.Last(), true, true, false)));        //  تکسیر مؤخر و صدر و دور کبیر

                return payani.ToArray();
            }
        }

        public class ravesh_2_i
        {

        }

        public class ravesh_2_ii
        {

        }

        public class ravesh_2_iii
        {

        }
    }





    public class Tool
    {
        #region نسبت
        /// <summary>
        /// نسبت دو حرف
        /// </summary>
        /// <param name="x_str">حرف اول</param>
        /// <param name="y_str">حرف دوم</param>
        /// <returns></returns>
        public static string nesbat(string x_str, string y_str)
        {
            string payani = "";
            for (int i = 0; i < x_str.Length && i < y_str.Length; i++)
            {
                int x = Math_Old.tarh_esghat(Hesab.select(x_str.Substring(i, 1), D_int.افلاکی), 9);
                int y = Math_Old.tarh_esghat(Hesab.select(y_str.Substring(i, 1), D_int.افلاکی), 9);

                if (i != 0)
                    payani += ", ";
                payani += Math_Old.kmm(x, y).ToString();        //  نسبت همان ک م م
            }
            return payani;
        }
        public static int nesbat(int x, int y) { return Math_Old.kmm(x, y); }

        public static List<int> nesbat(string text)
        {
            List<int> payani = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                int x = Math_Old.tarh_esghat(Hesab.select(text.Substring(i, 1), D_int.افلاکی), 9);
                int y = Math_Old.tarh_esghat(Hesab.select(
                    (i + 1 != text.Length) ? text.Substring(i + 1, 1) : text.Substring(0, 1),
                    D_int.افلاکی), 9);

                payani.Add(Math_Old.kmm(x, y));
            }
            return payani;
        }
        #endregion

        #region تتمه
        public static string tateme_fun(int x, int y) { return ((x == y) ? x + y : Math.Abs(x - y)).ToString(); }
        public static string tateme_fun(string x, string y) { return tateme_fun(Convert.ToInt32(x), Convert.ToInt32(y)); }
        /// <summary>
        /// تتمه دو حرف، شاه نعمت الله ولی
        /// </summary>
        public static int tateme_shah(int x, int y)
        {
            int payani;

            if (x == y)
                payani = x;
            else
                payani = Math.Abs(x - y);

            if (payani > 28)
                payani = Hesab.rad_be_ahad(payani);

            return payani;
        }
        /// <summary>
        /// تتمه دو عدد، شاه نعمت الله ولی
        /// </summary>
        public static int tateme_shah(string x, string y) { return tateme_shah(Convert.ToInt32(x), Convert.ToInt32(y)); }
        #endregion
    }
}
