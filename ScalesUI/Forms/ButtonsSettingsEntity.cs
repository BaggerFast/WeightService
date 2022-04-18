﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace ScalesUI.Forms
{
    internal class ButtonsSettingsEntity
    {
        #region Public and private fields and properties

        public bool IsKneading { get; set; }
        public bool IsMore { get; set; }
        public bool IsNewPallet { get; set; }
        public bool IsOrder { get; set; }
        public bool IsPlu { get; set; }
        public bool IsPrint { get; set; }
        public bool IsScalesInit { get; set; }
        public bool IsScalesTerminal { get; set; }

        #endregion

        #region Constructor and destructor

        public ButtonsSettingsEntity()
        {
            IsKneading = false;
            IsMore = false;
            IsNewPallet = false;
            IsOrder = false;
            IsPlu = false;
            IsPrint = false;
            IsScalesInit = false;
            IsScalesTerminal = false;
        }

        #endregion
    }
}