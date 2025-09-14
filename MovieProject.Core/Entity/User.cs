using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.Core.Entity;

public class User
{
    [Key]
    public string Id { set; get; }
    public string Email { set; get; }
    public string Name { set; get; }
    public string PasswordHash { set; get; }
    public string PasswordSalt { set; get; }
    public string RoleId { set; get; }
    [ForeignKey("RoleId")]
    public Role Role { set; get; }
    public DateTime CreatedAt { set; get; } = DateTime.UtcNow;  
    public DateTime UpdatedAt{ set; get; }  = DateTime.UtcNow;
}
