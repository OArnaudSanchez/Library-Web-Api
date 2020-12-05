using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.DTos
{
    public class BookDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(5, ErrorMessage = "El campo {0} debe ser mayor a {1} caracteres")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Editorial { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Author { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Gender { get; set; }

    }
}