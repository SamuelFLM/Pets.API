using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pets.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Pets.Context
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options){}

        public DbSet<Pet> Pets { get; set; }
    }
}