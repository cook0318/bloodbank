using System;

namespace bloodbank
{
    class Donor
    {
        
        public Donor(string name, int age, string bloodType, long phoneNumber, int id)
        {
            this.name = name;
            this.age = age;
            this.bloodType = bloodType;
            this.phoneNumber = phoneNumber;
            this.id = id;
        }
        
        
        public string name { get; set; }
        public int age { get; set; }
        public string bloodType { get; set; }
        public long phoneNumber { get; set; }
        public int id { get; private set; }
    }
}
