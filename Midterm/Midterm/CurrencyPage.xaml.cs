using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Midterm
{
    public partial class CurrencyPage : ContentPage
    {
        List<string> curPicker = new List<string>();
        public CurrencyPage()
        {
            InitializeComponent();

            /*pickerC01.Items.Add("Baht");
            pickerC01.Items.Add("Yen");
            pickerC01.Items.Add("Dollar");
            pickerC01.Items.Add("Pound");

            curPicker.Add("THB");
            curPicker.Add("JPY");
            curPicker.Add("USD");
            curPicker.Add("GBP");
            pickerC01.ItemsSource = curPicker;
            */
            pickerC01.SelectedIndexChanged += Pick_SelectedIndexChanged;
            pickerC02.SelectedIndexChanged += Pick_SelectedIndexChanged;
            String[] currency = {"Baht",
                                 "Yen",
                                 "Yuan",
                                 "Won",
                                 "Dollar",
                                 "Pound",
                                 "Euros"};

            foreach (string _currency in currency)
            {


                pickerC01.Items.Add(_currency);
                pickerC02.Items.Add(_currency);

            }

            Start();

            enTry0.Focused += EnTry_Focused;
            enTry1.Focused += EnTry_Focused;

            enTry0.TextChanged += EnTry_TextChanged;
            enTry1.TextChanged += EnTry_TextChanged;

        }

        private void Start()
        {
            pickerC01.SelectedIndex = 1;
            pickerC02.SelectedIndex = 0;
            enTry0.Text = "100";

            enTry0.Text = string.Format("{0:#,##0.00##}", 100);
            enTry1.Text = string.Format("{0:#,##0.00##}", Solution(enTry0.Text));
        }

        private bool check(int func)
        {
            if (func == 1)
            {
                if (string.IsNullOrEmpty(enTry0.Text) &&
                    string.IsNullOrWhiteSpace(enTry0.Text))

                {
                    return false;
                }
            }
            if (func == 2)
            {
                if (string.IsNullOrEmpty(enTry1.Text) &&
                string.IsNullOrWhiteSpace(enTry1.Text))
                {
                    return false;
                }
            }
            return true;
        }
        private async void Pick_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (semaphoreFlag) return;
            semaphoreFlag = true;
            if (check(1) && check(2))
            {
                enTry1.Text = Solution(enTry0.Text);
            }

            semaphoreFlag = false;
        }

        private bool semaphoreFlag = false;
        private void EnTry_Focused(object sender, FocusEventArgs e)
        {
            var EntryTapped = (Xamarin.Forms.Entry)sender;

            Device.BeginInvokeOnMainThread(() => {


                if (EntryTapped.ClassId == "1")
                {
                    if (!string.IsNullOrEmpty(enTry0.Text) &&
                        !string.IsNullOrWhiteSpace(enTry0.Text))
                    {
                        enTry0.CursorPosition = 0;
                        enTry0.SelectionLength = enTry0.Text.Length;
                    }
                }


                else if (EntryTapped.ClassId == "2")
                {
                    if (!string.IsNullOrEmpty(enTry1.Text) &&
                        !string.IsNullOrWhiteSpace(enTry1.Text))
                    {
                        enTry1.CursorPosition = 0;
                        enTry1.SelectionLength = enTry1.Text.Length;
                    }
                }

            });
        }

        private async void EnTry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (semaphoreFlag) return;
            semaphoreFlag = true;
            var EntryTapped = (Xamarin.Forms.Entry)sender;

            Device.BeginInvokeOnMainThread(() => {


                if (EntryTapped.ClassId == "1")
                {
                    double number = 0;
                    if (double.TryParse(enTry0.Text, out number))
                    {
                        if (number >= 0)
                        {
                            enTry1.Text = Solution(enTry0.Text);
                        }
                    }
                    semaphoreFlag = false;
                }


                else if (EntryTapped.ClassId == "2")
                {
                    double number = 0;
                    if (double.TryParse(enTry1.Text, out number))
                    {
                        if (number >= 0)
                        {
                            enTry0.Text = Solution2(enTry1.Text);
                        }
                    }
                    semaphoreFlag = false;

                }

            });

        }

        private string Solution(string _txt)
        {

            int value01 = pickerC01.SelectedIndex,
                value02 = pickerC02.SelectedIndex;
            if (!string.IsNullOrEmpty(enTry0.Text) &&
               !string.IsNullOrWhiteSpace(enTry0.Text))
            {
                double total = 0;
                double txt = double.Parse(_txt);
                switch (value01)
                {
                    //Baht
                    case 0:
                        switch (value02)
                        {
                            //Baht
                            case 0:
                                total = txt;
                                break;
                            //Yen
                            case 1:
                                total = txt * 3.84;
                                break;
                            //Yuan
                            case 2:
                                total = txt / 4.93;
                                break;
                            //Won
                            case 3:
                                total = txt * 37.4;
                                break;
                            //Dollar
                            case 4:
                                total = txt / 34.01;
                                break;
                            //Pound
                            case 5:
                                total = txt / 40.98;
                                break;
                            //Euros
                            case 6:
                                total = txt / 36.08;
                                break;
                        }
                        break;
                    //Yen
                    case 1:
                        switch (value02)
                        {
                            //Baht
                            case 0:
                                total = txt / 3.84;
                                break;
                            //Yen
                            case 1:
                                total = txt;
                                break;
                            //Yuan
                            case 2:
                                total = txt / 18.97;
                                break;
                            //Won
                            case 3:
                                total = txt * 9.72;
                                break;
                            //Dollar
                            case 4:
                                total = txt / 130.66;
                                break;
                            //Pound
                            case 5:
                                total = txt / 157.52;
                                break;
                            //Euros
                            case 6:
                                total = txt / 138.65;
                                break;
                        }
                        break;
                    //Yuan
                    case 2:
                        switch (value02)
                        {
                            //Baht
                            case 0:
                                total = txt * 4.93;
                                break;
                            //Yen
                            case 1:
                                total = txt * 18.97;
                                break;
                            //Yuan
                            case 2:
                                total = txt;
                                break;
                            //Won
                            case 3:
                                total = txt * 184.58;
                                break;
                            //Dollar
                            case 4:
                                total = txt / 6.88;
                                break;
                            //Pound
                            case 5:
                                total = txt / 8.30;
                                break;
                            //Euros
                            case 6:
                                total = txt / 7.30;
                                break;
                        }
                        break;
                    //Won
                    case 3:
                        switch (value02)
                        {
                            //Baht
                            case 0:
                                total = txt / 37.4;
                                break;
                            //Yen
                            case 1:
                                total = txt / 9.72;
                                break;
                            //Yuan
                            case 2:
                                total = txt / 184.58;
                                break;
                            //Won
                            case 3:
                                total = txt;
                                break;
                            //Dollar
                            case 4:
                                total = txt / 1270.74;
                                break;
                            //Pound
                            case 5:
                                total = txt / 1531.94;
                                break;
                            //Euros
                            case 6:
                                total = txt / 1348.23;
                                break;
                        }
                        break;
                    //Dollar
                    case 4:
                        switch (value02)
                        {
                            //Baht
                            case 0:
                                total = txt * 34.01;
                                break;
                            //Yen
                            case 1:
                                total = txt * 130.66;
                                break;
                            //Yuan
                            case 2:
                                total = txt * 6.88;
                                break;
                            //Won
                            case 3:
                                total = txt * 1270.74;
                                break;
                            //Dollar
                            case 4:
                                total = txt;
                                break;
                            //Pound
                            case 5:
                                total = txt / 1.20;
                                break;
                            //Euros
                            case 6:
                                total = txt / 1.06;
                                break;
                        }
                        break;
                    //Pound
                    case 5:
                        switch (value02)
                        {
                            //Baht
                            case 0:
                                total = txt * 40.98;
                                break;
                            //Yen
                            case 1:
                                total = txt * 157.52;
                                break;
                            //Yuan
                            case 2:
                                total = txt * 6.88;
                                break;
                            //Won
                            case 3:
                                total = txt * 1531.94;
                                break;
                            //Dollar
                            case 4:
                                total = txt * 1.20;
                                break;
                            //Pound
                            case 5:
                                total = txt;
                                break;
                            //Euros
                            case 6:
                                total = txt * 1.13;
                                break;
                        }
                        break;

                    case 6:
                        switch (value02)
                        {
                            //Baht
                            case 0:
                                total = txt * 36.08;
                                break;
                            //Yen
                            case 1:
                                total = txt * 138.65;
                                break;
                            //Yuan
                            case 2:
                                total = txt * 7.30;
                                break;
                            //Won
                            case 3:
                                total = txt * 1348.23;
                                break;
                            //Dollar
                            case 4:
                                total = txt * 1.06;
                                break;
                            //Pound
                            case 5:
                                total = txt / 1.13;
                                break;
                            //Euros
                            case 6:
                                total = txt;
                                break;
                        }
                        break;

                }

                return string.Format("{0:#,##0.00##}", total);
            }
            return null;
        }

        private string Solution2(string _txt)
        {

            int value01 = pickerC01.SelectedIndex,
                value02 = pickerC02.SelectedIndex;

            if (!string.IsNullOrEmpty(enTry1.Text) &&
              !string.IsNullOrWhiteSpace(enTry1.Text))
            {
                double total = 0;
                double txt = double.Parse(_txt);
                switch (value02)
                {
                    //Baht
                    case 0:
                        switch (value01)
                        {
                            //Baht
                            case 0:
                                total = txt;
                                break;
                            //Yen
                            case 1:
                                total = txt * 3.84;
                                break;
                            //Yuan
                            case 2:
                                total = txt / 4.93;
                                break;
                            //Won
                            case 3:
                                total = txt * 37.4;
                                break;
                            //Dollar
                            case 4:
                                total = txt / 34.01;
                                break;
                            //Pound
                            case 5:
                                total = txt / 40.98;
                                break;
                            //Euros
                            case 6:
                                total = txt / 36.08;
                                break;
                        }
                        break;
                    //Yen
                    case 1:
                        switch (value01)
                        {
                            //Baht
                            case 0:
                                total = txt / 3.84;
                                break;
                            //Yen
                            case 1:
                                total = txt;
                                break;
                            //Yuan
                            case 2:
                                total = txt / 18.97;
                                break;
                            //Won
                            case 3:
                                total = txt * 9.72;
                                break;
                            //Dollar
                            case 4:
                                total = txt / 130.66;
                                break;
                            //Pound
                            case 5:
                                total = txt / 157.52;
                                break;
                            //Euros
                            case 6:
                                total = txt / 138.65;
                                break;
                        }
                        break;
                    //Yuan
                    case 2:
                        switch (value01)
                        {
                            //Baht
                            case 0:
                                total = txt * 4.93;
                                break;
                            //Yen
                            case 1:
                                total = txt * 18.97;
                                break;
                            //Yuan
                            case 2:
                                total = txt;
                                break;
                            //Won
                            case 3:
                                total = txt * 184.58;
                                break;
                            //Dollar
                            case 4:
                                total = txt / 6.88;
                                break;
                            //Pound
                            case 5:
                                total = txt / 8.30;
                                break;
                            //Euros
                            case 6:
                                total = txt / 7.30;
                                break;
                        }
                        break;
                    //Won
                    case 3:
                        switch (value01)
                        {
                            //Baht
                            case 0:
                                total = txt / 37.4;
                                break;
                            //Yen
                            case 1:
                                total = txt / 9.72;
                                break;
                            //Yuan
                            case 2:
                                total = txt / 184.58;
                                break;
                            //Won
                            case 3:
                                total = txt;
                                break;
                            //Dollar
                            case 4:
                                total = txt / 1270.74;
                                break;
                            //Pound
                            case 5:
                                total = txt / 1531.94;
                                break;
                            //Euros
                            case 6:
                                total = txt / 1348.23;
                                break;
                        }
                        break;
                    //Dollar
                    case 4:
                        switch (value01)
                        {
                            //Baht
                            case 0:
                                total = txt * 34.01;
                                break;
                            //Yen
                            case 1:
                                total = txt * 130.66;
                                break;
                            //Yuan
                            case 2:
                                total = txt * 6.88;
                                break;
                            //Won
                            case 3:
                                total = txt * 1270.74;
                                break;
                            //Dollar
                            case 4:
                                total = txt;
                                break;
                            //Pound
                            case 5:
                                total = txt / 1.20;
                                break;
                            //Euros
                            case 6:
                                total = txt / 1.06;
                                break;
                        }
                        break;
                    //Pound
                    case 5:
                        switch (value01)
                        {
                            //Baht
                            case 0:
                                total = txt * 40.98;
                                break;
                            //Yen
                            case 1:
                                total = txt * 157.52;
                                break;
                            //Yuan
                            case 2:
                                total = txt * 6.88;
                                break;
                            //Won
                            case 3:
                                total = txt * 1531.94;
                                break;
                            //Dollar
                            case 4:
                                total = txt * 1.20;
                                break;
                            //Pound
                            case 5:
                                total = txt;
                                break;
                            //Euros
                            case 6:
                                total = txt * 1.13;
                                break;
                        }
                        break;

                    case 6:
                        switch (value01)
                        {
                            //Baht
                            case 0:
                                total = txt * 36.08;
                                break;
                            //Yen
                            case 1:
                                total = txt * 138.65;
                                break;
                            //Yuan
                            case 2:
                                total = txt * 7.30;
                                break;
                            //Won
                            case 3:
                                total = txt * 1348.23;
                                break;
                            //Dollar
                            case 4:
                                total = txt * 1.06;
                                break;
                            //Pound
                            case 5:
                                total = txt / 1.13;
                                break;
                            //Euros
                            case 6:
                                total = txt;
                                break;
                        }
                        break;

                }

                return string.Format("{0:#,##0.00##}", total);
            }
            return null;
        }

    }
}

