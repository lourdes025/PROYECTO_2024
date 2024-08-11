using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_2024.BD.DATA.ENTITY
{
    [Index(nameof(TdocumentoId), nameof(NumDoc), Name = "PersonaUq", IsUnique = true)]
    [Index(nameof(Apellido), nameof(Nombre), Name = "PersonaApellido_Nombre", IsUnique = false)]
    public class Persona : EntityBase
    {

           [Required(ErrorMessage = "Su nombre es obligatorio.")]
           [MaxLength(150, ErrorMessage = "Maximo de caracteres {1},")]

            public string Nombre { get; set; }

            [Required(ErrorMessage = "Su apellido es obligatorio.")]
            [MaxLength(150, ErrorMessage = "Maximo de caracteres {1},")]

            public string Apellido { get; set; }

           [Required(ErrorMessage = "Su edad es obligatoria.")]
           [MaxLength(3, ErrorMessage = "Maximo de caracteres {1},")]

            public int Edad { get; set; }

           [Required(ErrorMessage = "Su correo electronico es obligatorio.")]
            public string Correo { get; set; }

           [Required(ErrorMessage = "Su numero de celular es obligatorio.")]
           [MaxLength(11, ErrorMessage = "Maximo de caracteres {1},")]
        public int Celular { get; set; }

           [Required(ErrorMessage = "Su numero de documento es obligatorio.")]
           [MaxLength(12, ErrorMessage = "Maximo de caracteres {1},")]
            public int NumDoc { get; set; }

           // [Required(ErrorMessage = "Su Localidad es obligatoria.")]
           // esto hace las claves foraneas
            public int LocalidadId { get; set; }
            public Localidad Localidad { get; set; }

            public int TdocumentoId { get; set; }
            public Tdocumento Tdocumento { get; set; }

        }
    }
