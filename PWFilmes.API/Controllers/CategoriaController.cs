﻿using Microsoft.AspNetCore.Mvc;
using PWFilmes.API.Context;
using PWFilmes.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PWFilmes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private PWFilmesContext _context;

        public CategoriaController(PWFilmesContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.CategoriaSet.AsEnumerable());
        }

        [HttpGet("obter/{codigo}")]
        public IActionResult Obter(int codigo)
        {
            return Ok(_context.CategoriaSet.Find(codigo));
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar(Categoria categoria)
        {
            _context.CategoriaSet.Add(categoria);
            _context.SaveChanges();

            return Created("Created", $"Categoria {categoria.Codigo} Adicionada com Sucesso.");
        }
    }
}
