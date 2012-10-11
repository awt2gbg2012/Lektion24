using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion24.Models.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lektion24.Models.Entities
{
    public class News : IEntity
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid PostedByID { get; set; }
        public virtual User PostedBy { get; set; }
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public virtual NewsCaption NewsCaption { get; set; }
    }
}