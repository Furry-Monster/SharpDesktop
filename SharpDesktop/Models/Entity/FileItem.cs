using System;

namespace SharpDesktop.Models.Entity;

public class FileItem(string name, string icon, string path)
{
    public Guid Id { get; init; }

    public string Name { get; set; } = name;

    public string Icon { get; set; } = icon;

    public string Path { get; set; } = path;
}