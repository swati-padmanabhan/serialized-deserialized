﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeDeserializeOnLists.models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Person(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
            
    }
    
}
