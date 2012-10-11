using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion24.Models.Entities.Abstract;

namespace Lektion24.Models.Entities
{
    public class Category : IEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}