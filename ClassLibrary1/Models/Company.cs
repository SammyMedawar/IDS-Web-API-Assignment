using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Email { get; set; }

    public string? Logo { get; set; }

    public bool? Active { get; set; }

    public int? RelatedUser { get; set; }

    public virtual SystemUser? RelatedUserNavigation { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<SystemUser> SystemUsers { get; set; } = new List<SystemUser>();
}
