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
1544572230L.UnixTimeToDateTime() == new DateTime(2018, 12, 11, 21, 50, 30); //When local is -02:00 GMT
```

### ToUnixTime

```csharp
new DateTime(2018, 12, 11, 21, 50, 30).ToUnixTime() == 1544572230L;
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
//todo: put an example of use
```

### PreviousYear

```csharp
//todo: put an example of use
```

### PreviousMonth

```csharp
//todo: put an example of use
```

### PreviousDay

```csharp
//todo: put an example of use
```

### PreviousWeek

```csharp
//todo: put an example of use
```

### PreviousHour

```csharp
//todo: put an example of use
```

### PreviousMinute

```csharp
//todo: put an example of use
```

### PreviousSecond

```csharp
//todo: put an example of use
```

### Midnight

```csharp
//todo: put an example of use
```

### Noon

```csharp
//todo: put an example of use
```

### SetYear

```csharp
//todo: put an example of use
```

### SetMonth

```csharp
//todo: put an example of use
```

### SetDay

```csharp
//todo: put an example of use
```

### SetHour

```csharp
//todo: put an example of use
```

### SetMinute

```csharp
//todo: put an example of use
```

### SetSecond

```csharp
//todo: put an example of use
```

### SetMillisecond

```csharp
//todo: put an example of use
```

### GetMonthWeeks

```csharp
//todo: put an example of use
```

### AddWeeks

```csharp
//todo: put an example of use
```

### DateDiff

```csharp
//todo: put an example of use
```

### CalculateAge

```csharp
//todo: put an example of use
```

### IsBetween

```csharp
//todo: put an example of use
```

### FirstDayOfMonth

```csharp
//todo: put an example of use
```

### AmountDaysInMonth

```csharp
//todo: put an example of use
```

### LastDayOfMonth

```csharp
//todo: put an example of use
```

### IsValidDate

```csharp
//todo: put an example of use
```

### IsValidTime

```csharp
//todo: put an example of use
```

### NextFullOddHour

```csharp
//todo: put an example of use
```

### NextFullEvenHour

```csharp
//todo: put an example of use
```

### NextFullHour

```csharp
//todo: put an example of use
```

### NextHalfHour

```csharp
//todo: put an example of use
```