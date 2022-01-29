using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using trackingg.Data;
using trackingg.Models;

namespace trackingg.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IssueDbContext _context;

        public IndexModel(IssueDbContext context) => _context = context;

        public async void OnGet()
        {
            Issues = await _context.Issues.Where(i => i.Completed == null)
                .OrderByDescending(i => i.Created)
                .ToListAsync();
        }

        public IEnumerable<Issue> Issues { get; set; } = Enumerable.Empty<Issue>();
    }
}