using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class SystemUser
{
    public int UserId { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool? Gender { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? Role { get; set; }

    public int? CompanyId { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual Company? Company { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
