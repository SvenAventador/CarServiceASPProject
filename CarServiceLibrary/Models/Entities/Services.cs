using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618

namespace CarServiceLibrary.Models.Entities;

public class Services
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле не может быть пустым!")]
    public string? ServiceName { get; set; }

    [Required(ErrorMessage = "Поле не может быть пустым.")]
    public decimal Price { get; set; }

    public string? ServicesImage { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public int TypeId { get; set; }

    public virtual Types Type { get; set; }
}