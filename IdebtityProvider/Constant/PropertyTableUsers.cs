using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.Constant
{
    public static class PropertyTableUsers
    {
        internal static string IdentityPrefix = "T";
        internal static string IdentityUser = "AccountUser";
        internal static string AccountRoles = "AccountRoles";
        internal static string AccountLogins = "AccountLogins";
        internal static string AccountClaims = "AccountClaims";
        internal static string Roles = "Roles";
        internal static string GroupRoles = "GroupRoles";
        internal static string Groups = "Groups";
        internal static string AccountGroups = "AccountGroups";

        public static string UsersTable = IdentityPrefix + IdentityUser;
        public static string RolesTable = IdentityPrefix + Roles;
        public static string GroupsTable = IdentityPrefix + Groups;
        public static string AccountGroupsTable = IdentityPrefix + AccountGroups;
        public static string GroupRolesTable = IdentityPrefix + GroupRoles;
        public static string AccountRolesTable = IdentityPrefix + AccountRoles;
        public static string AccountLoginsTable = IdentityPrefix + AccountLogins;
    }
}
