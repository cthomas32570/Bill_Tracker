using System;
using System.Collections.Generic;
using System.Text;

namespace Bill_Tracker
{

    internal static class TestCases
    {

        internal static List<Bill> testBillList01()
        {
            List<Bill> testBillList = new List<Bill>();

            testBillList.Add(new Bill { DueDay = 1, IsPaid = true, Name = "Sample Company, Inc.", Amount = (decimal)1107.25, Reoccur = true, ReoccurAmount = true });
            testBillList.Add(new Bill { DueDay = 8, IsPaid = false, Name = "Sample Company, Inc.", Amount = (decimal)7.35, Reoccur = true, ReoccurAmount = true });
            testBillList.Add(new Bill { DueDay = 12, IsPaid = false, Name = "Sample Company, Inc.", Amount = (decimal)1.00, Reoccur = true, ReoccurAmount = true });
            testBillList.Add(new Bill { DueDay = 18, IsPaid = false, Name = "Sample Company, Inc.", Amount = (decimal)12.50, Reoccur = true, ReoccurAmount = true });
            testBillList.Add(new Bill { DueDay = 22, IsPaid = true, Name = "Sample Company, Inc.", Amount = (decimal)100.10, Reoccur = false, ReoccurAmount = false });
            testBillList.Add(new Bill { DueDay = 30, IsPaid = false, Name = "Sample Company, Inc.", Amount = (decimal)256.00, Reoccur = true, ReoccurAmount = true });

            return testBillList;
        }

        internal static Record TestRecord01()
        {
            Record output = new Record();
            output.Year = 2022;

            output[(int)Month.Jan] = testBillList01();
            output[(int)Month.Feb] = testBillList01();

            return output;
        }

    }
}
