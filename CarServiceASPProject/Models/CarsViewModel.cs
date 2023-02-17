using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarServiceASPProject.Models;

public class CarsViewModel
{
    [DisplayName("Car")]
    public int CarId { get; set; }
    
    public List<SelectListItem> ListofCar { get; set; }
}