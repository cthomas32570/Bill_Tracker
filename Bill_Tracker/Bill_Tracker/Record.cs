using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Bill_Tracker
{

    enum M
    {

        Jan,
        Feb,
        Mar,
        Apr,
        May,
        Jun,
        Jul,
        Aug,
        Sep,
        Oct,
        Nov,
        Dec

    }

    internal class Record
    {

        private Month[] _months = new Month[12];

        [PrimaryKey]
        public int Year { get; }

        public Month this[int i]
        {
            get { return _months[i]; }
            set { _months[i] = value; }
        }

        internal class Month
        {

            private List<Bill> _bills;

            Month()
            {
                _bills = new List<Bill>();
            }

            public List<Bill> Bills { get { return _bills; } }

        }

        internal class Bill
        {

            private bool reoccur;
            private bool reoccurAmount;

            private bool isPaid;

            private int _dueDay;
            private string _name;
            private decimal _amount;

            Bill(bool reoccur, bool reoccurAmount, int DueDay, string Name, decimal Amount)
            {
                this.reoccur = reoccur;
                this.reoccurAmount = reoccurAmount;

                this._dueDay = DueDay;
                this._name = Name;
                this._amount = Amount;

                this.isPaid = false;
            }

            public bool Reoccur
            {
                get { return reoccur; }
                set { reoccur = value; }
            }

            public bool ReoccurAmount
            {
                get { return reoccurAmount; }
                set { reoccurAmount = value; }
            }

            public bool IsPaid
            {
                get { return isPaid; }
                set { isPaid = value; }
            }

            public int DueDay
            {
                get { return _dueDay; }
                set { _dueDay = value; }
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public decimal Amount
            {
                get { return _amount; }
                set { _amount = value; }
            }

        }

    }

}
