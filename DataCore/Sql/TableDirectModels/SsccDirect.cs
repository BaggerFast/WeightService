﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Models;
using System.Text;
using System.Xml.Serialization;

namespace DataCore.Sql.TableDirectModels
{
    public class SsccDirect : BaseSerializeEntity
    {
        #region Public and private fields and properties


        [XmlElement("SSCC")]
        public string SSCC { get; set; }

        [XmlElement("GLN")]
        public string GLN { get; set; }

        [XmlElement("UnitID")]
        public int UnitID { get; set; }

        [XmlElement("UnitType")]
        public byte UnitType { get; set; }

        [XmlElement("SynonymSSCC")]
        public string SynonymSSCC { get; set; }

        [XmlElement("Check")]
        public int Check { get; set; }

        #endregion

        #region Constructor and destructor

        public SsccDirect() { }

        public SsccDirect(string sscc)
        {
            SSCC = sscc;
            GLN = sscc.Substring(3, 9);
            UnitID = int.Parse(sscc.Substring(12, 7));
            UnitType = byte.Parse(sscc.Substring(2, 1));
            SynonymSSCC = $"(00){sscc.Substring(3, 17)}";
            Check = int.Parse(sscc.Substring(19, 1));
        }

        #endregion

        #region Public and private methods

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"{SynonymSSCC}");
            return sb.ToString();
        }

        #endregion
    }
}