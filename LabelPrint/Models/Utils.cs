﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using LabelPrint.ViewModels;
using System.Windows;


namespace LabelPrint.Models
{
    public static class Utils
    {
        /// <summary>
        /// Получить программные настройки.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static ProgramSettings GetSettings(FrameworkElement element, string resource = "ViewModelProgramSettings")
        {
            var context = element.FindResource(resource);
            if (context is ProgramSettings settings)
            {
                return settings;
            }
            return null;
        }
    }
}
