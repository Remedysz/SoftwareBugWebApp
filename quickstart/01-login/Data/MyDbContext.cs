using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SampleMvcAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMvcApp.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<BugModel> SBDBTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "SBDB.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}
