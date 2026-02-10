using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcCv.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Proje> Projes { get; set; }
        public DbSet<SosyalMedya> SosyalMedyas { get; set; }
        // Add other DbSets here as needed based on existing entities
        // For example:
        // public DbSet<Admin> Admins { get; set; }
        // public DbSet<Yetenek> Yeteneks { get; set; }
        // public DbSet<Hakkimda> Hakkimdas { get; set; }
        // public DbSet<Egitim> Egitims { get; set; }
        // public DbSet<Deneyim> Deneyims { get; set; }
        // public DbSet<Hobi> Hobis { get; set; }
        // public DbSet<Sertifika> Sertifikas { get; set; }
    }
}
