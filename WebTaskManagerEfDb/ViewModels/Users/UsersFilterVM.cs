using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebTaskManagerEfDb.Models;
using WebTaskManagerEfDb.Tools;

namespace WebTaskManagerEfDb.ViewModels.Users
{
    public class UsersFilterVM : BaseFilterVM<UserEntity>
    {
        UsersRepository repo = new UsersRepository();

        public UsersFilterVM()
        {

        }

        [FilterProperty(DisplayName = "First Name")]
        public string FirstName { get; set; }

        [FilterProperty(DisplayName = "Last Name")]
        public string LastName { get; set; }

        [FilterProperty(DisplayName = "User Name")]
        public string Username { get; set; }

        //[FilterProperty(DisplayName = "UserName", DropDownTargetProperty = "UserName")]
        //public List<ISelectItem> UserName { get; set; }

        public override Expression<Func<UserEntity, bool>> BuildFilter()
        {
            return (p => ((p.FirstName.Contains(FirstName) || string.IsNullOrEmpty(FirstName))
            && ((p.LastName.Contains(LastName)) || string.IsNullOrEmpty(LastName))
            && ((p.Username.Contains(Username)) || string.IsNullOrEmpty(Username))));
           
        }
    }
}