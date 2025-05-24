namespace CinephileProject.Models
{
    public class Screen
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        //public virtual List<Seat> Seats { get; set; }
        public virtual List<Showtime> Showtimes { get; set; }
    }

    //public enum ScreenType
    //{
    //    IMAX,
    //    VIP
    //}
}
