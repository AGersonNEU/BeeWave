using BeeWave.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BeeWave.Models;


namespace BeeWave.Data
{
    public class ProfileDbDAL : IDataAccessLayer
    {
        private AppDbContext db;

        public ProfileDbDAL(AppDbContext indb)
        {
            db = indb;
        }

        public void AddProfile(Profile profile)
        {
            db.Profiles.Add(profile);
            db.SaveChanges();
        }

        public Profile GetProfile(int id)
        {
            Profile foundProfile = db.Profiles.Where(x => x.ProfileID == id).FirstOrDefault();
            return foundProfile;
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return db.Profiles;
        }

        public void EditProfile(Profile profile)
        {
            db.Profiles.Update(profile);
            db.SaveChanges();
        }


    }
}
