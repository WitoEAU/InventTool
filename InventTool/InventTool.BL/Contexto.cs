using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class Contexto: DbContext
    {
        public Contexto() : base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=" +
             Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\InventTool.DB.mdf")
        { 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Herramental>().MapToStoredProcedures();
            modelBuilder.Entity<Herramental>().ToTable("tablaHerramental");

        }

        //CODEFIRST
        public DbSet<Herramental> Herramental { get; set; }
        public DbSet<HerramentalTooling> HerramentalTooling { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ToolUsers> ToolUsers { get; set; }
        public DbSet<Descarga> Descarga { get; set; } 
        public DbSet<DescargaDetalle> DescargaDetalle { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }



    }
}
