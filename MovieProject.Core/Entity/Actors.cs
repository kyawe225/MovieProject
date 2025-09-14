using System;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Core.Entity;

public class Actors
{
    [Key]
    public string Id { set; get; }
    public string Name { set; get; }
    public string BirthDate { set; get; }
    public string Nationality { set; get; }
    public DateTime CreatedAt { set; get; }
    public DateTime UpdatedAt { set; get; }
}
