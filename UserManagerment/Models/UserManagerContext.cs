using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagerment.Models
{
    public class UserManagerContext : DbContext
    {
        public UserManagerContext(DbContextOptions<UserManagerContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
