using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJafr.ElmHorouf;
using HJafr.Enums;
using HJafr.data_cls;
using HJafr.math_old_cls;
using HJafr.main_codes;
using System.Xml;
using System.IO;
using System.Reflection;

/// <summary>
/// <right>فال</right>
/// <right>نسخه: 1.15.0</right>
/// <right>تاریخ: 1403.07.11</right>
/// </summary>
namespace HJafr.fal_cs
{
    /// <summary>
    /// فال‌های ابجدی
    /// </summary>
    public class Fal_abjadi
    {
        #region درباره شخص
        // طالع : 101
        public static string tale_101(string name) { return Data.borj_name((برج)((Hesab.select(name) - 1) % 12)); }
        //  کوکب طالع : 202
        public static string kokab_tale_102(string name) { return Data.kokab_name((کوکب)((Hesab.select(name) - 1) % 7)); }
        //  طبع شخص : 103
        public static string tabe_shakhs_103(string name)
        {
            switch ((Hesab.select(name) - 1) % 4)
            {
                default:
                case 0: return "آتش";
                case 1: return "باد";
                case 2: return "آب";
                case 3: return "خاک";
            }
        }
        //  روش نوشتن دعا : 104
        public static string ravesh_doa_104(string name)
        {
            switch ((Hesab.select(name) - 1) % 4)
            {
                case 1: return "لوح معدنی : مس، آهن، سرب";
                case 2: return "لوح نباتی : کاغذ";
                default: return "لوح حیوانی : پوست";
            }
        }

        #endregion


