<img alt="logo" width="150" height="150" src="nuget-logo.png">

Hto3.DateTimeHelpers
========================================

#### Nuget Package
[![Hto3.DateTimeHelpers](https://img.shields.io/nuget/v/Hto3.DateTimeHelpers.svg)](https://www.nuget.org/packages/Hto3.DateTimeHelpers/)


Features
--------
A set of extension methods that can be used to facilitate the manipulation of date and time solving common dev problems.

### UnixTimeToUTCDateTime

```csharp
1544572230L.UnixTimeToUTCDateTime() == new DateTime(2018, 12, 11, 23, 50, 30, DateTimeKind.Utc);
```

### UnixTimeToDateTime

```csharp
1544572230L.UnixTimeToDateTime() == new DateTime(2018, 12, 11, 21, 50, 30); //When local timezone is -02:00 GMT
```

### ToUnixTime

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).ToUnixTime() == 1544572230L; //When local timezone is -02:00 GMT
```

### StripTime

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).StripTime() == new DateTime(2018, 12, 11);
```

### EachDay

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

### NextYear

```csharp
new DateTime(2018, 3, 4).NextYear() == new DateTime(2019, 3, 4);
```

### NextDay

```csharp
new DateTime(2018, 3, 4).NextDay() == new DateTime(2018, 3, 5);
```

### NextWeek

```csharp
new DateTime(2018, 3, 4).NextDay() == new DateTime(2018, 3, 11);
```

### NextHour

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).NextHour() == new DateTime(2018, 12, 11, 22, 50, 30);
```

### NextMinute

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).NextMinute() == new DateTime(2018, 12, 11, 21, 51, 30);
```

### NextSecond

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).NextSecond() == new DateTime(2018, 12, 11, 21, 50, 31);
```

### PreviousYear

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousYear() == new DateTime(2017, 12, 11, 21, 50, 30);
```

### PreviousMonth

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousMonth() == new DateTime(2018, 11, 11, 21, 50, 30);
```

### PreviousDay

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousDay() == new DateTime(2018, 12, 10, 21, 50, 30);
```

### PreviousWeek

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousWeek() == new DateTime(2018, 12, 8, 21, 50, 30);
```

### PreviousHour

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousHour() == new DateTime(2018, 12, 11, 20, 50, 30);
```

### PreviousMinute

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousMinute() == new DateTime(2018, 12, 11, 21, 49, 30);
```

### PreviousSecond

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).PreviousSecond() == new DateTime(2018, 12, 11, 21, 50, 29);
```

### Midnight

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).Midnight() == new DateTime(2018, 12, 11, 0, 0, 0);
```

### Noon

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).Noon() == new DateTime(2018, 12, 11, 12, 0, 0);
```

### SetYear

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetYear(1999) == new DateTime(1999, 12, 11, 21, 50, 30);
```

### SetMonth

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetMonth(10) == new DateTime(2018, 10, 11, 21, 50, 30);
```

### SetDay

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetDay(27) == new DateTime(2018, 12, 27, 21, 50, 30);
```

### SetHour

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetHour(1) == new DateTime(2018, 12, 11, 1, 50, 30);
```

### SetMinute

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetMinute(9) == new DateTime(2018, 12, 11, 9, 50, 30);
```

### SetSecond

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).SetSecond(0) == new DateTime(2018, 12, 11, 21, 50, 0);
```

### SetMillisecond

```csharp
new DateTime(2018, 12, 11, 21, 50, 30, 3).SetMillisecond(9) == new DateTime(2018, 12, 11, 21, 50, 30, 9);
```

### GetMonthWeeks

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

```csharp
new DateTime(2018, 10, 1).AddWeeks(1) == new DateTime(2018, 10, 8);
```

### DateDiff

```csharp
var start = new DateTime(2010, 1, 1);
var end = new DateTime(2010, 1, 2);
start.DateDiff(end) == TimeSpan.FromDays(1);
```

### CalculateAge

```csharp
//assuming today as 02/26/2019
new DateTime(2018, 2, 25).CalculateAge() == 1;
```

### IsBetween

```csharp
var start = new DateTime(2009, 1, 1);
var end = new DateTime(2010, 1, 2);
new DateTime(2010, 1, 1).IsBetween(start, end) == true;
```

### FirstDayOfMonth

```csharp
new DateTime(2018, 2, 26).FirstDayOfMonth() == new DateTime(2018, 2, 1);
```

### AmountDaysInMonth

```csharp
//Date used only to extract the year and month
new DateTime(2018, 1, 1).AmountDaysInMonth() == 31;
```

### LastDayOfMonth

```csharp
//Date used only to extract the year and month
new DateTime(2018, 1, 1).AmountDaysInMonth() == 31;
```

### IsValidDate

```csharp
DateTimeHelpers.IsValidDate(2010, 1, 20) == true;
DateTimeHelpers.IsValidDate(99, -1, 99) == false;
```

### IsValidTime

```csharp
DateTimeHelpers.IsValidTime(23, 59, 1) == true;
DateTimeHelpers.IsValidTime(24, -1, 0) == false;
```

### NextFullOddHour

```csharp
var dateAndTime = new DateTime(2010, 10, 3, 12, 22, 7);
var expected = new DateTime(2010, 10, 3, 13, 0, 0);
dateAndTime.NextFullOddHour() == expected;
```

### NextFullEvenHour

```csharp
var dateAndTime = new DateTime(2010, 10, 3, 12, 22, 7);
var expected = new DateTime(2010, 10, 3, 14, 0, 0);
dateAndTime.NextFullOddHour() == expected;
```

### NextFullHour

```csharp
var dateAndTime = new DateTime(2010, 10, 3, 12, 22, 7);
var expected = new DateTime(2010, 10, 3, 13, 0, 0);
dateAndTime.NextFullOddHour() == expected;
```

### NextHalfHour

```csharp
var dateAndTime = new DateTime(2010, 10, 3, 12, 22, 7);
var expected = new DateTime(2010, 10, 3, 12, 30, 0);
dateAndTime.NextFullOddHour() == expected;
```