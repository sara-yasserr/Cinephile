using AutoMapper;
using CinephileProject.DTOs.BookingDTOs;
using CinephileProject.DTOs.GenreDTOs;
using CinephileProject.DTOs.MovieDTOs;
using CinephileProject.DTOs.PaymentDTOs;
using CinephileProject.DTOs.ReadScreenDTOs;
using CinephileProject.DTOs.ScreenDTOs;
using CinephileProject.DTOs.SeatDTOs;

//using CinephileProject.DTOs.SeatDTOs;
using CinephileProject.DTOs.ShowtimeDTO;
using CinephileProject.DTOs.TicketDTOs;
using CinephileProject.DTOs.UserDTOs;
using CinephileProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
namespace CinephileProject.MapperConfig
{
    public class mappConfig : Profile
    {
        public mappConfig()
        {
            #region User
            CreateMap<User, ReadUserDTO>().ReverseMap();
            #endregion 

            #region Movie
            CreateMap<AddMovieDTO, Movie>() .ForMember(dest => dest.Genres,
               opt => opt.MapFrom(src => src.Genres.Select(name => new Genre { Name = name })));

            CreateMap<Movie, ReadMovieDTO>()
                .AfterMap((src, dest) =>
            {
                dest.Genres = src.Genres?.Select(m => m.Name).ToList();
                dest.Showtimes = src.Showtimes?.Select(s => s.StartTime.ToString()).ToList();
            });
            CreateMap<ReadMovieDTO, Movie>()
                .AfterMap((src, dest) =>
            {
                foreach (var item in src.Genres)
                {
                    dest.Genres.Add(new Genre { Name = item });

                }
                foreach (var item in src.Showtimes)
                {
                    dest.Showtimes.Add(new Showtime { StartTime = DateTime.Parse(item) });

                }
            });

            #endregion

            #region Genre
            CreateMap<Genre, AddGenreDTO>().ReverseMap();
            CreateMap<Genre, ReadGenreDTO>().AfterMap((src, dest) =>
            {
                dest.Movies = src.Movies.Select(m => m.Title).ToList();
            }).ReverseMap();
            #endregion

            #region Showtime 
            CreateMap<Showtime, AddShowtimeDTO>().ReverseMap();
            CreateMap<Showtime, ReadShowtimeDTO>().AfterMap((src, dest) =>
            {
                dest.MovieTitle = src.Movie.Title;
                dest.ScreenType = src.Screen.Type;
            }).ReverseMap();
            #endregion

            #region Screen 
            CreateMap<Screen, AddScreenDTO>().ReverseMap();
            CreateMap<Screen, ReadScreenDTO>().ReverseMap();

            #endregion

            #region Seat
            CreateMap<Seat, AddSeatDTO>().ReverseMap();
            CreateMap<Seat, ReadSeatDTO>().AfterMap((src, dest) =>
            {
                dest.ScreenType = src.Screen.Type;
            }).ReverseMap();

            #endregion

            #region Booking 
            CreateMap<Booking, AddBookingDTO>().ReverseMap();
            CreateMap<Booking, ReadBookingDTO>().AfterMap((src, dest) =>
            {
                //dest.payment_Method = src.Payment.Method.ToString();
                //dest.numberOf_Tickets = src.Tickets.Count();
                dest.user_Name = src.User.Username;
                dest.showtime_Time = src.Showtime.StartTime;
                dest.BookingDate = src.BookingDate;
            }).ReverseMap();
            #endregion

            #region Ticket
            CreateMap<Ticket, AddTicketDTO>().ReverseMap();
            CreateMap<Ticket, ReadTicketDTO>().AfterMap((src, dest) =>
            {
                //dest.ScreenType = src.Showtime.Screen.Type;
                //dest.SeatType = src.Seat.Type;
                //dest.SeatRow = src.Seat.Row;
                //dest.SeatNum = src.Seat.Number;
                //dest.startTime = src.Showtime.StartTime;
                dest.ticketPrice = src.Price;
            }).ReverseMap();

            #endregion

            #region Payment
            CreateMap<Payment, AddPaymentDTO>().ReverseMap();
            CreateMap<Payment, ReadPaymentDTO>().ReverseMap();
            #endregion

        }
    }
}
