using System;
using System.Collections.Generic;
using System.Text;

namespace limo_droid_v4.Models
{
    public class Reservation
    {
        public int Id_reservation { get; set; }
        public Reservation() { }
        public Reservation(int Id_reservation)
        {
            this.Id_reservation = Id_reservation;
        }

    }
}
