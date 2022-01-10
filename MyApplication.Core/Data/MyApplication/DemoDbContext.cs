namespace MyApplication.Core.Data.Demo
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class defining the Demo database context.
    /// </summary>
    public class DemoDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the DemoDbContext.</param>
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Example table.
        /// </summary>
        public virtual DbSet<Models.Example> Example { get; set; }

        /// <summary>
        /// Handles specific properties for columns in the database.
        /// </summary>
        /// <param name="modelBuilder">The builder that is being used to modyfying the properties.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Models.Example>()
                .HasIndex(example => example.Id);

            modelBuilder
                .Entity<Models.Example>()
                .HasData(
                    new { Id = 1, Description = "example row" });
        }
    }
}
