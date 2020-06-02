using System;
using System.Collections.Generic;

namespace HotelReservations
{
    class Program
    {
        
        static void Main(string[] args)
        {
            HotelBusiness hb = new HotelBusiness();

            hb.InsertRooms(2);
            (int s, int e) period = (0,0);
            while (period.s != -5)
            {
                Console.WriteLine("S:");
                period.s = int.Parse(Console.ReadLine());

                Console.WriteLine("E:");
                period.e = int.Parse(Console.ReadLine());

                hb.BookRoom(period);
            }

            Console.ReadLine();
        }
        

        
    }
}
