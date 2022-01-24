using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bill_Tracker
{
    public partial class MainPage : ContentPage
    {
        internal MainPage(Record record, int month)
        {
            InitializeComponent();

            labelMonth.Text = $"{Enum.GetName(typeof(M), month)} {record.Year}";

            decimal billsTotal = 0;
            decimal billsPaid = 0;

            int i = 0;
            foreach (Record.Bill bill in record[month].Bills)
            {
                billsTotal += bill.Amount;
                billsPaid += bill.IsPaid ? bill.Amount : 0;

                string monthDigits = (month + 1) < 10 ? $"0{month + 1}" : $"{month + 1}";

                TextDecorations getStrikethrough = bill.IsPaid ? TextDecorations.Strikethrough : TextDecorations.None;

                BillDisplay.Children.Add(new CheckBox { 
                    IsChecked = bill.IsPaid, 
                    HorizontalOptions = LayoutOptions.Center 
                }, i, 0);

                BillDisplay.Children.Add(new Label { 

                    Text = $"{monthDigits}/{bill.DueDay}", 
                    TextDecorations = getStrikethrough,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start

                }, i, 1);

                BillDisplay.Children.Add(new Label
                {

                    Text = bill.Name,
                    TextDecorations = getStrikethrough,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start

                }, i, 2);

                BillDisplay.Children.Add(new Label
                {

                    Text = bill.Amount.ToString("$0000.00"),
                    TextDecorations = getStrikethrough,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.End

                }, i, 3);

                i++;

            }

            labelTotal.Text = billsTotal.ToString("$0000.00");
            labelPaid.Text = billsPaid.ToString("$0000.00");
            labelRemaining.Text = (billsTotal - billsPaid).ToString("$0000.00");

            progressBar.Progress = (double)(billsPaid / billsTotal);

        }
    }
}
