using StickyNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteClone.Utils
{
    public class NoteGenerator
    {
        private static Random random = new Random();

        private static string GenerateRandomContent()
        {
            var words = new string[]
            {
                "grocery", "homework", "meeting", "agenda", "conference", "important", "project", "deadline", "discussion",
                "presentation", "schedule", "meeting", "appointment", "plans", "notes", "tasks", "reminder", "plan",
                "update", "team", "work", "plan", "coffee", "email", "workshop", "call", "vacation"
            };

            int wordCount = random.Next(10, 21);
            List<string> contentWords = [];

            for (int i = 0; i < wordCount; i++)
            {
                contentWords.Add(words[random.Next(words.Length)]);
            }

            return string.Join(" ", contentWords);
        }

        private static string GenerateRandomDate()
        {
            DateTime startDate = new DateTime(2020, 1, 1);
            int range = (DateTime.Today - startDate).Days;
            return startDate.AddDays(random.Next(range)).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static List<Note> GenerateNotes(int count)
        {
            var notes = new List<Note>();
            for (int i = 0; i < count; i++)
            {
                var note = new Note
                {
                    Id = Guid.NewGuid().ToString(),
                    Content = GenerateRandomContent(),
                    CreatedAt = GenerateRandomDate(),
                    UpdatedAt = GenerateRandomDate(),
                    DeletedAt = random.Next(2) == 0 ? null : GenerateRandomDate()
                };
                notes.Add(note);
            }
            return notes;
        }
    }
}
