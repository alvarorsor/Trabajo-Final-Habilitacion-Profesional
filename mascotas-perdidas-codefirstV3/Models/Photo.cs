﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mascotas_perdidas_codefirstV3.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public byte[] Bytes { get; set; }
        public string Description { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
        public int MascotaId { get; set; }
        [ForeignKey("MascotaId")]
        public Mascota Mascota { get; set; }

    }
}