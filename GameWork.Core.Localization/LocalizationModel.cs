using GameWork.Core.Models.Interfaces;
using System.Collections.Generic;

namespace GameWork.Core.Localization
{
    public struct LocalizationModel : IModel
    {
        public string Default { get; set; }

        /// <summary>
        /// Structure:
        /// 
        /// {
        ///     Label1:
        ///     {
        ///         Language1: Localized Value,
        ///         Language2: Localized Value
        ///     },
        ///     Label2:
        ///     {
        ///         Language1: Localized Value,
        ///         Language2: Localized Value
        ///     }
        /// }
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> Localizations { get; set; }
    }
}