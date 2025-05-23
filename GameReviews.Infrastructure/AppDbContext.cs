﻿using Microsoft.EntityFrameworkCore;
using GameReviews.Entities;

namespace GameReviews.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Game> Games { get; set; }
}
