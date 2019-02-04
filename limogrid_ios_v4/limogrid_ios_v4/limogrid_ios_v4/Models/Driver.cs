using System;
using System.Collections.Generic;
using System.Text;

namespace limo_droid_v4.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public int Id_Chauffeur { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Company_Id { get; set; }

        public Driver() { }
        public Driver(string Email, string First_Name, string Last_Name, string Phone, string City, string Company_Id, int Id_Chauffeur)
        {
            this.Email = Email;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Phone = Phone;
            this.City = City;
            this.Company_Id = Company_Id;
            this.Id_Chauffeur = Id_Chauffeur;
        }
    }
}
