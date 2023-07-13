using mascotas_perdidas_codefirstV3.Models;
using mascotas_perdidas_codefirstV3.Models_mascota;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace mascotas_perdidas_codefirstV3
{
    public partial class mascotasContexto : DbContext
    {
        public mascotasContexto()
            : base("name=mascotasContexto")
        {
        }
        public DbSet<Especie> Especies { get; set; }

        public DbSet<Mascota> Mascotas { get; set; }

        public DbSet<Mascota_Usuario> Mascotas_Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
