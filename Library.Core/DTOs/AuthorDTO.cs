using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.DTos
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(3, ErrorMessage = "El campo {0} debe ser mayor a {1} caracteres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(3, ErrorMessage = "El campo {0} debe ser mayor a {1} caracteres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool? AuthorGender { get; set; }
    }
}