using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<EquipmentTable> EquipmentTable { get; set; }
        public DbSet<GymDetails> GymDetails { get; set; }
        public DbSet<MemberTable> MemberTable { get; set; }
        public DbSet<StaffTable> StaffTable { get; set; }

    }
}
