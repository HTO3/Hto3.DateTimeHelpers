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
        private static readonly Int64 _epochTicks = 621355968000000000L;
        /// <summary>
        /// Convert unix timestamp to UTC DateTime.
        /// </summary>
        /// <param name="unixTime">Unix Timestamp</param>
        /// <returns></returns>
        public static DateTime UnixTimeToUTCDateTime(this Int64 unixTime)
        {
            var result = _epoch.AddSeconds(unixTime);
            return result;
        }
        /// <summary>
        /// Convert unix timestamp to DateTime.
        /// </summary>
        /// <param name="unixTime">Unix Timestamp</param>
        /// <returns></returns>
        public static DateTime UnixTimeToDateTime(this Int64 unixTime)
        {
            var result = _epoch.AddSeconds(unixTime).ToLocalTime();
            return new DateTime(result.Ticks);
        }
        /// <summary>
        /// Convert a DateTime to unix timestamp.
        /// </summary>
        /// <param name="dateTime">DateTime object</param>
        /// <returns></returns>
        public static Int64 ToUnixTime(this DateTime dateTime)
        {
            var utcTime = dateTime.Kind == DateTimeKind.Utc ? dateTime : dateTime.ToUniversalTime();
            return (utcTime.Ticks - _epochTicks) / TimeSpan.TicksPerSecond;
        }
        /// <summary>
        /// Strip the time part of a DateTime.
        /// </summary>
        /// <param name="dateWithTime">A DateTime</param>
        /// <returns></returns>
        public static DateTime StripTime(this DateTime dateWithTime)
        {
            return dateWithTime.Date;
        }
        /// <summary>
        /// Gets the dates between date range.
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
        /// Get the first day of the next year of a base date. This is the same as calling .AddYears(1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextYear(this DateTime baseDate)
        {
            return baseDate.AddYears(1);
        }
        /// <summary>
        /// Get the first day of the next month of a base date. This is the same as calling .AddMonths(1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextMonth(this DateTime baseDate)
        {
            return baseDate.AddMonths(1);
        }
        /// <summary>
        /// Get the next day of a base date. This is the same as calling .AddDays(1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextDay(this DateTime baseDate)
        {
            return baseDate.AddDays(1);
        }
        /// <summary>
        /// Get the next week of a base date. This is the same as calling .AddWeeks(1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextWeek(this DateTime baseDate)
        {
            return baseDate.AddWeeks(1);
        }
        /// <summary>
        /// Get the next hour of a base DateTime. This is the same as calling .AddHours(1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextHour(this DateTime baseDate)
        {
            return baseDate.AddHours(1);
        }
        /// <summary>
        /// Get the next minute of a base DateTime. This is the same as calling .AddMinutes(1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextMinute(this DateTime baseDate)
        {
            return baseDate.AddMinutes(1);
        }
        /// <summary>
        /// Get the next second of a base DateTime. This is the same as calling .AddSeconds(1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextSecond(this DateTime baseDate)
        {
            return baseDate.AddSeconds(1);
        }
        /// <summary>
        /// Get the first day of the previous year of a base date. This is the same as calling .AddYears(-1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime PreviousYear(this DateTime baseDate)
        {
            return baseDate.AddYears(-1);
        }
        /// <summary>
        /// Get the first day of the previous month of a base date. This is the same as calling .AddMonths(-1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime PreviousMonth(this DateTime baseDate)
        {
            return baseDate.AddMonths(-1);
        }
        /// <summary>
        /// Get the previous day of a base date. This is the same as calling .AddDays(-1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime PreviousDay(this DateTime baseDate)
        {
            return baseDate.AddDays(-1);
        }
        /// <summary>
        /// Get the previous week of a base DateTime. This is the same as calling .AddWeeks(-1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime PreviousWeek(this DateTime baseDate)
        {
            return baseDate.AddWeeks(-1);
        }
        /// <summary>
        /// Get the previous hour of a base DateTime. This is the same as calling .AddHours(-1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime PreviousHour(this DateTime baseDate)
        {
            return baseDate.AddHours(-1);
        }
        /// <summary>
        /// Get the previous minute of a base DateTime. This is the same as calling .AddMinutes(-1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime PreviousMinute(this DateTime baseDate)
        {
            return baseDate.AddMinutes(-1);
        }
        /// <summary>
        /// Get the previous second of a base DateTime. This is the same as calling .AddSeconds(-1).
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime PreviousSecond(this DateTime baseDate)
        {
            return baseDate.AddSeconds(-1);
        }
        /// <summary>
        /// Return a new datetime with the same date but on midnight.
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime Midnight(this DateTime baseDate)
        {
            return new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0);
        }
        /// <summary>
        /// Return a new datetime with the same date but on noon.
        /// </summary>
        /// <param name="baseDate">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime Noon(this DateTime baseDate)
        {
            return new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 12, 0, 0);
        }
        /// <summary>
        /// Change the year of a DateTime.
        /// </summary>
        /// <param name="me">A DateTime to change</param>
        /// <param name="year">The new year</param>
        /// <returns></returns>
        public static DateTime SetYear(this DateTime me, Int32 year)
        {
            if (!DateTimeHelpers.IsValidDate(year, me.Month, me.Day))
                throw new ArgumentOutOfRangeException(nameof(year), "Invalid year!");

            return new DateTime(year, me.Month, me.Day, me.Hour, me.Minute, me.Second, me.Millisecond);
        }
        /// <summary>
        /// Change the month of a DateTime.
        /// </summary>
        /// <param name="me">A DateTime to change</param>
        /// <param name="month">The new month</param>
        /// <returns></returns>
        public static DateTime SetMonth(this DateTime me, Int32 month)
        {
            if (!DateTimeHelpers.IsValidDate(me.Year, month, me.Day))
                throw new ArgumentOutOfRangeException(nameof(month), "Invalid month!");

            return new DateTime(me.Year, month, me.Day, me.Hour, me.Minute, me.Second, me.Millisecond);
        }
        /// <summary>
        /// Change the day of a DateTime.
        /// </summary>
        /// <param name="me">A DateTime to change</param>
        /// <param name="day">the new day</param>
        /// <returns></returns>
        public static DateTime SetDay(this DateTime me, Int32 day)
        {
            if (!DateTimeHelpers.IsValidDate(me.Year, me.Month, day))
                throw new ArgumentOutOfRangeException(nameof(day), "Invalid day!");

            return new DateTime(me.Year, me.Month, day, me.Hour, me.Minute, me.Second, me.Millisecond);
        }
        /// <summary>
        /// Change the hour of a DateTime.
        /// </summary>
        /// <param name="me">A DateTime to change</param>
        /// <param name="hour">The new hour</param>
        /// <returns></returns>
        public static DateTime SetHour(this DateTime me, Int32 hour)
        {
            if (!DateTimeHelpers.IsValidTime(hour, me.Minute, me.Second))
                throw new ArgumentOutOfRangeException(nameof(hour), "Invalid hour!");

            return new DateTime(me.Year, me.Month, me.Day, hour, me.Minute, me.Second, me.Millisecond);
        }
        /// <summary>
        /// Change the minute of a DateTime.
        /// </summary>
        /// <param name="me">A DateTime to change</param>
        /// <param name="minute">The new minute</param>
        /// <returns></returns>
        public static DateTime SetMinute(this DateTime me, Int32 minute)
        {
            if (!DateTimeHelpers.IsValidTime(me.Hour, minute, me.Second))
                throw new ArgumentOutOfRangeException(nameof(minute), "Invalid minute!");

            return new DateTime(me.Year, me.Month, me.Day, me.Hour, minute, me.Second, me.Millisecond);
        }
        /// <summary>
        /// Change the second of a DateTime.
        /// </summary>
        /// <param name="me">A DateTime to change</param>
        /// <param name="second">The new second</param>
        /// <returns></returns>
        public static DateTime SetSecond(this DateTime me, Int32 second)
        {
            if (!DateTimeHelpers.IsValidTime(me.Hour, me.Minute, second))
                throw new ArgumentOutOfRangeException(nameof(second), "Invalid second!");

            return new DateTime(me.Year, me.Month, me.Day, me.Hour, me.Minute, second, me.Millisecond);
        }
        /// <summary>
        /// Change the milisecond of a DateTime.
        /// </summary>
        /// <param name="me">A DateTime to change</param>
        /// <param name="millisecond">The new millisecond</param>
        /// <returns></returns>
        public static DateTime SetMillisecond(this DateTime me, Int32 millisecond)
        {
            if (millisecond < 0)
                throw new ArgumentOutOfRangeException(nameof(millisecond), "Invalid millisecond!");

            return new DateTime(me.Year, me.Month, me.Day, me.Hour, me.Minute, me.Second, millisecond);
        }
        /// <summary>
        /// Get a collection of weeks of a month.
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
                var start = cursor;
                var end = cursor.AddDays(6 - (Int32)cursor.DayOfWeek);

                if (end > lastDay)
                    end = lastDay;

                output.Add(new Tuple<DateTime, DateTime>(start, end));

                cursor = cursor.AddDays(7 - (Int32)cursor.DayOfWeek);
            }

            return output;
        }
        /// <summary>
        /// Add weeks.
        /// </summary>
        /// <param name="reference">The point in your timeline</param>
        /// <param name="value">Amount weeks to add</param>
        /// <returns></returns>
        public static DateTime AddWeeks(this DateTime reference, Double value)
        {
            return reference.AddDays(value * 7);
        }
        /// <summary>
        /// Calculate the difference between two dates.
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
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
        /// Verify if the date is between a range of dates.
        /// </summary>
        /// <param name="reference">Date to verify</param>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <returns>Verdadeiro, se a data estiver entre as duas outras informadas (inclusive nas duas pontas)</returns>
        public static Boolean IsBetween(this DateTime reference, DateTime start, DateTime end)
        {
            return reference >= start && reference <= end;
        }
        /// <summary>
        /// Return the date of the first day in the specified month.
        /// </summary>
        /// <param name="value">Date to use as reference</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }
        /// <summary>
        /// Return the amount of days in the month.
        /// </summary>
        /// <param name="value">Date to use as reference</param>
        /// <returns></returns>
        public static Int32 AmountDaysInMonth(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }
        /// <summary>
        /// Return a new DateTime on the last day of the month based on the informed DateTime.
        /// </summary>
        /// <param name="value">Date to use as reference</param>
        /// <returns></returns>
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
        /// <param name="reference">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextFullOddHour(DateTime reference)
        {
            var next = DateTimeHelpers.NextFullHour(reference);

            if (next.Hour % 2 != 0)
                return next;
            else
                return DateTimeHelpers.NextFullHour(next);
        }
        /// <summary>
        /// Return the next even full hour. Example: Now it's 09/09/2018 15:36:12 so the next even full hour will be 09/09/2018 16:00:00.
        /// </summary>
        /// <param name="reference">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextFullEvenHour(DateTime reference)
        {
            var next = DateTimeHelpers.NextFullHour(reference);

            if (next.Hour % 2 != 0)
                return DateTimeHelpers.NextFullHour(next);
            else
                return next;
        }
        /// <summary>
        /// Return the next full hour. Example: Now it's 09/09/2018 15:36:12 so the next half hour will be 09/09/2018 16:00:00.
        /// </summary>
        /// <param name="reference">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextFullHour(DateTime reference)
        {
            var nextHour = reference.AddHours(1);
            return new DateTime(nextHour.Year, nextHour.Month, nextHour.Day, nextHour.Hour, 0, 0);
        }
        /// <summary>
        /// Return the next half hour. Example: Now it's 09/09/2018 15:36:12 so the next half hour will be 09/09/2018 16:00:00.
        /// </summary>
        /// <param name="reference">The point in your timeline</param>
        /// <returns></returns>
        public static DateTime NextHalfHour(DateTime reference)
        {
            if (reference.Minute >= 30)
                return DateTimeHelpers.NextFullHour(reference);
            else
                return new DateTime(reference.Year, reference.Month, reference.Day, reference.Hour, 30, 0);
        }
    }
}
