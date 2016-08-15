using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTaskManagerEfDb.Tools
{
    public class FilterPropertyAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public string DropDownTargetProperty { get; set; }
    }
}