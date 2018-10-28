using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.APZRPMJ2018.TextEditor.ViewModels
{
    class HistoryWindowViewModel
    {
        public string HistoryText { get; set; }

        public HistoryWindowViewModel (String historyText)
        {
            HistoryText = historyText;
        }
    }
}
