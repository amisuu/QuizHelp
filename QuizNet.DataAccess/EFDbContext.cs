using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizNet.DataAccess.Models;

namespace QuizNet.DataAccess
{
    public class EFDbContext : IdentityDbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Image> Images { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }
    }
}
