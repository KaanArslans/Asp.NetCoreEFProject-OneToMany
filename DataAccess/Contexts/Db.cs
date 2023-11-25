using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entitites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class Db:DbContext
    {

        public Db(DbContextOptions<Db> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }
}
