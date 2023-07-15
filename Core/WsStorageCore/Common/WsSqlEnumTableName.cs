// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.Common;

public enum WsSqlEnumTableName
{
    None,
    All,
    Areas,                  // ������ ProductionFacilities
    Boxes,
    Brands,
    Bundles,
    Clips,
    DeviceSettings,
    DeviceSettingsFks,
    Lines,                  // ������ Scales
    PluBrandsFks,
    PluBundlesFks,
    PluCharacteristics,
    PluCharacteristicsFks,
    PluClipsFks,
    PluFks,
    PluGroups,
    PluGroupsFks,
    PlusNestingFks,
    Plus,
    Plus1CFks,
    ViewPlusLines,          // ������ PlusScales
    ViewPlusNesting,        // ������ PluNestingFks
    ViewPlusStorageMethods, // ������ PluStorageMethodsFks
    WorkShops,
}