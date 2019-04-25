using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_Example.Model;

namespace MVVM_Example.ViewModel
{
    public class Presenter : BaseForiNotify
    {
        private readonly TextConverter textConverter = new TextConverter(s => s.ToUpper());
        private string someText;
        private readonly ObservableCollection<string> history = new ObservableCollection<string>();

        public string SomeText
        {
            get { return someText; }
            set
            {
                someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public IEnumerable<string> History
        {
            get { return history; }
        }

        public BaseForiCommand ConvertTextCommand
        {
            get { return new BaseForiCommand(ConvertText); }
        }

        private void ConvertText()
        {
            if (string.IsNullOrWhiteSpace(SomeText))
            {
                return;
            }
            AddToHistory(textConverter.ConvertText(SomeText));
            SomeText = string.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!history.Contains(item))
            {
                history.Add(item);
            }
        }
    }
}
