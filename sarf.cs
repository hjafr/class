using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJafr.sarf
{
    class adad
    {

        /// <summary><right>تبدیل عدد به کلمه فارسی</right></summary>
        public static string عددفارسی(string Fnum)
        {
            string payani = "";
            if (Convert.ToUInt64(Fnum) == 0)        //  هزار
                payani = "صفر";
            else
            {
                #region سه رقم سه رقم جدا کردن
                if (Fnum.Length % 3 == 1)
                    Fnum = "00" + Fnum;
                if (Fnum.Length % 3 == 2)
                    Fnum = "0" + Fnum;
                string[,] num = new string[Fnum.Length / 3, 3];
                for (int i = 0, j = 0, k = 0; i < Fnum.Length / 3; j++)
                {
                    num[i, j] = Fnum.Substring(k++, 1);
                    if (j == 2)
                    {
                        i++;
                        j = -1;
                    }
                }
                #endregion

                #region تبدیل به حروف هر دسته.
                string[] kalame = new string[Fnum.Length / 3];
                for (int i = 0; i < Fnum.Length / 3; i++)
                {
                    switch (num[i, 0])
                    {
                        case "1": kalame[i] += "یکصد"; break;
                        case "2": kalame[i] += "دویست"; break;
                        case "3": kalame[i] += "سیصد"; break;
                        case "4": kalame[i] += "چهارصد"; break;
                        case "5": kalame[i] += "پانصد"; break;
                        case "6": kalame[i] += "ششصد"; break;
                        case "7": kalame[i] += "هفتصد"; break;
                        case "8": kalame[i] += "هشتصد"; break;
                        case "9": kalame[i] += "نهصد"; break;
                    }

                    if (Convert.ToInt32(num[i, 1] + num[i, 2]) > 10 && Convert.ToInt32(num[i, 1] + num[i, 2]) < 20)
                    {
                        if (kalame[i] != null && num[i, 1] + num[i, 2] != "00")
                            kalame[i] += " و ";

                        switch (num[i, 1] + num[i, 2])
                        {
                            case "11": kalame[i] += "یازده"; break;
                            case "12": kalame[i] += "دوازده"; break;
                            case "13": kalame[i] += "سیزده"; break;
                            case "14": kalame[i] += "چهارده"; break;
                            case "15": kalame[i] += "پانزده"; break;
                            case "16": kalame[i] += "شانزده"; break;
                            case "17": kalame[i] += "هفده"; break;
                            case "18": kalame[i] += "هجده"; break;
                            case "19": kalame[i] += "نوزده"; break;
                        }
                    }
                    else
                    {
                        if (kalame[i] != null && num[i, 1] != "0")
                            kalame[i] += " و ";

                        switch (num[i, 1])
                        {
                            case "1": kalame[i] += "ده"; break;
                            case "2": kalame[i] += "بیست"; break;
                            case "3": kalame[i] += "سی"; break;
                            case "4": kalame[i] += "چهل"; break;
                            case "5": kalame[i] += "پنجاه"; break;
                            case "6": kalame[i] += "شصت"; break;
                            case "7": kalame[i] += "هفتاد"; break;
                            case "8": kalame[i] += "هشتاد"; break;
                            case "9": kalame[i] += "نود"; break;
                        }

                        if (kalame[i] != null && num[i, 2] != "0")
                            kalame[i] += " و ";

                        switch (num[i, 2])
                        {
                            case "1": kalame[i] += "یک"; break;
                            case "2": kalame[i] += "دو"; break;
                            case "3": kalame[i] += "سه"; break;
                            case "4": kalame[i] += "چهار"; break;
                            case "5": kalame[i] += "پنج"; break;
                            case "6": kalame[i] += "شش"; break;
                            case "7": kalame[i] += "هفت"; break;
                            case "8": kalame[i] += "هشت"; break;
                            case "9": kalame[i] += "نه"; break;
                        }
                    }
                    if (kalame[i] != "")
                        switch ((Fnum.Length / 3) - 1 - i)
                        {
                            case 1: kalame[i] += " هزار"; break;
                            case 2: kalame[i] += " میلیون"; break;
                            case 3: kalame[i] += " میلیارد"; break;
                            case 4: kalame[i] += " بیلیون"; break;
                            case 5: kalame[i] += " بیلیارد"; break;
                            case 6: kalame[i] += " ترلیون"; break;
                            case 7: kalame[i] += " ترلیارد"; break;
                        }
                }
                #endregion

                for (int i = 0; i < Fnum.Length / 3; i++)       //  جمع کردن هر دسته
                {
                    payani += kalame[i];
                    if (i + 1 < Fnum.Length / 3 && kalame[i + 1] != "")
                        payani += " و ";
                }
            }
            return payani;
        }

        /// <summary><right>تبدیل عدد به حروف عربی</right></summary>
        public static string عددعربی(string Fnum)
        {
            string payani = "";
            if (Convert.ToUInt64(Fnum) == 0)        //  هزار
                payani = "صفر";
            else
            {
                #region سه رقم سه رقم جدا کردن
                if (Fnum.Length % 3 == 1)
                    Fnum = "00" + Fnum;
                if (Fnum.Length % 3 == 2)
                    Fnum = "0" + Fnum;

                string[] num_3 = new string[Fnum.Length / 3];
                for (int i = 0; i < Fnum.Length / 3; i++)
                    num_3[i] = Fnum.Substring(i * 3, 3);

                string[,] num = new string[Fnum.Length / 3, 3];
                for (int i = 0, j = 0, k = 0; i < Fnum.Length / 3; j++)
                {
                    num[i, j] = Fnum.Substring(k++, 1);
                    if (j == 2)
                    {
                        i++;
                        j = -1;
                    }
                }
                #endregion

                #region تبدیل به حروف هر دسته.
                string[] kalame = new string[Fnum.Length / 3];
                for (int i = 0; i < Fnum.Length / 3; i++)
                {
                    if ((num_3[i] == "001" || num_3[i] == "002") && i + 1 != Fnum.Length / 3)        //  سری آخر نباشد
                    {   //  یک یا دو در بخش هزارگان
                        if (num_3[i] == "001")
                            switch (Fnum.Length / 3 - 1 - i)
                            {
                                case 1: kalame[i] += "ألف"; break;
                                case 2: kalame[i] += "ملیون"; break;
                                case 3: kalame[i] += "ملیار"; break;
                                case 4: kalame[i] += "تریلیون"; break;
                            }
                        else if (num_3[i] == "002")
                            switch (Fnum.Length / 3 - 1 - i)
                            {
                                case 1: kalame[i] += "ألفان"; break;
                                case 2: kalame[i] += "ملیونان"; break;
                                case 3: kalame[i] += "میلیاران"; break;
                                case 4: kalame[i] += "تریلیونان"; break;
                            }
                    }
                    else
                    {
                        if (num[i, 0] != "0")       //  صدگان
                            kalame[i] += yekad_dahgan_arabi(num[i, 0], true, 100) + " ";

                        if (num[i, 2] != "0")       //  یکان
                            kalame[i] += yekad_dahgan_arabi(num[i, 2], true, 1) + " ";

                        if (num[i, 1] != "0")       //  دهگان
                            kalame[i] += yekad_dahgan_arabi(num[i, 1], true, 10) + " ";

                        if (kalame[i].Length != 0)      //  بخش هزارگان
                            switch (Fnum.Length / 3 - 1 - i)
                            {
                                case 1: kalame[i] += "آلاف"; break;
                                case 2: kalame[i] += "ملایین"; break;
                                case 3: kalame[i] += "ملیارات"; break;
                                case 4: kalame[i] += "تریلیونات"; break;
                            }
                    }
                }
                #endregion

                for (int i = 0; i < Fnum.Length / 3; i++)       //  جمع کردن هر دسته
                {
                    payani += kalame[i];
                    if (i + 1 < Fnum.Length / 3 && kalame[i + 1].Length != 0)
                        payani += " و ";
                }
            }
            return payani;
        }

        /// <summary>
        /// <right>یکان و دهگان عربی</right>
        /// </summary>
        /// <param name="num">عدد</param>
        /// <param name="asli"><right>اصلی و غیر اصلی</right></param>
        /// <param name="martabe"><right>مرتبه یکان و دهگان و صدگان</right></param>
        /// <returns></returns>
        static string yekad_dahgan_arabi(string num, bool asli, int martabe)
        {
            if (martabe == 1)
            {
                switch (num)        //  یکان
                {
                    case "1": return asli ? "أحد" : "حادی";
                    case "2": return asli ? "إثنان" : "ثانی";
                    case "3": return asli ? "ثلاث" : "ثلاث";
                    case "4": return asli ? "أربع" : "رابع";
                    case "5": return asli ? "خمس" : "خامس";
                    case "6": return asli ? "ستّ" : "سادس";
                    case "7": return asli ? "سبع" : "سابع";
                    case "8": return asli ? "ثمانی" : "ثامن";
                    case "9": return asli ? "تسع" : "تاسع";
                }
            }

            else if (martabe == 10)
            {   //  دهگان
                switch (num)
                {
                    case "1": return asli ? "عشر" : "عاشر";
                    case "2": return "عشرون";
                    case "8": return "ثمانون";
                }
                return yekad_dahgan_arabi(num, true, 1) + "ون";
            }

            else if (martabe == 100)
            {   //  صدگان
                if (num == "1")
                    return "مأة";
                else if (num == "2")
                    return "مأتین";
                else
                    return yekad_dahgan_arabi(num, true, 1) + " مأة";
            }

            return "";
        }
    }

    /// <summary>
    /// اعداد
    /// </summary>
    class number
    {
        public static string ارمنی1(int num)
        {
            string kalame = "";
            if (num < 9999 || num > 0)
            {
                switch (num / 1000)
                {
                    case 1: kalame += "Ռ"; break;
                    case 2: kalame += "Ս"; break;
                    case 3: kalame += "Վ"; break;
                    case 4: kalame += "Տ"; break;
                    case 5: kalame += "Ր"; break;
                    case 6: kalame += "Ց"; break;
                    case 7: kalame += "Ւ"; break;
                    case 8: kalame += "Փ"; break;
                    case 9: kalame += "Ք"; break;
                }

                switch ((num / 100) % 10)
                {
                    case 1: kalame += "Ճ"; break;
                    case 2: kalame += "Մ"; break;
                    case 3: kalame += "Յ"; break;
                    case 4: kalame += "Ն"; break;
                    case 5: kalame += "Շ"; break;
                    case 6: kalame += "Ո"; break;
                    case 7: kalame += "Չ"; break;
                    case 8: kalame += "Պ"; break;
                    case 9: kalame += "Ջ"; break;
                }

                switch ((num / 10) % 10)
                {
                    case 1: kalame += "Ժ"; break;
                    case 2: kalame += "Ի"; break;
                    case 3: kalame += "Լ"; break;
                    case 4: kalame += "Խ"; break;
                    case 5: kalame += "Ծ"; break;
                    case 6: kalame += "Կ"; break;
                    case 7: kalame += "Հ"; break;
                    case 8: kalame += "Ձ"; break;
                    case 9: kalame += "Ղ"; break;
                }

                switch (num % 10)
                {
                    case 1: kalame += "Ա"; break;
                    case 2: kalame += "Բ"; break;
                    case 3: kalame += "Գ"; break;
                    case 4: kalame += "Դ"; break;
                    case 5: kalame += "Ե"; break;
                    case 6: kalame += "Զ"; break;
                    case 7: kalame += "Է"; break;
                    case 8: kalame += "Ը"; break;
                    case 9: kalame += "Թ"; break;
                }
            }

            return kalame;
        }

        public static int ارمنی2(string kalame)
        {
            string num = "";
            if (kalame.Length < 5 && kalame.Length != 0)
            {
                int x;
                if (kalame.Length == 4)
                {
                    switch (kalame.Substring(0, 1))
                    {
                        case "Ռ": num += 1; break;
                        case "Ս": num += 2; break;
                        case "Վ": num += 3; break;
                        case "Տ": num += 4; break;
                        case "Ր": num += 5; break;
                        case "Ց": num += 6; break;
                        case "Ւ": num += 7; break;
                        case "Փ": num += 8; break;
                        case "Ք": num += 9; break;
                    }
                }

                x = kalame.Length - 3;
                if (kalame.Length > 3)
                {
                    switch (kalame.Substring(x, 1))
                    {
                        case "Ճ": num += 1; break;
                        case "Մ": num += 2; break;
                        case "Յ": num += 3; break;
                        case "Ն": num += 4; break;
                        case "Շ": num += 5; break;
                        case "Ո": num += 6; break;
                        case "Չ": num += 7; break;
                        case "Պ": num += 8; break;
                        case "Ջ": num += 9; break;
                    }
                }

                x = kalame.Length - 2;
                if (kalame.Length > 2)
                {
                    switch (kalame.Substring(x, 1))
                    {
                        case "Ժ": num += 1; break;
                        case "Ի": num += 2; break;
                        case "Լ": num += 3; break;
                        case "Խ": num += 4; break;
                        case "Ծ": num += 5; break;
                        case "Կ": num += 6; break;
                        case "Հ": num += 7; break;
                        case "Ձ": num += 8; break;
                        case "Ղ": num += 9; break;
                    }
                }

                x = kalame.Length - 1;
                if (kalame.Length > 2)
                {
                    switch (kalame.Substring(x, 1))
                    {
                        case "Ա": num += 1; break;
                        case "Բ": num += 2; break;
                        case "Գ": num += 3; break;
                        case "Դ": num += 4; break;
                        case "Ե": num += 5; break;
                        case "Զ": num += 6; break;
                        case "Է": num += 7; break;
                        case "Ը": num += 8; break;
                        case "Թ": num += 9; break;
                    }
                }
            }

            return Convert.ToInt32(num);
        }
    }
}
