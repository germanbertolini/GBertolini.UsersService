using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Sanitizers
{
    public class StringSanitizer
    {
        public static string Sanitize(string value)
                => value.Trim();
    }
}
