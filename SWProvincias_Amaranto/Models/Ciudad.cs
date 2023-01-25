﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWProvincias_Amaranto.Models
{
    public class Ciudad
    {
        [Key]
        public int IdCiudad { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [ForeignKey("ProvinciaId")]
        public int ProvinciaId { get; set; }

        public Provincia provincia { get; set; }

    }
}
