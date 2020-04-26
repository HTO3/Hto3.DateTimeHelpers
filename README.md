<img alt="logo" width="150" height="150" src="nuget-logo.png">

Hto3.DateTimeHelpers
========================================

|Nuget Package|Build|Test Coverage|
|---|---|---|
|[![Hto3.DateTimeHelpers](https://img.shields.io/nuget/v/Hto3.DateTimeHelpers.svg)](https://www.nuget.org/packages/Hto3.DateTimeHelpers/)|[![Build Status](https://travis-ci.org/HTO3/Hto3.DateTimeHelpers.svg?branch=master)](https://travis-ci.org/HTO3/Hto3.DateTimeHelpers)|[![codecov](https://codecov.io/gh/HTO3/Hto3.DateTimeHelpers/branch/master/graph/badge.svg)](https://codecov.io/gh/HTO3/Hto3.DateTimeHelpers)|

Features
--------
A set of extension methods that can be used to manipulate date and time solving common dev problems.

### UnixTimeToUTCDateTime

Convert unix timestamp to UTC DateTime

```csharp
1544572230L.UnixTimeToUTCDateTime() == new DateTime(2018, 12, 11, 23, 50, 30, DateTimeKind.Utc);
```

### UnixTimeToDateTime

Convert unix timestamp to DateTime

```csharp
1544572230L.UnixTimeToDateTime() == new DateTime(2018, 12, 11, 21, 50, 30); //When local timezone is -02:00 GMT
```

### ToUnixTime

Convert a DateTime to unix timestamp

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).ToUnixTime() == 1544572230L; //When local timezone is -02:00 GMT
```

### StripTime

Strip the time part of a DateTime

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).StripTime() == new DateTime(2018, 12, 11);
```

### EachDay

Gets the dates between date range

```csharp
var start = new DateTime(2018, 2, 26);
var end = new DateTime(2018, 3, 4);

var result = start.EachDay(end).ToArray();

result[0] == new DateTime(2018, 2, 26);
result[1] == new DateTime(2018, 2, 27);
result[2] == new DateTime(2018, 2, 28);
result[3] == new DateTime(2018, 3, 1);
result[4] == new DateTime(2018, 3, 2);
result[5] == new DateTime(2018, 3, 3);
result[6] == new DateTime(2018, 3, 4);
```

### NextMonth

Get the first day of the next month of a base date. This is the same as calling .AddMonths(1).

```csharp
new DateTime(2018, 3, 4).NextYear() == new DateTime(2019, 4, 4);
```

### NextYear

Get the first day of the next year of a base date. This is the same as calling .AddYears(1).

```csharp
new DateTime(2018, 3, 4).NextYear() == new DateTime(2019, 3, 4);
```

### NextDay

Get the next day of a base date. This is the same as calling .AddDays(1).

```csharp
new DateTime(2018, 3, 4).NextDay() == new DateTime(2018, 3, 5);
```

### NextWeek

Get the next week of a base date. This is the same as calling .AddWeeks(1).

```csharp
new DateTime(2018, 3, 4).NextWeek() == new DateTime(2018, 3, 11);
```

### NextHour

Get the next hour of a base DateTime. This is the same as calling .AddHours(1).

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).NextHour() == new DateTime(2018, 12, 11, 22, 50, 30);
```

### NextMinute

Get the next minute of a base DateTime. This is the same as calling .AddMinutes(1).

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).NextMinute() == new DateTime(2018, 12, 11, 21, 51, 30);
```

### NextSecond

Get the next second of a base DateTime. This is the same as calling .AddSeconds(1).

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).NextSecond() == new DateTime(2018, 12, 11, 21, 50, 31);
```

### PreviousYear

Get the first day of the previous year of a base date. This is the same as calling .AddYears(-1).

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousYear() == new DateTime(2017, 12, 11, 21, 50, 30);
```

### PreviousMonth

Get the first day of the previous month of a base date. This is the same as calling .AddMonths(-1).

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousMonth() == new DateTime(2018, 11, 11, 21, 50, 30);
```

### PreviousDay

Get the previous day of a base date. This is the same as calling .AddDays(-1).

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousDay() == new DateTime(2018, 12, 10, 21, 50, 30);
```

### PreviousWeek

Get the previous week of a base DateTime. This is the same as calling .AddWeeks(-1).

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousWeek() == new DateTime(2018, 12, 8, 21, 50, 30);
```

### PreviousHour

Get the previous hour of a base DateTime. This is the same as calling .AddHours(-1).

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousHour() == new DateTime(2018, 12, 11, 20, 50, 30);
```

### PreviousMinute

Get the previous minute of a base DateTime. This is the same as calling .AddMinutes(-1).

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousMinute() == new DateTime(2018, 12, 11, 21, 49, 30);
```

### PreviousSecond

Get the previous second of a base DateTime. This is the same as calling .AddSeconds(-1).

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousSecond() == new DateTime(2018, 12, 11, 21, 50, 29);
```

### Midnight

Returns a new datetime with the same date but at midnight.

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).Midnight() == new DateTime(2018, 12, 11, 0, 0, 0);
```

### Noon

Returns a new datetime with the same date but at noon.

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).Noon() == new DateTime(2018, 12, 11, 12, 0, 0);
```

### SetYear

Change the year of a DateTime.

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetYear(1999) == new DateTime(1999, 12, 11, 21, 50, 30);
```

### SetMonth

Change the month of a DateTime.

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetMonth(10) == new DateTime(2018, 10, 11, 21, 50, 30);
```

