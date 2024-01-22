﻿using System;
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
        //public MakesController(ApplicationDbContext context)
        public TradesController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        public async Task<IActionResult> GetTrades()
        {
            //Refactored
            // if (_context.Makes == null)
            //  {
            //       return NotFound();
            //   }
            //     return await _context.Makes.ToListAsync();
            var Trades = await _unitOfWork.Trades.GetAll();
            return Ok(Trades);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]

        //Refactored
        // public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetTrade(int id)
        {
            //Refactored
            // if (_context.Makes == null)
            //{
            //   return NotFound();
            //}
            // var make = await _context.Makes.FindAsync(id);
            var Trade = await _unitOfWork.Trades.Get(q => q.TradeID == id);

            if (Trade == null)
            {
                return NotFound();
            }

            //Refactored
            //return make;
            return Ok(Trade);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Trade Trade)
        {
            if (id != Trade.TradeID)
            {
                return BadRequest();
            }

            //Refactored
            // _context.Entry(make).State = EntityState.Modified;
            _unitOfWork.Trades.Update(Trade);

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

        // POST: api/Makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trade>> PostMake(Trade Trade)
        {
            //Refactored
            //if (_context.Makes == null)
            //{
            //   return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
            //}
            // _context.Makes.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Trades.Insert(Trade);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTrade", new { id = Trade.TradeID }, Trade);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrade(int id)
        {
            //Refactored
            // if (_context.Makes == null)
            //{
            //   return NotFound();
            //}
            //var make = await _context.Makes.FindAsync(id);
            var Trade = await _unitOfWork.Trades.Get(q => q.TradeID == id);

            if (Trade == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Trades.Delete(id);
            await _unitOfWork.Save(HttpContext);


            return NoContent();
        }

        //Refactored
        //private bool MakeExists(int id)
        private async Task<bool> TradeExists(int id)
        {
            //Refactored
            //return (_context.Makes?.Any(e => e.Id == id)).GetValueOrDefault();
            var Trade = await _unitOfWork.Trades.Get(q => q.TradeID == id);
            return Trade != null;
        }
    }
}
