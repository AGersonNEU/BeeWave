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


        public IEnumerable<Profile> GetProfilesByName(string name)
        {
            return db.Profiles.Where(x => x.Name.ToLower().Contains(name.ToLower()));
        }


        public Profile GetProfileByName(string name)
        {
            return db.Profiles.Where(x => x.Name.ToLower().Contains(name.ToLower())).FirstOrDefault();
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


        /// <summary>
        /// Posts
        /// </summary>
 

        public IEnumerable<Post> GetAllPosts()
        {
            return db.Posts.ToList();
        }

        public IEnumerable<Post> GetAllPostsForPage(int userId)
        {
            return db.Posts.Where(x => x.PageId == userId).ToList();
        }

        public Post GetPost(int postId)
        {
            return db.Posts.Where(x => x.PostId == postId).FirstOrDefault();
        }

        public void AddPost(Post newPost)
        {
            db.Posts.Add(newPost);
            db.SaveChanges();
        }


        public void DeletePost(Post removePost)
        {
            db.Posts.Remove(removePost);
            db.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            db.Posts.Update(post);
            db.SaveChanges();
        }

        //////MESSAGES
        ///

        public IEnumerable<Message> GetAllMessagesForPage(int profileId)
        {
            return db.Messages.Where(x => x.PageId ==  profileId).ToList();
        }

        public void AddMessage(Message message)
        {
            db.Messages.Add(message);
            db.SaveChanges();
        }

        public void DeleteMessage(Message message)
        {
            db.Messages.Remove(message);
            db.SaveChanges();
        }
    }
}
