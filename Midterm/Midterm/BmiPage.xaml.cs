using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Midterm
{
    public partial class BmiPage : ContentPage
    {
        public BmiPage()
        {
            InitializeComponent();

            inputHeight.Focused += EnTry_Focused;
            inputWeight.Focused += EnTry_Focused;

            start();
            go.Clicked += Go_Clicked;
        }

        private void Go_Clicked(object sender, EventArgs e)
        {
            if (!check(1) && !check(2))
            {
                error();
            }
            else
            {
                Solution();
            }

        }

        public void start()
        {
            string[] _weight = { "Kilograms", "Pounds" },
                     _height = { "Centimeters", "Meters", "Feet", "Inches" };

            foreach (string weight in _weight)
            {
                wEight.Items.Add(weight);
            }
            foreach (string height in _height)
            {
                hEight.Items.Add(height);
            }

            wEight.SelectedIndex = 0;
            hEight.SelectedIndex = 0;
            inputWeight.Text = "90";
            inputHeight.Text = "170";
            Solution();

        }
        public bool check(int function)
        {
            if (function == 1)
            {
                if (string.IsNullOrEmpty(inputHeight.Text) &&
                    string.IsNullOrWhiteSpace(inputHeight.Text))
                {
                    return false;
                }
            }
            if (function == 2)
            {
                if (string.IsNullOrEmpty(inputWeight.Text) &&
                string.IsNullOrWhiteSpace(inputWeight.Text))
                {
                    return false;
                }
            }
            return true;
        }

        public void Solution()
        {
            double num = 0,
                   weight,
                   height;
            string txt = "";

            if (check(1) && check(2))
            {
                weight = double.Parse(inputWeight.Text);
                height = double.Parse(inputHeight.Text);

                if (wEight.SelectedIndex == 1)
                {
                    weight = weight / 2.20462;
                }

                if (hEight.SelectedIndex == 0)
                {
                    height = height / 100;
                }

                else if (hEight.SelectedIndex == 2)
                {
                    height = height / 3.28084;
                }

                else if (hEight.SelectedIndex == 3)
                {
                    height = height / 39.721;
                }

                num = weight / (height * height);


                if (num != 0)
                {
                    if (num < 18.5)
                    {
                        txt = "Underweight";
                        clear(2);
                        clear(3);
                        bmiRe.TextColor = Color.FromHex("#3d85c6");
                        under.FontAttributes = FontAttributes.Bold;
                        under.TextColor = Color.FromHex("#3d85c6");
                    }
                    else if (num >= 18.5 && num <= 25.0)
                    {
                        txt = "Normal";
                        clear(1);
                        clear(3);
                        bmiRe.TextColor = Color.FromHex("#93c47d");
                        norm.FontAttributes = FontAttributes.Bold;
                        norm.TextColor = Color.FromHex("#93c47d");
                    }
                    else if (num >= 25.0)
                    {
                        txt = "Overweight";
                        clear(1);
                        clear(2);
                        bmiRe.TextColor = Color.FromHex("#ff0000");
                        over.FontAttributes = FontAttributes.Bold;
                        over.TextColor = Color.FromHex("#ff0000");
                    }

                }
            }
            else
            {
                error();
            }

            if (num >= 50 || num < 1)
            {
                error();
            }
            else
            {
                bmiRe.Text = txt;
                bMi.Text = num != 0 ? string.Format("{0:#,##0.0}", num) : "0";
            }
        }

        async private void error()
        {
            inputHeight.Text = null;
            inputWeight.Text = null;
            bmiRe.Text = "none";
            bmiRe.TextColor = Color.FromHex("#EDE4E5");
            bMi.Text = "0";

            clear(0);

            await DisplayAlert("", "This BMI doesn't look right.", "OK");
        }

        private void clear(int function)
        {
            if (function == 0)
            {
                under.FontAttributes = FontAttributes.None;
                over.FontAttributes = FontAttributes.None;
                norm.FontAttributes = FontAttributes.None;

                under.TextColor = Color.FromHex("#EDE4E5");
                over.TextColor = Color.FromHex("#EDE4E5");
                norm.TextColor = Color.FromHex("#EDE4E5");
            }
            else if (function == 1)
            {
                under.FontAttributes = FontAttributes.None;
                under.TextColor = Color.FromHex("#EDE4E5");
            }
            else if (function == 2)
            {
                norm.FontAttributes = FontAttributes.None;
                over.TextColor = Color.FromHex("#EDE4E5");
            }
            else if (function == 3)
            {
                norm.FontAttributes = FontAttributes.None;
                over.TextColor = Color.FromHex("#EDE4E5");
            }
        }


        private void EnTry_Focused(object sender, FocusEventArgs e)
        {
            var EntryTapped = (Xamarin.Forms.Entry)sender;

            Device.BeginInvokeOnMainThread(() =>
            {
                if (EntryTapped.ClassId == "1")
                {
                    if (!string.IsNullOrEmpty(inputWeight.Text) &&
                        !string.IsNullOrWhiteSpace(inputWeight.Text))
                    {
                        inputWeight.Text = null;
                    }
                }


                else if (EntryTapped.ClassId == "2")
                {
                    if (!string.IsNullOrEmpty(inputHeight.Text) &&
                        !string.IsNullOrWhiteSpace(inputHeight.Text))
                    {
                        inputHeight.Text = null;
                    }
                }

            });
        }




    }
}

