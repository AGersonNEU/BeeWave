

using BeeWave.Models;

namespace BeeWave.Interfaces
{
    public interface IDataAccessLayer
    {
        public Profile GetProfile(int id);
        public IEnumerable<Profile> GetProfiles();

        public Profile GetProfileByName(string name);
        public IEnumerable<Profile> GetProfilesByName(string name);

        public void AddProfile(Profile profile);

        public void EditProfile(Profile profile);

        public IEnumerable<Post> GetAllPostsForPage(int userId);

        public Post GetPost(int postId);

        public void AddPost(Post newPost);

        public void DeletePost(Post removePost);

        public void UpdatePost(Post post);

        public IEnumerable<Post> GetAllPosts();

        public IEnumerable<Message> GetAllMessagesForPage(int profileId);

        public void DeleteMessage(Message message);

        public void AddMessage(Message message);
    }
}
