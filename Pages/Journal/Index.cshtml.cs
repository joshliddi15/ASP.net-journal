using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Journal
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<JournalEntry> JournalEntry { get;set; } = default!;

        /*public async Task OnGetAsync()
        {
            JournalEntry = await _context.JournalEntry.OrderByDescending(entry => entry.Date).ToListAsync();
        }*/

        // Override for OnGetAsync to include search functionality
        public async Task OnGetAsync(string bookSearch, string keywordSearch)
        {
            // Retrieve all journal entries
            IQueryable<JournalEntry> journalQuery = _context.JournalEntry;

            // Filter by ScriptureBook if the bookSearch parameter is provided
            if (!string.IsNullOrEmpty(bookSearch))
            {
                journalQuery = journalQuery
                    .Where(entry => entry.ScriptureBook.Contains(bookSearch));
            }

            // Filter by Content if the keywordSearch parameter is provided
            if (!string.IsNullOrEmpty(keywordSearch))
            {
                journalQuery = journalQuery
                    .Where(entry => entry.Content.Contains(keywordSearch));
            }

            journalQuery = journalQuery.OrderByDescending(entry => entry.Date);
            JournalEntry = await journalQuery.ToListAsync();
        }
    }
}
