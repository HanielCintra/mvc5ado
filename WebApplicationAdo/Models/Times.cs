using System.ComponentModel.DataAnnotations;

namespace WebApplicationAdo.Models
{
    public class Times
    {
        [Display(Name = "Id")]
        public int TimeId { get; set; }

        [Required(ErrorMessage = "Informe o nome do time")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Informe o estado do time")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe as cores do time")]
        public string Cores { get; set; }
    }
}