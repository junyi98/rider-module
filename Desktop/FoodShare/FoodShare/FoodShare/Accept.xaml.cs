using System;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using FoodShare.Helper;
using FoodShare.Model;


using Xamarin.Forms;

namespace FoodShare
{
    public partial class Accept : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public Accept()
        {
            InitializeComponent();
        }

        //protected async override void OnAppearing()
        //{

        //    base.OnAppearing();
        //    var allJob = await firebaseHelper.GetAllJob();
        //    JobList.ItemsSource = allJob;
        //}
        private async void startPickUp(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(" https://waze.com/ul/hw281r3dy3&navigate=yes"));
        }

        private async void startDelivery(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://waze.com/ul/hw281x4cx3&navigate=yes"));
        }


    }
}



