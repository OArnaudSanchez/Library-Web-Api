using System.ComponentModel.DataAnnotations;

namespace Library.Core.DTos
{
    public class GenderDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [MinLength(3,ErrorMessage = "El campo {0} debe ser mayor a {1} caracteres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string NameGender { get; set; }

    }
}