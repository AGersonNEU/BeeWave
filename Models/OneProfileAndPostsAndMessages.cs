using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeeWave.Models
{
    public class OneProfileAndPostsAndMessages
    {
        public IEnumerable<Post> Posts { get; set; }

        public Profile PageProfile { get; set; }

        public IEnumerable<Message> Messages { get; set; }


        public OneProfileAndPostsAndMessages() { }

        public OneProfileAndPostsAndMessages(Profile pageProfile,IEnumerable<Post> posts, IEnumerable<Message> messages) 
        { 
            Posts = posts;
            PageProfile = pageProfile;
            Messages = messages;
        }

    }
}
