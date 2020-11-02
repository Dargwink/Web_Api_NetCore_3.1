using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackComentario.DTO
{
    public class ComentarioDTO
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Creado { get; set; }
        [Required]
        public string Texto { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
