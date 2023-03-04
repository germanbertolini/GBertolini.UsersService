using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Sanitizers
{
    public static class EmailSanitizer
    {
        public static string Sanitize(string address)
        {
            if (address.Contains("@"))
                address = $"{NormalizeName(address)}@{NormalizeDomain(address)}";

            return address;
        }

        private static string NormalizeName(string address)
            => address.Substring(0, address.IndexOfAny(new char[] { '+', '@' }))
                      .Replace(".", string.Empty)
                      .Trim();

        private static string NormalizeDomain(string address)
            => address.Substring(address.LastIndexOf('@') + 1, address.Length - address.LastIndexOf('@') - 1)
                      .Trim();
    }
}
