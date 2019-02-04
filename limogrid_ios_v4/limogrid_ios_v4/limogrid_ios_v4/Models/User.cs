using System;
using System.Collections.Generic;
using System.Text;

namespace limo_droid_v4.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Device { get; set; }
        public string Company { get; set; }

        public User() { }
        public User(string Username, string Password, string Device, string Company)
        {
            this.Username = Username;
            this.Password = Password;
            this.Device = Device;
            this.Company = Company;
        }

        public bool CheckInformation()
        {
            if ((!this.Username.Equals("") && !this.Password.Equals("") && !this.Company.Equals("")))
            {

                return Data.User.CheckCredentials(this.Username, this.Password, this.Device, this.Company);
            }
            else
            {
                return false;
            }
        }
    }
}
