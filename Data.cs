using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJafr.Enums;
using Telerik.Windows.Controls;

/// <summary>
/// <right>داده‌ها</right>
/// <right>نسخه: 1.11.0</right>
/// <right>تاریخ: 1403.07.11</right>
/// </summary>
namespace HJafr.data_cls
{
    /// <summary>
    /// <right>داده‌ها</right>
    /// </summary>
    class Data
    {
        /// <summary>
        /// <right>دایره‌های حروف</right>
        /// </summary>
        /// <param name="name">نام دایره دلخواه</param>
        /// <returns><right>حروف دایره دلخواه به ترتیب، بدون فاصله</right></returns>
        public static string d(D_name name = D_name.ابجد)
        {
            switch (name)
            {
                /// اصلی
                default:
                case D_name.ابجد: return "ابجدهوزحطیکلمنسعفصقرشتثخذضظغ";
                case D_name.ابتث: return "ابتثجحخدذرزسشصضطظعغفقکلمنوهی";
                case D_name.اهطم: return "اهطمفشذبوینصتضجزکسقثظدحلعرخغ";
                case D_name.ایقغ: return "ایقغبکرجلشدمتهنثوسخزعذحفضطصظ";

                /// ا
                //  ب
                case D_name.ابجدمغاربه: return "ابجدهوزحطیکلمنصعفضقرستثخذظغش";      //  غربی
                case D_name.ابجد3: return "ابجدهوزنملکیطحسعفصقرشغظضذخثت";
                case D_name.ابهو: return "ابهوطیمنفصشتذضجدزحکلسعقرثخظغ";
                case D_name.ابهش: return "ابهشحذلجقوطصسنثفغظزتکعرخیدضم";
                case D_name.ابتج: return "ابتجحدرسصطعفکومنثخیذزشضظغقله";
                //  ج
                case D_name.اجهب: return "اجهبوزردیکشخلسثظمفذغنتصضعحطق";
                case D_name.اجهز: return "اجهزطکمبدوحیلنسفقشثذظعصرتخضغ";
                case D_name.اجهز2: return "اجهزطکمسفقشثذظبدوحیلنعصرتخضغ";
                case D_name.اجهز3: return "اجهزطکمبدوحیلنعصرتخضغسفقشثذظ";
                case D_name.اجهز4: return "اجهزطکمسفقشثذظغضخترصعنلیحودب";
                case D_name.اجعف: return "اجعفرشنزغتضخیبهکمصدطلزحوثظسق";
                case D_name.اجنذ: return "اجنذیلحسقشوفغدسضبمخطکتزصرهعظ";
                case D_name.اجذش: return "اجذشظقنحبرصعکوتخزضغلهثدسطفمی";
                case D_name.اجذش2: return "اجذشظقنبحرصعکوتخزضغلهثدسطفمی";
                case D_name.اجذش3: return "اجذشظقنبحرصعکوتخزضغلهثدسطفمی";
                case D_name.اجذش4: return "اجذشظقنیمفطسدثبحرصعکوهلغضزخت";
                //  د
                case D_name.ادجه: return "ادجهزکلسعفشثخذبحوطیمنصقرتضظغ";
                case D_name.ادزی: return "ادزیمعقتذغبهحکتفرثضجوطلسصشخظ";
                case D_name.ادزی2: return "ادزیمعقتذغجوطلسصشخظبهحکنفرثض";
                case D_name.ادزی3: return "ادزیمعقتذغضثرفنکحهبجوطلسصشخظ";
                case D_name.ادثت: return "ادثتجیظصهکمضبشفعوخذحزلعطرسنق";
                case D_name.ادضک: return "ادضکیقصخبذطلهفشحترظموغسجثزعن";
                //  ه‍
                case D_name.اهوی: return "اهویکبمدفحقعظشنذغتضخرجصزثطلس";
                case D_name.اهحط_نور: return "اهحطیکلمنسعصقربجدوزفشتثخذضظغ";
                case D_name.اهطم2: return "اهطمفشذغخرعلحدبوینصتضظثقسکزج";
                case D_name.اهثم: return "اهثمخقرعشضطسغذکحنتیبوجلدفزظص";
                //  و
                case D_name.اوزی: return "اوزیمعقتذغبهحکنفرتضجدطلسصشخظ";
                case D_name.اوزی2: return "اوزیمعقتذغبهحکنفرثضجدطلسصشخظ";
                case D_name.اویل: return "اویلمنعجزکسفتحهرشثذصطبدخظغضق";
                case D_name.اویل2: return "اویلمنعهرشثذصطجزکسفتحبدخظغضق";
                case D_name.اوکع: return "اوکعشضجحمصثغهیسرذبزلفتظدطنقخ";
                case D_name.اوضک: return "اوضکبذطلتذطمثرعنجسغهحشفزخصقی";
                //  ز
                case D_name.ازمق: return "ازمقذجطسشظهکفثبحنرضدیعتغولصخ";
                case D_name.ازمق2: return "ازمقذبحنرضجطسشظدیعتغهکضثولصخ";
                case D_name.ازمق3: return "ازمقذضرنحبولصخظشسطجهکفثغتعید";
                //  ح
                case D_name.احجش: return "احجشبدلهطسعقفصثونتیکمخذظغرضز";
                case D_name.احزط: return "احزطقوتدشعلیجرضفنبخسظکهثذصغم";
                case D_name.احزط2: return "احزطقوثدشعلیجرصفنبخسظکهتذضغم";
                case D_name.احطم: return "احطمرشغبزینقتظجوکسصثضدهلعفخذ";
                case D_name.احمد: return "احمدنبقذرتیوضلغخسشکجهزطفعثظص";
                case D_name.احسی: return "احسینقکرمتفثذغبلعشخدهطزوصجضظ";
                case D_name.احسن: return "احسنقیرکتمضفغذثلبعودهجزطشصخظ";
                case D_name.احست: return "احستبطعثجیفخدکصذهلقضومرظزنشغ";
                case D_name.احست2: return "احستغشنزبطعثظرموجیفخضقلهدکصذ";
                //  ط
                case D_name.اطفذ: return "اطفذهمشبیصضونتجکقظزسثدلرغحعخ";
                case D_name.اطفذ2: return "اطفذونتجکقظحعخهمشبیصضزسثدلرغ";
                case D_name.اطفذ3: return "اطفذبیصضجکقظدلرغهمشونتزسثحعخ";
                case D_name.اطفذ4: return "اطفذخعحبیصضثسزجکقظتنودلرغشمه";
                //  ی
                case D_name.ایبه: return "ایبهتوثنجمحلخکدقذفرغزعسظشطصض";
                case D_name.ایقغ2: return "ایقغطصظحفضزعذوسخهنثدمتجلشبکر";
                case D_name.ایقغ3: return "ایقغفسبکرجلشنعدمتهصثوخزذحضطظ";
                case D_name.ایقغ4: return "ایقغبثسکرجلشفطدمتهنوصخزعذحضظ";
                case D_name.ایقغ5: return "ایقغرکبطصظشلجحفضتمدزعذثنهوسخ";
                //  ک
                case D_name.اکدح: return "اکدحطهجیلنمعفقوثسشتبذزضخظصغر";
                case D_name.اکدخ: return "اکدخیرمزقجتذغلهحفشصضسنثطبعوظ";
                case D_name.اکصذ: return "اکصذهحظغثنزسمتفطخیدضقبلشروجع";
                case D_name.اکشب: return "اکشبلتجمثدنخهسذوعضزفظحصغطقیر";
                case D_name.اکشب2: return "اکشبلتجمثدنحهسروغزطیعفصقخذضظ";
                case D_name.اکشج: return "اکشجمثهسذزفظطقبلتدنخوعضحصغیر";
                case D_name.اکذق: return "اکذقجشعهخنبلتوسصزثضرظعذمحیفط";
                //  ل
                case D_name.الهط: return "الهطحیومبفدقزسشکخغرتضعذنتصجظ";
                case D_name.الهط2: return "الهطحیومبفدقزسشکخغرتضعذنثصجظ";
                case D_name.الشب: return "الشبمخجنذدسصهعظوفغزضحقطریکتث";
                case D_name.الثب: return "الثبمخجنذدسضهعظوفغزصحفطریشکت";
                case D_name.الثو: return "الثوفغکتهعظیشدسضطرجنذحقبمخزص";
                //  م
                case D_name.اموس: return "اموسیقرتضغخبحکزلدفشطصذثظجهنع";
                case D_name.امرض: return "امرضغحیجفصزلبنذطعخهثقشسکتودظ";
                case D_name.امذب: return "امذبنضجسظدعغهفوصزقحرطشیتکثلخ";
                case D_name.امذط: return "امذطشهفبنضیتوصجسظکثزقدعغلخحر";
                case D_name.امذر: return "امذرحوصظسجکثتیدعغفهطشخلبنضقز";
                //  ن
                case D_name.اندع: return "اندعضزکثیجقسصغخوبمذظطرلتهحفش";
                case D_name.انسج: return "انسجیلعمهضرزطغثبحظنخقکوتفصدذ";
                case D_name.انسغ: return "انسغبمعظجلفضدکصذهیقخوطرثزحشت";
                case D_name.انظب: return "انظبسغجعدفهصوقزرحشطتیثکخلذمض";
                case D_name.انظل: return "انظلذیثحشوقدفبسغمضکخطتزرهصجع";
                case D_name.انظف: return "انظفدکخرزحشثیهصضمبسغعجلذقوطت";
                //  س
                case D_name.اسبع: return "اسبعجفدصهقورزشحتطثیخکذلضمظنغ";
                case D_name.اسغن: return "اسغنبعظمجفضلوصذکهقخیورثطزشتح";
                case D_name.اسغن2: return "اسغنبعظمجفضلدصذکهقخیورثطزشتح";
                case D_name.اسغن3: return "اسغنبعظمجفضلدصذکهقخیورثطزشتح";
                //  ع
                case D_name.اعجص: return "اعجصهرزتطخکضمغسبفدقوشحثیذلظن";
                case D_name.اعهط: return "اعهطحفشقیضغظکصسلرثنذوجمزبختد";
                case D_name.اعهط2: return "اعهطحقشسلرثنودفیضغظکصجمزبختذ";
                case D_name.اعکج: return "اعکجصوذرهشحلظبغقثضندزیسخمطتف";
                case D_name.اعلی: return "اعلیقحتضغخرطکمفبثسزدجنوهصشزظ";
                //  ف
                case D_name.افهش: return "افهشطذمبصوتیضنجقزثکظسدرحخلغع";
                case D_name.افوت: return "افوتکظعهشیضسدرطزنجقحخمبصذثلغ";
                case D_name.افطم: return "افطمهقلزسثکغینحجوردعبصشختذضظ";
                case D_name.افسج: return "افسجیعلمهضرزطغثبحظنخقکوتشصدذ";
                case D_name.افسج2: return "افسجعیلمهضرزطغثبحظنخقکوتشصدذ";
                case D_name.افسج3: return "افسجیلعمهضرزطغثبحظنخقکوتشصدذ";
                case D_name.افسج4: return "افسجعیلمهصرزطغثبحظنخقکوتشضدذ";
                case D_name.افعت: return "افعتکطجمصخوسذیرزهدشنحضلثظقبغ";
                case D_name.افخح: return "افخحیضسجقتولغمهشردنظکزثصبعذط";
                //  ص
                case D_name.اصهظ: return "اصهظثزمفخدقلرجعوشبضیطتسنغحذک";
                case D_name.اصحذ: return "اصحذسهتلبقطضعوثمجریظفزخندشکغ";
                case D_name.اصزخ: return "اصزخمبقحذنجرطضسدشیظعهتکغفوثل";
                case D_name.اصته: return "اصتهنضطیظموثفبقشدسذحکغلزخعجر";
                //  ق
                case D_name.اقبر: return "اقبرلدتنوخعحضصیغکجشمهثسرذفطظ";
                case D_name.اقبر2: return "اقبرلدتنوخعحضصیغکجشمهثسزذفطظ";
                case D_name.اقیغ: return "اقیغوخسکبرعزذشلجضفحدتمطظصهنث";
                case D_name.اقطظ: return "اقطظفزذسهثمجشکبریغصحضعوخندتل";
                case D_name.اقرب: return "اقربصشجفتدعثهسخونذزمضحلظطکغی";
                //  ر
                case D_name.ارکب: return "ارکبشلجتمدثنهخسوذعزضفحظصطغقی";
                case D_name.ارصج: return "ارصجتعهخنزضلطغیکظحمذوسثدفشبق";
                case D_name.ارلد: return "ارلدثسزضصیبشمهخعحظقکجتنوذفطغ";
                case D_name.ارغی: return "ارغیبدفتسقثشکجصلحضمخطتذظوزعه";
                case D_name.ارغی2: return "ارغیذعهدظوخطنحضمجصلثشکتسقبزف";
                case D_name.ارغی3: return "ارغیبزفتسقثشکجصلحضمخطندظوذعه";
                case D_name.ارغی4: return "ارغیفزبذعهقستدظوکشثخطنلصجحضم";
                //  ش
                case D_name.اشمه: return "اشمهذفطبتنوضصیجثسزظقکدخعحغرل";
                case D_name.اشنف: return "اشنفدحعهضتزلکرثطیظجذقمسبصوغخ";
                //  ت
                case D_name.اتجخ: return "اتجخذزشضظغقلنهبثحدرسصطعفکموی";
                case D_name.اتجخ2: return "اتجخذزشضظغقلنهیومکفعطصسردحثب";
                case D_name.اتنط: return "اتنطظوفقدذکلخجرعزغحسشبثمیضهص";
                case D_name.اتسح: return "اتسحبثعطجخفیدذصکهضقلوظرمزغشن";
                //  ث
                case D_name.اثفک: return "اثفکهظشسطجذقمزبخصلوغتعیدضرنح";
                case D_name.اثصم: return "اثصمحجذرسیهظتفلزبخقنطدضشعکوغ";
                case D_name.اثخر: return "اثخرشطغکنیتحزسضعقمهبجودذصظفل";
                case D_name.اثخر2: return "اثخرشطغکنیولفظصزدجبتحذسضعقمه";
                case D_name.اثخر3: return "اثخزشطغکنیتحذسضعقمهبجدرصظفلو";
                //  خ
                case D_name.اخیس: return "اخیسقوغهرنکثبذطعصزظدشملتجضحف";
                case D_name.اخقن: return "اخقنطدظتفلزبذرسیهغثصمحجضشعکو";
                case D_name.اخشغ: return "اخشغنوفصدبحسعمهقضذتجزظلیکطرث";
                //  ذ
                case D_name.اذحص: return "اذحصسکتدغهشلنقزضبخطفعیثجظورم";
                case D_name.اذشف: return "اذشفمطهبضتصنیوجظثقسکزدغخرعلح";
                case D_name.اذظن: return "اذظنمطدبرعولضختزغهکصحثسفیقشج";
                //  ض
                case D_name.اضیص: return "اضیصبطهشتظوسثعنزجغمرحفلذخقکد";
                case D_name.اضثر: return "اضثرفنکحهبظخشصسلطوجغذتقعمیزد";
                case D_name.اضخت: return "اضخترصعنلیحودبظذثشقفسمکطزهجغ";
                //  ظ
                case D_name.اظبغ: return "اظبغجهدوزطحیکملنسفعصقشرتثذخض";
                case D_name.اظدخ: return "اظدخزشیصمسعلقطتوذجغبضهثحرکفن";
                case D_name.اظمد: return "اظمدروضتغکحسیشجقفثصهزخلعبطنذ";
                case D_name.اظذث: return "اظذثشقفسمکطزهجبغضخترصعنلیحود";
                //  غ
                case D_name.اغبظ: return "اغبظجضدذهخوثزتحشطریقکصلفمعنس";
                case D_name.اغفب: return "اغفبعقتظکثطلجضمحصنخشودسهذزیر";
                case D_name.اغظض: return "اغظضذخثتشرقصفعسنملکیطحزوهدجب";


                /// ب
                case D_name.بدوح: return "بدوحیلنعصرتخضغظذثشقفسمکطزهجا";
                case D_name.بثحد: return "بثحدرسصطعفکمویهنلقغظضشزذخجتا";
                //case d_name.سوره112: return "بسمالهرحنیقودصکفجزطعشتثخذضظغ";


                /// د
                case D_name.دحلع: return "دحلعرخغذشفمطهاجزکسقثظضتصنیوب";
                case D_name.دطمن: return "دطمنظذاخضلوعربحصکهغزتجشقیفسث";

                /// ز
                case D_name.زنشغ: return "زنشغتسحاومرظثعطبهلقضخفیجدکصذ";

                /// ح
                case D_name.حعخذ: return "حعخذفطازسثضصیبونتظقکجهمشغرلد";

                /// ط
                case D_name.طنذخ: return "طنذخلعبصهزجقفثسیشتغکحروضاظمد";

                /// ی
                case D_name.یاهب: return "یاهبوتنثمجلحکخقدفذغرعزظسطشضص";

                /// ن
                case D_name.نادعلی: return "نادعلیمظهرجبتوفکغسصحقشضطثزخذ";
                case D_name.نخعص: return "نخعصزقثیتکرضظدماوحغشسفجهبلذط";
                case D_name.نغسا: return "نغسامظعبلضفجکذصدیخقهطثروحتشز";

                /// س
                case D_name.سوال: return "سوالعظیمخقحزتفصنذغربشکضطهجدث";

                /// ع
                case D_name.عذطز: return "عذطزثصبنظکهشردلغمجقتویضسافخح";

                /// ص
                case D_name.صیضا: return "صیضاشهطبسوظتزنعثرمغجذلفحدکقخ";

                /// ت
                case D_name.تثخذ: return "تثخذضظغشرقصفعسحطیکلمنزوهدجبا";

                /// ث
                case D_name.ثدسط: return "ثدسطفمینقظشذجاتخزضغلهوکعصرحب";

                /// خ
                case D_name.خدیع: return "خدیعضاجلصکطقفزوحثشغذبسهرتنظم";
                case D_name.خصقی: return "خصقیکضداحشفهلطذبجسغومظرتثزعن";

                /// ذ
                case D_name.ذزصن: return "ذزصنکشدغجتیسفحخاضوقملرهظبثطع";

                /// غ
                case D_name.غاظب: return "غاظبضجذدخهثوتزشحرطقیصکفلعمسن";
                case D_name.غسنا: return "غسناظعمبضفلجذصکدخقیهثرطوتشحز";

                /// سوره‌های قرآن
                case D_name.سوره1: return "بسمالهرحنیدعکوتصطقذغضجزفشثخظ";



                case D_name.عبری: return "אבגדהוזחטיכלמנסעפצקרשת";
                case D_name.انگلیسی: return "abcdefghijklmnopqrstuvwxyz";
            }
        }
        public static string dayere_harf_name(D_name name = D_name.ابجد)
        {
            switch (name)
            {
                default: return name.ToString();

                //  استثنائات
                case D_name.ابجدمغاربه: return "ابجد مغاربه";       //  غربی
                case D_name.ابهو: return "ابهو : ربعات القمر";
                case D_name.اجهب: return "اجهب اعرابی";
                case D_name.اهحط_نور: return "اهحط: نورانی";
                case D_name.افسج2: return "افسج2 : افسج بروجی";

                case D_name.سوال: return "سوال عظیم : قطب";
                case D_name.خدیع: return "خدیع : منظوم";

                /// سوره‌های قرآن
                case D_name.سوره1: return "سوره 1 : حمد";
            }
        }

