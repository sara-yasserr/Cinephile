using LetterboxdProject.AccountDTOs;
using LetterboxdProject.Models;
using LetterboxdProject.Repositories;

namespace LetterboxdProject.UnitsOfWork
{
    public class unitOfWork
    {
        GenericRepositorycs<User> UserRepo;
        GenericRepositorycs<Film> FilmRepo;

        AppDbContext db;
        public unitOfWork(AppDbContext db)
        {
            this.db = db;
        }

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
        public GenericRepositorycs<Film> filmRepo
        {
            get
            {
                if (FilmRepo == null)
                {
                    FilmRepo = new GenericRepositorycs<Film>(db);
                }
                return FilmRepo;
            }
        }
        //public GenericRepositorycs<CodeSubmission> codeSubmissionRepo
        //{
        //    get
        //    {
        //        if(CodeSubmissionRepo== null)
        //        {
        //            CodeSubmissionRepo = new GenericRepositorycs<CodeSubmission> (db);
        //        }
        //        return CodeSubmissionRepo;
        //    }
        //}
        //public GenericRepositorycs<ReviewResult> reviewResultRepo
        //{
        //    get
        //    {
        //        if(ReviewResultRepo== null)
        //        {
        //            ReviewResultRepo = new GenericRepositorycs<ReviewResult> (db);
        //        }
        //        return ReviewResultRepo;
        //    }
        //}

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
