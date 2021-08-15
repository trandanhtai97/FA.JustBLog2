using FA.JustBlog.Data.Infrastructure.Repositories;
using FA.JustBlog.Models.BaseEntities;
using FA.JustBlog.Models.Common;
using System;
using System.Threading.Tasks;

namespace FA.JustBlog.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        JustBlogContext DataContext { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;

        IGenericRepository<Category> CategoryRepository { get; }

        IGenericRepository<Post> PostRepository { get; }

        IGenericRepository<Tag> TagRepository { get; }

        IGenericRepository<Comment> CommentRepository { get; }
    }
}
