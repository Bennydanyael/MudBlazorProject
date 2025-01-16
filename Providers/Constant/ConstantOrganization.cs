using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Constant
{
    public static class ConstantOrganization
    {
        public static string PrefixM = "TOM";
        public static string PrefixD = "TOD";

        private static string CompanyPolicy = "CompanyPolicy";
        private static string CompanyProfile = "CompanyProfile";
        private static string Announcement = "Announcement";

        public static string CompanyPolicyTable = PrefixM + CompanyPolicy;
        public static string CompanyProfileTable = PrefixM + CompanyProfile;
        public static string AnnouncementTable = PrefixM + Announcement;
    }
}
