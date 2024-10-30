using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiServicioCupones.Data;
using ApiServicioCupones.Models;
using ClientesApi.Models;

namespace ApiServicioCupones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ClientesController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteModel>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> GetClienteModel(string id)
        {
            var clienteModel = await _context.Clientes.FindAsync(id);

            if (clienteModel == null)
            {
                return NotFound();
            }

            return clienteModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteModel(string id, ClienteModel clienteModel)
        {
            if (id != clienteModel.CodCliente.ToString())
            {
                return BadRequest();
            }

            _context.Entry(clienteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteModelExists(id))
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

        [HttpPost]
        public async Task<ActionResult<ClienteModel>> PostClienteModel(ClienteModel clienteModel)
        {
            clienteModel.CodCliente = FormatCodCliente(clienteModel.CodCliente);

            _context.Clientes.Add(clienteModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteModel", new { id = clienteModel.CodCliente }, clienteModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteModel(string id)
        {
            var clienteModel = await _context.Clientes.FindAsync(id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clienteModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteModelExists(string id)
        {
            return _context.Clientes.Any(e => e.CodCliente.ToString() == id); 
        }

        private string FormatCodCliente(string codCliente)
        {
            string sinPuntos = codCliente.Replace(".", "");

            if (long.TryParse(sinPuntos, out long numero))
            {
                return numero.ToString();
            }
            throw new ArgumentException("El DNI debe contener solo números y puntos.");
        }

    }
}
