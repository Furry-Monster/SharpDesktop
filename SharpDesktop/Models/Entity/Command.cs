using System;

namespace SharpDesktop.Models.Entity;

public class Command
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }
}