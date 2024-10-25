using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJafr.ElmHorouf;
using HJafr.Enums;
using HJafr.data_cls;

/// <summary>
/// <right>جفرجامع</right>
/// <right>نسخه: 0.5.0</right>
/// <right>تاریخ: 1403.07.11</right>
/// </summary>
namespace HJafr.jafr_jame_cls
{
    class JJ_code
    {
        #region تبدیل عدد و حرف
        //  harf
        public static int[] harf_to_array(string text)
        {
            int[] num = new int[4];
            for (int i = 0; i < 4; i++)
                num[i] = Hesab.select(text.Substring(i, 1), D_int.وضعی) - 1;
            return num;
        }
        public static int harf_to_num(string text) { return array_to_num(harf_to_array(text)); }

        //  num
        public static string num_to_harf(int num)
        {
            string payani = "";
            string d = Data.d(D_name.ابجد);
            int[] x = num_to_array(num);
            for (int i = 0; i < 4; i++)
                payani += d.Substring(x[i], 1);
            return payani;
        }
        public static string array_to_harf(int[] num) { return num_to_harf(array_to_num(num)); }
        #endregion

        #region تبدیل و تنظیم عدد
        public static int[] num_to_array(int num)
        {
            int[] x = new int[4];
            num = num_fix(num);
            for (int i = 0; i < 4 && num > 0; i++)
            {
                x[i] = num % 28;
                num /= 28;
            }
            return x;
        }
        public static int array_to_num(int[] num) { return num_fix(num[0] + (num[1] * 28) + (num[2] * 28 * 28) + (num[3] * 28 * 28 * 28)); }
        public static int num_fix(int num, int plus = 0) { return math_old_cls.Math_Old.tarh_esghat(num + plus, 28 * 28 * 28 * 28); }
        public static int num_fix(int num, int[] plus) { return num_fix(num + plus[0] + (plus[1] * 28) + (plus[2] * 28 * 28) + (plus[3] * 28 * 28 * 28)); }
        #endregion

        #region گرفتن یک صفحه
        //  array
        public static int[][] get_page(int[] num)
        {
            int[][] payani = new int[28 * 28][];
            for (int i = 0; i < 28; i++)
                for (int k = 0; k < 28; k++)
                    payani[i * 28 + k] = new int[4] { num[0], num[1], i, k };
            return payani;
        }
        public static int[][] get_page(int num) { return get_page(num_to_array(num)); }
        public static int[][] get_page(string text) { return get_page(harf_to_num(text)); }

        //  num
        public static int[] get_page_num(int[] num)
        {
            int[] payani = new int[28 * 28];
            int[][] x = get_page(num);
            for (int i = 0; i < 28 * 28; i++)
                payani[i] = array_to_num(x[i]);
            return payani;
        }
        public static int[] get_page_num(int num) { return get_page_num(num_to_array(num)); }
        public static int[] get_page_num(string text) { return get_page_num(harf_to_array(text)); }

        //  harf
        public static string[] get_page_harf(int[] num, bool space)
        {
            string[] payani = new string[28 * 28];
            string fasele = space ? " " : "";
            string d = Data.d(D_name.ابجد);
            int[][] page = get_page(num);

            for (int i = 0; i < 28 * 28; i++)
            {
                payani[i] = "";
                for (int k = 0; k < 4; k++)
                    payani[i] += d.Substring(page[i][k], 1) + fasele;
            }
            return payani;
        }
        public static string[] get_page_harf(int num, bool space) { return get_page_harf(num_to_array(num), space); }
        public static string[] get_page_harf(string text, bool space) { return get_page_harf(harf_to_array(text), space); }
        #endregion
    }
}
