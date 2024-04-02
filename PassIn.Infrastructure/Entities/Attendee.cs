﻿namespace PassIn.Infrastructure.Entities;
public class Attendee
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public Guid Event_Id { get; set; }
    public DateTime Created_At { get; set; }
}
