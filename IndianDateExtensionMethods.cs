using System;
using System.Globalization;
using System.Reflection;

namespace System
{
    public static class IndianDateExtensionMethods
    {
        private static CultureInfo _Culture;

        public static CultureInfo GetEnglishCulture()
        {
            if (_Culture == null)
            {
                _Culture = new CultureInfo("en-US");

                System.Globalization.Calendar cal = new GregorianCalendar();

                DateTimeFormatInfo formatInfo = _Culture.DateTimeFormat;

                formatInfo.AbbreviatedDayNames = new[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
                formatInfo.DayNames = new[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
                formatInfo.AbbreviatedMonthNames
                    = formatInfo.MonthNames
                    = formatInfo.MonthGenitiveNames
                    = formatInfo.AbbreviatedMonthGenitiveNames
                    = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "" };

                formatInfo.AMDesignator = "AM";
                formatInfo.PMDesignator = "PM";

                formatInfo.ShortDatePattern = "MM/dd/yyyy";   
                formatInfo.LongDatePattern = "dddd, MMMM dd, yyyy";

                formatInfo.ShortTimePattern = "HH:mm:ss";
                formatInfo.LongTimePattern = "HH:mm:ss";

                formatInfo.FullDateTimePattern = "MM/dd/yyyy HH:mm:ss";

                formatInfo.FirstDayOfWeek = DayOfWeek.Sunday;

                FieldInfo fieldInfo = _Culture.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo != null)
                    fieldInfo.SetValue(_Culture, cal);

                FieldInfo info = formatInfo.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
                if (info != null)
                    info.SetValue(formatInfo, cal);

                _Culture.NumberFormat.NumberDecimalSeparator = ".";
                _Culture.NumberFormat.DigitSubstitution = DigitShapes.None;
                _Culture.NumberFormat.NumberNegativePattern = 1;
            }

            return _Culture;
        }

        public static string ToEnglishDateString(this DateTime date)
        {
            string format = "MM/dd/yyyy HH:mm:ss";
            return date.ToLocalTime().ToString(format, GetEnglishCulture());
        }
    }
}
