using System.ComponentModel.DataAnnotations;

namespace BeeWave.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        //who posted it
        [Required]
        public int PosterId { get; set; }

     
        public string? PosterName { get; set; }

        //what page it was posted to
        [Required]
        public int PageId { get; set; }

        [Required]
        public string PostImage { get; set; }

        public Post() { }

        public Post(int postId, int posterId, int pageId, string postImage, string? posterName)
        {
            PostId = postId;
            PosterId = posterId;
            PageId = pageId;
            PostImage = postImage;
            PosterName = posterName;
        }
    }
}
