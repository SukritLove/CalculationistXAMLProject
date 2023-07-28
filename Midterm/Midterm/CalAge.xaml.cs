using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;




namespace Midterm
{

    public partial class CalAge : ContentPage
    {
        public CalAge()
        {
            InitializeComponent();
            datePick.DateSelected += DatePick_DateSelected;
            dateToday.DateSelected += DateToday_DateSelected;
            Start();
    }
        //--------------------------Start----------------------------------------
        private void Start()
        {
            age();   
        }
        //-------------------------Show Age--------------------------------------
        private void age()
        {
            int dPick = datePick.Date.Day,
                mPick = datePick.Date.Month,
                yPick = datePick.Date.Year,
                dToday = dateToday.Date.Day,
                mToday = dateToday.Date.Month,
                yToday = dateToday.Date.Year;

            int[] month = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            
            if(dPick > dToday)
            {
                dToday = (dToday + month[mPick - 1])-1;
                mToday = mToday - 1;
            }

            if(mPick > mToday)
            {
                yToday = yToday - 1;
                mToday = mToday + 12;
            }

            int dFin = dToday - dPick,
                mFin = mToday - mPick,
                yFin = yToday - yPick;

            labelYear.Text = (yFin).ToString();
            labelMonth.Text = (mFin).ToString();
            labelDays.Text = (dFin).ToString();
        }
        //-------------------------Next Birthday---------------------------------
        
        //-------------------------Date Select-----------------------------------
        private void DatePick_DateSelected(object sender, DateChangedEventArgs e)
        {
            age();
        }
        //-------------------------Today Select----------------------------------
        private void DateToday_DateSelected(object sender, DateChangedEventArgs e)
        {
            age();
        }
        //-----------------------------------------------------------------------


    }
}

