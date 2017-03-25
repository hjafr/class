using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJafr.Enums
{
    /// <summary>
    /// <right>دایره حروف</right>
    /// </summary>
    public enum d_name
    {
        ابجد, ابتث, اهطم, ایقغ,
        اجهب, اجذش, ارغی, انسغ,
        احست, اویل, اجهز, افسخ,
        اعهط, احمد, اموس,

        نادعلی,


        عبری = 998,
        انگلیسی=999
    };

    /// <summary>
    /// <right>دایره عدد</right>
    /// </summary>
    public enum d_int
    {
        kabir,
        maakoos,
        vazi,
        aflaki,
        saghir,
        borooji,

        abjad_edrici,
        abjad_adad_vasat,
        abjad_thani,
        abjad_alavi,
        abjad_az_amir,
        abjad_shoaib,
        abjad_nabavi,

        abtath_adam,
        abtath_amir,
        abtath_sadegh,

        ahtam_martabe,
        ahtam_heja,
        ahtam_fithaghooreth,
        ahtam_danial,
        ahtam_vosta,
        ahtam_mothalathat,
        ahtam_vasit_1,
        ahtam_vasit_2,

        ighagh_yooshaa,


        faal_1
    }

    /// <summary>
    /// برج
    /// </summary>
    public enum برج
    {
        حمل,
        ثور,
        جوزا,
        سرطان,
        اسد,
        سنبله,
        میزان,
        عقرب,
        قوس,
        جدی,
        دلو,
        حوت
    }

    /// <summary>
    /// کوکب
    /// </summary>
    public enum کوکب
    {
        زحل,
        مشتری,
        مریخ,
        شمس,
        زهره,
        عطارد,
        قمر
    }
}
