using System;
using System.Collections.Generic;

namespace SharpDesktop.Models.Entity;

public class Terminal(string name, string? description = null, string? iconPath = null)
{
    public Guid Id { get; set; }

    public string Name { get; set; } = name;

    public string? Description { get; set; } = description;

    public string? IconPath { get; set; } = iconPath;

    public ICollection<Command> Commands { get; set; } = [];
}