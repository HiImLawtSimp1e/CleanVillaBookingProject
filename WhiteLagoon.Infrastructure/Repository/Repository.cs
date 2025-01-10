using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Context;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        // DbSet<T> trong EF Core đại diện cho một tập hợp thực thể trong cơ sở dữ liệu.
        // dbSet được sử dụng để truy cập dữ liệu từ một bảng tương ứng với kiểu thực thể T trong cơ sở dữ liệu.
        // Sử dụng dbSet trong Repository được dùng để tóm gọn và trừu tượng hóa các thao tác với cơ sở dữ liệu. Thay vì làm việc trực tiếp với DbContext, bạn tương tác thông qua Repository.

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
            // Khi gọi _context.Set<T>(), EF Core sẽ trả về một đối tượng DbSet<T> được ánh xạ tới bảng tương ứng trong cơ sở dữ liệu.
            // Ví dụ: Nếu T là Villa, thì dbSet ánh xạ tới bảng Villas trong cơ sở dữ liệu.
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return dbSet.Any(filter);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet; // Thực thể được theo dõi
            }
            else
            {
                query = dbSet.AsNoTracking(); // Thực thể không được theo dõi (AsNoTracking trong EF Core được sử dụng để chỉ định rằng các thực thể trả về từ truy vấn sẽ không được theo dõi bởi DbContext)
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet; // Thực thể được theo dõi
            }
            else
            {
                query = dbSet.AsNoTracking(); // Thực thể không được theo dõi (AsNoTracking trong EF Core được sử dụng để chỉ định rằng các thực thể trả về từ truy vấn sẽ không được theo dõi bởi DbContext)
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
