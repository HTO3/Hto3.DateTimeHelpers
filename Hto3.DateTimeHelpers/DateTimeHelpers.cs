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
        /// <param name="localDateTime">Local DateTime object</param>
        /// <returns></returns>
        public static Int64 LocalToUnixTime(this DateTime localDateTime)
        {
            if (localDateTime.Kind == DateTimeKind.Utc)
                throw new InvalidOperationException("Cannot use a utc DateTime. Needs to be a local or unspecified (assumed as a local) DateTime.");
            if (localDateTime.Kind == DateTimeKind.Unspecified)
                localDateTime = new DateTime(localDateTime.Ticks, DateTimeKind.Local);

            var utcTime = localDateTime.ToUniversalTime();
            return UTCtoUnixTime(utcTime);
        }
        /// <summary>
        /// Convert UTC DateTime to unix timestamp
        /// </summary>
        /// <param name="utcDateTime">UTC DateTime object</param>
        /// <returns></returns>
        public static Int64 UTCtoUnixTime(this DateTime utcDateTime)
        {
            return (utcDateTime.Ticks - _epochTicks) / TimeSpan.TicksPerSecond;
        }
        /// <summary>
        /// Strip the time part of a DateTime
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
        public static IEnumerable<DateTime> EachDay(this DateTime startDate, DateTime endDate)
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
            return baseDate.AddYears(1);
        }
        /// <summary>
        /// Get the first day of the next month of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextMonth(this DateTime baseDate)
        {
            return baseDate.AddMonths(1);
        }
        /// <summary>
        /// Get the next day of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextDay(this DateTime baseDate)
        {
            return baseDate.AddDays(1);
        }
        /// <summary>
        /// Get the next hour of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextHour(this DateTime baseDate)
        {
            return baseDate.AddHours(1);
        }
        /// <summary>
        /// Get the next minute of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextMinute(this DateTime baseDate)
        {
            return baseDate.AddMinutes(1);
        }
        /// <summary>
        /// Get the next second of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime NextSecond(this DateTime baseDate)
        {
            return baseDate.AddSeconds(1);
        }
        /// <summary>
        /// Get the first day of the previous year of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousYear(this DateTime baseDate)
        {
            return baseDate.AddYears(-1);
        }
        /// <summary>
        /// Get the first day of the previous month of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousMonth(this DateTime baseDate)
        {
            return baseDate.AddMonths(-1);
        }
        /// <summary>
        /// Get the previous day of a base date
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousDay(this DateTime baseDate)
        {
            return baseDate.AddDays(-1);
        }
        /// <summary>
        /// Get the previous hour of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousHour(this DateTime baseDate)
        {
            return baseDate.AddHours(-1);
        }
        /// <summary>
        /// Get the previous minute of a base DateTime
        /// </summary>
        /// <param name="baseDate"></param>
        /// <returns></returns>
        public static DateTime PreviousMinute(this DateTime baseDate)
        {
            return baseDate.AddMinutes(-1);
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
            if (!DateTimeHelpers.IsValidDate(year, me.Month, me.Day))
                throw new InvalidOperationException("Invalid month!");

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
            if (!DateTimeHelpers.IsValidDate(me.Year, month, me.Day))
                throw new InvalidOperationException("Invalid month!");

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
            if (!DateTimeHelpers.IsValidDate(me.Year, me.Month, day))
                throw new InvalidOperationException("Invalid day!");

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
            if (!DateTimeHelpers.IsValidTime(hour, me.Minute, me.Second))
                throw new InvalidOperationException("Invalid hour!");

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
            if (!DateTimeHelpers.IsValidTime(me.Hour, minute, me.Second))
                throw new InvalidOperationException("Invalid minute!");

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
            if (!DateTimeHelpers.IsValidTime(me.Hour, me.Minute, second))
                throw new InvalidOperationException("Invalid minute!");

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
            if (birthday > DateTime.Now)
                return (DateTime.MinValue.AddDays(birthday.Subtract(DateTime.Now).TotalHours / 24).Year - 1) * -1;
            else
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
        /// Return true if the numbers representing the hour, minute and second of a time build a valid time.
        /// </summary>
        /// <param name="hour">hour</param>
        /// <param name="minute">minute</param>
        /// <param name="second">second</param>
        /// <returns></returns>
        public static Boolean IsValidTime(Int32 hour, Int32 minute, Int32 second)
        {
            if (hour <= 23 && hour >= 0)
            {
                if (minute <= 59 && minute >= 0)
                {
                    if (second <= 59 && second >= 0)
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
