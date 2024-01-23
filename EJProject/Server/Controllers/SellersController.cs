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
        //public SellersController(ApplicationDbContext context)
        public SellersController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Sellers
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Seller>>> GetSellers()
        public async Task<IActionResult> GetSellers()
        {
            //Refactored
            //if (_context.Sellers == null)
            // {
            //     return NotFound();
            // }
            //return await _context.Sellers.ToListAsync();
            var sellers = await _unitOfWork.Sellers.GetAll();
            return Ok(sellers);
        }

        // GET: api/Sellers/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Seller>> GetSeller(int id)
        public async Task<IActionResult> GetSeller(int id)

        {
            //Refactored
            //if (_context.Sellers == null)
            //{
            //    return NotFound();
            //}
            //  var seller = await _context.Sellers.FindAsync(id);
            var seller = await _unitOfWork.Sellers.Get(q => q.SellerID == id);

            if (seller == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(seller);
        }

        // PUT: api/Sellers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeller(int id, Seller seller)
        {
            if (id != seller.SellerID)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(seller).State = EntityState.Modified;
            _unitOfWork.Sellers.Update(seller);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!SellerExists(id))
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

        // POST: api/Sellers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seller>> PostSeller(Seller seller)
        {
            //Refactored
            //if (_context.Sellers == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Sellers'  is null.");
            //}
            // _context.Sellers.Add(seller);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Sellers.Insert(seller);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSeller", new { id = seller.SellerID }, seller);
        }

        // DELETE: api/Sellers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            //Refactored
            //if (_context.Sellers == null)
            //{
            //    return NotFound();
            //}
            //var seller = await _context.Sellers.FindAsync(id);
            var seller = await _unitOfWork.Sellers.Get(q => q.SellerID == id);
            if (seller == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Sellers.Remove(seller);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Sellers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool SellerExists(int id)
        private async Task<bool> SellerExists(int id)
        {
            //Refactored
            //return (_context.Sellers?.Any(e => e.SellerID == id)).GetValueOrDefault();
            var seller = await _unitOfWork.Sellers.Get(q => q.SellerID == id);
            return seller != null;
        }
    }
}

