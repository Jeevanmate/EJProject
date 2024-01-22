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
    public class BuyersController : ControllerBase
    {

        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public MakesController(ApplicationDbContext context)
        public BuyersController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        public async Task<IActionResult> GetBuyers()
        {
            //Refactored
            // if (_context.Makes == null)
            //  {
            //       return NotFound();
            //   }
            //     return await _context.Makes.ToListAsync();
            var buyers = await _unitOfWork.Buyers.GetAll();
            return Ok(buyers);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]

        //Refactored
        // public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetBuyer(int id)
        {
            //Refactored
            // if (_context.Makes == null)
            //{
            //   return NotFound();
            //}
            // var make = await _context.Makes.FindAsync(id);
            var buyer = await _unitOfWork.Buyers.Get(q => q.BuyerID == id);

            if (buyer == null)
            {
                return NotFound();
            }

            //Refactored
            //return make;
            return Ok(buyer);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Buyer buyer)
        {
            if (id != buyer.BuyerID)
            {
                return BadRequest();
            }

            //Refactored
            // _context.Entry(make).State = EntityState.Modified;
            _unitOfWork.Buyers.Update(buyer);

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
                if (!await BuyerExists(id))
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
        public async Task<ActionResult<Buyer>> PostMake(Buyer buyer)
        {
            //Refactored
            //if (_context.Makes == null)
            //{
            //   return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
            //}
            // _context.Makes.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Buyers.Insert(buyer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBuyer", new { id = buyer.BuyerID }, buyer);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyer(int id)
        {
            //Refactored
            // if (_context.Makes == null)
            //{
            //   return NotFound();
            //}
            //var make = await _context.Makes.FindAsync(id);
            var buyer = await _unitOfWork.Buyers.Get(q => q.BuyerID == id);

            if (buyer == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Buyers.Delete(id);
            await _unitOfWork.Save(HttpContext);


            return NoContent();
        }

        //Refactored
        //private bool MakeExists(int id)
        private async Task<bool> BuyerExists(int id)
        {
            //Refactored
            //return (_context.Makes?.Any(e => e.Id == id)).GetValueOrDefault();
            var buyer = await _unitOfWork.Buyers.Get(q => q.BuyerID == id);
            return buyer != null;
        }
    }
}

