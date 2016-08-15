using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public interface ISelectItem
    {
        bool Selected { get; set; }
        bool Disabled { get; set; }
        string Text { get; set; }
        string Value { get; set; }
    }
}
