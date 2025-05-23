﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWebApp.Application.Exceptions
{
    public class InvalidCredentialsException : ApplicationException
    {
        public InvalidCredentialsException() : base("Invalid email or password.") { }
    }
}
