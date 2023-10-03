using System.ComponentModel.DataAnnotations;

namespace BeeWave.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        //who posted it
        [Required]
        public int PosterId { get; set; }

        public string? PosterName { get; set; }

        //what page it was posted to (profileId)
        [Required]
        public int PageId { get; set; }

        [Required]
        public string MessageContent { get; set; }

        public Message() { }

        public Message(int messageId, int posterId, int pageId, string messageContent, string posterName)
        {
            MessageId = messageId;
            PosterId = posterId;
            PageId = pageId;
            MessageContent = messageContent;
            PosterName = posterName;
        }
    }
}
