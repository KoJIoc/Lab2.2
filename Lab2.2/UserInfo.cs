using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace BlogNamespace
{
    public class UserInfo
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string RolesToString()
        {
            string roles ="";
            foreach (var role in Roles)
            {
                roles += $"{role.Title}, {role.Description}, {role.Id}";
            }
            return roles;
        }
    }
}
