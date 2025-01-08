using StickyNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteClone.Domain.IRepositories;

public interface INoteRepository
{
    Task<List<Note>> GetAllNotesAsync();
    Task<Note> GetNoteByIdAsync(int id);
    Task<bool> AddNoteAsync(Note note);
    Task<bool> UpdateNoteAsync(int id, Note newNote);
    Task<bool> DeleteNoteAsync(int id);
}
