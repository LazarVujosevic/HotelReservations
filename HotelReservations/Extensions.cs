using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservations
{
    public static class Extensions
    {
        public static bool isFree(this Room room, (int startDate, int endDate) period)
        {
            if (room.Reservations.Count == 0)
            {
                if (period.startDate >= 0 && period.startDate <= 365 && period.endDate >= 0 && period.endDate <= 365)
                    return true;

                return false;
            }
            else
            {
                foreach (var reservation in room.Reservations.OrderBy(x => x.StartDay))
                {
                    if (!period.isPeriodValid(reservation))
                        return false;
                }
            }

            return true;
        }

        private static bool isPeriodValid(this (int startDate, int endDate) period, Reservation reservation)
        {
            bool isStartDayValid = false;
            bool isSEndDayValid = false;
            if ((period.startDate < reservation.StartDay && period.startDate >= 0) ||
                        (period.startDate >= reservation.EndDay && period.startDate <= 365))
                isStartDayValid = true;
            if ((period.endDate < reservation.StartDay && period.endDate >= 0) ||
                        (period.endDate > reservation.EndDay && period.endDate <= 365))
                isSEndDayValid = true;

            if (isStartDayValid && isSEndDayValid && !(reservation.StartDay > period.startDate && reservation.EndDay < period.endDate))
                return true;

            return false;
        }
    }
}
