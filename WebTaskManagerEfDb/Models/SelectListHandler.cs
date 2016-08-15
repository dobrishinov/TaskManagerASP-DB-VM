using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTaskManagerEfDb.Models
{
    public class SelectListHandler
    {
        //Represents a method that creates a dropdownlist with some objects
        public static List<ISelectItem> Create<T>(List<T> items, Func<T, string> getValue,
            Func<T, string> getID, string selectedValue = null) where T : BaseEntity
        {
            var result = new List<ISelectItem>();
            foreach (var x in items)
            {
                result.Add(new SelectItem
                {
                    Value = getID(x),
                    Text = getValue(x),
                    Selected = selectedValue != null && selectedValue == getID(x)
                });
            }
            return result.OrderBy(x => x.Text).ToList();
        }
    }
}