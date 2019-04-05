using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using LiteDB;
using Firebase.Database;
using Firebase.Database.Query;
using FoodShare.Helper;
using FoodShare.Model;

namespace FoodShare
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public Home ()
		{
			InitializeComponent ();
            
		}

        async void notify(object sender, ToggledEventArgs e)
        {
            if(notification.IsToggled == true)
            {
                var answer = await DisplayAlert("Delivery", "Pick up point: 23, jalan usj 12/1D\nDelivery point: KDU Glenmarie", "Accept", "Cancel");
                System.Diagnostics.Debug.WriteLine("Answer: " + answer);
                if (answer == true)
                {
                    await Navigation.PushAsync(new Accept());
                    //Device.OpenUri(new Uri("https://waze.com/ul?q=KDU%20Glenmarie&navigate=yes"));
                    //try
                    //{
                    //    // Launch Waze to look for Hawaii:
                    //    String url = "https://waze.com/ul?q=KDU%20Glenmarie&navigate=yes";
                    //    Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse(url));
                    //    startActivity(intent);
                    //}
                    //catch (ActivityNotFoundException ex)
                    //{
                    //    // If Waze is not installed, open it in Google Play:
                    //    Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("market://details?id=com.waze"));
                    //    startActivity(intent);
                    //}
                }
            }


        }

        async void clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new History());
        }

        async void click(object sender, EventArgs e)
        {


            var person = await firebaseHelper.GetPerson(label.Text);

            var info = new Profile();
            var information = new Person
            {
                Name = person.Name,
                ICNumber = person.ICNumber,
                Address = person.Address,
                HPNum = person.HPNum,
                Email = person.Email,
                Password = person.Password
            };


            System.Diagnostics.Debug.WriteLine("information: " + information);
            info.BindingContext = information;
            Navigation.InsertPageBefore(info,this);
            await Navigation.PushAsync(new Profile());





            //if(label.Text == person.Name)
            //{
            //     var info = new Person
            //     {
            //         Name = person.Name,
            //         ICNumber = person.ICNumber,
            //         Address = person.Address,
            //         HPNum = person.HPNum,
            //         Email = person.Email,
            //         Password = person.Password
            //       };

            //       System.Diagnostics.Debug.WriteLine("person.name: " + info);
            //     var infos = new Profile();
            //     infos.BindingContext = info;
            //     await Navigation.PushAsync(new Profile());
            //}


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
            //var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), @"testuser.db");
            //using (var db = new LiteDatabase(dbPath))
            //{
            //    var col = db.GetCollection<user>("users");
            //    var list = col.FindAll().ToList();
            //    foreach(var i in list)
            //    {
            //        var info = new user
            //        {
            //            name = i.name,
            //            ic = i.ic,
            //            add = i.add,
            //            phone = i.phone,
            //            email = i.email,
            //            pass = i.pass
            //        };
            //        if(label.Text == i.name)
            //        {
            //            var infos = new Profile();
            //            infos.BindingContext = info;
            //            await Navigation.PushAsync(infos);
            //        }
            //    }
            //}

        }
    }
}