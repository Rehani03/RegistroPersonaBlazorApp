using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPersonaBlazor.Entidades
{
    public class Personas
    {
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 1000000.")]
        public int personaId { get; set; }

        [Required(ErrorMessage = "El campo nombre no puede estar vacío.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener por lo menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre es muy largo.")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string nombre { get; set;}

        [Required(ErrorMessage = "El campo telefono no puede estar vacío.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor ingrese un No. de teléfono válido.")]
        [MaxLength(10, ErrorMessage = "El campo telefono no tiene más de diez dígitos.")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El campo cedula no puede estar vacío.")]
        [MinLength(9, ErrorMessage = "El campo cedula debe contener 11 caracteres.")]
        public string cedula { get; set; }

        [Required(ErrorMessage = "El campo dirección no puede estar vacía.")]
        [MinLength(10, ErrorMessage = "La dirección es muy corta.")]
        [MaxLength(40, ErrorMessage = "La dirección debe contener menos de 40 caracteres.")]
        public string direccion { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime fecha { get; set; }

        public Personas()
        {
            personaId = 0;
            nombre = string.Empty;
            telefono = string.Empty;
            cedula = string.Empty;
            direccion = string.Empty;
            fecha = DateTime.Now;
        }

    }
}
