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
        //public BuyersController(ApplicationDbContext context)
        public BuyersController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Buyers
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Buyer>>> GetBuyers()
        public async Task<IActionResult> GetBuyers()
        {
          //Refactored
          //if (_context.Buyers == null)
         // {
         //     return NotFound();
         // }
            //return await _context.Buyers.ToListAsync();
            var buyers = await _unitOfWork.Buyers.GetAll();
            return Ok(buyers);
        }

        // GET: api/Buyers/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Buyer>> GetBuyer(int id)
        public async Task<IActionResult> GetBuyer(int id)
    
        {
            //Refactored
            //if (_context.Buyers == null)
            //{
            //    return NotFound();
            //}
            //  var buyer = await _context.Buyers.FindAsync(id);
            var buyer = await _unitOfWork.Buyers.Get(q => q.BuyerID == id);

            if (buyer == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(buyer);
        }

        // PUT: api/Buyers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyer(int id, Buyer buyer)
        {
            if (id != buyer.BuyerID)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(buyer).State = EntityState.Modified;
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
                //if (!BuyerExists(id))
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

        // POST: api/Buyers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buyer>> PostBuyer(Buyer buyer)
        {
            //Refactored
            //if (_context.Buyers == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Buyers'  is null.");
            //}
            // _context.Buyers.Add(buyer);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Buyers.Insert(buyer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBuyer", new { id = buyer.BuyerID }, buyer);
        }

        // DELETE: api/Buyers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyer(int id)
        {
            //Refactored
            //if (_context.Buyers == null)
            //{
            //    return NotFound();
            //}
            //var buyer = await _context.Buyers.FindAsync(id);
            var buyer = await _unitOfWork.Buyers.Get(q => q.BuyerID == id);
            if (buyer == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Buyers.Remove(buyer);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Buyers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool BuyerExists(int id)
        private async Task<bool> BuyerExists(int id)
        {
            //Refactored
            //return (_context.Buyers?.Any(e => e.BuyerID == id)).GetValueOrDefault();
            var buyer = await _unitOfWork.Buyers.Get(q => q.BuyerID == id);
            return buyer != null;
        }
    }
}
