using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJafr.Enums;
using HJafr.data_cls;
using HJafr.main_codes;

/// <summary>
/// <right>تغییر حروف</right>
/// <right>نسخه: 1.0.0</right>
/// <right>تاریخ: 1403.07.11</right>
/// </summary>
namespace HJafr.harf_change_cls
{
    public class Harf_Change
    {
        /// <summary><right>جداسازی حروف یا چسباندن آن‌ها</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="space"><right>جدا کردن یا چسباندن</right></param>
        /// <returns></returns>
        public static string[] space(string[] text, bool space = true)
        {
            string[] payani = new string[text.LongLength];

            for (int i = 0; i < text.LongLength; i++)
                payani[i] = Harf_Change.space(text[i], space);

            return payani;
        }
        /// <summary><right>جداسازی حروف یا چسباندن آن‌ها</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="space"><right>جدا کردن یا چسباندن</right></param>
        /// <returns></returns>
        public static string space(string text, bool space = true)
        {
            string payani = "";
            string fasele = space ? " " : "";
            if (text != null)
                for (int i = 0; i < text.Length; i++)
                {
                    string harf = text.Substring(i, 1);
                    if (harf == " ")
                        continue;
                    else
                        payani += text.Substring(i, 1) + fasele;
                }
            return payani;
        }

        /// <summary><right>اعراب گذاری نوشته بنابه دایره دلخواه</right></summary>
        public static string harekat_gozari(string text, D_name dn)
        {
            string payani = "";
            string d = Data.d(dn);
            text = alefbae(text, space: true);
            while (text != "")
            {
                string h = text.Substring(0, 1);
                if (h == " " || h == "\n")
                    payani += h;
                else if (d.Contains(h))
                    switch (d.IndexOf(h) / 7)
                    {
                        case 0: payani += h + "ُ"; break;
                        case 1: payani += h + "َ"; break;
                        case 2: payani += h + "ِ"; break;
                        case 3: payani += h + ((payani == "" || payani.Substring(payani.Length - 2, 1) == "ْ") ? "ِ" : "ْ"); break;
                    }
                text = text.Remove(0, 1);
            }
            return payani;
        }

