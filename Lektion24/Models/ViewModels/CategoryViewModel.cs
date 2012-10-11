using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion24.Models.Entities;

namespace Lektion24.Models.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public List<SelectedStringsViewModel> SelectedStrings { get; set; }
    }

    public class SelectedStringsViewModel
    {
        public bool Selected { get; set; }
        public string Text { get; set; }
        public Guid ID { get { return Guid.NewGuid(); } }
    }
}