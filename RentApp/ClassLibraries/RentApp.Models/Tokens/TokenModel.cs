﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Models.Tokens
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime DateExpires { get; set; }
    }
}
