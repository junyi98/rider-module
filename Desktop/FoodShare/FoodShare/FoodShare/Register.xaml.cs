using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LiteDB;
using System.IO;
using Firebase.Database;
using Firebase.Database.Query;
using FoodShare.Helper;
using FoodShare.Model;

namespace FoodShare
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public Register ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
           //lstPersons.ItemsSource = allPersons;
        }

        private async void signup(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson(Convert.ToInt32(txtpass.Text), txtName.Text, Convert.ToInt32(txtic.Text), txtadd.Text, Convert.ToInt32(txtphone.Text),txtemail.Text);
            txtpass.Text = string.Empty;
            txtName.Text = string.Empty;
            txtic.Text = string.Empty;
            txtadd.Text = string.Empty;
            txtphone.Text = string.Empty;
            txtemail.Text = string.Empty;
            //await firebaseHelper.AddJob(txtDeliverAddressName.Text, txtDeliverAddress.Text,  txtPickUpAddressName.Text, txtPickUpAddress.Text);



            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
           // lstPersons.ItemsSource = allPersons;
        }

        //void signup(object sender, EventArgs e)
        //{
        //    var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), @"testuser.db");
        //    using(var db = new LiteDatabase(dbpath))
        //    {
        //        var col = db.GetCollection<user>("users");
        //        var user = new user
        //        {
        //            name = txtname.Text,
        //            ic = txtic.Text,
        //            add = txtadd.Text,
        //            phone = txtphone.Text,
        //            email = txtemail.Text,
        //            pass = txtpass.Text
        //        };
        //        col.Upsert(user);
        //        DisplayAlert("Sign up", "Sign up successfully", "OK");

        //    }
        //}
	}
}