using ForouzanTask.DataLayer.Entities.Article;
using ForouzanTask.DataLayer.Entities.Common;
using ForouzanTask.DataLayer.Entities.CompanyClass;
using ForouzanTask.DataLayer.Entities.Projects;
using Microsoft.EntityFrameworkCore;

namespace ForouzanTask.DataLayer.Context
{
    public class ForouzanTaskContext : DbContext
    {
        public ForouzanTaskContext(DbContextOptions<ForouzanTaskContext> options) : base(options)
        {

        }
        #region DbSets
        public virtual DbSet<TbTaskRequested> TbTaskRequesteds { get; set; } = null!;
        public virtual DbSet<TbTaskRequestedValue> TbTaskRequestedValues { get; set; } = null!;
        public virtual DbSet<TbUser> TbUsers { get; set; } = null!;
        public virtual DbSet<TbRole> TbRoles { get; set; } = null!;
        public virtual DbSet<TbUserRole> TbUserRoles { get; set; } = null!;
        public virtual DbSet<TbProject> TbProjects { get; set; } = null!;
        public virtual DbSet<TbProjectType> TbProjectTypes { get; set; } = null!;
        public virtual DbSet<TbProjectRole> TbProjectRoles { get; set; } = null!;
        public virtual DbSet<TbUserInProject> TbUserInProjects { get; set; } = null!;
        public virtual DbSet<TbProjectNote> TbProjectNotes { get; set; } = null!;
        public virtual DbSet<TbProjectDocument> TbProjectDocuments { get; set; } = null!;
        public virtual DbSet<TbProjectRequest> TbProjectRequests { get; set; } = null!;
        public virtual DbSet<TbSubArticle> TbSubArticles { get; set; } = null!;
        public virtual DbSet<TbArticle> TbArticles { get; set; } = null!;
        public virtual DbSet<TbOurService> TbOurServices { get; set; } = null!;
        public virtual DbSet<TbOurProject> TbOurProjects { get; set; } = null!;
        public virtual DbSet<TbCategory> TbCategories { get; set; } = null!;
        public virtual DbSet<TbProjectTask> TbProjectTasks { get; set; } = null!;
        public virtual DbSet<TbProjectTaskDetails> TbProjectTaskDetails { get; set; } = null!;
        public virtual DbSet<TbProjectTaskTitleDefault> TbProjectTaskTitleDefaults { get; set; } = null!;

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbRole>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbUserRole>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbProject>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbProjectType>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbProjectRole>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbUserInProject>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbProjectRequest>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbProjectDocument>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbProjectNote>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbArticle>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbSubArticle>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbOurProject>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbOurService>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbProjectTask>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbProjectTaskDetails>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbProjectTaskTitleDefault>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbTaskRequested>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TbTaskRequestedValue>(entity =>
            {
                entity.Property(t => t.Id).HasDefaultValueSql("(newid())");
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
