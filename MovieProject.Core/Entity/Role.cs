using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MovieProject.Core.CommonEnum;

namespace MovieProject.Core.Entity
{
    public class Role
    {
        [Key]
        public string Id { set; get; }
        [StringLength(225)]
        public string Name { set; get; }
        [StringLength(225)]
        public string Description { set; get; }
        public RoleStatus Status { set; get; }
        public DateTime CreatedAt { set; get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { set; get; } = DateTime.UtcNow;
    }
}
