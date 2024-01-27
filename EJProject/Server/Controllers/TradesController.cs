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
    public class TradesController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public TradesController(ApplicationDbContext context)
        public TradesController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Trades
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Trade>>> GetTrades()
        public async Task<IActionResult> GetTrades()
        {
            //To be deleted or commented after testing Global Error Handling
            //return NotFound();
            //Refactored
            //if (_context.Trades == null)
            // {
            //     return NotFound();
            // }
            //return await _context.Trades.ToListAsync();
            var trades = await _unitOfWork.Trades.GetAll(includes:q => q.Include(x => x.Buyer));
            return Ok(trades);
        }

        // GET: api/Trades/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Trade>> GetTrade(int id)
        public async Task<IActionResult> GetTrade(int id)

        {
            //Refactored
            //if (_context.Trades == null)
            //{
            //    return NotFound();
            //}
            //  var trade = await _context.Trades.FindAsync(id);
            var trade = await _unitOfWork.Trades.Get(q => q.TradeID == id);

            if (trade == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(trade);
        }

        // PUT: api/Trades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrade(int id, Trade trade)
        {
            if (id != trade.TradeID)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(trade).State = EntityState.Modified;
            _unitOfWork.Trades.Update(trade);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!TradeExists(id))
                if (!await TradeExists(id))
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

        // POST: api/Trades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trade>> PostTrade(Trade trade)
        {
            //Refactored
            //if (_context.Trades == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Trades'  is null.");
            //}
            // _context.Trades.Add(trade);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Trades.Insert(trade);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTrade", new { id = trade.TradeID }, trade);
        }

        // DELETE: api/Trades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrade(int id)
        {
            //Refactored
            //if (_context.Trades == null)
            //{
            //    return NotFound();
            //}
            //var trade = await _context.Trades.FindAsync(id);
            var trade = await _unitOfWork.Trades.Get(q => q.TradeID == id);
            if (trade == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Trades.Remove(trade);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Trades.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool TradeExists(int id)
        private async Task<bool> TradeExists(int id)
        {
            //Refactored
            //return (_context.Trades?.Any(e => e.TradeID == id)).GetValueOrDefault();
            var trade = await _unitOfWork.Trades.Get(q => q.TradeID == id);
            return trade != null;
        }
    }
}
