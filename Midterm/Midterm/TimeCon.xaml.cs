using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Midterm
{
    public partial class TimeCon : ContentPage
    {
        public TimeCon()
        {
            InitializeComponent();

            start();
            inPut00.Focused += InPut_Focused;
            inPut01.Focused += InPut_Focused; ;

            inPut00.TextChanged += InPut_TextChanged;
            inPut01.TextChanged += InPut_TextChanged;

            inPut00.Placeholder = "Input number";
            inPut01.Placeholder = "Input number";

            picK00.SelectedIndexChanged += Pick_SelectedIndexChanged;
            picK01.SelectedIndexChanged += Pick_SelectedIndexChanged;
        }
        //----------------Start----------------
        private void start()
        {
            String[] dataName = { "Day", "Hour", "Minute", "Second" };

            foreach (String _dataName in dataName)
            {
                picK00.Items.Add(_dataName);
                picK01.Items.Add(_dataName);
            }

            picK00.SelectedIndex = 0;
            picK01.SelectedIndex = 1;



            inPut00.Text = "1";
            inPut01.Text = Solution("1");

        }
        //----------------Start----------------

        private bool check(int func)
        {
            if (func == 1)
            {
                if (string.IsNullOrEmpty(inPut00.Text) &&
                    string.IsNullOrWhiteSpace(inPut00.Text))

                {
                    return false;
                }
            }
            if (func == 2)
            {
                if (string.IsNullOrEmpty(inPut01.Text) &&
                string.IsNullOrWhiteSpace(inPut01.Text))
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
                inPut01.Text = Solution(inPut00.Text);
            }

            semaphoreFlag = false;
        }

        private bool semaphoreFlag = false;

        private void InPut_Focused(object sender, FocusEventArgs e)
        {
            var EntryTapped = (Xamarin.Forms.Entry)sender;

            Device.BeginInvokeOnMainThread(() =>
            {


                if (EntryTapped.ClassId == "1")
                {

                    if (!string.IsNullOrEmpty(inPut00.Text) &&
                        !string.IsNullOrWhiteSpace(inPut00.Text))
                    {
                        inPut00.CursorPosition = 0;
                        inPut00.SelectionLength = inPut00.Text.Length;
                    }
                }


                else if (EntryTapped.ClassId == "2")
                {
                    if (!string.IsNullOrEmpty(inPut01.Text) &&
                        !string.IsNullOrWhiteSpace(inPut01.Text))
                    {
                        inPut01.CursorPosition = 0;
                        inPut01.SelectionLength = inPut01.Text.Length;
                    }
                }

            });
        }

        private async void InPut_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (semaphoreFlag) return;
            semaphoreFlag = true;
            var EntryTapped = (Xamarin.Forms.Entry)sender;

            Device.BeginInvokeOnMainThread(() =>
            {


                if (EntryTapped.ClassId == "1")
                {
                    double number = 0;
                    if (double.TryParse(inPut00.Text, out number))
                    {
                        if (number >= 0)
                        {
                            inPut01.Text = Solution(inPut00.Text);
                        }
                    }
                    semaphoreFlag = false;
                }

                else if (EntryTapped.ClassId == "2")
                {
                    double number = 0;
                    if (double.TryParse(inPut01.Text, out number))
                    {
                        if (number >= 0)
                        {
                            inPut00.Text = Solution2(inPut01.Text);
                        }
                    }
                    semaphoreFlag = false;
                }

            });

        }


        //-------------Solution-------------
        private string Solution(string _txt)
        {

            int value0 = picK00.SelectedIndex,
                value1 = picK01.SelectedIndex;

            if (!string.IsNullOrEmpty(_txt) &&
                !string.IsNullOrWhiteSpace(_txt))
            {
                double txt = double.Parse(_txt),
                       total = 0;
                switch (value0)
                {
                    case 0:
                        switch (value1)
                        {

                            case 0:
                                total = double.Parse(inPut00.Text);
                                break;
                            case 1:
                                total = txt * 24;
                                break;

                            case 2:
                                total = txt * 1440;
                                break;

                            case 3:
                                total = txt * 86400;
                                break;
                        }
                        break;

                    case 1:
                        switch (value1)
                        {

                            case 0:
                                total = txt / 24;
                                break;
                            case 1:
                                total = double.Parse(inPut00.Text);
                                break;
                            case 2:
                                total = txt * 60;
                                break;
                            case 3:
                                total = txt * 3600;
                                break;
                        }
                        break;

                    case 2:
                        switch (value1)
                        {

                            case 0:
                                total = txt / 1440;
                                break;
                            case 1:
                                total = txt / 60;
                                break;

                            case 2:
                                total = double.Parse(inPut00.Text);
                                break;

                            case 3:
                                total = txt * 60;
                                break;
                        }
                        break;

                    case 3:
                        switch (value1)
                        {

                            case 0:
                                total = txt / 86400;
                                break;
                            case 1:
                                total = txt / 3600;
                                break;

                            case 2:
                                total = txt / 60;
                                break;

                            case 3:
                                total = double.Parse(inPut00.Text);
                                break;
                        }
                        break;

                }
                return string.Format("{0:#,##0.###}", total);
            }
            else
            {
                return null;
            }

        }

        private string Solution2(string _txt)
        {

            int value0 = picK00.SelectedIndex,
                value1 = picK01.SelectedIndex;

            if (!string.IsNullOrEmpty(_txt) &&
                !string.IsNullOrWhiteSpace(_txt))
            {
                double txt = double.Parse(_txt),
                   total = 0;
                switch (value1)
                {
                    case 0:
                        switch (value0)
                        {

                            case 0:
                                total = double.Parse(inPut01.Text);
                                break;
                            case 1:
                                total = txt * 24;
                                break;

                            case 2:
                                total = txt * 1440;
                                break;

                            case 3:
                                total = txt * 86400;
                                break;
                        }
                        break;

                    case 1:
                        switch (value0)
                        {

                            case 0:
                                total = txt / 24;
                                break;
                            case 1:
                                total = double.Parse(inPut01.Text);
                                break;
                            case 2:
                                total = txt * 60;
                                break;
                            case 3:
                                total = txt * 3600;
                                break;
                        }
                        break;

                    case 2:
                        switch (value0)
                        {

                            case 0:
                                total = txt / 1440;
                                break;
                            case 1:
                                total = txt / 60;
                                break;

                            case 2:
                                total = double.Parse(inPut01.Text);
                                break;

                            case 3:
                                total = txt * 60;
                                break;
                        }
                        break;

                    case 3:
                        switch (value0)
                        {

                            case 0:
                                total = txt / 86400;
                                break;
                            case 1:
                                total = txt / 3600;
                                break;

                            case 2:
                                total = txt / 60;
                                break;

                            case 3:
                                total = double.Parse(inPut01.Text);
                                break;
                        }
                        break;
                }
                return string.Format("{0:#,##0.###}", total);
            }
            else
            {
                return null;
            }

        }
    }
}

