using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Bill_Tracker
{

    enum Month
    {

        Jan, Feb, Mar, Apr, 
        May, Jun, Jul, Aug,
        Sep, Oct, Nov, Dec

    }

    internal class Record
    {

        private List<Bill>[] _months = new List<Bill>[12];

        [PrimaryKey]
        public int Year { get; set; }

        public List<Bill> this[int i]
        {
            get { return _months[i]; }
            set { _months[i] = value; }
        }

        public List<Bill> this[Month e]
        {
            get { return _months[(int)e]; }
            set { _months[(int)e] = value; }
        }


    }

    internal class Bill
    {

        private bool reoccur;
        private bool reoccurAmount;

        private bool isPaid;

        private int _dueDay;
        private string _name;
        private decimal _amount;

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
