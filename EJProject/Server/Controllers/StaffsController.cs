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
    public class StaffsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public MakesController(ApplicationDbContext context)
        public StaffsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        public async Task<IActionResult> GetStaffs()
        {
            //Refactored
            // if (_context.Makes == null)
            //  {
            //       return NotFound();
            //   }
            //     return await _context.Makes.ToListAsync();
            var Staffs = await _unitOfWork.Staffs.GetAll();
            return Ok(Staffs);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]

        //Refactored
        // public async Task<ActionResult<Make>> GetMake(int id)
        public async Task<IActionResult> GetStaff(int id)
        {
            //Refactored
            // if (_context.Makes == null)
            //{
            //   return NotFound();
            //}
            // var make = await _context.Makes.FindAsync(id);
            var Staff = await _unitOfWork.Staffs.Get(q => q.StaffID == id);

            if (Staff == null)
            {
                return NotFound();
            }

            //Refactored
            //return make;
            return Ok(Staff);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, Staff Staff)
        {
            if (id != Staff.StaffID)
            {
                return BadRequest();
            }

            //Refactored
            // _context.Entry(make).State = EntityState.Modified;
            _unitOfWork.Staffs.Update(Staff);

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
                if (!await StaffExists(id))
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
        public async Task<ActionResult<Staff>> PostMake(Staff Staff)
        {
            //Refactored
            //if (_context.Makes == null)
            //{
            //   return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
            //}
            // _context.Makes.Add(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Staffs.Insert(Staff);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetStaff", new { id = Staff.StaffID }, Staff);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            //Refactored
            // if (_context.Makes == null)
            //{
            //   return NotFound();
            //}
            //var make = await _context.Makes.FindAsync(id);
            var Staff = await _unitOfWork.Staffs.Get(q => q.StaffID == id);

            if (Staff == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Staffs.Delete(id);
            await _unitOfWork.Save(HttpContext);


            return NoContent();
        }

        //Refactored
        //private bool MakeExists(int id)
        private async Task<bool> StaffExists(int id)
        {
            //Refactored
            //return (_context.Makes?.Any(e => e.Id == id)).GetValueOrDefault();
            var Staff = await _unitOfWork.Staffs.Get(q => q.StaffID == id);
            return Staff != null;
        }
    }
}
