using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class JournalEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [StringLength(10000, ErrorMessage = "Journal entry cannot exceed 10000 characters")]
        [Required(ErrorMessage = "Journal entry is required")]
        [Display(Name = "Journal Entry")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Scripture book is required")]
        [Display(Name = "Scripture Book")]
        public string ScriptureBook { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Chapter must be a positive number")]
        [Required(ErrorMessage = "Chapter is required")]
        [Display(Name = "Scripture Chapter")]
        public int ScriptureChapter { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Verse must be a positive number")]
        [Required(ErrorMessage = "Verse is required")]
        [Display(Name = "Scripture Verse")]
        public int ScriptureVerse { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [Display(Name = "Link to scripture")]
        public string OnlineLibraryLink { get; set; }
    }
}
