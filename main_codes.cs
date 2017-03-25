using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HJafr.main_codes
{
    public class code
    {
        /// <summary>
        /// کپی کردن درست از نوشته تا آخر
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="startIndex">خانه شروع</param>
        /// <returns></returns>
        public static string SubStr(string text, int startIndex) => SubStr(text, startIndex, text.Length - startIndex);
        /// <summary>
        /// کپی کردن درست از نوشته
        /// </summary>
        /// <param name="text">نوشته</param>
        /// <param name="startIndex">خانه شروع</param>
        /// <param name="length">طول برداشت</param>
        /// <returns></returns>
        public static string SubStr(string text, int startIndex, int length, bool dour_zadan = false)
        {
            string payani = "";
            if (text.Length > 0)
            {
                if (dour_zadan)     //  اگر نقطه شروع بیش از حد متن بود بیاید از اول ادامه را بشمارد
                    startIndex = startIndex % text.Length;

                if (startIndex >= 0 && length > 0)
                    if (startIndex < text.Length && length + startIndex <= text.Length)
                        payani = text.Substring(startIndex, length);
                    else if (startIndex < text.Length)
                        payani = text.Substring(startIndex);
            }
            return payani;
        }

        public static string Remove_Str(string text, int startIndex, int length, bool dour_zadan = false)
        {
            string payani = "";
            if (text.Length > 0)
            {
                if (dour_zadan)     //  اگر نقطه شروع بیش از حد متن بود بیاید از اول ادامه را بشمارد
                    startIndex = startIndex % text.Length;

                if (startIndex >= 0 && length > 0)
                    if (startIndex < text.Length && length + startIndex <= text.Length)
                        payani = text.Remove(startIndex, length);
                    else if (startIndex < text.Length)
                        payani = text.Remove(startIndex);
            }
            return payani;
        }
        public static string Replace_list(string text, string[] old_char, string new_char)
        {
            for (int i = 0; i < old_char.LongLength; i++)
                text = text.Replace(old_char[i], new_char);
            return text;
        }


        public static List<string> ToString(List<int> list)
        {
            List<string> payani = new List<string>();
            for (int i = 0; i < list.Count; i++)
                payani.Add(list[i].ToString());
            return payani;
        }

        public static string jame(string[] text)
        {
            string payani = "";
            for (int i = 0; i < text.LongLength; i++)
                payani += text[i];
            return payani;
        }
        public static int jame(int[] num)
        {
            int payani = 0;
            for (int i = 0; i < num.LongLength; i++)
                payani += num[i];
            return payani;
        }

        public static List<int> int_max(List<int> num, int max)
        {
            num.Sort();     //  کوچک به بزرگ
            num.Reverse();      //  بر عکس
            for (int i = 0; i < num.Count; i++)
                if (max < num[i])
                    num.RemoveAt(i--);
                else break;
            return num;
        }
        public static List<int> int_min(List<int> num, int min)
        {
            num.Sort();     //  کوچک به بزرگ
            for (int i = 0; i < num.Count; i++)
                if (min > num[i])
                    num.RemoveAt(i--);
                else break;
            return num;
        }
        public static List<int> int_min_max(List<int> num, int max, int min) => int_max(int_min(num, min), max);

        public static int Round(int melak, int a, int b)
        {
            int x = Math.Abs(melak - a);
            int y = Math.Abs(melak - b);
            return (x == y || Math.Min(x, y) == x) ? a : b;
        }







        public static string get_zero(int num, int joker = 2)
        {
            string payani = num.ToString();
            for (int i = payani.Length; i < joker; i++)
                payani = "0" + payani;
            return payani;
        }

        public string GetResourceTextFile(string filename)
        {
            string result = string.Empty;
            using (Stream stream = this.GetType().Assembly.GetManifestResourceStream(filename))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }
    }

    public class algoritm
    {
        public static List<int> jame_list_int(int majmooe, List<int> list_int, List<int> akhz = null)
        {
            if (akhz == null)       //  اگر بار اول بود
            {
                akhz = new List<int>();
                //list_int = list_int.Distinct().ToList();        //  حذف تکراری‌ها
                list_int = code.int_max(list_int, majmooe);        //  حذف اعداد اضافی از لیست کلی
            }

            bool done = false;
            int jame_akhz = code.jame(akhz.ToArray());      //  جمع اعداد اخذ شده

            while (list_int.Count > 0)
            {   //  چون هر بار، اولین آرایه حذف می‌شود و به ترتیب هم هست، همیشه از اولین آرایه استفاده می‌گردد
                if (jame_akhz + list_int[0] == majmooe)     //  اگر جمع قبلی‌ها با این عدد همان مجموع بود، پایان کار است
                {
                    akhz.Add(list_int[0]);
                    done = true;
                    break;
                }
                else if (jame_akhz + list_int[0] + list_int[list_int.Count - 1] <= majmooe)     //  اگر جمع، کمتر از عدد دلخواه بود
                {
                    akhz.Add(list_int[0]);      //  افزودن عدد بعد به لیست موقت برای بررسی
                    list_int.RemoveAt(0);     //  حذف عدد از لیست

                    if (list_int.Count > 0)
                    {
                        List<int> list_int__tmp = new List<int>(code.int_max(new List<int>(list_int), majmooe - (jame_akhz + list_int[0])));     //  حذف اعداد اضافی
                        if (list_int__tmp.Count > 0)
                        {
                            akhz = new List<int>(jame_list_int(majmooe, new List<int>(list_int__tmp), new List<int>(akhz)));     //  شروع مجدد تابع 

                            if (akhz.Count > 0)       //  اگر خروجی صحیح بود
                            {
                                done = true;
                                break;
                            }
                        }
                    }
                }
                else if (list_int.Count > 0)
                    list_int.RemoveAt(0);     //  حذف عدد از لیست
            }

            return done ? akhz : new List<int>();
        }


        public static List<string> jaygasht(string text, int del, int len = 0, string last_str = "")
        {
            /// del = 0 : با تکرار
            /// del = 1 : بدون تکرار در هر خط
            /// del = 2 : بدون تکرار کلا

            List<string> payani = new List<string>();
            if (len == 0)
                len = text.Length;

            string text_tmp = text;
            for (int i = 0; i < text.Length; i++)
            {
                if (text_tmp.Length == 0) break;
                int count = (text_tmp.Length < i + 1) ? 0 : i;

                string last_str_2 = last_str + text_tmp.Substring(count, 1);
                if (del == 2)
                    text_tmp = text_tmp.Remove(count, 1);

                if (last_str_2.Length == len)
                    payani.Add(last_str_2);
                else
                    payani.AddRange(jaygasht(del == 1 ? text_tmp.Remove(count, 1) : text_tmp,
                        del, len, last_str_2));

                if (del == 2) i--;
            }
            return payani;
        }
        public static List<List<int>> jaygasht(List<int> num, int del, int len = 0, List<int> last = null)
        {
            /// del = 0 : با تکرار
            /// del = 1 : بدون تکرار در هر خط
            /// del = 2 : بدون تکرار کلا

            List<List<int>> payani = new List<List<int>>();
            if (len == 0)
                len = num.Count;
            if (last == null)
                last = new List<int>();

            List<int> num_tmp = new List<int>(num);
            for (int i = 0; i < num.Count; i++)
            {
                if (num_tmp.Count == 0) break;
                int count = (num_tmp.Count < i + 1) ? 0 : i;

                List<int> last_2 = new List<int>(last);
                last_2.Add(num_tmp[count]);
                if (del == 2)
                {
                    num_tmp.RemoveAt(count);
                    i--;
                }

                if (last_2.Count == len)
                    payani.Add(last_2);
                else
                {
                    if (del == 1)
                    {
                        List<int> num_tmp_2 = new List<int>(num_tmp);
                        if (del == 1)
                            num_tmp_2.RemoveAt(count);
                        payani.AddRange(jaygasht(new List<int>(num_tmp_2), del, len, new List<int>(last_2)));
                    }
                    else
                        payani.AddRange(jaygasht(new List<int>(num_tmp), del, len, new List<int>(last_2)));
                }
            }
            return payani;
        }
        public static List<List<int>> jaygasht(int first, int end, int del, int len = 0)
        {
            List<int> num = new List<int>();
            for (int i = first; i <= end; i++)
                num.Add(i);
            return jaygasht(num, del, len);
        }

    }

    public class value_change
    {
        public static string[] int_to_string_array(int[] num)
        {
            string[] payani = new string[num.LongLength];
            for (int i = 0; i < num.LongLength; i++)
                payani[i] = num[i].ToString();
            return payani;
        }

        public static int[] string_to_int_array(string[] text)
        {
            int[] payani = new int[text.LongLength];
            for (int i = 0; i < text.LongLength; i++)
                try { payani[i] = Convert.ToInt32(text[i]); }
                catch (Exception) { payani[i] = -1; }
            return payani;
        }

        public static string[] string_to_array(string text)
        {
            string[] payani = new string[text.Length];
            for (int i = 0; i < text.Length; i++)
                payani[i] = text.Substring(i, 1);
            return payani;
        }
    }

    /// <summary>
    /// <right>تنظیم کدهای ساعت</right>
    /// </summary>
    public class saat_code
    {
        public static double saat_tanzim(double num, bool manfi = true)
        {
            while (num > 24)
                num -= 24;
            if (manfi)
                while (num < 0)
                    num += 24;
            return num;
        }
        public static string saat_tanzim_int_s(int[] saat, bool manfi = true)
        {
            string payani = "";
            for (int i = 0; i < saat.LongLength; i++)
            {
                payani += code.get_zero(saat[i]);
                if (i + 1 != saat.LongLength)
                    payani += ":";
            }
            return saat_tanzim(payani, manfi);
        }
        public static int[] saat_tanzim_int(int[] saat, bool manfi = true) => num_to_array_saat(saat_tanzim(array_to_num_saat(saat), manfi));
        public static string saat_tanzim(string saat, bool manfi = true) => num_to_saat(saat_tanzim(saat_to_num(saat), manfi));
        public static string saat_tanzim_d_s(double num, bool manfi = true) => num_to_saat(saat_tanzim(num, manfi));

        /// <summary>
        /// تبدیل ساعت به عدد
        /// </summary>
        /// <param name="saat">ساعت</param>
        /// <param name="fasele">کارکتر فاصله</param>
        /// <returns></returns>
        public static double saat_to_num(string saat)
        {
            double payani = 0;
            for (int i = 0; saat.Length > 0; i++)
            {
                payani += Convert.ToDouble(saat.Substring(0, 2)) / Math.Pow(60, i);
                if (saat.Length > 2)
                    saat = saat.Remove(0, 3);
                else
                    break;
            }
            return payani;
        }

        /// <summary>
        /// تبدیل عدد به ساعت
        /// </summary>
        /// <param name="num_hour">عدد</param>
        /// <param name="bakhsh">تعداد دسته‌ها</param>
        /// <returns></returns>
        public static string num_to_saat(double num_hour, int bakhsh = 3)
        {
            string payani = "";
            for (int i = 0; i < bakhsh; i++)
            {
                payani += code.get_zero((int)Math.Floor(num_hour));
                if (i + 1 != bakhsh)
                    payani += ":";
                num_hour = (num_hour - Math.Floor(num_hour)) * 60;
            }
            return payani;
        }

        public static int[] num_to_array_saat(double num, int bakhsh = 3)
        {
            int[] payani = new int[bakhsh];
            for (int i = 0; i < bakhsh; i++)
            {
                payani[i] = (int)Math.Floor(num);
                num = (num - Math.Floor(num)) * 60;
            }
            return payani;
        }

        public static double array_to_num_saat(int[] num)
        {
            double payani = 0;
            for (int i = 0; i < num.LongLength; i++)
                payani += num[i] / Math.Pow(60, i);
            return payani;
        }
    }
}
