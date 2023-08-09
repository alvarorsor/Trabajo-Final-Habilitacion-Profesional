using Castle.MicroKernel.SubSystems.Conversion;
using mascotas_perdidas_codefirstV3.Models_mascota;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mascotas_perdidas_codefirstV3.Models
{
    public class Mascota
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Especie")]
        public int IDEspecie { get; set; }
        public virtual Especie Especie { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public int edad { get; set; }

        [Required]
        [StringLength(20)]
        public string raza { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_extravio { get; set; }

        [Required]
        [StringLength(20)]
        public string lugar_extravio { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        [Column(TypeName = "image")]
        public byte[] foto { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_dueño { get; set; }

        [Column(TypeName = "text")]
        public string correo_dueño { get; set; }

        [Required]
        public long telefono_dueño { get; set; }

        
        public bool encontrada { get; set; }



    }
}