using GemPuzzle.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemPuzzle
{
    public class LanguageProvider
    {
        public LanguageProvider()
        {
        }
        private Language actualLanguage;

        public Language ActualLanguage
        {
            get
            {
                if (actualLanguage == null)
                    actualLanguage = new Language();
                return actualLanguage;
            }
        }

    }
}
