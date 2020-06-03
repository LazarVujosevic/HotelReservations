using System;
using System.Collections.Generic;

namespace HotelReservations
{
    class Program
    {
        
        static void Main(string[] args)
        {
            HotelBusiness hotelBusiness = new HotelBusiness();

            int numberOfRooms;
            Console.WriteLine("Number of rooms:");
            numberOfRooms = int.Parse(Console.ReadLine());

            hotelBusiness.InsertRooms(numberOfRooms);
            (int startDay, int endDay) period = (0,0);

            //-365 is number for exit booking loop
            while (period.startDay != -365)
            {
                Console.WriteLine("Start Day:");
                period.startDay = int.Parse(Console.ReadLine());

                Console.WriteLine("End Day:");
                period.endDay = int.Parse(Console.ReadLine());

                hotelBusiness.BookRoom(period);
            }

            Console.ReadLine();
        }
        

        
    }
}
