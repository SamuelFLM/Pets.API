using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Api_Pets.Context;
using Api_Pets.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Pets.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class PetController : ControllerBase
    {
        private readonly PetContext _context;
        public PetController(PetContext context)
        {
            _context = context;
        }
        [HttpGet("pet")]
        public IActionResult Obter()
        {
            var pets = _context.Pets;
            return Ok(pets);
        }
        [HttpGet("pet/{id}")]
        public IActionResult ObterId(int id)
        {
            var idPet = _context.Pets.Find(id);
            if (idPet == null)
                return NotFound();
            return Ok(idPet);
        }
        [HttpPost]
        public IActionResult Cadastrar(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterId), new { id = pet.Id }, pet);
        }

        [HttpPut("pet")]
        public IActionResult Alterar(int id, Pet _pet)
        {
            var pet = _context.Pets.Find(id);
            if (pet == null)
                return BadRequest();
            pet.Nome = _pet.Nome;
            pet.Raca = _pet.Raca;
            pet.Adocao = _pet.Adocao;
            _context.Update(pet);
            _context.SaveChanges();
            return Ok(pet);
        }
        [HttpDelete("pet/")]
        public IActionResult Deletar(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet == null)
                return BadRequest();

            _context.Pets.Remove(pet);
            _context.SaveChanges();
            return Ok();

        }
    }
}