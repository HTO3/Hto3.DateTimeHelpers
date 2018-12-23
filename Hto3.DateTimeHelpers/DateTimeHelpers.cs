using System;
using System.Collections.Generic;

namespace Hto3.DateTimeHelpers
{
    /// <summary>
    /// Class containing helpers for date and time manipulation
    /// </summary>
    public static class DateTimeHelpers
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly Int64 _epochTicks = new DateTime(1970, 1, 1, 0, 0, 0).Ticks;
        /// <summary>
        /// Convert unix timestamp to UTC DateTime
        /// </summary>
        /// <param name="unixTime">Unix Timestamp</param>
        /// <returns></returns>
        public static DateTime UnixTimeToUTCDateTime(this Int64 unixTime)
        {
            var result = _epoch.AddSeconds(unixTime);
            return result;
        }
        /// <summary>
        /// Convert unix timestamp to DateTime
        /// </summary>
        /// <param name="unixTime">Unix Timestamp</param>
        /// <returns></returns>
        public static DateTime UnixTimeToDateTime(this Int64 unixTime)
        {
            var result = _epoch.AddSeconds(unixTime).ToLocalTime();
            return new DateTime(result.Ticks);
        }
        /// <summary>
        /// Convert Local DateTime to unix timestamp
        /// </summary>
        /// <param name="localTime">Local DateTime object</param>
        /// <returns></returns>
        public static Int64 LocalToUnixTime(this DateTime localTime)
        {
            if (localTime.Kind == DateTimeKind.Utc)
                throw new InvalidOperationException("Cannot use a utc DateTime. Needs to be a local or unspecified (assumed as a local) DateTime.");
            if (localTime.Kind == DateTimeKind.Unspecified)
                localTime = new DateTime(localTime.Ticks, DateTimeKind.Local);

            var utcTime = localTime.ToUniversalTime();
            return UTCtoUnixTime(utcTime);
        }
        /// <summary>
        /// Convert UTC DateTime to unix timestamp
        /// </summary>
        /// <param name="utcTimestamp">UTC DateTime object</param>
        /// <returns></returns>
        public static Int64 UTCtoUnixTime(DateTime utcTimestamp)
        {
            return (utcTimestamp.Ticks - _epochTicks) / TimeSpan.TicksPerSecond;
        }

