using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example.Model
{
    public class TextConverter
    {
        private readonly Func<string, string> convertion;

        public TextConverter(Func<string, string> convertion)
        {
            this.convertion = convertion;
        }

        public string ConvertText(string inputText)
        {
            return convertion(inputText);
        }
    }
}
