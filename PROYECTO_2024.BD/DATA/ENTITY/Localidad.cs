using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_2024.BD.DATA.ENTITY
{
    [Index(nameof(codigo), Name = "LocalidadUq", IsUnique = true)]

    public class Localidad : EntityBase
    {
        [Required(ErrorMessage = "Su el codigo  es obligatoria.")]
        [MaxLength(4, ErrorMessage = "Maximo de caracteres {1},")]
        public string codigo { get; set; }

        [Required(ErrorMessage = "El nombre de la localidad es obligatorio.")]
        public string Nombre { get; set; }

        //relacion con persona. lista de personas de esa localidad
        //public List<Persona> Personas { get; set; }
    }
}
