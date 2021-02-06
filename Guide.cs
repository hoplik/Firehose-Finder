using System.Collections;
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
            { "3", "Firehose programmer" },
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
            { "200", "Debug Policy" }
        };

        /// <summary>
        /// Справочник типов памяти
        /// </summary>
        internal enum MEM_TYPE
        {
            eMMC,
            UFS
        }

        /// <summary>
        /// Дубликаты CPU
        /// </summary>
        internal readonly Dictionary<string, string> Double_CPU = new Dictionary<string, string>(46)
        {
            { "000630E1", "MSM8996AU" },
            { "001080E1", "SDM712" },
            { "007190E1", "APQ8056" },
            { "007210E1", "MSM8930" },
            { "008000E1", "MSM8226" },
            { "009000E1", "APQ8084" },
            { "009010E1", "APQ8084" },
            { "009150E1", "MSM8226" },
            { "009300E1", "APQ8092" },
            { "009630E1", "APQ8092" },
            { "009640E1", "MSM8992" },
            { "009690E1", "MSM8992" },
            { "009700E1", "MSM8956" },
            { "009710E1", "APQ8056" },
            { "009820E1", "MSM8976" },
            { "009830E1", "APQ8076" },
            { "009900E1", "MSM8976" },
            { "30020000", "MSM8998" },
            { "30060000", "SDM660" },
            { "30070000", "SDM630" },
            { "60000000", "SDM845" },
            { "60040000", "SDM712" },
            { "0005E0E1", "MSM8998" },
            { "0006F0E1", "MSM8996AU" },
            { "0007D0E1", "SDM660" },
            { "0007E0E1", "SDM630" },
            { "0008B0E1", "SDM845" },
            { "0008C0E1", "SDM660" },
            { "0009C0E1", "SDM660" },
            { "000AC0E1", "SDM636" },
            { "000CC0E1", "SDM636" },
            { "006B10E1", "MSM8974AC" },
            { "0072C0E1", "MSM8930" },
            { "007B00E1", "MSM8974" },
            { "007B20E1", "MSM8974" },
            { "007B40E1", "MSM8974AB" },
            { "007B60E1", "MSM8974AC" },
            { "007BA0E1", "MSM8974AB" },
            { "0090B0E1", "MSM8939" },
            { "009B00E1", "MSM8956" },
            { "009D00E1", "APQ8076" },
            { "009F00E1", "APQ8056" },
            { "00FFF0E1", "MSM8998" },
            { "050E10E1", "MSM8939" },
            { "1006F0E1", "MSM8996AU" },
            { "4006F0E1", "MSM8996AU" }
        };
    }
}
