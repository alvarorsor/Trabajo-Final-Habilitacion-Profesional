using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mascotas_perdidas_codefirstV3.Models
{
    public class Mascota_Usuario
    {
        [Key]
        public int ID { get; set; }


        [Required]
        public string nombreUsuario { get; set; }

        [Required]
        [ForeignKey("Mascota")]
        public int IDMascotas { get; set; }
        public virtual Mascota Mascota { get; set; }

    }
}