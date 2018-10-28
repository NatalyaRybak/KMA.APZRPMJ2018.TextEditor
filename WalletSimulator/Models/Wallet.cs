using System;

namespace KMA.APZRPMJ2018.WalletSimulator.Models
{
    public class Wallet
    {
        #region Fields
        private Guid _guid;
        private string _title;
        private string _text;
        private string _fileName;
        private string _filePath;
        private bool _isEmpty;

        private long _totalIncome;
        private long _totalOutcome;
        #endregion

        #region Properties


        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath= value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public bool isEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(FileName) ||
                    string.IsNullOrEmpty(FilePath))
                    return true;

                return false;
            }
        }





        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public long TotalIncome
        {
            get { return _totalIncome; }
            private set { _totalIncome = value; }
        }
        public long TotalOutcome
        {
            get { return _totalOutcome; }
            private set { _totalOutcome = value; }
        }
        #endregion

        #region Constructor
        public Wallet(string title, User user) : this()
        {
            _guid = Guid.NewGuid();
            _title = title;
            _totalIncome = 0;
            _totalOutcome = 0;
            user.Wallets.Add(this);
        }
        private Wallet()
        {
        }
        #endregion
        public override string ToString()
        {
            return FileName;
        }
    }   
}
