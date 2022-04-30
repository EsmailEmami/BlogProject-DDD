using System.Globalization;

namespace Blog.Domain.Common.Extensions;

public static class DateTimeExtension
{
    public static string ToPersianDate(this DateTime date)
    {
        PersianCalendar pc = new PersianCalendar();

        return pc.GetYear(date).ToString("00") + "/" +
               pc.GetMonth(date).ToString("00") + "/" +
               pc.GetDayOfMonth(date).ToString("00");
    }
}