        #region همسر
        // ازدواج کردن : 201
        public static string ezdevaj_201(string name) { return (Hesab.select(name) % 5) % 2 == 1 ? "ازدواج می‌کنند." : "ازدواج نمی‌کنند."; }
        //  دانستن احوال زنان : 202
        public static string ahval_zanan_202(string name)
        {
            switch ((Hesab.select(name) - 1) % 3)
            {
                case 1: return "زن مطلوب و عفیف است.";
                case 2: return "زن حرّه و بدون همسر است.";
                default: return "زن فاسد و خراب است.";
            }
        }
        //  دوستی میان زن و مرد : 203
        public static string doosti_zan_mard_203(string name)
        {
            switch ((Hesab.select(name) - 1) % 3)
            {
                case 1: return "دوستی بسیار باشد.";
                case 2: return "دوستی نباشد.";
                default: return "دوستی میانه باشد.";
            }
        }
        //  فال بطلیموس : 204
        public static string botlimoos_204(string name_a, string name_b)
        {
            int k = Math_Old.tarh_esghat(Hesab.select(name_a), 9);
            int g = Math_Old.tarh_esghat(Hesab.select(name_b), 9);
            int x = Math.Max(k, g);
            int y = Math.Min(k, g);

            switch (x)
            {
                default: case 1: return "زی بود نیکو.";

                case 2: return (y == 1) ? "کمال محبت بود." : "محبت ظاهری بود.";

                case 3:
                    switch (y)
                    {
                        default:
                        case 1: return "طبایع مختلف بود.";
                        case 2: return "محبت صاف بود.";
                        case 3: return "مخالف کلی بود.";
                    }


                case 4:
                    switch (y)
                    {
                        default:
                        case 1: return "دوستی و بدی.";
                        case 2: return "عاشق بوند و معشوق.";
                        case 3: return "اختلاف افعال بود.";
                        case 4: return "با هم یک جهت اند.";
                    }


                case 5:
                    switch (y)
                    {
                        default:
                        case 1: return "موافقت دایمی بود.";
                        case 2: return "عداوت و مخالفت بود.";
                        case 3: return "الفت محض بود.";
                        case 4: return "دوستی در ظاهر.";
                        case 5: return "محبت بود.";
                    }


                case 6:
                    switch (y)
                    {
                        default:
                        case 1: return "اختلاف اعمال بود.";
                        case 2: return "موافق باشند.";
                        case 3: return "یک جهت اند.";
                        case 4: return "یک دل و یک جهت اند.";
                        case 5: return "مطیع یکدیگرند.";
                        case 6: return "مخالفت در ظاهر بود.";
                    }


                case 7:
                    switch (y)
                    {
                        default:
                        case 1: return "دوستی در ظاهر بود.";
                        case 2: return "خصومت بود.";
                        case 3: return "درستی بود.";
                        case 4: return "محبت زبانی بود.";
                        case 5: return "کمال دوستی بود.";
                        case 6: return "فراق و محبت بود.";
                        case 7: return "مخالف باشند.";
                    }


                case 8:
                    switch (y)
                    {
                        default:
                        case 1: return "محبت همیشه بود.";
                        case 2: return "خصومت بود.";
                        case 3: return "هراسانی بود.";
                        case 4: return "یار و یاری بود.";
                        case 5: return "دوستی بود.";
                        case 6: return "موافقت باشد.";
                        case 7: return "اتفاق بود.";
                        case 8: return "محبت در ظاهر بود.";
                    }


                case 9:
                    switch (y)
                    {
                        default:
                        case 1: return "مشفق باشند.";
                        case 2: return "یک دل و یک جهت اند.";
                        case 3: return "دوستی در ظاهر بود.";
                        case 4: return "گریزان از هم بوند.";
                        case 5: return "محبت ظاهر بود.";
                        case 6: return "موافقت باشد.";
                        case 7: return "فراق بود.";
                        case 8: return "همیشه دشمنی بود.";
                        case 9: return "بسی نیک است.";
                    }

            }
        }
        //  فرزنددار شدن 1 : 205
        public static string farzand_1_205(string name) { return Hesab.select(name) % 13 == 0 ? "اولاددار نخواهد شد." : "اولاددار خواهد شد."; }
        //  فرزنددار شدن 2 : 206
        public static string farzand_2_206(string name) { return (Hesab.select(name) % 3 == 2) ? "فرزنددار می‌شوند." : "اولاددار نمی‌شوند."; }
        //  فرزنددار شدن 3 : 207
        public static string farzand_3_207(string name) { return (Hesab.select(name, D_int.صغیر) % 13 == 0) ? "اولاددار نمی‌شوند." : "فرزنددار می‌شوند."; }
        //  علت بچه‌دار نشدن : 208
        public static string elat_bachedar_nashodan_208(string name) { return (Hesab.select(name) % 9 == 0) ? "قصور از مرد است." : "قصور از زن است."; }
        // جنسیت جنین : 209
        public static string jens_jenin_209(string name)
        {
            switch (Hesab.select(name) % 3)
            {
                case 1: return "جنین پسر است.";
                case 2: return "جنین دختر است.";
                default: return "جنین ساقط می‌گردد.";
            }
        }
        //  مرگ همسر 1 : 210
        public static string marg_hamsar_1_210(string name) { return (Math_Old.tarh_esghat(Hesab.select(name), 5) % 2 == 1) ? "مرد زودتر می‌میرد." : "زن پیشتر می‌میرد."; }
        //  مرگ همسر 2 : 211
        public static string marg_hamsar_2_211(string name) { return (((Hesab.select(name, D_int.فال_1) + 20) % 7) % 2 == 1) ? "مرد پیشتر می‌میرد." : "زن زودتر می‌میرد."; }
        // زندگی کردن دو همسر تا آخر عمر : 212
        public static string zendegi_212(string name) { return (Math_Old.tarh_esghat(Hesab.select(name), 5) % 2 == 1) ? "تا آخر عمر می توانند با هم بمانند." : "نمی‌توانند تا آخر عمر با هم بمانند."; }

        #endregion


