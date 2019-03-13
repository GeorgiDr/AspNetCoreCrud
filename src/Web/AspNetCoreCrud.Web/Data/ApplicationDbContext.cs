using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreCrud.Web.Models;

namespace AspNetCoreCrud.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AspNetCoreCrud.Web.Models.Album> Album { get; set; }

        public DbSet<AspNetCoreCrud.Web.Models.Category> Category { get; set; }
    }
}
