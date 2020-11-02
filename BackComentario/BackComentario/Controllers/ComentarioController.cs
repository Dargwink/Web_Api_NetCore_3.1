using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackComentario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackComentario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {

        private readonly AplicationDbContext _Context;

        public ComentarioController(AplicationDbContext context)
        {
            _Context = context;
        }
        // GET: api/<ComentarioController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comentario>>> Get()
        {
            
           return await _Context.Comentarios.ToListAsync();
            
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComentario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comentario = await _Context.Comentarios.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _Context.Comentarios.Add(comentario);
            await _Context.SaveChangesAsync();

            return CreatedAtAction("GetComentario", new { id = comentario.Id }, comentario);
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentario.Id)
            {
                return BadRequest();
            }

            _Context.Entry(comentario).State = EntityState.Modified;

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comentario = await _Context.Comentarios.FindAsync(id);
             if (comentario == null)
            {
                return NotFound();
            }

            _Context.Comentarios.Remove(comentario);
            await _Context.SaveChangesAsync();

            return Ok(comentario);
        }
       
        
        private bool BankExists(int id)
        {
            return _Context.Comentarios.Any(e => e.Id == id);
        }
    }
}
