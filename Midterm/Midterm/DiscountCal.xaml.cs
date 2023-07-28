using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Midterm
{
    public partial class DiscountCal : ContentPage
    {
        public DiscountCal()
        {

            InitializeComponent();
            inputOrigin.Focused += Input_Focused;
            inputDiscount.Focused += Input_Focused;

            inputOrigin.TextChanged += Input_TextChanged;
            inputDiscount.TextChanged += Input_TextChanged;
            start();

        }

        private void start()
        {
            Solution(inputOrigin.Text, inputDiscount.Text);
        }

        private async void Input_Focused(object sender, FocusEventArgs e)
        {
            var EntryTapped = (Xamarin.Forms.Entry)sender;

            Device.BeginInvokeOnMainThread(() =>
            {
                if (EntryTapped.ClassId == "1")
                {
                    if (!string.IsNullOrEmpty(inputOrigin.Text) &&
                        !string.IsNullOrWhiteSpace(inputOrigin.Text))
                    {
                        inputOrigin.CursorPosition = 0;
                        inputOrigin.SelectionLength = inputOrigin.Text.Length;
                    }
                }


                else if (EntryTapped.ClassId == "2")
                {
                    if (!string.IsNullOrEmpty(inputDiscount.Text) &&
                        !string.IsNullOrWhiteSpace(inputDiscount.Text))
                    {
                        inputDiscount.CursorPosition = 0;
                        inputDiscount.SelectionLength = inputDiscount.Text.Length;
                    }
                }

            });
        }

        private bool semaphoreFlag = false;

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (semaphoreFlag) return;
            semaphoreFlag = true;
            var EntryTapped = (Xamarin.Forms.Entry)sender;

            Device.BeginInvokeOnMainThread(() =>
            {


                if (EntryTapped.ClassId == "1")
                {

                    double number;
                    if (check(1))
                    {

                        if (double.TryParse(inputOrigin.Text, out number))
                        {
                            if (number >= 0)
                            {
                                Solution(inputOrigin.Text, inputDiscount.Text);
                            }
                            else
                            {
                                error(1);
                            }
                        }

                    }
                    else if (!check(1))
                    {
                        fiNal.Text = "0.00".ToString();
                        diFF.Text = "0.00".ToString();
                    }
                    if (!check(2))
                    {
                        if (double.TryParse(inputOrigin.Text, out number))
                        {
                            if (number >= 0)
                            {
                                fiNal.Text = inputOrigin.Text;

                                diFF.Text = "0.00".ToString();

                            }
                        }
                    }
                    if (!check(2) && !check(1))
                    {
                        fiNal.Text = "0.00".ToString();
                        diFF.Text = "0.00".ToString();
                    }


                    semaphoreFlag = false;

                }


                else if (EntryTapped.ClassId == "2")
                {
                    double number;
                    if (check(2))
                    {

                        if (double.TryParse(inputDiscount.Text, out number))
                        {
                            if (number >= 0)
                            {
                                Solution(inputOrigin.Text, inputDiscount.Text);
                            }
                        }
                    }
                    //DiscountNull
                    else if (!check(2))
                    {
                        if (double.TryParse(inputDiscount.Text, out number))
                        {
                            if (number >= 0)
                            {

                                diFF.Text = "0.00".ToString();
                                fiNal.Text = inputOrigin.Text;
                            }
                        }
                        else
                        {
                            diFF.Text = "0.00".ToString();
                            fiNal.Text = inputOrigin.Text;
                        }
                    }
                    //DiscountNull

                    //AllnNull
                    if (!check(2) && !check(1))
                    {
                        fiNal.Text = "0.00".ToString();
                        diFF.Text = "0.00".ToString();
                    }
                    //AllnNull
                    semaphoreFlag = false;
                }

            });

        }

        private bool check(int function)
        {

            if (function == 1)
            {
                if (string.IsNullOrEmpty(inputOrigin.Text) &&
                    string.IsNullOrWhiteSpace(inputOrigin.Text))
                {
                    return false;
                }
            }

            else if (function == 2)
            {
                if (string.IsNullOrEmpty(inputDiscount.Text) &&
                    string.IsNullOrWhiteSpace(inputDiscount.Text))
                {
                    return false;
                }
            }
            else if (function == 3)
            {
                double _dis = double.Parse(inputDiscount.Text);
                if (_dis < 0 || _dis > 100)
                {
                    return false;
                }
            }
            return true;
        }

        private void Solution(string price, string discount)
        {
            double total = 0, diff = 0, _price, _discount;
            if (check(1) && check(2))
            {

                _price = double.Parse(price);
                _discount = double.Parse(discount);
                if (check(3))
                {
                    total = _price - (_price * (_discount / 100));
                    diff = _price - total;
                }
                else
                {
                    total = _price;

                    error(2);
                }
            }


            fiNal.Text = string.Format("{0:#,##0.00}",total);

            diFF.Text = total == 0 ? "0.00" : string.Format("{0:#,##0.00}", diff);

        }
        async private void error(int function)
        {
            if (function == 1)
            {
                fiNal.Text = "0".ToString();
                await DisplayAlert("", "Price can't be negative.", "OK");
            }
            else if (function == 2)
            {
                inputDiscount.Text = "100".ToString();
                await DisplayAlert("", "Discount % doesn't look right.", "OK");
            }
            else if (function == 3)
            {
                diFF.Text = "0".ToString();
                fiNal.Text = inputOrigin.Text;
                await DisplayAlert("", "Price can't be negative.", "OK");
            }

        }
    }
}

