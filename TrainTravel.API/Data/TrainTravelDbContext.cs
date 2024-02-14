using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Data
{
    public class TrainTravelDbContext : IdentityDbContext<TrainTravelUser>
    {
        public TrainTravelDbContext(DbContextOptions<TrainTravelDbContext> options) : base(options)
        {

        }
        public DbSet<TrainTimeTableData> TrainTimeTableData { get; set; }
        public DbSet<TrainInfoData> TrainInfoData { get; set; }
        public DbSet<StationInfoData> StationInfoData { get; set; }
        public DbSet<BookingsData> BookingsData { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var adminRoleId = "616c65b6-6985-4ff8-862a-b4d95a092947";
            var userRoleId = "a1dfa24d-e4d1-4664-89e9-26fdaa7e3271";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName="Admin".ToUpper(),
                },
                new IdentityRole
                {
                    Id=userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName="User".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<TrainTimeTableData>().HasNoKey();
            builder.Entity<TrainInfoData>().HasNoKey();
            builder.Entity<StationInfoData>().HasNoKey();

        }
    }
}
