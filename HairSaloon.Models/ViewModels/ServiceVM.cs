using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HairSaloon.Models.ViewModels;

public class ServiceVM
{
    public int Id { get; set; }

    [Display(Name = "Nazwa")]
    [Required(ErrorMessage = "Nazwa jest wymagana.")]
    [StringLength(50, ErrorMessage = "Nazwa usługi nie może przekraczać 50 znaków")]
    public string? Name { get; set; }

    [Display(Name = "Kategoria")]
    [Required(ErrorMessage = "Kategoria jest wymagana.")]
    [StringLength(50, ErrorMessage = "Kategoria usługi nie może przekraczać 50 znaków")]
    public string? Category { get; set; }

    [Display(Name = "Cena")]
    [Required(ErrorMessage = "Cena jest wymagana.")]
    [Range(1, 999, ErrorMessage = "Cena usługi musi mieścić się w przedziale 1-999")]
    public int? Price { get; set; }

    [Display(Name = "Przewidywany czas trwania")]
    [Required(ErrorMessage = "Czas trwania jest wymagany.")]
    [Range(1, 999, ErrorMessage = "Czas trwania musi mieścić się w przedziale 1-999")]
    public int? DurationInMinutes { get; set; }

    [Display(Name = "Opis")]
    [StringLength(500)]
    public string? Description { get; set; }

    public ServiceVM()
    {
        Description = "";
    }

    public ServiceVM(Service service)
    {
        Id = service.Id;
        Name = service.Name;
        Category = service.Category;
        Price = service.Price;
        DurationInMinutes = service.DurationInMinutes;
        Description = service.Description;
    }
}