        #region بیماری و رنج
        //  طالعنامه پریان : 301
        public static string tale_parian_301(string name)
        {
            switch (Hesab.select(name) % 7)
            {
                case 1: case 2: return "نظر آوردن جن یا پری در شب یکشنبه و از جانب کشیش.";
                case 3: case 4: return "از جانب پریان نصرانی.";
                case 5: case 6: return "نظر آوردن پری اسلامی در شب دوشنبه.";
                default: return "از جانب پریان جهود.";
            }
        }
        //  سحر شدن : 302
        public static string sehr_shodan_302(string name)
        { return (Hesab.select(name) % 2 == 1) ? "هیچ سحر و جادویی برایش نوشته نشده است." : "برایش سحر و جادو نوشته‌اند."; }
        //  منشأ بیماری 1 : 303
        public static string manshaa_bimari_1_303(string name)
        {
            switch ((Hesab.select(name, D_int.صغیر) + 20) % 30)
            {
                default: return "منشأ انسانی دارد.";
                case 2: case 4: case 5: case 6: case 7: case 9: case 12: case 17: case 18: case 21: case 25: case 26: return "منشأ جنّی دارد.";
                case 14: case 16: case 20: case 22: case 27: return "منشأ نامرئی دارد.";
            }
        }
        //  منشأ بیماری 2 : 304
        public static string manshaa_bimari_2_304(string name)
        {
            switch (Hesab.select(name) % 5)
            {
                case 1: return "حکماً باید بیمار را مورد تداوی قرار دهند.";
                case 2: return "بیمار دچار چشم زخم شده است.";
                case 3: return "بیمار تحت سحر و افسون، جادو شده است.";
                case 4: return "در جسم بیمار جن رفته است.";
                default: return "بیمار توسط باد مریض شده است.";
            }
        }
        //  احوال مریض 1 : 305
        public static string ahval_mariz_1_305(string name)
        {
            switch (Hesab.select(name) % 7)
            {
                case 1: return "روز شنبه : بیماری‌اش 7 روز طول کشد و در خطر باشد باید که صدقه دهد.";
                case 2: return "روز یکشنبه : بیماری‌اش توسط چشم زخم است، صدقه دهد تا رفع شود.";
                case 3: return "روز دوشنبه : بیماری‌اش درد اندام است و از باد می‌باشد و زود به شود.";
                case 4: return "روز سه‌شنبه : بیماری‌اش از درد پشت و شکم است.";
                case 5: return "روز چهارشنبه : بیماری‌اش از خون است و تا 21 روز خطر دارد.";
                case 6: return "روز پنجشنبه : بیماری‌اش درد اندام است و از گرمی میباشد و تا 29 روز در خطر است.";
                default: return "روز جمعه : بیماری‌اش از خوف و خطر است و رنجوری دراز دارد.";
            }
        }
        //  احوال مریض 2 : 306
        public static string ahval_mariz_2_306(string name)
        {
            switch (Hesab.select(name) % 3)
            {
                case 1: return "مریض، زنده بماند.";
                case 2: return "اگر پنج‌شنبه است، دراز کشد و اگر یکشنبه یا چهارشنبه است، به شود و گرنه بمیرد.";
                default: return "اگر شنبه یا یکشنبه است، طول کشد و اگر دوشنبه یا سه‌شنبه است به شود وگرنه دراز کشد.";
            }
        }
        //  احوال مریض 3 : 307
        public static string ahval_mariz_3_307(string name)
        {
            switch (Hesab.select(name) % 3)
            {
                case 1: return "بیمار فوت کند.";
                case 2: return "بیمار بهبود یابد.";
                default: return "بیماری بیمار طول کشد.";
            }
        }
        //  احوال مریض 4 : 308
        public static string ahval_mariz_4_308(string name)
        {
            switch (Hesab.select(name) % 3)
            {
                case 1: return "مریض صحت یابد";
                case 2: return "بیماری آن طول کشد";
                default: return "مریض می‌میرد";
            }
        }
        //  احوال مریض 5 : 309
        public static string ahval_mariz_5_309(string name)
        {
            switch (Hesab.select(name) % 3)
            {
                case 1: return "بیمار فوت کند.";
                case 2: return "بیمار بهبود یابد.";
                default: return "بیماری بیمار طول کشد.";
            }
        }
        // لوح حیات و ممات 1 : 310
        public static string hayat_1_310(string name)
        {
            int h = Hesab.select(name) % 30;
            return (h == 1 || h == 2 || h == 3 || h == 7 || h == 11 || h == 13 || h == 14 || h == 16 || h == 17 || h == 19 || h == 20 || h == 22 || h == 23 || h == 26 || h == 28) ?
                "لوح حیات : بیمار نمی‌میرد" :
                "لوح ممات : بیمار می‌میرد";
        }
        // لوح حیات و ممات 2 : 311
        public static string hayat_2_311(string name)
        {
            int h = (Hesab.select(name) + 20) % 30;
            return (h == 1 || h == 2 || h == 9 || h == 10 || h == 11 || h == 12 || h == 13 || h == 14 || h == 15 || h == 16 || h == 17 || h == 19 || h == 22 || h == 23 || h == 27 || h == 28) ?
                "لوح حیات : بیمار نمی‌میرد" :
                "لوح ممات : بیمار می‌میرد";
        }
        // لوح حیات و ممات 3 : 312
        public static string hayat_3_312(string name)
        {
            int h = Hesab.select(name) % 30;
            return (h == 1 || h == 2 || h == 3 || h == 8 || h == 13 || h == 14 || h == 15 || h == 16 || h == 17 || h == 19 || h == 20 || h == 23 || h == 26 || h == 27 || h == 28) ?
                "لوح حیات : بیمار نمی‌میرد" :
                "لوح ممات : بیمار می‌میرد";
        }
        //  تشخیص بیماری و درمان : 313
        public static string tashkhis_bimari_313(string name)
        {
            switch (Hesab.select(name) % 12)
            {
                case 1: return "بیماری‌های وی از غلبه و فشار خون، قولنج، گرمی، زبان، چشم زخم، اعصاب و روان و خواب‌آشفتگی است که معمولا به خاطر حرارت بدن می‌باشد.";
                case 2: return "بیماری‌های وی، عطش و استسقاء، تب شدید، عموما غلبه صفراء، هذیان‌گویی در خواب، پاشنه پا را به زمین کشیدن است و در ناحیه پهلو، دنده‌ها و اضلاع، درد و ناراحتی خواهد داشت.";
                case 3: return "بیماری‌های وی عموما صفراوی و از غلبه صفرا است و بیماری‌های آن عموما‍ً پهلو می‌باشد.";
                case 4: return "پریشان حالی و بیماری‌های وی از غلبه خون و حرارت و زیادتی بلغم است که انواع بیماری‌های آن در ناحیه سر، چشم، گوش، بینی و بعضاً دنده‌ها و کمر می‌باشد.";
                case 5: return "سردرد، تب، قرمزی چشم و چشم درد، بیماری و یا نگرانی دائمی.";
                case 6: return "سردرد، چشم درد، گوش درد، درد بینی و پهلوها و دنده‌ها، معمولا بدن و اندام او درد می‌کند که علت آن غلبه حرارت و صفرا و غلبه خون می‌باشد.";
                case 7: return "بیماری‌های ناشی از غلبه خون و صفراء، خون دماغ ناشی از باد.";
                case 8: return "سر و روی و اعضاء و جوارح او درد می‌کند، گردن و یا دست و پای او کج می‌شود.";
                case 9: return "پریشانی، دردسر، چشم، گوش و سینه، دهان وی تلخ، چشمش تاریکی می‌کند که بیشتر از سنگینی معده است. در وی بیشتر غلبه خون و صفراست.";
                case 10: return "دردسر، کمر، عطش زیاد که منشاء آن تبی است که در اعضاء و جوارح دارد.";
                case 11: return "عدم آسایش، تب دارد، گاه گاه لرزه افتادن بر اندام، در خواب ناله می‌کند چون از خواب برخیزد، سرش دردگرفته، گیج می‌رود، کمردرد، پادرد و بعضی از بیماری‌های مزمن که نشای از انواع تب می‌باشد.";
                default: return "خواب پریشان، گلو و حلق درد و بیماری‌های حاکی از غلبه حرارت و صفرا از جمله، درد پهلو و دنده‌ها.";
            }
        }

