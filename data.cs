using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJafr.Enums;

namespace HJafr.data_cls
{
    /// <summary>
    /// <right>داده‌ها</right>
    /// </summary>
    class data
    {
        /// <summary>
        /// <right>دایره‌های حروف</right>
        /// </summary>
        /// <param name="name">نام دایره دلخواه</param>
        /// <returns><right>حروف دایره دلخواه به ترتیب، بدون فاصله</right></returns>
        public static string d(d_name name = d_name.ابجد)
        {
            switch (name)
            {
                default:
                case d_name.ابجد: return "ابجدهوزحطیکلمنسعفصقرشتثخذضظغ";
                case d_name.ابتث: return "ابتثجحخدذرزسشصضطظعغفقکلمنوهی";
                case d_name.اهطم: return "اهطمفشذبوینصتضجزکسقثظدحلعرخغ";
                case d_name.ایقغ: return "ایقغبکرجلشدمتهنثوسخزعذحفضطصظ";

                case d_name.اجهب: return "اجهبوزردیکشخلسثظمفذغنتصضعحطق";
                case d_name.اجذش: return "اجذشظقنحبرصعکوتخزضغلهثدسطفمی";
                case d_name.ارغی: return "ارغیبدفتسقثشکجصلحضمخطتذظوزعه";
                case d_name.انسغ: return "انسغبمعظجلفضدکصذهیقخوطرثزحشت";

                case d_name.احست: return "احستبطعثجیفخدکصذهلقضومرظزنشغ";
                case d_name.اویل: return "اویلمنعجزکسفتحهرشثذصطبدخظغضق";
                case d_name.اجهز: return "اجهزطکمبدوحیلنسفقشثذظعصرتخضغ";
                case d_name.افسخ: return "افسجیعلمهضرزطغثبحظنخقکوتشصدذ";

                case d_name.اعهط: return "اعهطحفشقیضغظکصسلرثنذوجمزبختد";
                case d_name.احمد: return "احمدنبقذرتیوضلغخسشکجهزطفعثظص";
                case d_name.اموس: return "اموسیقرتضغخبحکزلدفشطصذثظجهنع";

                case d_name.نادعلی: return "نادعلیمظهرجبتوفکغسصحقشضطثزخذ";


                case d_name.عبری: return "אבגדהוזחטיכלמנסעפצקרשת";
                case d_name.انگلیسی: return "abcdefghijklmnopqrstuvwxyz";
            }
        }

        /// <summary>
        /// <right>اسم حروف</right>
        /// </summary>
        /// <param name="h"><right>حروف</right></param>
        /// <param name="space"><right>فاصله دار بودن بین اسم‌ها</right></param>
        /// <returns><right>اسامی حروف </right></returns>
        public static string esmharf(string h, bool space = false)
        {
            string payani = "";
            for (int i = 0; i < h.Length; i++)
            {
                switch (h.Substring(i, 1))
                {
                    case "ا": payani += "الف"; break;
                    case "ب": payani += "با"; break;
                    case "ج": payani += "جیم"; break;
                    case "د": payani += "دال"; break;
                    case "ه": payani += "ها"; break;
                    case "و": payani += "واو"; break;
                    case "ز": payani += "زا"; break;
                    case "ح": payani += "حا"; break;
                    case "ط": payani += "طا"; break;
                    case "ی": payani += "یا"; break;
                    case "ک": payani += "کاف"; break;
                    case "ل": payani += "لام"; break;
                    case "م": payani += "میم"; break;
                    case "ن": payani += "نون"; break;
                    case "س": payani += "سین"; break;
                    case "ع": payani += "عین"; break;
                    case "ف": payani += "فا"; break;
                    case "ص": payani += "صاد"; break;
                    case "ق": payani += "قاف"; break;
                    case "ر": payani += "را"; break;
                    case "ش": payani += "شین"; break;
                    case "ت": payani += "تا"; break;
                    case "ث": payani += "ثا"; break;
                    case "خ": payani += "خا"; break;
                    case "ذ": payani += "ذال"; break;
                    case "ض": payani += "ضاد"; break;
                    case "ظ": payani += "ظا"; break;
                    case "غ": payani += "غین"; break;
                }
                if (space) payani += " ";
            }
            return payani;
        }


        #region برج
        /// <summary>
        /// <right>نام برج‌ها</right>
        /// </summary>
        /// <param name="borj"><right>برج دلخواه</right></param>
        /// <returns><right>رشته نام برج</right></returns>
        public static string borj_name(برج borj)
        {
            switch (borj)
            {
                default:
                case برج.حمل: return "حمل";
                case برج.ثور: return "ثور";
                case برج.جوزا: return "جوزا";

                case برج.سرطان: return "سرطان";
                case برج.اسد: return "اسد";
                case برج.سنبله: return "سنبله";

                case برج.میزان: return "میزان";
                case برج.عقرب: return "عقرب";
                case برج.قوس: return "قوس";

                case برج.جدی: return "جدی";
                case برج.دلو: return "دلو";
                case برج.حوت: return "حوت";
            }
        }

        /// <summary>
        /// <right>حروف برج</right>
        /// </summary>
        /// <param name="borj"><right>برج دلخواه</right></param>
        /// <returns><right>حروف منتسب به برج</right></returns>
        public static string borj_harf(برج borj)
        {
            switch (borj)
            {
                default:
                case برج.حمل: return "اهط";
                case برج.ثور: return "دحل";
                case برج.جوزا: return "بوی";

                case برج.سرطان: return "جزک";
                case برج.اسد: return "طمف";
                case برج.سنبله: return "لعر";

                case برج.میزان: return "ینص";
                case برج.عقرب: return "کسق";
                case برج.قوس: return "فشذ";

                case برج.جدی: return "رخغ";
                case برج.دلو: return "صتض";
                case برج.حوت: return "قثظ";
            }
        }
        #endregion


        #region کوکب
        /// <summary>
        /// <right>نام کوکب</right>
        /// </summary>
        /// <param name="kokab"><right>کوکب دلخواه</right></param>
        /// <returns><right>نام کوکب دلخواه</right></returns>
        public static string kokab_name(کوکب kokab)
        {
            switch (kokab)
            {
                default:
                case کوکب.زحل: return "زحل";
                case کوکب.مشتری: return "مشتری";
                case کوکب.مریخ: return "مریخ";
                case کوکب.شمس: return "شمس";
                case کوکب.زهره: return "زهره";
                case کوکب.عطارد: return "عطارد";
                case کوکب.قمر: return "قمر";
            }
        }

        /// <summary>
        /// <right>صاحب طالع</right>
        /// </summary>
        /// <param name="borj"><right>برج دلخواه</right></param>
        /// <returns><right>کوکبی که صاحب طالع برج دلخواه محاسبه می‌شود</right></returns>
        public static کوکب borj_saheb_tale(برج borj)
        {
            switch (borj)
            {
                default: case برج.حمل: case برج.عقرب: return کوکب.مریخ;
                case برج.ثور: case برج.میزان: return کوکب.زهره;
                case برج.جوزا: case برج.سنبله: return کوکب.عطارد;
                case برج.سرطان: return کوکب.قمر;
                case برج.اسد: return کوکب.شمس;
                case برج.قوس: case برج.حوت: return کوکب.مشتری;
                case برج.جدی: case برج.دلو: return کوکب.زحل;
            }
        }
        #endregion

    }
}
