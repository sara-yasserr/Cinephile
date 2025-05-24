using CinephileProject.Models;
using CinephileProject.Repositories;

namespace CinephileProject.UnitsOfWork
{
    public class unitOfWork
    {
        GenericRepositorycs<User> UserRepo;
        GenericRepositorycs<Movie> MovieRepo;
        GenericRepositorycs<Genre> GenreRepo;
        GenericRepositorycs<Showtime> ShowtimeRepo;
        GenericRepositorycs<Seat> SeatRepo;
        GenericRepositorycs<Screen> ScreenRepo;
        GenericRepositorycs<Booking> BookingRepo;
        GenericRepositorycs<Ticket> TicketRepo;
        GenericRepositorycs<Payment> PaymentRepo;

        AppDbContext db;
        public unitOfWork(AppDbContext db)
        {
            this.db = db;
        }

        #region Properties
        public GenericRepositorycs<User> userRepo
        {
            get
            {
                if (UserRepo == null)
                {
                    UserRepo = new GenericRepositorycs<User>(db);
                }
                return UserRepo;
            }
        }
        public GenericRepositorycs<Movie> movieRepo
        {
            get
            {
                if (MovieRepo == null)
                {
                    MovieRepo = new GenericRepositorycs<Movie>(db);
                }
                return MovieRepo;
            }
        }
        public GenericRepositorycs<Genre> genreRepo
        {
            get
            {
                if (GenreRepo == null)
                {
                    GenreRepo = new GenericRepositorycs<Genre>(db);
                }
                return GenreRepo;
            }
        }
        public GenericRepositorycs<Showtime> showtimeRepo
        {
            get
            {
                if (ShowtimeRepo == null)
                {
                    ShowtimeRepo = new GenericRepositorycs<Showtime>(db);
                }
                return ShowtimeRepo;
            }
        }
        public GenericRepositorycs<Seat> seatRepo
        {
            get
            {
                if (SeatRepo == null)
                {
                    SeatRepo = new GenericRepositorycs<Seat>(db);
                }
                return SeatRepo;
            }
        }
        public GenericRepositorycs<Screen> screenRepo
        {
            get
            {
                if (ScreenRepo == null)
                {
                    ScreenRepo = new GenericRepositorycs<Screen>(db);
                }
                return ScreenRepo;
            }
        }
        public GenericRepositorycs<Booking> bookingRepo
        {
            get
            {
                if (BookingRepo == null)
                {
                    BookingRepo = new GenericRepositorycs<Booking>(db);
                }
                return BookingRepo;
            }
        }
        public GenericRepositorycs<Ticket> ticketRepo
        {
            get
            {
                if (TicketRepo == null)
                {
                    TicketRepo = new GenericRepositorycs<Ticket>(db);
                }
                return TicketRepo;
            }
        }
        public GenericRepositorycs<Payment> paymentRepo
        {
            get
            {
                if (PaymentRepo == null)
                {
                    PaymentRepo = new GenericRepositorycs<Payment>(db);
                }
                return PaymentRepo;
            }
        }
        #endregion

        #region methods
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
        #endregion
    }
}
