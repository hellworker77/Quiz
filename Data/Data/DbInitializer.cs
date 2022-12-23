﻿using DataAccessLayer.Abstraction.Interfaces;

namespace DataAccessLayer.Data;

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationContext _context;

    public DbInitializer(ApplicationContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _context.Roles.AddRange(FakeData.Roles);
        _context.SaveChanges();
        
        _context.Users.AddRange(FakeData.Users);
        _context.SaveChanges();

        _context.UserRoles.AddRange(FakeData.UserRoles);
        _context.SaveChanges();

        _context.Tests?.AddRange(FakeData.Tests);
        _context.SaveChanges();

        _context.Answers?.AddRange(FakeData.Answers);
        _context.SaveChanges();

        _context.Questions?.AddRange(FakeData.Questions);
        _context.SaveChanges();
    }
}