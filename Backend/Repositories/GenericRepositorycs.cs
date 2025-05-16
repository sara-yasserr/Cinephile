using LetterboxdProject.Models;

namespace LetterboxdProject.Repositories
{
    public class GenericRepositorycs<Tentity> where Tentity:class
    {
        AppDbContext db;
        public GenericRepositorycs(AppDbContext db) 
        { this.db = db; }

        public List<Tentity> GetAll()
        {
            return db.Set<Tentity>().ToList();
        }
        public void Add(Tentity entity)
        { db.Set<Tentity>().Add(entity); }

        public void Update(Tentity entity)
        {
            //db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Set<Tentity>().Update(entity);
        }
        public void Delete(int id)
        {
            Tentity entity = GetById(id);
            db.Set<Tentity>().Remove(entity);
        }
        public Tentity GetById(int id)
        {
            return db.Set<Tentity>().Find(id);
        }
        public async Task<Tentity> FindAsync(int id)
        {
            return await db.Set<Tentity>().FindAsync(id);
        }

    }
}