        /// <summary><right>استاندارد سازی : تبدیل حروف الفبا فارسی و عربی</right></summary>
        /// <param name="text">نوشته</param>
        /// <param name="n"><right>محاسبه اینتر=1</right></param>
        /// <param name="paj"><right>تبدیل نکردن پژگچ</right></param>
        /// <param name="hamze"><right>به حال خود گذاشتن همزه</right></param>
        /// <param name="space"><right>باقی گذاردن فاصله‌ها</right></param>
        /// <returns></returns>
        public static string alefbae(string text, bool n = false, bool paj = false, bool hamze = true, bool space = false)
        {
            if (text == null) return "";
            string payani = "";
            string d = Data.d(D_name.ابجد);

            #region تبدیل حروف
            text = Code.Replace_list(text, new string[] { "آ", "أ", "إ", "ٱ", "ٲ", "ٳ", "ٵ" }, "ا");
            text = Code.Replace_list(text, new string[] { "ڀ", "ٻ" }, "ب");
            text = Code.Replace_list(text, new string[] { "ڃ", "ڄ", "ڇ", "ڿ" }, "ج");
            text = Code.Replace_list(text, new string[] { "ڋ", "ڊ", "ډ", "ڈ", "ڍ" }, "د");
            text = Code.Replace_list(text, new string[] { "ة", "ھ", "ۀ", "ہ", "ۂ", "ۃ" }, "ه");
            text = Code.Replace_list(text, new string[] { "ؤ", "ٶ", "ٷ", "ۄ", "ۅ", "ۇ", "ۈ", "ۉ", "ۊ", "ۋ", "ۏ" }, "و");
            text = Code.Replace_list(text, new string[] { "ڗ", "ڙ" }, "ز");
            text = text.Replace("ځ", "ح");
            text = text.Replace("ڟ", "ظ");
            text = Code.Replace_list(text, new string[] { "ي", "ى", "ئ", "ٸ", "ۍ", "ێ", "ې", "ۑ", "ے", "ۓ" }, "ی");
            text = Code.Replace_list(text, new string[] { "ك", "ڪ", "ګ", "ڬ", "ڭ", "ڮ", "ڱ", "ڰ", "ڲ", "ڳ", "ڴ" }, "ک");
            text = Code.Replace_list(text, new string[] { "ڵ", "ڶ", "ڷ", "ڸ" }, "ل");
            text = Code.Replace_list(text, new string[] { "ﻣ", "ﻤ", "ﻢ" }, "م");
            text = Code.Replace_list(text, new string[] { "ڹ", "ں", "ڻ", "ڼ", "ڽ" }, "ن");
            text = Code.Replace_list(text, new string[] { "ښ", "ڛ" }, "س");
            text = Code.Replace_list(text, new string[] { "ڡ", "ڢ", "ڣ", "ڤ", "ڥ", "ڦ" }, "ف");
            text = text.Replace("ڝ", "ص");
            text = Code.Replace_list(text, new string[] { "ڧ", "ڨ" }, "ق");
            text = Code.Replace_list(text, new string[] { "ڑ", "ړ", "ڕ", "ږ" }, "ر");
            text = text.Replace("ڜ", "ش");
            text = Code.Replace_list(text, new string[] { "ٹ", "ٺ", "ټ", "ٽ", "ٿ" }, "ت");
            text = Code.Replace_list(text, new string[] { "څ", "ڂ" }, "خ");
            text = Code.Replace_list(text, new string[] { "ڌ", "ڎ", "ڏ", "ڐ" }, "ذ");
            text = text.Replace("ڞ", "ض");
            text = text.Replace("ڠ", "غ");

            if (!hamze)     //  اگر همزه مجاز نبود
                text = text.Replace("ء", "ا");

            if (!paj)        //  اگر پژگچ مجاز نبود
            {
                text = text.Replace("پ", "ب");
                text = text.Replace("چ", "ج");
                text = text.Replace("ژ", "ز");
                text = text.Replace("گ", "ک");
            }
            #endregion

            d += "ء" + "پ" + "چ" + "ژ" + "گ";        //  اگر همزه و پژگچ مجاز نباشد قبل از این تبدیل می‌گردد و اگر نه که به دایره اضافه شده و قابل اخذ است
            if (space)
                d += " ";
            if (n)
                d += "\n";

            for (int i = 0; i < text.Length; i++)
            {
                string h = text.Substring(i, 1);
                if (d.Contains(h))
                    payani += h;
            }
            return payani;
        }
        /*  الفبا خلاصه
               if (text == null) return "";
            string payani = "";
            string d = data.d(d_name.ابجد);
            for (int i = 0; i < text.Length; i++)
            {
                string harf = text.Substring(i, 1);
                if (d.Contains(harf))
                    payani += harf;
                else
                {
                    if ("آأإٱٲٳٵ".Contains(harf))
                        payani += "ا";
                    else if ("ةھۀہۂۃ".Contains(harf))
                        payani += "ه";
                    else if ("يىئ".Contains(harf))
                        payani += "ی";
                    else switch (harf)
                        {
                            case "پ": payani += "ب"; break;
                            case "چ": payani += "ج"; break;
                            case "ؤ": payani += "و"; break;
                            case "ژ": payani += "ز"; break;
                            case "ك": payani += "ک"; break;
                        }
                }
            }
        */
        /// <summary><right>استاندارد سازی آرایه ای : تبدیل حروف الفبا فارسی و عربی</right></summary>
        /// <param name="text">نوشته‌ها</param>
        /// <param name="n"><right>محاسبه اینتر=1</right></param>
        /// <param name="paj"><right>تبدیل نکردن پژگچ</right></param>
        /// <param name="hamze"><right>به حال خود گذاشتن همزه</right></param>
        /// <param name="space"><right>باقی گذاردن فاصله‌ها</right></param>
        /// <returns></returns>
        public static string[] alefbae(string[] text, bool n = false, bool paj = false, bool hamze = false, bool space = false)
        {
            for (int i = 0; i < text.LongLength; i++)
                text[i] = alefbae(text[i], n, paj, hamze, space);
            return text;
        }
        
        /// <summary><right>استانداردسازی عبری</right></summary>
        public static string الفباعبری(string text)
        {
            string payani = "";
            string d = Data.d(D_name.عبری);

            //  تبدیل حروف آخر به معمولی
            text = text.Replace("ך", "כ");
            text = text.Replace("ם", "מ");
            text = text.Replace("ן", "נ");
            text = text.Replace("ף", "פ");
            text = text.Replace("ץ", "צ");

            for (int i = 0; i < text.Length; i++)
            {
                string h = text.Substring(i, 1);
                if (d.Contains(h))
                    payani += h;
            }
            return payani;
        }

        /// <summary><right>استانداردسازی انگلیسی : ناکامل!!!</right></summary>
        public static string الفباانگلیسی(string text)      // 26: abcdefghijklmnopqrstuvwxyz
        {
            // باید حروف بزرگ به کوچک تبدیل شود
            string payani = "";
            string d = Data.d(D_name.انگلیسی);
            text = text.ToLower();

            for (int i = 0; i < text.Length; i++)
            {
                string h = text.Substring(i, 1);
                if (d.Contains(h))
                    payani += h;
            }
            return payani;
        }
    }
}
