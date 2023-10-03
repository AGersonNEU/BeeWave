using System.ComponentModel.DataAnnotations;

namespace BeeWave.Models
{
    public class Profile
    {
        [Key]
        public int ProfileID { get; set; } 

        [Required]
        public int UserID { get; set; }

        public string? Image { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Age { get; set; }

        public string? Likes { get; set; }

        public string? Dislikes { get; set; }

        [Required]
        public string Password { get; set; }

        public Profile() { }

        public Profile(int userID, string image, string name, int age, string? likes, string? dislikes)
        {
            UserID = userID;
            Name = name;
            Age = age;
            Likes = likes;
            Image = image;
            Dislikes = dislikes;
        }
    }
}
