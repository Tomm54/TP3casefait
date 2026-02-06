using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3Console.Models.EntityFramework;

[Table("categorie")]
public partial class Categorie
{
    


    [Key]
    [Column("idcategorie")]
    public int Idcategorie { get; set; }

    [Column("nom")]
    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    private ILazyLoader _lazyLoader;
    public Categorie(ILazyLoader lazyLoader)
    {
        _lazyLoader = lazyLoader;
    }

    private ICollection<Film> films;

    [InverseProperty("CategorieNavigation")]
    public virtual ICollection<Film> Films
    {
        get
        {
            return _lazyLoader.Load(this, ref films);
        }
        set { films = value; }
    }
}