        #endregion


        #region دیگر فالهای ابجدی
        //  ضمیر سایل : 401
        public static string zamir_sael_401(string name)
        {
            switch (Hesab.select(name) % 7)
            {
                case 1: return "سلطان";
                case 2: return "زنان";
                case 3: return "کتاب و علم";
                case 4: return "سفر";
                case 5: return "دروغ و مکر";
                case 6: return "شر و خصومت";
                default: return "قوت و دشمنی";
            }
        }
        //  غالب و مغلوب : 402
        public static string ghaleb_maghloob_402(string a, string b)
        {
            bool payani;
            int x = Hesab.select(a);
            int y = Hesab.select(b);

            if (x == y)     //  دو عدد برابر
                payani = (x % 2 != 0);      //  زوج : مطلوب غالب   -   فرد : طالب غالب
            else
            {
                payani = (x < y);       //  هر دو زوج یا هر دو فرد : کمتر غالب
                if (x % 2 != y % 2)
                    payani = !payani;       //  مختلف در زوج و فرد : بیشتر غالب
            }
            return payani ?
                (a + " غالب است و " + b + " مغلوب") :
                (b + " غالب است و " + a + " مغلوب");
        }
        // زمان شروع کار : 403
        public static string zaman_shoroo_kar_403(int x, int y)
        {
            int h = (y <= 6) ?
                (x + (y - 1) * 31) % 3 :
                (x + 186 + (y - 7) * 30);
            h %= 3;

            return (h == 1) ? "البیت الجیده : شروع کن که خیر و سعادت بینی" :
                (h == 2) ? "البیت المتوسطه : در انجام کار مخیر هستی" :
                "البیت الروّیه : آن کار را نکن که ضرر می‌بینی";      //  h == 0
        }
        //  حاجت روایی : 404
        public static string hajat_rava_404(string name)
        {
            switch (Hesab.select(name) % 3)
            {
                case 1: return "روا نشود.";
                case 2: return "به زحمت روا شود";
                default: return "روا شود.";
            }
        }
        //  اقامت : 405
        public static string eghamat_405(string name)
        {
            switch (Hesab.select(name) % 4)
            {
                case 1: return "رنج و سختی کشد.";
                case 2: return "متوسط باشد.";
                case 3: return "اندک رزق در آن محل باشد.";
                default: return "سعادت و دولت نصیبش گردد.";
            }
        }
        //  رفع اختلاط : 406
        public static string rafe_ekhtelat_406(string name)
        { return (Math_Old.tarh_esghat(Hesab.select(name) + 32, 9) % 2 == 1) ? "اختلاط حل نشود." : "اختلاط حل شود."; }
        //  دستگیری سارق : 407
        public static string dastgiri_saregh_407(int x, int y)
        {
            int h = (y <= 6) ?
                (x + (y - 1) * 31) % 3 :
                (x + 186 + (y - 7) * 30);
            h %= 36;

            return (h >= 30 && h <= 35) || (h < 30 && h % 3 == 0) ?
                "رجوع : دستگیری سارق" :
                "عدم رجوع : ناتوانی از دستگیری";
        }
        //  ادامه شراکت : 408
        public static string sherakat_408(string name)
        { return (Math_Old.tarh_esghat(Hesab.select(name), 5) % 2 == 1) ? "ادامه شراکت امکان دارد." : "ادامه شراکت نمی‌شود یا به سختی است."; }
        //  وضع غایب 1 : 409
        public static string vaze_ghaeb_1_409(int x, int y)
        {
            int h = (y <= 6) ?
                (x + (y - 1) * 31) % 3 :
                (x + 186 + (y - 7) * 30);
            h += (h + 20) % 36;

            return h % 3 == 2 || h == 0 ? "بازگشت" : "عدم بازگشت";
        }
        //  وضع غایب 2 : 410
        public static string vaze_ghaeb_2_410(string name)
        {
            switch (Hesab.select(name) % 4)
            {
                case 1: return "غایب در حبس است.";
                case 2: return "غایب جای دوری است.";
                case 3: return "غایب مریض است.";
                default: return "غایب سالم و خشنود است.";
            }
        }
        //  وضع غایب 3 : 411
        public static string vaze_ghaeb_3_411(string name)
        {
            switch (Hesab.select(name) % 12)
            {
                case 1: return "غایب می‌آید با مال فراوان.";
                case 2: return "مشغول باشد به خدمت دولتی.";
                case 3: return "در آمدن درنگی داشته باشد.";
                case 4: return "جای خوبی دارد.";
                case 5: return "خسته نباشد.";
                case 6: return "درست و صحیح است.";
                case 7: return "صحیح و سالم است.";
                case 8: return "در آن محل خواهد ماند.";
                case 9: return "مریض سختی باشد.";
                case 10: return "در راه است، می‌آید.";
                case 11: return "از آنجا بجای دیگری منتقل می‌شود.";
                default: return "برحمت حق پیوسته است.";
            }
        }