        public static string dayere_adad_name(D_int name = D_int.kabir)
        {
            switch (name)
            {
                default: return "بی‌نام!";
                case D_int.kabir: return "کبیر";
                case D_int.معکوس: return "معکوس";
                case D_int.وضعی: return "وضعی";
                case D_int.افلاکی: return "افلاکی";
                case D_int.صغیر: return "صغیر";
                case D_int.بروجی: return "بروجی";

                case D_int.عناصری: return "عناصری";
                case D_int.کواکبی: return "کواکبی";
                case D_int.منازلی: return "منازلی (قمری)";
                case D_int.آحاد: return "آحاد";
                case D_int.عشرات: return "عشرات";
                case D_int.مآت: return "مآت";
                case D_int.الوف: return "الوف";

                case D_int.ابجدادریسی: return "ابجد ادریسی";
                case D_int.ابجدعددوسط: return "ابجد عدد وسط";
                case D_int.ابجدثانی: return "ابجد ثانی";
                case D_int.ابجدعلوی: return "ابجد علوی";
                case D_int.ابجدازامیر: return "ابجدی از امیرالمؤمنین ع";
                case D_int.ابجدشعیب: return "ابجد شعیب ع";
                case D_int.ابجدنبوی: return "ابجد نبوی";

                case D_int.ابتث_آدم: return "ابتث آدم ع";
                case D_int.ابتث_امیر: return "ابتث امیر ع";
                case D_int.ابتث_صادق: return "ابتث امام صادق ص";

                case D_int.اهطم_مرتبه: return "اهطم مرتبه";
                case D_int.اهطم_هجا: return "اهطم هجا";
                case D_int.اهطم_فیثاغورث: return "اهطم فیثاغورث";
                case D_int.اهطم_دانیال: return "اهطم دانیال ع";
                case D_int.اهطم_وسطی: return "اهطم وسطی";
                case D_int.اهطم_مثلثات: return "اهطم مثلثلات";
                case D_int.اهطم_تسلط: return "اهطم غایت تسلط";
                case D_int.اهطم_مراد: return "اهطم نهایت المراد";

                case D_int.ایقغ_ابجدکبیر: return "ایقغ ابجدی کبیر";
                case D_int.ایقغ_یوشع: return "ایقغ یوشع بن نون ع";
            }
        }

