using System.ComponentModel.DataAnnotations;

namespace HairSaloon.Models;

public class Service
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Nazwa jest wymagana.")]
    [StringLength(50, ErrorMessage = "Nazwa usługi nie może przekraczać 50 znaków")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Kategoria jest wymagana.")]
    [StringLength(50, ErrorMessage = "Kategoria usługi nie może przekraczać 50 znaków")]
    public string? Category { get; set; }
    [Required(ErrorMessage = "Cena jest wymagana.")]
    [Range(1, 999, ErrorMessage = "Cena usługi musi mieścić się w przedziale 1-999")]
    public int? Price { get; set; }
    [Required(ErrorMessage = "Czas trwania jest wymagany.")]
    [Range(1, 999, ErrorMessage = "Czas trwania musi mieścić się w przedziale 1-999")]
    public int? DurationInMinutes { get; set; }
    [StringLength(500)]
    public string? Description { get; set; }
}
