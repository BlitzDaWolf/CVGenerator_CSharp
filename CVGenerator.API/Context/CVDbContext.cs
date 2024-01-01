using CVGenerator.API.Entity;
using CVGenerator.API.Entiy;
using Microsoft.EntityFrameworkCore;

namespace CVGenerator.API.Context
{
    public class CVDbContext : DbContext
    {
        public CVDbContext(DbContextOptions options) : base(options) { }

        public DbSet<EducationEntity> Educations { get; set; }
        public DbSet<ExpierenceEntity>Expierences { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<SkillEntity> Skills { get; set; }
    }
}
