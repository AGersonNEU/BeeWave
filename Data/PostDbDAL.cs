//using BeeWave.Interfaces;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using BeeWave.Models;

//namespace BeeWave.Data
//{
//    public class PostDbDAL :
//    {
//        private AppDbContext db;

//        public PostDbDAL(AppDbContext indb)
//        {
//            db = indb;
//        }

//        public IEnumerable<Post> GetAllPostsForPage(int userId)
//        {
//            return db.Posts.Where(x => x.PageId == userId).ToList();
//        }
 
//        public Post GetPost(int postId)
//        {
//            return db.Posts.Where(x => x.PostId == postId).FirstOrDefault();
//        }

//        public void AddPost(Post newPost)
//        {
//            db.Posts.Add(newPost);
//            db.SaveChanges();
//        }


//        public void DeletePost(Post removePost)
//        {
//            db.Posts.Remove(removePost);
//            db.SaveChanges();
//        }

//        public void UpdatePost(Post post)
//        {
//            db.Posts.Update(post);
//            db.SaveChanges();
//        }
//    }
//}
