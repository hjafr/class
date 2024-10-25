using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJafr.ElmHorouf;
using HJafr.main_codes;

/// <summary>
/// <right>ریاضی قدیمی</right>
/// <right>نسخه: 1.0.0</right>
/// <right>تاریخ: 1403.07.11</right>
/// </summary>
namespace HJafr.math_old_cls
{
    public class Math_Old
    {
        /// <summary><right>عدد بزرگ یا کوچک</right></summary>
        /// <param name="x">اعداد</param>
        /// <param name="big"><right>گرفتن عدد بزرگتر</right></param>
        /// <returns></returns>
        public static int big_low(string[] x, bool big)
        {
            List<int> y = new List<int>();
            for (int i = 0; i < x.LongLength; i++)
                y.Add(x[i].Length);
            return big_low(y.ToArray(), big);
        }
        /// <summary><right>عدد بزرگ یا کوچک</right></summary>
        /// <param name="x">اعداد</param>
        /// <param name="big"><right>گرفتن عدد بزرگتر</right></param>
        /// <returns></returns>
        public static int big_low(int[] x, bool big)
        {
            int a = x[0];
            int b = x[1];

            int g = 0;
            int h = 1;

            for (int i = 1; ;)
            {
                if (!big_low(a, b, big))
                {
                    a = b;
                    g = h;
                }
                if (i + 1 < x.LongLength)
                {
                    b = x[++i];
                    h++;
                }
                else
                    break;
            }
            return g;
        }
        /// <summary><right>عدد بزرگ یا کوچک</right></summary>
        /// <param name="a">عدداول</param>
        /// <param name="b">عدددوم</param>
        /// <param name="big"><right>گرفتن عدد بزرگتر</right></param>
        /// <returns></returns>
        public static bool big_low(int a, int b, bool big) { return big ? (a > b) : (a < b); }

        /// <summary>
        /// <right>ب.م.م : بزرگترین عاد یا مقسوم علیه مشترک</right>
        /// </summary>
        public static int bmm(int a, int b) { return (b == 0) ? a : bmm(b, a % b); }
        public static int bmm(int[] a)
        {
            int b = a[0];
            for (int i = 0; i < a.Length; i++)
                b = bmm(a[i], b);
            return b;
        }
        /// <summary>
        /// <right>ک.م.م : کوچکترین مضرب مشترک</right>
        /// </summary>
        public static int kmm(int a, int b) { return (a * b) / bmm(a, b); }
        public static int kmm(int[] a)
        {
            int b = 0;
            for (int i = 0; i < a.LongLength; i++)
                b = kmm(a[i], b);
            return b;
        }


        /// <summary>
        /// اسقاط
        /// </summary>
        /// <param name="num"><right>عدد دلخواه برای اسقاط</right></param>
        /// <param name="tarh"><right>عددی که با آن طرح می‌شود</right></param>
        /// <param name="baghi"><right>باقی مانده داشتن یا صفر آوردن</right></param>
        /// <returns>حاصل اسقاط</returns>
        public static int tarh_esghat(int num, int tarh, bool baghi = true)
        {
            num %= tarh;
            if (num < 0 || (baghi && num == 0))
                num += tarh;
            return num;
        }

        /// <summary>
        /// <right>جمع الجمع</right>
        /// </summary>
        /// <param name="num">لیست اعداد</param>
        /// <returns>جمع هر عدد با مجموع اعداد قبل</returns>
        public static List<int> jame_aljame(List<int> num)
        {
            List<int> payani = new List<int>();
            for (int i = 0; i < num.Count; i++)
                payani.Add(num[i] + (i != 0 ? payani[i - 1] : 0));
            return payani;
        }

        /// <summary>
        /// <right>گرد کردن، نزدیکترین عدد کبیر</right>
        /// </summary>
        /// <param name="num"><right>عدد دلخواه</right></param>
        /// <returns><right>عدد کبیر</right></returns>
        public static int gerd_kabir(int num)
        {
            if (is_kabor(num))        //  اگر فقط رقم اول غیر صفر باشد
                return num;
            else
            {
                int a = num;
                for (int i = 0; !is_kabor(a); i++)
                    a += (a.ToString().Substring(a.ToString().Length - 1) != "0") ? 1 :
                             (a.ToString().Substring(a.ToString().Length - 2) != "00") ? 10 : 100;

                int b = num;
                for (int i = 0; !is_kabor(b); i++)
                    b -= (b.ToString().Substring(b.ToString().Length - 1) != "0") ? 1 :
                         (b.ToString().Substring(b.ToString().Length - 2) != "00") ? 10 : 100;

                return Code.Round(num, a, b);
            }
        }

