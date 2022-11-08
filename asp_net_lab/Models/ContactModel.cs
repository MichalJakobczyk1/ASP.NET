using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class ContactModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać imię!")]
        public string Name { get; set; }
        [Range(0,120)]
        [Required(ErrorMessage = "Należy podać wiek!")]
        public int Age { get; set; }
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Required(ErrorMessage = "Proszę podać poprawny e-mail!")]
        public string Email { get; set; }
    }
}
