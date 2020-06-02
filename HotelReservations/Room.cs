using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservations
{
    public class Room
    {
        public string Name { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
