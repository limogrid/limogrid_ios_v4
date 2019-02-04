using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using limo_droid_v4.Models;

namespace limo_droid_v4.Data
{
    public class Reservation
    {
        public static Models.Reservation reservation = new Models.Reservation();

        public static void SalvaId(int id_reserva)
        {
            reservation.Id_reservation = id_reserva;
            Debug.WriteLine("RESERVA: " + id_reserva);
        }
    }
    
}