        #endregion
    }

    public class Fal_jadvali
    {
        /// <summary>
        /// فالنامه شیخ بهایی
        /// </summary>
        /// <param name="harf_int">خانه شروع</param>
        /// <param name="jadval">جدول</param>
        /// <param name="gam">گام</param>
        /// <returns></returns>
        public static string[] sheikh_bahai(int harf_int, string jadval, int gam = 6)
        {
            harf_int--;
            if (harf_int == -1)
                harf_int += jadval.Length;

            string all_fal = Taksir.laght(jadval, harf_int, gam, 1, اتصال_لقط.منفصل, true);
            string[] line = new string[2] { "", "" };
            for (int i = 0; i < all_fal.Length; i++)
                line[i % 2] += all_fal.Substring(i, 1);

            return line;
        }
        /// <summary>
        /// فال مفتاح الغیوب
        /// </summary>
        /// <param name="harf_int">خانه شروع</param>
        /// <param name="jadval">جدول</param>
        /// <param name="gam">گام</param>
        /// <returns></returns>
        public static string meftah_alghouob(int harf_int, string jadval, int gam = 48) { return Taksir.laght(jadval, harf_int, gam, 1, اتصال_لقط.منفصل, true); }
        /// <summary>
        /// فالنامه ابن عربی
        /// </summary>
        /// <param name="harf_int">خانه شروع</param>
        /// <param name="jadval">جدول</param>
        /// <param name="gam">گام</param>
        /// <returns></returns>
        public static string fal_ibn_arabi(int harf_int, string jadval, int gam = 5) { return Taksir.laght(jadval, harf_int, gam, 1, اتصال_لقط.منفصل, true); }
        /// <summary>
        /// فال مجرب شیخ بهایی
        /// </summary>
        /// <param name="harf_int">خانه شروع</param>
        /// <param name="jadval">جدول</param>
        /// <param name="gam">گام</param>
        /// <returns></returns>
        public static string fal_mojarab_sb(int harf_int, string jadval, int gam = 9) { return Taksir.laght(jadval, harf_int, gam, 1, اتصال_لقط.منفصل, true); }

