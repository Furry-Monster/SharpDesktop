namespace SharpDesktop.Models;

public class Desktop(string name, string? iconPath = null)
{
    public string Name { get; set; } = name;

    public string? IconPath { get; set; } = iconPath;

}