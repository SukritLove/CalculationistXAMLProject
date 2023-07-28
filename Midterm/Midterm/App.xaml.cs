using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Midterm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new SplashPage();
        }
        public class SplashPage : ContentPage
        {
            Image splashImage;

            public SplashPage()
            {
                NavigationPage.SetHasNavigationBar(this, false);

                var sub = new AbsoluteLayout();
                splashImage = new Image
                {
                    Source = "icon.png",
                    WidthRequest = 100,
                    HeightRequest = 100
                };
                AbsoluteLayout.SetLayoutFlags(splashImage,
                   AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(splashImage,
                 new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

                sub.Children.Add(splashImage);

                this.BackgroundColor = Color.FromHex("#D7AF8B");
                this.Content = sub;
            }


            protected override async void OnAppearing()
            {
                base.OnAppearing();

                await splashImage.ScaleTo(1.1, 1500); //Time-consuming processes such as initialization
                await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
                await splashImage.FadeTo(0, 300, Easing.Linear);

                var main = new MainPage();
                var np = new NavigationPage(main);
                np.BarBackgroundColor = Color.FromHex("#CE6143");
                np.BarTextColor = Color.FromHex("#070D0C");
                Application.Current.MainPage = np;    //After loading  MainPage it gets Navigated to our new Page
            }

        }
    }
}

