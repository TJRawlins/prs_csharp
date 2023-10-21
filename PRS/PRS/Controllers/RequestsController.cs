using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRS.Data;
using PRS.Models;

namespace PRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly PRSContext _context;

        public RequestsController(PRSContext context)
        {
            _context = context;
        }

        /**-*-*-*-*-*-*-*-* CAPSTONE METHOD - GET REVIEWS *-*-*-*-*-*-*-*-* */
        // GET: api/Requests/reviews/5
        [HttpGet("reviews/{userId}")]
        //public async Task<ActionResult<Request>> GetReviews(int userId)
        public async Task<ActionResult<IEnumerable<Request>>> GetReviews(int userId) {
            if (_context.Requests == null)
            {
                return NotFound();
            }

            //var request = await _context.Requests
            //                        .Include(x => x.User)
            //                        .SingleOrDefaultAsync(x => x.UserId != userId && x.Status == "REVIEW");

            var request = await _context.Requests
                                    .Where(x => x.UserId != userId && x.Status == "REVIEW")
                                    .Include(x => x.User).ToListAsync();

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }


        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
          if (_context.Requests == null)
          {
              return NotFound();
          }
            return await _context.Requests.Include(x => x.User).ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
          if (_context.Requests == null)
          {
              return NotFound();
          }
            /**-*-*-*-*-*-*-*-* CAPSTONE - GROUP USER AND PRODUCTS *-*-*-*-*-*-*-*-* */
            var request = await _context.Requests
                                    .Include(x => x.User)
                                    .Include(x => x.RequestLines)!
                                    .ThenInclude(x => x.Products)
                                    .SingleOrDefaultAsync(x => x.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        /**-*-*-*-*-*-*-*-* CAPSTONE METHODS - STATUS UPDATE *-*-*-*-*-*-*-*-* */
        // PUT: api/Requests/review/5
        [HttpPut("review/{id}")]
        public async Task<IActionResult> StatusReview(int id, Request request)
        {
            request.Status = request.Total < 50 ? request.Status = "APPROVED" : request.Status = "REVIEW";
            return await PutRequest(id, request);

        }

        /**-*-*-*-*-*-*-*-* CAPSTONE METHODS - STATUS UPDATE *-*-*-*-*-*-*-*-* */
        // PUT: api/Requests/approve/5
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> StatusApprove(int id, Request request)
        {
            request.Status = "APPROVED";
            return await PutRequest(id, request);

        }

        /**-*-*-*-*-*-*-*-* CAPSTONE METHODS - STATUS UPDATE *-*-*-*-*-*-*-*-* */
        // PUT: api/Requests/reject/5
        [HttpPut("reject/{id}")]
        public async Task<IActionResult> StatusReject(int id, Request request)
        {
            request.Status = "REJECTED";
            return await PutRequest(id, request);

        }


        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
          if (_context.Requests == null)
          {
              return Problem("Entity set 'PRSContext.Requests'  is null.");
          }
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            if (_context.Requests == null)
            {
                return NotFound();
            }
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return (_context.Requests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
