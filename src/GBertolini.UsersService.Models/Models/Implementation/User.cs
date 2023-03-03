using AutoMapper.Execution;
using GBertolini.UsersService.Models.Attributes;
using GBertolini.UsersService.Models.Enums;
using GBertolini.UsersService.Models.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Models.Implementation
{
    public abstract class User : IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Money { get; set; }

        /// <summary>
        /// Apply an additional amount in Money value
        /// </summary>
        public abstract void ApplyGift();
    }
}
