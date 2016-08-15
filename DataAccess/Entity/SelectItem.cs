using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class SelectItem : ISelectItem
    {
        public bool Selected { get; set; }
        public bool Disabled { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
