using System;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Core.Entity;

public class PublisherCompany
{
    [Key]
    public string Id { set; get; }
    public string Name { set; get; }
    public string Country { set; get; }
    public string FoundedYear { set; get; }
    public string Website { set; get; }
    public DateTime CreatedAt { set; get; } = DateTime.UtcNow;
    public DateTime UpdatedAt { set; get; } = DateTime.UtcNow;
}
