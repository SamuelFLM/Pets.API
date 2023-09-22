using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pets.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Adocao { get; set; }
    }
}