using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ja.training.csharp._02_FormatWith
{
    public static class StringExtensions
    {
        /// <summary>
        /// interpoliert {PropName} mit den Inhalten von Properties vom übergebenen param
        /// </summary>
        /// <param name="format">das String-Template</param>
        /// <param name="param">das Objekt mit Inhalten, die ins Template interpoliert werden</param>
        /// <param name="formatPrefix">ist für Benutzer unwichtig, hilft aber bei Rekursion</param>
        /// <returns>den String format nur mit Inhalten aus param</returns>
        public static string FormatWith(this string format, object param, string formatPrefix = "")
        {
            // naiiver erster Ansatz, der nur 2/7 Tests grün macht. Das reicht so nicht...
            foreach (var p in param.GetType().GetProperties().Where( p => p.CanRead))
            {
                var oldValue = "{" + p.Name + "}";
                var newValue = p.GetValue(param).ToString();
                format = format.Replace(oldValue, newValue);
            }

            return format;
        }

    }
}
