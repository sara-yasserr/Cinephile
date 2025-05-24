using AutoMapper;
using CinephileProject.DTOs.GenreDTOs;
using CinephileProject.DTOs.MovieDTOs;
using CinephileProject.DTOs.ShowtimeDTO;
using CinephileProject.Models;
using CinephileProject.UnitsOfWork;
using Microsoft.EntityFrameworkCore;

namespace CinephileProject.Services
{
    public class MovieService
    {
        IMapper mapper;
        unitOfWork unitOfWork;
        public MovieService(IMapper mapper, unitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public Movie AddMovieWithDetails(AddMovieDTO dto)
        {
            //var movie = mapper.Map<Movie>(dto);
            var movie = new Movie
            {
                Title = dto.Title,
                ReleaseYear = dto.ReleaseYear,
                Director = dto.Director,
                Runtime = dto.Runtime,
                BackgroundPath = dto.BackgroundPath,
                PosterPath = dto.PosterPath,
                Description = dto.Description,
                YouTubeTrailerId = dto.YouTubeTrailerId,
                Language = dto.Language
            };
            unitOfWork.movieRepo.Add(movie);

            ProcessGenres(movie, dto.Genres);
            //ProcessShowtimes(movie, dto.ShowtimesId);
            unitOfWork.SaveChanges();
            return movie;
        }

        //public Movie EditMovieWithDetails(AddMovieDTO dto)
        //{
        //    var movie = new Movie
        //    {
        //        Title = dto.Title,
        //        ReleaseYear = dto.ReleaseYear,
        //        Director = dto.Director,
        //        Runtime = dto.Runtime,
        //        BackgroundPath = dto.BackgroundPath,
        //        PosterPath = dto.PosterPath,
        //        Description = dto.Description,
        //        YouTubeTrailerId = dto.YouTubeTrailerId,
        //        Language = dto.Language
        //    };
        //    ProcessGenres(movie, dto.Genres);

        //}
        public void ProcessGenres(Movie movie, List<string> genreNames)
        {
            foreach (var item in genreNames)
            {

                var genre = unitOfWork.genreRepo.GetByName(item);
                var genreDTO = new AddGenreDTO { Name = item };
                var genreAdded = mapper.Map<Genre>(genreDTO);
                if (genre == null)
                {
                    unitOfWork.genreRepo.Add(genreAdded);
                }
                movie.Genres.Add(genreAdded);

            }
        }

        //private void ProcessShowtimes(Movie movie, List<int> showtimes)
        //{
        //    foreach (var item in showtimes)
        //    {
        //        //var showtime=mapper.Map<Showtime>(item);
        //        movie.Showtimes.Add(new Showtime
        //        {
        //            Id =item,
        //            Movie = movie,
        //            MovieId = movie.Id
        //        });
        //    }
        //}

        #region Upload photos 
        public async Task<string> UploadPoster(IFormFile posterFile)
        {
            if (posterFile != null && posterFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/posters");
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(posterFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await posterFile.CopyToAsync(stream);
                }

                return "/images/posters/" + uniqueFileName;
            }

            return null;
        }

        public async Task<string> UploadBackground(IFormFile bgFile)
        {
            if (bgFile != null && bgFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/backgrounds");
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(bgFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await bgFile.CopyToAsync(stream);
                }

                return "/images/backgrounds/" + uniqueFileName;
            }

            return null;
        }
        #endregion
    }
}
