using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public DateTime? ReservationDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? Endtime { get; set; }

    public int? RoomId { get; set; }

    public int? NumberAttendees { get; set; }

    public int? UserId { get; set; }

    public bool? MeetingStatus { get; set; }

    public virtual Room? Room { get; set; }

    public virtual SystemUser? User { get; set; }
}
