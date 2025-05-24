using CinephileProject.Models;

namespace CinephileProject.Services
{
    public class TicketPriceCalculator
    {
        // bool isHoliday
        //public decimal CalculatePrice(
        //ScreenType screenType,
        //    SeatType seatType,
        //    DateTime showtime
        //   )
        //{
        //    // السعر الأساسي
        //    decimal basePrice = 50m; // يمكن تغيير القيمة الأساسية

        //    // تعديل حسب نوع الشاشة
        //    switch (screenType)
        //    {
        //        case ScreenType.IMAX:
        //            basePrice *= 1.5m;
        //            break;
        //        case ScreenType.VIP:
        //            basePrice *= 1.8m;
        //            break;
        //    }

        //    // تعديل حسب نوع المقعد
        //    switch (seatType)
        //    {
        //        case SeatType.Premium:
        //            basePrice *= 1.3m;
        //            break;
        //        case SeatType.VIP:
        //            basePrice *= 1.6m;
        //            break;
        //    }

        //    // تعديل حسب وقت العرض
        //    if (showtime.Hour >= 18 && showtime.Hour < 22) // وقت الذروة
        //    {
        //        basePrice *= 1.2m;
        //    }
        //    else if (showtime.Hour >= 10 && showtime.Hour < 14) // وقت الظهيرة
        //    {
        //        basePrice *= 0.9m;
        //    }

        //    // تعديل في أيام العطلات
        //    //if (isHoliday)
        //    //{
        //    //    basePrice *= 1.15m;
        //    //}

        //    return Math.Round(basePrice, 2);
        //}
    }
}
