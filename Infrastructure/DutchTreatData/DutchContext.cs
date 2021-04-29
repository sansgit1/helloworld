using System;
using helloworld.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace helloworld.Infrastructure.Data
{
    public class DutchContext : DbContext
    {

        private readonly IConfiguration _config;
        private ILoggerFactory loggerFactory;

        //public DutchContext(IConfiguration config)
        //{
        //    _config = config;
        //}


        ///// <summary>
        ///// Constructor.
        ///// </summary>
        ///// <param name="options">DbContextOptions.</param>
        ///// <param name="connectionManager">Instance of IConnectionManager.</param>
        ///// <param name="loggerFactory">Instance of loggerFactory.</param>
        //public DutchContext(DbContextOptions<DutchContext> options, ILoggerFactory loggerFactory)
        //    : base(options)
        //{
        //    this.loggerFactory = loggerFactory;
        //}


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options">DbContextOptions.</param>
        /// <param name="connectionManager">Instance of IConnectionManager.</param>
        /// <param name="loggerFactory">Instance of loggerFactory.</param>
        public DutchContext(DbContextOptions<DutchContext> options)
            : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connstr = _config.GetConnectionString(Constants.Environment.DutchConnectionString); //Environment.GetEnvironmentVariable(Constants.Environment.DutchConnectionString);
            //var connBuilder = new SqlConnectionStringBuilder(connstr);
            //var sqlConnection = new SqlConnection(connBuilder.ToString());

            //if (optionsBuilder.IsConfigured) return;

            //optionsBuilder.UseSqlServer(sqlConnection, o =>
            //{
            //    o.EnableRetryOnFailure(4, TimeSpan.FromSeconds(4), null);
            //});


            // optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=dutchTreatLDB;Integrated Security=True;Connect Timeout=120;Encrypt=False;");

           // optionsBuilder.UseLoggerFactory(this.loggerFactory);

            //optionsBuilder.ConfigureWarnings(warnings =>
            //{
            //    warnings.Log(RelationalEventId.TransactionError);
            //    warnings.Log(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning);
            //});

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
              .Property(p => p.Price)
              .HasColumnType("money");

            modelBuilder.Entity<OrderItem>()
              .Property(o => o.UnitPrice)
              .HasColumnType("money");

            modelBuilder.Entity<Order>()
              .HasData(new Order()
              {
                  Id = 1,
                  OrderDate = DateTime.UtcNow,
                  OrderNumber = "12345"
              });
        }
    }
}
