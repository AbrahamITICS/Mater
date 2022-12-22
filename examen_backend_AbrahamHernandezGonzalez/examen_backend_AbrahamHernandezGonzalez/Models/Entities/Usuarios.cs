using System;
using System.Collections.Generic;

namespace examen_backend_AbrahamHernandezGonzalez.Models.Entities
{
    public partial class Usuarios
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}