        //  گرفتن آیتم برای دایره‌های حروف
        public static RadComboBox dayere_harf_item(RadComboBox list_drop)
        {
            RadComboBoxItem[] d_items = new RadComboBoxItem[(int)D_name.end];
            for (int i = 0; i < d_items.Length; i++)
            {
                d_items[i] = new RadComboBoxItem();
                d_items[i].Content = dayere_harf_name((D_name)i);
                list_drop.Items.Add(d_items[i]);
            }
            return list_drop;
        }
        //  گرفتن آیتم برای دایره‌های عدد
        public static RadComboBox dayere_adad_item(RadComboBox list_drop)
        {
            RadComboBoxItem[] d_items = new RadComboBoxItem[(int)D_int.فال_1];
            for (int i = 0; i < d_items.Length; i++)
            {
                d_items[i] = new RadComboBoxItem();
                d_items[i].Content = dayere_adad_name((D_int)i);
                list_drop.Items.Add(d_items[i]);
            }
            return list_drop;
        }


        /// <summary><right>اسم حروف</right></summary>
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


        public static string payamha(پیام payam)
        {
            switch (payam)
            {
                default: return "";

                //  head
                case پیام.خطا: return "خطا!";

                //  tooltip
                case پیام.do_it: return "اجرای عملیات انتخابی";
                case پیام.harf: return "دایره حرف دلخواه شما";
                case پیام.adad: return "دایره عدد دلخواه شما";
                case پیام.help: return "راهنمای این بخش";

                //  DAlert
                case پیام.v0: return "ورودی معتبر نمی‌باشد! دوباره امتحان کنید.";
                case پیام.v1: return "ورودی معتبر نیست یا یکی از ورودی‌ها خالی می‌باشد!";
                case پیام.all1: return "خروجی‌ها رونوشت شدند!";
                case پیام.all2: return "خروجی‌ها با توضیحات رونوشت شدند!";
                case پیام.k01: return "ورودی خالی است و امکان رونوشت ندارد!";
                case پیام.k02: return "ورودی خالی است و امکان انتقال ندارد!";
                case پیام.k11: return "رونوشت متن انتخاب شده، به درستی انجام شد!";
                case پیام.k12: return "انتقال متن به صفحه دلخواه به درستی انجام شد!";
                case پیام.k99: return "امکان امتزاج مهیا نیست!";
                case پیام.mohas: return "هنوز محاسبه‌ای انجام نشده است!";

                //  OkButtonContent
                case پیام.خواندم: return "خواندم";
            }
        }
    }
}
