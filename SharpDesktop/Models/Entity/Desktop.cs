using System;
using System.Collections.Generic;

namespace SharpDesktop.Models.Entity;

public class Desktop(string name, string? iconName = null)
{
    public Guid Id { get; init; }

    public string Name { get; set; } = name;

    public string? IconName { get; set; } = iconName;

    public ICollection<Launcher> Launchers { get; set; } = [];
}