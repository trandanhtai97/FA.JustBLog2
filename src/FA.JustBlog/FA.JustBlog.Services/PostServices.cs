using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public class PostServices : BaseServices<Post>, IPostServices
    {
        public PostServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override int Add(Post entity)
        {
            return base.Add(entity);
        }

        public override Task<int> AddAsync(Post entity)
        {
            return base.AddAsync(entity);
        }

        public async Task<int> CountPostsForCategoryAsync(string category)
        {
            return await _unitOfWork.PostRepository.GetQuery().CountAsync(x => x.Category.Name.Equals(category));
        }

        public async Task<int> CountPostsForTagAsync(string tag)
        {
            return await _unitOfWork.PostRepository.GetQuery().CountAsync(x => x.Tags.Any(t => t.Name.Equals(tag)));
        }

        public async Task<IEnumerable<Post>> GetHighestPosts(int size)
        {
            return await _unitOfWork.PostRepository.GetQuery().OrderByDescending(x => x.Rate).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetLatestPostAsync(int size, bool published = true)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.PostedOn).Take(size).ToListAsync();
        }

        public IEnumerable<Post> GetLatestPost(int size, bool published = true)
        {
            return _unitOfWork.PostRepository.GetQuery().Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.PostedOn).Take(size).ToList();
        }

        public async Task<IEnumerable<Post>> GetMostViewedPostAsync(int size)
        {
            return await _unitOfWork.PostRepository.GetQuery().OrderByDescending(x => x.ViewCount).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x => x.Category.Name.Equals(category)).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(Guid categoryId)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByMonthAsync(DateTime monthYear)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x => x.PostedOn.Month == monthYear.Month
                                                                    && x.PostedOn.Year == monthYear.Year).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(string tag)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x => x.Tags.Any(t => t.Name.Equals(tag))).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(Guid tagId)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x => x.Tags.Any(t => t.Id == tagId)).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPublisedPostsAsync(bool published = true)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x => x.Published == published).ToListAsync();
        }

        public async Task<Post> FindPostAsync(int year, int month, string urlSlug)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(x => x.PostedOn.Year == year && x.PostedOn.Month == month && x.UrlSlug.Equals(urlSlug)).FirstOrDefaultAsync();
        }

        public IEnumerable<Post> GetMostViewedPost(int size)
        {
            return _unitOfWork.PostRepository.GetQuery().OrderByDescending(x => x.ViewCount).Take(size).ToList();
        }
    }
}
