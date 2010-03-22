using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace LaunchPad.Utilities
{
    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
    public struct TimeZoneInformation
    {
        /// <summary>
        /// Current bias for local time translation on this computer, in minutes. The bias is the difference, in minutes, between Coordinated Universal Time (UTC) and local time. All translations between UTC and local time are based on the following formula: 
        /// <para>UTC = local time + bias</para>
        /// <para>This member is required.</para>
        /// </summary>
        public int bias;
        /// <summary>
        /// Pointer to a null-terminated string associated with standard time. For example, "EST" could indicate Eastern Standard Time. The string will be returned unchanged by the GetTimeZoneInformation function. This string can be empty.
        /// </summary>
        [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 32 )]
        public string standardName;
        /// <summary>
        /// A SystemTime structure that contains a date and local time when the transition from daylight saving time to standard time occurs on this operating system. If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time, the wMonth member in the SystemTime structure must be zero. If this date is specified, the DaylightDate value in the TimeZoneInformation structure must also be specified. Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
        /// <para>To select the correct day in the month, set the wYear member to zero, the wHour and wMinute members to the transition time, the wDayOfWeek member to the appropriate weekday, and the wDay member to indicate the occurence of the day of the week within the month (first through fifth).</para>
        /// <para>Using this notation, specify the 2:00a.m. on the first Sunday in April as follows: wHour = 2, wMonth = 4, wDayOfWeek = 0, wDay = 1. Specify 2:00a.m. on the last Thursday in October as follows: wHour = 2, wMonth = 10, wDayOfWeek = 4, wDay = 5.</para>
        /// </summary>
        public SystemTime standardDate;
        /// <summary>
        /// Bias value to be used during local time translations that occur during standard time. This member is ignored if a value for the StandardDate member is not supplied. 
        /// <para>This value is added to the value of the Bias member to form the bias used during standard time. In most time zones, the value of this member is zero.</para>
        /// </summary>
        public int standardBias;
        /// <summary>
        /// Pointer to a null-terminated string associated with daylight saving time. For example, "PDT" could indicate Pacific Daylight Time. The string will be returned unchanged by the GetTimeZoneInformation function. This string can be empty.
        /// </summary>
        [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 32 )]
        public string daylightName;
        /// <summary>
        /// A SystemTime structure that contains a date and local time when the transition from standard time to daylight saving time occurs on this operating system. If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time, the wMonth member in the SystemTime structure must be zero. If this date is specified, the StandardDate value in the TimeZoneInformation structure must also be specified. Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
        /// <para>To select the correct day in the month, set the wYear member to zero, the wHour and wMinute members to the transition time, the wDayOfWeek member to the appropriate weekday, and the wDay member to indicate the occurence of the day of the week within the month (first through fifth).</para>
        /// </summary>
        public SystemTime daylightDate;
        /// <summary>
        /// Bias value to be used during local time translations that occur during daylight saving time. This member is ignored if a value for the DaylightDate member is not supplied. 
        /// <para>This value is added to the value of the Bias member to form the bias used during daylight saving time. In most time zones, the value of this member is –60.</para>
        /// </summary>
        public int daylightBias;
    }

    [StructLayoutAttribute( LayoutKind.Sequential )]
    public struct SystemTime
    {
        public short year;
        public short month;
        public short dayOfWeek;
        public short day;
        public short hour;
        public short minute;
        public short second;
        public short milliseconds;
    }
}