        /// <summary>
        /// <right>کبیر بودن عدد</right>
        /// </summary>
        /// <param name="num"><right>عدد دلخواه</right></param>
        /// <returns><right>عدد کبیر بودن</right></returns>
        public static bool is_kabor(int num)
        {
            return (num <= 9 ||
                (num > 9 && num.ToString().Substring(1, 1) == "0") ||
                (num > 99 && num.ToString().Substring(1, 2) == "00") ||
                (num > 999 && num.ToString().Substring(1, 3) == "000"));
        }




        public static int nesbat_int(int a, int b)//, bool one = false
        {
            /// توضیحات
            /// 0 : متماثل
            /// 1 : متباین
            /// 2 : متوافق
            /// 3 : متداخل

            int payani = 0;
            if (a == b)        // متماثل
                payani = 0;
            //else if (one && (i == 1 || k == 1))
            //payani = 3;
            else if (bmm(a, b) == 1)        // متباین
                payani = 1;
            else if (a % b == 0 || b % a == 0)        // متداخل
                payani = 3;
            else        // متوافق
                payani = 2;

            return payani;
        }
    }

    /// <summary>
    /// <right>ریاضیات و حروف</right>
    /// </summary>
    public class Math_Harf
    {
        /// <summary>
        /// <right>عدد بودن یک رشته</right>
        /// </summary>
        public static bool num_true(string num)
        {
            if (num.Length == 0 || num == null)
                return false;
            for (int i = 0; i < num.Length; i++)
                if (!"۱۲۳۴۵۶۷۸۹۰1234567890١٢٣٤٥٦٧٨٩٠".Contains(num.Substring(i, 1)))
                    return false;
            return true;
        }

        /// <summary>
        /// <right>تبدیل اعداد به عدد انگلیسی</right>
        /// </summary>
        public static string num_change(string num)
        {
            //  اعداد فارسی
            num = num.Replace("۱", "1");
            num = num.Replace("۲", "2");
            num = num.Replace("۳", "3");
            num = num.Replace("۴", "4");
            num = num.Replace("۵", "5");
            num = num.Replace("۶", "6");
            num = num.Replace("۷", "7");
            num = num.Replace("۸", "8");
            num = num.Replace("۹", "9");
            num = num.Replace("۰", "0");

            //  اعداد عربی
            num = num.Replace("١", "1");
            num = num.Replace("٢", "2");
            num = num.Replace("٣", "3");
            num = num.Replace("٤", "4");
            num = num.Replace("٥", "5");
            num = num.Replace("٦", "6");
            num = num.Replace("٧", "7");
            num = num.Replace("٨", "8");
            num = num.Replace("٩", "9");
            num = num.Replace("٠", "0");
            return num;
        }

        /// <summary>
        /// <right>تبدیل اعداد به عدد فارسی</right>
        /// </summary>
        public static string num_change_fa(string num)
        {
            //  اعداد فارسی
            num = num.Replace("1", "۱");
            num = num.Replace("2", "۲");
            num = num.Replace("3", "۳");
            num = num.Replace("4", "۴");
            num = num.Replace("5", "۵");
            num = num.Replace("6", "۶");
            num = num.Replace("7", "۷");
            num = num.Replace("8", "۸");
            num = num.Replace("9", "۹");
            num = num.Replace("0", "۰");

            //  اعداد عربی
            num = num.Replace("١", "1");
            num = num.Replace("٢", "2");
            num = num.Replace("٣", "3");
            num = num.Replace("٤", "4");
            num = num.Replace("٥", "5");
            num = num.Replace("٦", "6");
            num = num.Replace("٧", "7");
            num = num.Replace("٨", "8");
            num = num.Replace("٩", "9");
            num = num.Replace("٠", "0");
            return num;
        }

        /// <summary>
        /// <right>چک کردن عدد بودن همه</right>
        /// </summary>
        public static string num_just(string num)
        {
            string payani = "";
            num = num_change(num);
            for (int i = 0; i < num.Length; i++)
                if ("1234567890".Contains(num.Substring(i, 1)))
                    payani += num.Substring(i, 1);
            return payani;
        }

        /// <summary>
        /// <right>افزایش رقم ها با صفر</right>
        /// </summary>
        public static string num_add_0(string num, int len)
        {
            for (int i = 0; i < len; i++)
                if (num.Length < len)
                    num = "0" + num;
                else
                    break;
            return num;
        }
        public static string num_add_0(int num, int len) { return num_add_0(num.ToString(), len); }

    }
}