        /// <summary>
        /// Convert UTC DateTime to unix timestamp
        /// </summary>
        /// <param name="utcTimestamp">UTC DateTime object</param>
        /// <returns>unix timestamp</returns>
        public static Int64 UTCtoUnixTime(this DateTimeOffset utcTimestamp)
        {
            return (utcTimestamp.Ticks - _epochTicks) / TimeSpan.TicksPerSecond;
        }
        /// <summary>
        /// Strip the time part of a complete DateTime
        /// </summary>
        /// <param name="dateWithTime">A DateTime</param>
        /// <returns></returns>
        public static DateTime StripTime(this DateTime dateWithTime)
        {
            return dateWithTime.Date;
        }
        /// <summary>
        /// Gets the dates between date range
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> EachDay(DateTime startDate, DateTime endDate)
        {
            for (var day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
                yield return day;
        }
        /// <summary>
        /// Get the first day of the next year of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextYear(this DateTime baseDate)
        {
            return new DateTime(baseDate.Year + 1, 1, 1);
        }
        /// <summary>
        /// Get the first day of the next month of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextMonth(this DateTime baseDate)
        {
            var next = baseDate.AddMonths(1);
            return new DateTime(next.Year, next.Month, 1);
        }
        /// <summary>
        /// Get the next day of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextDay(this DateTime baseDate)
        {
            var next = baseDate.AddDays(1);
            return new DateTime(next.Year, next.Month, next.Day);
        }
        /// <summary>
        /// Get the next hour of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextHour(this DateTime baseDate)
        {
            var next = baseDate.AddHours(1);
            return new DateTime(next.Year, next.Month, next.Day, next.Hour, 0, 0);
        }
        /// <summary>
        /// Get the next minute of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextMinute(this DateTime baseDate)
        {
            var next = baseDate.AddMinutes(1);
            return new DateTime(next.Year, next.Month, next.Day, next.Hour, next.Minute, 0);
        }
        /// <summary>
        /// Get the next second of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextSecond(this DateTime baseDate)
        {
            var next = baseDate.AddSeconds(1);
            return new DateTime(next.Year, next.Month, next.Day, next.Hour, next.Minute, next.Second);
        }
        /// <summary>
        /// Get the first day of the previous year of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousYear(this DateTime baseDate)
        {
            return new DateTime(baseDate.Year - 1, 1, 1);
        }
        /// <summary>
        /// Get the first day of the previous month of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousMonth(this DateTime baseDate)
        {
            var previous = baseDate.AddMonths(-1);
            return new DateTime(previous.Year, previous.Month, 1);
        }
        /// <summary>
        /// Get the previous day of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousDay(this DateTime baseDate)
        {
            var previous = baseDate.AddDays(-1);
            return new DateTime(previous.Year, previous.Month, previous.Day);
        }
        /// <summary>
        /// Get the previous hour of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousHour(this DateTime baseDate)
        {
            var previous = baseDate.AddHours(-1);
            return new DateTime(previous.Year, previous.Month, previous.Day, previous.Hour, 0, 0);
        }
        /// <summary>
        /// Get the previous minute of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousMinute(this DateTime baseDate)
        {
            var previous = baseDate.AddMinutes(-1);
            return new DateTime(previous.Year, previous.Month, previous.Day, previous.Hour, previous.Minute, 0);
        }
        /// <summary>
        /// Get the previous second of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousSecond(this DateTime baseDate)
        {
            var previous = baseDate.AddSeconds(-1);
            return new DateTime(previous.Year, previous.Month, previous.Day, previous.Hour, previous.Minute, previous.Second);
        }
        /// <summary>
        /// Return a new datetime with the same date but on midnight
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime Midnight(this DateTime baseDate)
        {
            return new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0);
        }
        /// <summary>
        /// Return a new datetime with the same date but on noon
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime Noon(this DateTime baseDate)
        {
            return new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 12, 0, 0);
        }
        /// <summary>
        /// Change the year of a DateTime
        /// </summary>
        /// <param name="me"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SetYear(this DateTime me, Int32 year)
        {
            return new DateTime(year, me.Month, me.Day, me.Hour, me.Minute, me.Second, me.Millisecond);
        }
        /// <summary>
        /// Change the month of a DateTime
        /// </summary>
        /// <param name="me"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime SetMonth(this DateTime me, Int32 month)
        {
            return new DateTime(me.Year, month, me.Day, me.Hour, me.Minute, me.Second, me.Millisecond);
        }
        /// <summary>
        /// Change the day of a DateTime
        /// </summary>
        /// <param name="me"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SetDay(this DateTime me, Int32 day)
        {
            return new DateTime(me.Year, me.Month, day, me.Hour, me.Minute, me.Second, me.Millisecond);
        }
        /// <summary>
        /// Change the hour of a DateTime
        /// </summary>
        /// <param name="me"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTime SetHour(this DateTime me, Int32 hour)
        {
            return new DateTime(me.Year, me.Month, me.Day, hour, me.Minute, me.Second, me.Millisecond);
        }
        /// <summary>
        /// Change the minute of a DateTime
        /// </summary>
        /// <param name="me"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTime SetMinute(this DateTime me, Int32 minute)
        {
            return new DateTime(me.Year, me.Month, me.Day, me.Hour, minute, me.Second, me.Millisecond);
        }
        /// <summary>
        /// Change the second of a DateTime
        /// </summary>
        /// <param name="me"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime SetSecond(this DateTime me, Int32 second)
        {
            return new DateTime(me.Year, me.Month, me.Day, me.Hour, me.Minute, second, me.Millisecond);
        }
        /// <summary>
        /// Change the milisecond of a DateTime
        /// </summary>
        /// <param name="me"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTime SetMillisecond(this DateTime me, Int32 millisecond)
        {
            return new DateTime(me.Year, me.Month, me.Day, me.Hour, me.Minute, me.Second, millisecond);
        }
        /// <summary>
        /// Get a collection of weeks of a month
        /// </summary>
        /// <param name="month">The month</param>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public static IReadOnlyCollection<Tuple<DateTime, DateTime>> GetMonthWeeks(Int32 month, Int32 year)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException("The month need to be between 1 and 12.");

            if (year < DateTime.MinValue.Year || year > DateTime.MaxValue.Year)
                throw new ArgumentOutOfRangeException("Out of range year.");

            var output = new List<Tuple<DateTime, DateTime>>();
            var firstDay = new DateTime(year, month, 1);
            var lastDay = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);

            var cursor = firstDay;
            while (cursor <= lastDay)
            {
                output.Add(new Tuple<DateTime, DateTime>
                (
                    cursor
                    ,
                    cursor.AddDays(6 - (Int32)cursor.DayOfWeek)
                ));

                cursor = cursor.AddDays(7 - (Int32)cursor.DayOfWeek);
            }

            return output;
        }
        /// <summary>
        /// Add weeks
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime AddWeeks(this DateTime reference, Double value)
        {
            return reference.AddDays(value * 7);
        }
        /// <summary>
        /// Add fortnights
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime AddFortnights(this DateTime reference, Int32 value)
        {
            var movedRef = reference.AddMonths(value / 2);

            if (reference.Day > 15)
            {
                var daysPassedFortnight = reference.Day - 15;

                if (value > 0)//advancing
                {
                    var aux = movedRef.AddMonths(1);
                    return new DateTime(aux.Year, aux.Month, daysPassedFortnight > 15 ? 15 : daysPassedFortnight);
                }
                else//regress
                {
                    var aux = new DateTime(movedRef.Year, movedRef.Month, 1);
                    return aux.AddDays(daysPassedFortnight - 1);
                }
            }
            else
            {
                if (value > 0)//advancing
                {
                    return new DateTime
                        (
                            movedRef.Year,
                            movedRef.Month,
                            movedRef.Day + 15 > movedRef.AmountDaysInMonth()
                                ? movedRef.AmountDaysInMonth()
                                : movedRef.Day + 15
                        );
                }
                else//regress
                {
                    var aux = movedRef.AddMonths(-1);
                    return new DateTime
                        (
                            aux.Year,
                            aux.Month,
                            movedRef.Day + 15 > aux.AmountDaysInMonth()
                                ? aux.AmountDaysInMonth()
                                : movedRef.Day + 15
                        );
                }
            }
        }

        /// <summary>
        /// Calculate the difference between two dates.
        /// </summary>
        /// <param name="start">Data Inicial</param>
        /// <param name="end">Data Final</param>
        /// <returns></returns>
        public static TimeSpan DateDiff(this DateTime start, DateTime end)
        {
            return end - start;          
        }
        /// <summary>
        /// Calculate the age in years based on the birthday. 
        /// </summary>
        /// <param name="birthday">birthday</param>
        /// <returns></returns>
        public static Int32 CalculateAge(this DateTime birthday)
        {
            return DateTime.MinValue.AddDays(DateTime.Now.Subtract(birthday).TotalHours / 24).Year - 1;
        }
        /// <summary>
        /// Verify if the date is between a range of dates
        /// </summary>
        /// <param name="reference">Data a se verificar</param>
        /// <param name="start">Data inicio do período</param>
        /// <param name="end">Data término do período</param>
        /// <returns>Verdadeiro, se a data estiver entre as duas outras informadas (inclusive nas duas pontas)</returns>
        public static Boolean IsBetween(this DateTime reference, DateTime start, DateTime end)
        {
            return reference >= start && reference <= end;
        }
        /// <summary>
        /// Return the date of the first day in the specified month
        /// </summary>
        /// <param name="value">Data para tomar como referência</param>
        /// <returns>Data no primeiro dia do mês, ou seja, dia 1</returns>
        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }
        /// <summary>
        /// Return the amount of days in the month
        /// </summary>
        /// <param name="value">Data para tomar como referência</param>
        /// <returns>Quantidade de dias no mês.</returns>
        public static Int32 AmountDaysInMonth(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }
        /// <summary>
        /// Return a new DateTime on the last day of the month based on the informed DateTime.
        /// </summary>
        /// <param name="value">Data para tomar como referência</param>
        /// <returns>Data no último dia do mês, ou seja, dia 28, 29, 30 ou 31</returns>
        public static DateTime LastDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.AmountDaysInMonth());
        }
        /// <summary>
        /// Return true if the numbers representing the year, month and day build a valid date.
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="month">month</param>
        /// <param name="day">day</param>
        /// <returns></returns>
        public static Boolean IsValidDate(Int32 year, Int32 month, Int32 day)
        {
            if (year <= DateTime.MaxValue.Year && year >= DateTime.MinValue.Year)
            {
                if (month >= 1 && month <= 12)
                {
                    if (DateTime.DaysInMonth(year, month) >= day && day >= 1)
                        return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Return the next odd full hour. Example: Now it's 09/09/2018 15:36:12 so the next odd full hour will be 09/09/2018 17:00:00.
        /// </summary>
        /// <returns></returns>
        public static DateTime NextOddHour()
        {
            var next = DateTimeHelpers.NextFullHour();

            if (next.Hour % 2 != 0)
                return next;
            else
                return next.AddHours(1);
        }
        /// <summary>
        /// Return the next even full hour. Example: Now it's 09/09/2018 15:36:12 so the next even full hour will be 09/09/2018 16:00:00.
        /// </summary>
        /// <returns></returns>
        public static DateTime NextEvenHour()
        {
            var next = DateTimeHelpers.NextFullHour();

            if (next.Hour % 2 != 0)
                return next.AddHours(1);
            else
                return next;
        }
        /// <summary>
        /// Return the next full hour. Example: Now it's 09/09/2018 15:36:12 so the next half hour will be 09/09/2018 16:00:00.
        /// </summary>
        /// <returns></returns>
        public static DateTime NextFullHour()
        {
            var nextHour = DateTime.Now.AddHours(1);
            return new DateTime(nextHour.Year, nextHour.Month, nextHour.Day, nextHour.Hour, 0, 0);
        }
        /// <summary>
        /// Return the next half hour. Example: Now it's 09/09/2018 15:36:12 so the next half hour will be 09/09/2018 16:00:00.
        /// </summary>
        /// <returns></returns>
        public static DateTime NextHalfHour()
        {
            var now = DateTime.Now;

            if (now.Minute >= 30)
                return DateTimeHelpers.NextFullHour();
            else
                return new DateTime(now.Year, now.Month, now.Day, now.Hour, 30, 0);
        }
    }
}
