using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPINET8.Models
{
    using System.Collections.Generic;

    public class Carrera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } // Nombre de la carrera

        public string Perfil { get; set; } // Descripción de la carrera
 
        public List<string> Materias { get; set; } //Materias de la carrera

        public List<string> Especialidades { get; set; } //Especialidades de la Carrera
    }

}


