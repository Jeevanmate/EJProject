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
    public class ProfilesController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public ProfilesController(ApplicationDbContext context)
        public ProfilesController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Profiles
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        public async Task<IActionResult> GetProfiles()
        {
            //To be deleted after testing Global Error Handling
            //return NotFound();
            //Refactored
            //if (_context.Profiles == null)
            // {
            //     return NotFound();
            // }
            //return await _context.Profiles.ToListAsync();
            var Profiles = await _unitOfWork.Profiles.GetAll();
            return Ok(Profiles);
        }

        // GET: api/Profiles/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Profile>> GetProfile(int id)
        public async Task<IActionResult> GetProfile(int id)

        {
            //Refactored
            //if (_context.Profiles == null)
            //{
            //    return NotFound();
            //}
            //  var Profile = await _context.Profiles.FindAsync(id);
            var Profile = await _unitOfWork.Profiles.Get(q => q.ProfileID == id);

            if (Profile == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(Profile);
        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, Profile Profile)
        {
            if (id != Profile.ProfileID)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Profile).State = EntityState.Modified;
            _unitOfWork.Profiles.Update(Profile);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!ProfileExists(id))
                if (!await ProfileExists(id))
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

        // POST: api/Profiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile Profile)
        {
            //Refactored
            //if (_context.Profiles == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Profiles'  is null.");
            //}
            // _context.Profiles.Add(Profile);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Profiles.Insert(Profile);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProfile", new { id = Profile.ProfileID }, Profile);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            //Refactored
            //if (_context.Profiles == null)
            //{
            //    return NotFound();
            //}
            //var Profile = await _context.Profiles.FindAsync(id);
            var Profile = await _unitOfWork.Profiles.Get(q => q.ProfileID == id);
            if (Profile == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Profiles.Remove(Profile);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Profiles.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool ProfileExists(int id)
        private async Task<bool> ProfileExists(int id)
        {
            //Refactored
            //return (_context.Profiles?.Any(e => e.ProfileID == id)).GetValueOrDefault();
            var Profile = await _unitOfWork.Profiles.Get(q => q.ProfileID == id);
            return Profile != null;
        }
    }
}