### SetDay

Change the day of a DateTime.

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetDay(27) == new DateTime(2018, 12, 27, 21, 50, 30);
```

### SetHour

Change the hour of a DateTime.

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetHour(1) == new DateTime(2018, 12, 11, 1, 50, 30);
```

### SetMinute

Change the minute of a DateTime.

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetMinute(9) == new DateTime(2018, 12, 11, 9, 50, 30);
```

### SetSecond

Change the second of a DateTime.

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetSecond(0) == new DateTime(2018, 12, 11, 21, 50, 0);
```

### SetMillisecond

Change the milisecond of a DateTime.

```csharp
new DateTime(2018, 12, 11, 21, 50, 30, 3).SetMillisecond(9) == new DateTime(2018, 12, 11, 21, 50, 30, 9);
```

### GetMonthWeeks

Get a collection of weeks of a month.

```csharp
var weeks = DateTimeHelpers.GetMonthWeeks(2, 2018);

weeks.ElementAt(0).Item1 == new DateTime(2018, 2, 1);//week start
weeks.ElementAt(0).Item2 == new DateTime(2018, 2, 3);//week end

weeks.ElementAt(1).Item1 == new DateTime(2018, 2, 4);//week start
weeks.ElementAt(1).Item2 == new DateTime(2018, 2, 10);//week end

weeks.ElementAt(2).Item1 == new DateTime(2018, 2, 11);//week start
weeks.ElementAt(2).Item2 == new DateTime(2018, 2, 17);//week end

weeks.ElementAt(3).Item1 == new DateTime(2018, 2, 18);//week start
weeks.ElementAt(3).Item2 == new DateTime(2018, 2, 24);//week end

weeks.ElementAt(4).Item1 == new DateTime(2018, 2, 25);//week start
weeks.ElementAt(4).Item2 == new DateTime(2018, 2, 28);//week end
```

### AddWeeks

Add weeks.

```csharp
new DateTime(2018, 10, 1).AddWeeks(1) == new DateTime(2018, 10, 8);
```

### DateDiff

Calculate the difference between two dates.

```csharp
var start = new DateTime(2010, 1, 1);
var end = new DateTime(2010, 1, 2);
start.DateDiff(end) == TimeSpan.FromDays(1);
```

### CalculateAge

Calculate the age in years based on the birthday.

```csharp
//assuming today as 02/26/2019
new DateTime(2018, 2, 25).CalculateAge() == 1;
```

### IsBetween

Verify if the date is between a range of dates.

```csharp
var start = new DateTime(2009, 1, 1);
var end = new DateTime(2010, 1, 2);
new DateTime(2010, 1, 1).IsBetween(start, end) == true;
```

### FirstDayOfMonth

Return the date of the first day in the specified month.

```csharp
new DateTime(2018, 2, 26).FirstDayOfMonth() == new DateTime(2018, 2, 1);
```

### AmountDaysInMonth

Return the amount of days in the month.

```csharp
//Date used only to extract the year and month
new DateTime(2018, 1, 1).AmountDaysInMonth() == 31;
```

### LastDayOfMonth

Return a new DateTime on the last day of the month based on the informed DateTime.

```csharp
//Date used only to extract the year and month
new DateTime(2018, 1, 1).AmountDaysInMonth() == 31;
```

### IsValidDate

Return true if the numbers representing the year, month and day build a valid date.

```csharp
DateTimeHelpers.IsValidDate(2010, 1, 20) == true;
DateTimeHelpers.IsValidDate(99, -1, 99) == false;
```

### IsValidTime

Return true if the numbers representing the hour, minute and second of a time build a valid time.

```csharp
DateTimeHelpers.IsValidTime(23, 59, 1) == true;
DateTimeHelpers.IsValidTime(24, -1, 0) == false;
```

### NextFullOddHour

Return the next odd full hour. Example: Now it's 09/09/2018 15:36:12 so the next odd full hour will be 09/09/2018 17:00:00.

```csharp
var dateAndTime = new DateTime(2010, 10, 3, 12, 22, 7);
var expected = new DateTime(2010, 10, 3, 13, 0, 0);
dateAndTime.NextFullOddHour() == expected;
```

### NextFullEvenHour

Return the next even full hour. Example: Now it's 09/09/2018 15:36:12 so the next even full hour will be 09/09/2018 16:00:00.

```csharp
var dateAndTime = new DateTime(2010, 10, 3, 12, 22, 7);
var expected = new DateTime(2010, 10, 3, 14, 0, 0);
dateAndTime.NextFullOddHour() == expected;
```

### NextFullHour

Return the next full hour. Example: Now it's 09/09/2018 15:36:12 so the next half hour will be 09/09/2018 16:00:00.

```csharp
var dateAndTime = new DateTime(2010, 10, 3, 12, 22, 7);
var expected = new DateTime(2010, 10, 3, 13, 0, 0);
dateAndTime.NextFullOddHour() == expected;
```

### NextHalfHour

Return the next half hour. Example: Now it's 09/09/2018 15:36:12 so the next half hour will be 09/09/2018 16:00:00.

```csharp
var dateAndTime = new DateTime(2010, 10, 3, 12, 22, 7);
var expected = new DateTime(2010, 10, 3, 12, 30, 0);
dateAndTime.NextFullOddHour() == expected;
```