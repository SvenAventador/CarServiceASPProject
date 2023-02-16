using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceLibrary.Models.Entities;

public class Cars
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле не может быть пустым!")]
    public string? CarName { get; set; }

    public string? CarImage { get; set; }
}