using System;

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
