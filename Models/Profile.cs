namespace BeeWave.Models
{
    public class Profile
    {
        public int UserID { get; set; }

        public string Image { get; set; }
        public string Name { get; set; }

        public int? Age { get; set; }

        public string? Likes { get; set; }

        public Profile() { }

        public Profile(int userID, string image, string name, int age, string likes)
        {
            UserID = userID;
            Name = name;
            Age = age;
            Likes = likes;
            Image = image;
        }
    }
}
