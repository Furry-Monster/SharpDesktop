using System;

namespace SharpDesktop.Models.Entity;

public class Desktop(string name, string? iconPath = null)
{
    public Guid Id { get; set; }

    public string Name { get; set; } = name;

    public string? IconPath { get; set; } = iconPath;

}