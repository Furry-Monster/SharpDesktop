using System;
using ReactiveUI;

namespace SharpDesktop.Models.Entity;

public class DesktopItem(string name, string? iconPath = null, string[]? files = null)
{
    public Guid Id { get; init; }

    public string Name { get; set; } = name;

    public string? IconPath { get; set; } = iconPath;

    public string[]? Files { get; set; } = files;
}