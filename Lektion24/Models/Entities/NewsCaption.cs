using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion24.Models.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lektion24.Models.Entities
{
    public class NewsCaption : IEntity
    {
        [Key, ForeignKey("News")]
        public Guid ID { get; set; }
        public string Caption { get; set; }
        public virtual News News { get; set; }
    }
}