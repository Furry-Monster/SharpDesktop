using System;

namespace SharpDesktop.Models.Entity;

public class CommandItem(string name, string content, string? description = null)
{
    public Guid Id { get; init; }

    public string Name { get; } = name;

    public string? Description { get; } = description;

    public string Content { get; } = content;
}