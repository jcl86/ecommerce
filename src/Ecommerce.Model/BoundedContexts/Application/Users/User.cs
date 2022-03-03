using System;
using System.Collections;
using System.Collections.Generic;

namespace Ecommerce.Application.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
