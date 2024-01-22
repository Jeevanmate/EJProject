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
    public class SellersController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public MakesController(ApplicationDbContext context)
        public SellersController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        public async Task<IActionResult> GetSellers()
        {
            //Refactored
            // if (_context.Makes == null)
            //  {
            //       return NotFound();
            //   }
            //     return await _context.Makes.ToListAsync();
            var Sellers = await _unitOfWork.Sellers.GetAll();
            return Ok(Sellers);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]

        //Refactored
        // public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetSeller(int id)
        {
            //Refactored
            // if (_context.Makes == null)
            //{
            //   return NotFound();
            //}
            // var make = await _context.Makes.FindAsync(id);
            var Seller = await _unitOfWork.Sellers.Get(q => q.SellerID == id);

            if (Seller == null)
            {
                return NotFound();
            }

            //Refactored
            //return make;
            return Ok(Seller);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Seller Seller)
        {
            if (id != Seller.SellerID)
            {
                return BadRequest();
            }

            //Refactored
            // _context.Entry(make).State = EntityState.Modified;
            _unitOfWork.Sellers.Update(Seller);

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
                if (!await SellerExists(id))
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
        public async Task<ActionResult<Seller>> PostMake(Seller Seller)
        {
            //Refactored
            //if (_context.Makes == null)
            //{
            //   return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
            //}
            // _context.Makes.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Sellers.Insert(Seller);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSeller", new { id = Seller.SellerID }, Seller);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            //Refactored
            // if (_context.Makes == null)
            //{
            //   return NotFound();
            //}
            //var make = await _context.Makes.FindAsync(id);
            var Seller = await _unitOfWork.Sellers.Get(q => q.SellerID == id);

            if (Seller == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Sellers.Delete(id);
            await _unitOfWork.Save(HttpContext);


            return NoContent();
        }

        //Refactored
        //private bool MakeExists(int id)
        private async Task<bool> SellerExists(int id)
        {
            //Refactored
            //return (_context.Makes?.Any(e => e.Id == id)).GetValueOrDefault();
            var Seller = await _unitOfWork.Sellers.Get(q => q.SellerID == id);
            return Seller != null;
        }
    }
}
