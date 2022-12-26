﻿namespace Entities.Entity.Abstraction;

public abstract class AbstractTest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset Date { get; set; }
}