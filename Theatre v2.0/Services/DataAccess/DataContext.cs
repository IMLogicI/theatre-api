using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.DataAccess
{
    public class DataContext : DbContext
    {
        private static DataContext dataContext;

        protected DataContext() : base("DataContext")
        {
        }

        public static DataContext GetDataContext()
        {
            return dataContext ?? (dataContext = new DataContext());
        }

        public DbSet<DbAccount> Account { get; set; }
        public DbSet<DbActor> Actor { get; set; }
        public DbSet<DbBook> Book { get; set; }
        public DbSet<DbJenre> Jenre { get; set; }
        public DbSet<DbSchedule> Schedule { get; set; }
        public DbSet<DbShow> Show { get; set; }
        public DbSet<DbShowActors> ShowActors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public T Insert<T>(T item) where T : class, new()
        {
            return PerformAction(item, EntityState.Added);
        }

        protected virtual TItem PerformAction<TItem>(TItem item, EntityState entityState) where TItem : class, new()
        {
            Entry(item).State = entityState;
            return item;
        }

        public IQueryable<T> GetQueryable<T>(bool trackChanges = true) where T : class, new()
        {
            return GetQueryable<T>(null, trackChanges);

        }

        private IQueryable<T> GetQueryable<T>(Expression<Func<T, bool>> expression, bool trackChanges = true)
            where T : class, new()
        {
            var query = GetQueryableNonAudit(expression, trackChanges);

            return query;
        }

        private IQueryable<T> GetQueryableNonAudit<T>(Expression<Func<T, bool>> expression, bool trackChanges = true)
            where T : class, new()
        {
            var query = trackChanges
                ? Set<T>().AsQueryable()
                : Set<T>().AsNoTracking();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return query;
        }

        public int Save()
        {
            List<DbEntityEntry> addedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
            List<DbEntityEntry> modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted || e.State == EntityState.Modified).ToList();

            int changes = 0;

            try
            {
                changes = SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);

                if (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException);
                }

                if (e.EntityValidationErrors != null)
                {
                    foreach (var dbEntityValidationResult in e.EntityValidationErrors)
                    {
                        Console.WriteLine(dbEntityValidationResult.ValidationErrors.First()?.PropertyName);
                        Console.WriteLine(dbEntityValidationResult.ValidationErrors.First()?.ErrorMessage);
                    }
                }
            }

            return changes;
        }
    }
}