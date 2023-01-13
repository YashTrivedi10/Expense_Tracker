using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expence_tracker;
using Expence_tracker.Models;

namespace Expence_tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class expensesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public expensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<expense>>> Getexpense()
        {
            return await _context.expense.ToListAsync();
        }

        // GET: api/expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<expense>> Getexpense(int id)
        {
            var expense = await _context.expense.FindAsync(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }

        // PUT: api/expenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putexpense(int id, expense expense)
        {
            if (id != expense.categoryid)
            {
                return BadRequest();
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!expenseExists(id))
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

        // POST: api/expenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<expense>> Postexpense(expense expense)
        {
            _context.expense.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getexpense", new { id = expense.categoryid }, expense);
        }

        // DELETE: api/expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteexpense(int id)
        {
            var expense = await _context.expense.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.expense.Remove(expense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool expenseExists(int id)
        {
            return _context.expense.Any(e => e.categoryid == id);
        }
    }
}
