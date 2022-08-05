﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql;
using DataCore.Sql.TableScaleModels;
using MDSoft.BarcodePrintUtils.Tsc;
using System;
using System.IO;
using System.Linq;
using System.Text.Unicode;
using System.Xml;
using System.Xml.Xsl;
using WeightCore.Helpers;
using static DataCore.ShareEnums;
using TableDirectModels = DataCore.Sql.TableDirectModels;

namespace WeightCore.Zpl
{
    public static class ZplUtils
    {
        #region Public and private fields and properties

        private static readonly char[] DigitsCharacters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private static readonly char[] SpecialCharacters = { ' ', ',', '.', '-', '~', '!', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '"', '№', ';', ':', '?', '/', '|', '\\', '{', '}', '<', '>' };

        #endregion

        #region Public and private methods

        public static string XmlCompatibleReplace(string xmlInput)
        {
            string result = xmlInput;
            if (string.IsNullOrEmpty(result))
                return result;
            // TableDirectModels.
            result = result.Replace(nameof(TableDirectModels.HostDirect), "HostEntity");
            result = result.Replace(nameof(TableDirectModels.NomenclatureDirect), "NomenclatureEntity");
            result = result.Replace(nameof(TableDirectModels.OrderDirect), "OrderEntity");
            result = result.Replace(nameof(TableDirectModels.PluDirect), "PluEntity");
            result = result.Replace(nameof(TableDirectModels.PrinterDirect), "ZebraPrinterEntity");
            //result = result.Replace(nameof(TableDirectModels.ProductionFacilityDirect), "ProductionFacilityEntity");
            result = result.Replace(nameof(TableDirectModels.ProductSeriesDirect), "ProductSeriesEntity");
            result = result.Replace(nameof(TableDirectModels.SsccDirect), "SsccEntity");
            result = result.Replace(nameof(TableDirectModels.TaskDirect), "TaskEntity");
            result = result.Replace(nameof(TableDirectModels.TemplateDirect), "TemplateEntity");
            result = result.Replace(nameof(TableDirectModels.WeighingFactDirect), "WeighingFactEntity");
            //result = result.Replace(nameof(TableDirectModels.WorkShopDirect), "WorkShopEntity");
            result = result.Replace(nameof(TableDirectModels.ZplLabelDirect), "ZplLabelEntity");
            // TableScaleModels.
            result = result.Replace(nameof(PrinterEntity), "PrinterEntity");
            result = result.Replace(nameof(ScaleEntity), "ScaleEntity");
            result = result.Replace(nameof(TemplateEntity), "TemplateEntity");
            // SqlViewModelHelper.
            result = result.Replace(nameof(SqlViewModelHelper.Instance.Area), "Area");
            // Result.
            return result;
        }

        public static string XsltTransformation(string xslInput, string xmlInput)
        {
            using StringReader stringReaderXslt = new(xslInput.Trim());
            using StringReader stringReaderXml = new(xmlInput.Trim());
            using XmlReader xmlReaderXslt = XmlReader.Create(stringReaderXslt);
            using XmlReader xmlReaderXml = XmlReader.Create(stringReaderXml);
            XslCompiledTransform xslt = new();
            xslt.Load(xmlReaderXslt);
            using StringWriter stringWriter = new();
            // Use OutputSettings of xsl, so it can be output as HTML.
            using XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xslt.OutputSettings);
            xslt.Transform(xmlReaderXml, xmlWriter);
            string result = stringWriter.ToString();
            return result;
        }

        public static bool IsCyrillic(char value)
        {
            char[] cyrillic = Enumerable
                .Range(UnicodeRanges.Cyrillic.FirstCodePoint, UnicodeRanges.Cyrillic.Length)
                .Select(ch => (char)ch)
                .ToArray();
            return Array.BinarySearch(cyrillic, value) >= 0;
        }

        public static bool IsDigit(char value) => DigitsCharacters.Contains(value);

        public static bool IsSpecial(char value, bool isExcludeTop = true)
        {
            if (isExcludeTop && value == '^')
                return false;
            return SpecialCharacters.Contains(value);
        }

        /// <summary>
        /// Replace zpl-resources.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string PrintCmdReplaceZplResources(string value)
        {
            string result = value;
            if (string.IsNullOrEmpty(result))
                return result;

            TemplateResourceEntity[]? resources = DataAccessHelper.Instance.Crud.GetEntities<TemplateResourceEntity>(
                new(new() { new($"{nameof(TemplateResourceEntity.Type)}", DbComparer.Equal, "ZPL") }),
                new(DbField.Name));
            if (resources != null)
            {
                foreach (TemplateResourceEntity resource in resources.ToList())
                {
                    string resourceHex = MDSoft.BarcodePrintUtils.Zpl.ZplUtils.ConvertStringToHex(resource.ImageData.ValueUnicode);
                    result = result.Replace($"[{resource.Name}]", resourceHex);
                }
            }

            //result = PrintCmdReplaceArea(result);
            return result;
        }

        /// <summary>
        /// Replace area-resource.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string PrintCmdReplaceArea(string value)
        {
            string result = value;
            if (string.IsNullOrEmpty(result))
                return result;
            if (UserSessionHelper.Instance.SqlViewModel.Area != null)
            {
                string area = UserSessionHelper.Instance.SqlViewModel.Area.Name;
                if (string.IsNullOrEmpty(area))
                    return result;
                string resourceHex = MDSoft.BarcodePrintUtils.Zpl.ZplUtils.ConvertStringToHex(area);
                result = result.Replace($"[AREA]", resourceHex);
            }
            return result;
        }

        public static void CmdConvertZpl(TscDriverHelper tscDriver, bool isUsePicReplace)
        {
            tscDriver.Cmd = MDSoft.BarcodePrintUtils.Zpl.ZplUtils.ConvertStringToHex(tscDriver.TextPrepare);
            if (isUsePicReplace)
            {
                tscDriver.Cmd = PrintCmdReplaceZplResources(tscDriver.Cmd);
                //Cmd = Cmd.Replace("[EAC_107x109_090]", ZplSamples.GetEac);
                //Cmd = Cmd.Replace("[FISH_94x115_000]", ZplSamples.GetFish);
                //Cmd = Cmd.Replace("[TEMP6_116x113_090]", ZplSamples.GetTemp6);
            }
        }

        public static string MergeXml(string xmlParent, string xmlChild)
        {
	        string result = string.Empty;
            bool isInsert = false;
	        foreach (string lineParent in xmlParent.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
			{
		        if (isInsert && !string.IsNullOrEmpty(xmlChild))
		        {
			        foreach (string lineChild in xmlChild.Split(new [] { Environment.NewLine }, StringSplitOptions.None))
			        {
				        if (!lineChild.StartsWith("<?xml "))
							result += "\t" + lineChild + Environment.NewLine;
			        }
			        xmlChild = string.Empty;
		        }
                if (lineParent.StartsWith("<") && !lineParent.StartsWith("<?xml "))
                    isInsert = true;
				result += lineParent + Environment.NewLine;
	        }
			return result;
        }

        #endregion
    }
}
