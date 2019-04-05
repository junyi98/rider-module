using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using LiteDB;
using Firebase.Database;
using Firebase.Database.Query;
using FoodShare.Helper;
using FoodShare.Model;

namespace FoodShare
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }


        private async void signup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        public async void signin(object sender, EventArgs e)
        {
            var person = await firebaseHelper.GetPerson(txtName.Text );
            if (person != null)
            {

                System.Diagnostics.Debug.WriteLine("data: " + person);
                if (txtName.Text == person.Name && txtpass.Text == person.Password.ToString())
                {
                    await DisplayAlert("Success", "Log In Successfully", "OK");
                    App.loggedin = true;
                    var info = new Home();
                    var information = new Person
                    {
                        Name = txtName.Text,
                        Password = Convert.ToInt32(txtpass.Text),
                        ICNumber = person.ICNumber,
                        Address = person.Address,
                        HPNum = person.HPNum,
                        Email = person.Email
                    };
                    System.Diagnostics.Debug.WriteLine("information.Email: " + information.Email);
                    info.BindingContext = information;
                    Navigation.InsertPageBefore(info, this);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Authentication Fail", "Username or password incorrect", "OK");
                }

                // if (txtName.Text == allPersons.FirstOrDefault().name && txtpass.Text == GetPerson.FirstOrDefault().pass)
                //{
                //    App.loggedin = true;
                //    var info = new Home();
                //    var information = new user
                //    {
                //        name = txtName.Text
                //    };
                //    info.BindingContext = information;
                //    Navigation.InsertPageBefore(info, this);
                //    await Navigation.PopAsync();
                //}
                //txtName.Text = person.Name;
                //txtpass.Text = person.Password.ToString()
            }


        }
       
    }
}
