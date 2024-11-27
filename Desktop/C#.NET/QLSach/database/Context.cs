using Microsoft.EntityFrameworkCore;
using QLSach.database.models;
using QLSach.dbContext.models;

namespace QLSach.database
{
    public class Context : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UseSerialColumns();
            //NpgsqlModelBuilderExtensions.UseIdentityColumns(modelBuilder);
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);
            new DataInitializer(modelBuilder).Seed();
            new RelationshipInit(modelBuilder).init();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String ConnectionString = "server=localhost; Database=qlsach; Port=3306; uid=root; Password=pw;";
            optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<author> Authors { get; set; }
        public DbSet<Feedback> BookInteractions { get; set; }
        //public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBook> CategoriesBook { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
