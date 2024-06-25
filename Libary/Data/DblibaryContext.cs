using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Libary.Data;

public partial class DblibaryContext : DbContext
{
    public DblibaryContext()
    {
    }

    public DblibaryContext(DbContextOptions<DblibaryContext> options)
        : base(options)
    {
    }



    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Epoch> Epoches { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<LibaryCheck> LibaryChecks { get; set; }

    public virtual DbSet<Publication> Publications { get; set; }

    public virtual DbSet<PublicationAutor> PublicationAutors { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

}