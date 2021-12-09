﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataShareCore;
using System.Collections.ObjectModel;
using System.Threading;

namespace WeightCore.Helpers
{
    public class CollectionsHelper
    {
        #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static CollectionsHelper _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static CollectionsHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

        #endregion

        #region Public fields and properties

        /// <summary>
        /// Документация.
        /// </summary>
        public Collection<string> Docs { get; } = new Collection<string>() { "CHANGELOG.md", "README.md", "TO-DO LIST.md", "License.rtf" };

        /// <summary>
        /// Руководства.
        /// </summary>
        public Collection<string> Manuals { get; } = new Collection<string>() { "Руководство пользователя.docx" };

        /// <summary>
        /// Архивы драйверов.
        /// </summary>
        public Collection<string> DriversArchives { get; } = new Collection<string>() { "en.stsw-stm32102.zip" };

        #endregion

        #region Public methods

        /// <summary>
        /// Имя файла установки драйвера.
        /// </summary>
        /// <param name="winVersion">Версия WiNdows</param>
        /// <returns></returns>
        public string GetDriverFileName(ShareEnums.WinVersion winVersion)
        {
            if (winVersion == ShareEnums.WinVersion.Win7x64)
                return "VCP_V1.5.0_Setup_W7_x64_64bits.exe";
            if (winVersion == ShareEnums.WinVersion.Win7x32)
                return "VCP_V1.5.0_Setup_W7_x86_32bits.exe";
            if (winVersion == ShareEnums.WinVersion.Win10x64)
                return "VCP_V1.5.0_Setup_W8_x64_64bits.exe";
            if (winVersion == ShareEnums.WinVersion.Win10x32)
                return "VCP_V1.5.0_Setup_W8_x86_32bits.exe";

            return string.Empty;
        }

        #endregion
    }
}