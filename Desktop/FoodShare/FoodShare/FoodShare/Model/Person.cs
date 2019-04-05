using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShare.Model
{
    public class Person
    {
        public int Password { get; set; }
        public string Name { get; set; }
        public int ICNumber {get; set;}
        public string Address {get; set;}
        public int HPNum {get; set;}
        public string Email {get; set;}
    }

    public class Job
    {
        public string Pickup_AddressName { get; set; }
        public string Pickup_Address { get; set; }
        public string Deliver_AddressName { get; set; }
        public string Deliver_Address { get; set; }

    }
}
