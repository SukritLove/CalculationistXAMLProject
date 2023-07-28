using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Midterm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            birthDay.Clicked += BirthDay_Clicked;
            getBmi.Clicked += GetBmi_Clicked;
            currencyConv.Clicked += CurrencyConv_Clicked;
            dataConv.Clicked += DataConv_Clicked;
            disCount.Clicked += DisCount_Clicked;
            timeCal.Clicked += TimeCal_Clicked;
        }

         async private void TimeCal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimeCon());
        }

        async private void DisCount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DiscountCal());
        }

        async private void DataConv_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DataCal());
        }

        async private void CurrencyConv_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CurrencyPage());
        }

        async private void GetBmi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BmiPage());
        }

        async private void BirthDay_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalAge());
        }
    }
}

