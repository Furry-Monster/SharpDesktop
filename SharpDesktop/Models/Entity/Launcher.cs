using System;
using System.Collections.Generic;

namespace SharpDesktop.Models.Entity;

public class Launcher(string name, string? path = null, string? backgroundPath = null)
{
    public Guid Id { get; init; }

    public string Name { get; set; } = name;

    public string? Path { get; set; } = path;

    public string? BackgroundPath { get; set; } = backgroundPath;

    public List<Desktop> Desktops { get; set; } = [];
}