        public static string[] fal_jafr_saghir_1(string soal, string tarikh, int saat, string lesan_al_gheib, string name_sael, bool day)
        {
            List<string> payani = new List<string>();

            int[] madkhal_soal = Hesab.madakhel_arbae(soal);
            int jame_madakhel = madkhal_soal[0] + madkhal_soal[1] + madkhal_soal[2] + madkhal_soal[3];
            string[] harf_4 = new string[4];
            harf_4[0] = Stentagh.makani(madkhal_soal[0] + madkhal_soal[1] + madkhal_soal[2] + madkhal_soal[3]);        //  حرف اول : سوال
            harf_4[1] = Stentagh.makani(Hesab.rad_be_ahad( Hesab.select(tarikh)));       //  حرف دوم : تاریخ
            harf_4[2] = Stentagh.makani(day ? saat : 27 - saat);      //  حرف سوم : ساعت

            int harf_4_4 = Hesab.select(lesan_al_gheib, D_int.افلاکی);
            harf_4[3] = Stentagh.makani(harf_4_4 <= 28 ? harf_4_4 :
                Hesab.madkhal_vasit(harf_4_4));

            int harf_4_kabir = Hesab.select(harf_4[0] + harf_4[1] + harf_4[2] + harf_4[3]);     //  کبیر 4 حرف
            int jadval_index = Math_Old.tarh_esghat(harf_4_kabir, 12);      //  طرح بروجی کبیر 4 حرف : شماره جدول
            برج borj = (برج)(jadval_index - 1);
            string borj_name = Data.borj_name(borj);     //  نام برج

            int start = Math_Old.tarh_esghat(           //  خانه شروع : طرح افلاکی موارد زیر
                harf_4_kabir +                                  //  چهار حرف
                Hesab.select(name_sael) +               //  کبیر نام سائل
                Hesab.select(Data.borj_harf(borj)),      //  کبیر حروف برج
                9)          //  عدد اسقاط
                - 2;        //  تبدیل عدد به جایگاه (از صفر)ا

            string jadval = get_data_xml("HJafr.xml.fal.fal_jafr_saghir_1.xml", jadval_index);      //  متن جدول

            string a = Taksir.laght(jadval, start, 9, 1, اتصال_لقط.متصل_حذفی);
            a=a.Replace("ﻻ", "");
            string b = Asas_Dour.asas(a);
            string c = Asas_Dour.aamal_riazi(b, 3,عمل_ریاضی.جمع,  D_name.اجهز2);
            string d = Asas_Dour.asas(c,D_name.اجهز2);
            string e = Asas_Dour.asas(d);
            string f = Taksir.zomam_once(e, true, true, false);

            {
                int ff = f.Length;
               payani.Add(                   harf_change_cls.Harf_Change.space(a) + "\n\n" +
                   harf_change_cls.Harf_Change.space(b) + "\n\n" +
                   harf_change_cls.Harf_Change.space(c) + "\n\n" +
                   harf_change_cls.Harf_Change.space(d) + "\n\n" +
                   harf_change_cls.Harf_Change.space(e) + "\n\n");
            }






            /*
            payani.Add(borj.ToString());        //  جدول و برج
            payani.Add(shoroe.ToString());      //  خانه شروع
            payani.AddRange(code.ToString(madkhal_soal.ToList()));      //  مداخل اربعه
            payani.Add(jame_madakhel.ToString());       //  جمع مداخل
            payani.AddRange(harf_4);        //  4 حرف
            payani.AddRange(code.ToString(start_before.ToList()));     //  3 عدد آخر
            */


            return payani.ToArray();
        }

        public static string get_data_xml(string xml_str, int index)
        {
            XmlDocument xml = new XmlDocument();

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(xml_str))
            using (StreamReader reader = new StreamReader(stream))
            {
                xml.LoadXml(reader.ReadToEnd());
            }

            XmlNode node = xml.SelectSingleNode("/fal/jadval[@index='" + index + "']");
            return node.Attributes["text"].Value;
        }

    }
}
