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

            labelMonth.Text = $"{Enum.GetName(typeof(Month), month)} {record.Year}";

            decimal billsTotal = 0;
            decimal billsPaid = 0;

            int i = 0;
            foreach (Bill bill in record[month])
            {
                billsTotal += bill.Amount;
                billsPaid += bill.IsPaid ? bill.Amount : 0;

                string monthDigits = (month + 1) < 10 ? $"0{month + 1}" : $"{month + 1}";
                string dayDigits = bill.DueDay < 10 ? $"0{bill.DueDay}" : $"{bill.DueDay}";

                TextDecorations getStrikethrough = bill.IsPaid ? TextDecorations.Strikethrough : TextDecorations.None;

                BillDisplay.Children.Add(new CheckBox { 
                    IsChecked = bill.IsPaid, 
                    HorizontalOptions = LayoutOptions.Center 
                }, 0, i);

                BillDisplay.Children.Add(new Label { 

                    Text = $"{monthDigits}/{dayDigits}", 
                    TextDecorations = getStrikethrough,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start

                }, 1, i);

                BillDisplay.Children.Add(new Label
                {

                    Text = bill.Name,
                    TextDecorations = getStrikethrough,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start

                }, 2, i);

                BillDisplay.Children.Add(new Label
                {

                    Text = bill.Amount.ToString("$0000.00"),
                    TextDecorations = getStrikethrough,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.End

                }, 3, i);

                i++;

            }

            labelTotal.Text = billsTotal.ToString("$0000.00");
            labelPaid.Text = billsPaid.ToString("$0000.00");
            labelRemaining.Text = (billsTotal - billsPaid).ToString("$0000.00");

            progressBar.Progress = (double)(billsPaid / billsTotal);

        }
    }
}
