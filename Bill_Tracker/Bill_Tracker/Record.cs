using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Bill_Tracker
{

    internal class Record
    {

        private int _year;
        private Dictionary<int, Month> _months;

        [PrimaryKey]
        public int year { get { return _year; } set { _year = value; } }


        private class Month
        {

            private List<Bill> _bills;

            Month()
            {
                _bills = new List<Bill>();
            }

        }

        private class Bill
        {

            private bool reoccur;
            private bool reoccurAmount;

            private bool isPaid;

            private int _dueDay;
            private string _name;
            private decimal _amount;

            Bill(bool reoccur, bool reoccurAmount, int dueDay, string name, decimal amount)
            {
                this.reoccur = reoccur;
                this.reoccurAmount = reoccurAmount;

                this._dueDay = dueDay;
                this._name = name;
                this._amount = amount;

                this.isPaid = false;
            }

            public void ToggleReoccur()
            {
                reoccur = !reoccur;
            }

            public void ToggleReoccurAmount()
            {
                reoccurAmount = !reoccurAmount;
            }

            public void ToggleIsPaid()
            {
                isPaid = !isPaid;
            }

            public int dueDay
            {
                get { return _dueDay; }
                set { _dueDay = value; }
            }

            public string name
            {
                get { return _name; }
                set { _name = value; }
            }

            public decimal amount
            {
                get { return _amount; }
                set { _amount = value; }
            }

        }

    }

}
