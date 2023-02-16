using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS8618

namespace CarServiceLibrary.Models.Entities;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public class Orders
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }
    
    public virtual Users? User { get; set; }
    
    public int ServiceId { get; set; }
    
    public virtual Services Service { get; set; }
    
    [Required(ErrorMessage = "Поле не может быть пустым!")]
    public string? UserName { get; set; }
    
    public int StatusId { get; set; }
    
    public virtual Statuses Status { get; set; }

    public int CarId { get; set; }
    
    public virtual Cars Car { get; set; }
    
    [Required(ErrorMessage = "Поле не может быть пустым!")]
    public string? CarModelName { get; set; }
    
    public string DateOrder { get; set; } = DateTime.Now.ToShortDateString();
    
    public Orders(int userId, 
                  int serviceId, 
                  string? userName, 
                  int statusId, 
                  int carId, 
                  string? carModelName)
    {
        UserId = userId;
        ServiceId = serviceId;
        UserName = userName;
        StatusId = statusId;
        CarId = carId;
        CarModelName = carModelName;
    }
}