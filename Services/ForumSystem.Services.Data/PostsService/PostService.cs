namespace ForumSystem.Services.Data.PostsService
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ForumSystem.Data;
    using ForumSystem.Data.Models;
    using ForumSystem.InputModels.Posts;
    using Microsoft.EntityFrameworkCore;

    public class PostService : IPostService
    {
        private readonly ApplicationDbContext dbContext;

        public PostService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(PostFormModel postForm)
        {
            Post post = new Post()
            {
                Title = postForm.Title,
                Content = postForm.Content,
                CategoryId = postForm.CategoryId,
                UserId = postForm.UserId,
            };

            await this.dbContext.Posts.AddAsync(post);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Post post = await this.dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);

            try
            {
                post.IsDeleted = true;
                post.DeletedOn = DateTime.UtcNow;

                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetById<T>(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(int id, PostFormModel postForm)
        {
            throw new System.NotImplementedException();
        }
    }
}
