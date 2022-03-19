using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UploadFile.Models;

namespace UploadFile.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<FileOnDatabase> FilesOnDatabase { get; set; } = null!;

        public DbSet<FileOnFileSystem> FilesOnFileSystem { get; set; } = null!;
    }
}