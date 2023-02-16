using CarServiceLibrary.Models.Entities;

namespace CarServiceLibrary.Models.ViewModels;

public class ServicesViewModel
{
    public List<Services> Services { get; set; }
    public Services Service { get; set; }
}