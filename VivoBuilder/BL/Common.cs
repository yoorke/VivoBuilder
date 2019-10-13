using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivoBuilder.BL
{
    public class Common
    {
        public string ToPascalCase(string value)
        {
            string pascalCaseValue = value;

            if (string.IsNullOrEmpty(value))
                return value;

            if (!value.Contains("_"))
                pascalCaseValue = value[0].ToString().ToUpper() + value.Substring(1);
            else
            {
                string[] words = value.Split('_');
                pascalCaseValue = string.Empty;

                foreach (string word in words)
                    pascalCaseValue += !string.IsNullOrEmpty(word) ? word[0].ToString().ToUpper() + word.Substring(1).ToLower() : word;

                
            }

            if (pascalCaseValue.ToLower().EndsWith("id"))
                pascalCaseValue = pascalCaseValue.Substring(0, pascalCaseValue.Length - 2) + "ID";

            return pascalCaseValue;
        }
    }
}
