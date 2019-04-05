using System;
using System.Collections.Generic;
using System.Text;
using FoodShare.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodShare.Helper
{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://icpfoodshare.firebaseio.com/");

        public async Task<List<Person>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Name = item.Object.Name,
                  Password = item.Object.Password
              }).ToList();
        }


        public async Task AddPerson(int Password, string name, int ic, string address, int HPNum, string email)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { Password = Password, Name = name, ICNumber = ic, Address = address, HPNum = HPNum, Email = email });
        }

        //internal Task AddPerson(int v, string text1, string text2, string text3, string text4, string text5)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Person> GetPerson(string name)
        {
            var allPersons = await GetAllPersons();
            await firebase
                .Child("Persons")
                .OnceAsync<Person>();

            //var retrieve = (await firebase
            //      .Child("Persons")
            //      .OnceAsync<Person>()).Where(a => a.Object.Name == name).FirstOrDefault();

            //System.Diagnostics.Debug.WriteLine("allPersons = : " + data);
            return allPersons.Where(a => a.Name == name).FirstOrDefault();
            //return allPersons(name).GetValue();
            //return allPersons.EqualTo(name).AddListenerForSingleValueEvent(userListener));
            //return allPersons;
            //var data = allPersons.Where(a => a.Name == name).FirstOrDefault();

            //return data;
        }

        public async Task UpdatePerson(int Password, string name)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.Password == Password).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { Password = Password, Name = name });
        }

        public async Task DeletePerson(int Password)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.Password == Password).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }

        public async Task<List<Job>> GetAllJob()
        {

            return (await firebase
              .Child("Job")
              .OnceAsync<Job>()).Select(item => new Job
              {
                  Deliver_Address = item.Object.Deliver_Address,
                  Pickup_Address = item.Object.Pickup_Address
              }).ToList();
        }

        public async Task AddJob(string txtDeliverAddressName, string txtDeliverAddress, string txtPickUpAddressName, string txtPickUpAddress)
        {

            await firebase
              .Child("Job")
              .PostAsync(new Job() { Pickup_AddressName = txtPickUpAddressName, Pickup_Address = txtPickUpAddress , Deliver_AddressName = txtDeliverAddressName, Deliver_Address = txtDeliverAddress });
        }

    }
}
