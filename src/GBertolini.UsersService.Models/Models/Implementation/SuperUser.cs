using GBertolini.UsersService.Models.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Models.Implementation
{
    public class SuperUser : User
    {
        private decimal ResolveGiftPercentage()
                => Money > 100 ? (decimal)0.20 : (decimal)0.00;

        public override void ApplyGift()
                => Money *= (1 + ResolveGiftPercentage());
    }
}
