using System.Collections.Generic;

namespace FirehoseFinder
{
    class Guide
    {
        ///<summary>
        ///Справочник типов программного обеспечения из сертификата
        ///</summary>
        internal readonly Dictionary<string, string> SW_ID_type = new Dictionary<string, string>(28)
        {
            { "0", "SBL1 image" },
            { "1", "MBA image" },
            { "2", "Modem image hashtable" },
            { "3", "Загрузчик из аварийного режима (EDL-9008)" },
            { "4", "lpass etc running on ADSP" },
            { "5", "Device configuration image" },
            { "6", "Reserved" },
            { "7", "TZBSP image" },
            { "8", "Reserved" },
            { "9", "APPSBL" },
            { "A", "RPM firmware" },
            { "B", "Reserved" },
            { "C", "TrustZone applications - Playready/TrustZone" },
            { "D", "Pronto/WCN image" },
            { "E", "Venus image" },
            { "F", "Reserved" },
            { "12", "System debug image" },
            { "13", "Reserved" },
            { "14", "GPU Microcode" },
            { "15", "Hypervisor image" },
            { "16", "PMIC" },
            { "17", "Reserved" },
            { "18", "SLPI" },
            { "19", "EOS firmware image" },
            { "1A", "Validated image programmer (VIP)" },
            { "1B", "EFS TAR" },
            { "1C", "Reserved" },
            { "200","Debug Policy"}
        };
        /// <summary>
        /// Список идентификаторов процессоров
        /// </summary>
        internal readonly Dictionary<string, string> HW_IDs = new Dictionary<string, string>()
        {
           /* 0008B0E1 - SDM845     - Qualcomm® Snapdragon™ 845 mobile platform
0008C0E1 - SDM660     - Qualcomm® Snapdragon™ 660 mobile platform
000950E1 - SDM675     - Qualcomm® Snapdragon™ 675 mobile platform *
0009A0E1 - SDM450     - Qualcomm® Snapdragon™ 450 mobile platform
000A50E1 - SDM855     - Qualcomm® Snapdragon™ 855 mobile platform *
000AC0E1 - SDM630     - Qualcomm® Snapdragon™ 630 mobile platform
000BA0E1 - SDM632     - Qualcomm® Snapdragon™ 632 mobile platform
000BE0E1 - SDM429     - Qualcomm® Snapdragon™ 429 mobile platform
000BF0E1 - SDM439     - Qualcomm® Snapdragon™ 439 mobile platform
000CC0E1 - SDM636     - Qualcomm® Snapdragon™ 636 mobile platform
000DB0E1 - SDM710     - Qualcomm® Snapdragon™ 710 mobile platform
000E60E1 - SDM730     - Qualcomm® Snapdragon™ 730 mobile platform *
001080E1 - SDM712     - Qualcomm® Snapdragon™ 712 mobile platform
0010A0E1 - SDM665     - Qualcomm® Snapdragon™ 765 mobile platform *
000460E1 - MSM8953    - Qualcomm® Snapdragon™ 625 mobile platform
0004F0E1 - MSM8937    - Qualcomm® Snapdragon™ 430 mobile platform
000560E1 - MSM8917    - Qualcomm® Snapdragon™ 425 mobile Platform
0005E0E1 - MSM8998    - Qualcomm® Snapdragon™ 835 mobile platform
0005F0E1 - MSM8996Pro - Qualcomm® Snapdragon™ 821 mobile platform
0006B0E1 - MSM8940    - Qualcomm® Snapdragon™ 435 mobile platform
000940E1 - MSM8905    - Qualcomm® Snapdragon™ 205 mobile platform
000510E1 - APQ8009w   - Qualcomm® Snapdragon™ 2100 wearable platform
000520E1 - MSM8909w   - Qualcomm® Snapdragon™ 2100 wearable platform
000550E1 - APQ8017    - Qualcomm® Snapdragon™ 425 mobile platform
000660E1 - APQ8053    - Qualcomm® Snapdragon™ 624 mobile platform
007050E1 - MSM8916    - Qualcomm® Snapdragon™ 410 processor
0072C0E1 - MSM8930    - Qualcomm® Snapdragon™ 400 processor
007B00E1 - MSM8974    - Qualcomm® Snapdragon™ 800 processor
007B40E1 - MSM8974AC  - Qualcomm® Snapdragon™ 801 processor
007B60E1 - MSM8274AC  - Qualcomm® Snapdragon™ 800 processor
007B80E1 - MSM8974AB  - Qualcomm® Snapdragon™ 801 processor
007BC0E1 - MSM8974AA  - Qualcomm® Snapdragon™ 801 processor
008000E1 - MSM8226    - Qualcomm® Snapdragon™ 400 processor
008050E1 - MSM8926    - Qualcomm® Snapdragon™ 400 processor
008110E1 - MSM8210    - Qualcomm® Snapdragon™ 200 processor
008140E1 - MSM8212    - Qualcomm® Snapdragon™ 200 processor
0090B0E1 - MSM8939    - Qualcomm® Snapdragon™ 615 processor
009180E1 - MSM8928    - Qualcomm® Snapdragon™ 400 processor
0091B0E1 - MSM8929    - Qualcomm® Snapdragon™ 415 processor
009400E1 - MSM8994    - Qualcomm® Snapdragon™ 810 processor
009470E1 - MSM8996    - Qualcomm® Snapdragon™ 820 processor
009600E1 - MSM8909    - Qualcomm® Snapdragon™ 210 processor
009680E1 - APQ8909    - Qualcomm® Snapdragon™ 210 mobile platform
009690E1 - MSM8992    - Qualcomm® Snapdragon™ 808 processor
009720E1 - MSM8952    - Qualcomm® Snapdragon™ 617 processor
009900E1 - MSM8976    - Qualcomm® Snapdragon™ 652 processor
009B00E1 - MSM8956    - Qualcomm® Snapdragon™ 650 processor
009D00E1 - APQ8076    - Qualcomm® Snapdragon™ 652 mobile platform*/
        };
        /// <summary>
        /// Список идентификаторов вендоров
        /// </summary>
        public readonly Dictionary<string, string> OEM_IDs = new Dictionary<string, string>(28)
        {
            { "0000", "Qualcomm" },
            { "0001", "Sony/Wingtech" },
            { "0004", "ZTE" },
            { "0015", "Huawei" },
            { "0017", "Lenovo" },
            { "0029", "Asus" },
            { "0030", "Haier" },
            { "0031", "LG" },
            { "0038", "Sharp" },
            { "0039", "Kyocera" },
            { "0042", "Alcatel" },
            { "0043", "Hisense" },
            { "0045", "Nokia" },
            { "0048", "YuLong" },
            { "0072", "Xiaomi" },
            { "00C8", "Motorola" },
            { "0168", "Motorola" },
            { "01B0", "Motorola" },
            { "0208", "Motorola" },
            { "0228", "Motorola" },
            { "0328", "Motorola" },
            { "0368", "Motorola" },
            { "03C8", "Motorola" },
            { "0348", "Motorola" },
            { "1111", "Asus" },
            { "143A", "Asus" },
            { "1978", "Blackphone" },
            { "2A70", "Oxygen"}
        };
    }
}
