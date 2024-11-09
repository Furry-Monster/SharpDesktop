using System;
using System.Collections.Generic;

namespace SharpDesktop.Models.Entity;

public class Desktop(string name, string? iconPath = null)
{
    public Guid Id { get; init; }

    public string Name { get; set; } = name;

    public string? IconPath { get; set; } = iconPath;

    public List<Launcher> Launchers { get; set; } = [];
}