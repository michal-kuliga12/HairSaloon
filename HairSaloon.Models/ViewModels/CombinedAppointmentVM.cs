namespace HairSaloon.Models.ViewModels;

public class CombinedAppointmentVM
{
    public IEnumerable<Service> Services { get; set; }
    //public IEnumerable<ApplicationUser> Employees { get; set; }
    public IEnumerable<ApplicationUser> Employees { get; set; }
    public Appointment? Appointment { get; set; }

    public CombinedAppointmentVM()
    {

    }
}
