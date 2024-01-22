using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EJProject.Server.Data;
using EJProject.Shared.Domain;
using EJProject.Server.IRepository;

namespace EJProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public MakesController(ApplicationDbContext context)
        public ProductsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        public async Task<IActionResult> GetProducts()
        {
            //Refactored
            // if (_context.Makes == null)
            //  {
            //       return NotFound();
            //   }
            //     return await _context.Makes.ToListAsync();
            var Products = await _unitOfWork.Products.GetAll();
            return Ok(Products);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]

        //Refactored
        // public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetProduct(int id)
        {
            //Refactored
            // if (_context.Makes == null)
            //{
            //   return NotFound();
            //}
            // var make = await _context.Makes.FindAsync(id);
            var Product = await _unitOfWork.Products.Get(q => q.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }

            //Refactored
            //return make;
            return Ok(Product);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Product Product)
        {
            if (id != Product.ProductID)
            {
                return BadRequest();
            }

            //Refactored
            // _context.Entry(make).State = EntityState.Modified;
            _unitOfWork.Products.Update(Product);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!MakeExists(id))
                if (!await ProductExists(id))
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

        // POST: api/Makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostMake(Product Product)
        {
            //Refactored
            //if (_context.Makes == null)
            //{
            //   return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
            //}
            // _context.Makes.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Products.Insert(Product);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProduct", new { id = Product.ProductID }, Product);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //Refactored
            // if (_context.Makes == null)
            //{
            //   return NotFound();
            //}
            //var make = await _context.Makes.FindAsync(id);
            var Product = await _unitOfWork.Products.Get(q => q.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Products.Delete(id);
            await _unitOfWork.Save(HttpContext);


            return NoContent();
        }

        //Refactored
        //private bool MakeExists(int id)
        private async Task<bool> ProductExists(int id)
        {
            //Refactored
            //return (_context.Makes?.Any(e => e.Id == id)).GetValueOrDefault();
            var Product = await _unitOfWork.Products.Get(q => q.ProductID == id);
            return Product != null;
        }
    }
}
