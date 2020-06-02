using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservations
{
    public class HotelBusiness
    {
        List<Room> rooms = new List<Room>();
        public void InsertRooms(int roomsNumbers)
        {
            for (int i = 0; i < roomsNumbers; i++)
            {
                rooms.Add(new Room { Name = $"Room{i + 1}", Reservations = new List<Reservation>() });
            }
        }

        public bool BookRoom((int startDate, int endDate) period)
        {
            foreach (var room in rooms)
            {
                if (room.isFree(period))
                {
                    room.Reservations.Add(new Reservation { StartDay = period.startDate, EndDay = period.endDate });
                    Console.WriteLine($"Booked {room.Name}");
                    return true;
                }
            }

            Console.WriteLine("All rooms booked for that period");
            return false;
        } 
    }
}
