using System;
using System.Collections.Generic;
using System.Text;

namespace Bill_Tracker
{
    internal class Model
    {
        private Dictionary<int, Year> _years;

        Model()
        {
            _years = new Dictionary<int, Year>();
        }

        private class Year
        {

            private Dictionary<int, Month> _months;

            Year()
            {
                _months = new Dictionary<int, Month>();
            }

        }

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
