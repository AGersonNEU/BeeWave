

using BeeWave.Models;

namespace BeeWave.Interfaces
{
    public interface IDataAccessLayer
    {
        public Profile GetProfile(int id);

        public void AddProfile(Profile profile);

        public IEnumerable<Profile> GetProfiles();

        public void EditProfile(Profile profile);
    }
}
