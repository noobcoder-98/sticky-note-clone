using Microsoft.Extensions.DependencyInjection;
using StickyNoteClone.Data.Common;
using StickyNoteClone.Data.Services;
using StickyNoteClone.Domain.IRepositories;
using StickyNoteClone.Models;
using StickyNoteClone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteClone.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly List<Note> _notes = NoteGenerator.GenerateNotes(20);
        private FileStorageService _fileStorageService;
        public NoteRepository()
        {
            _fileStorageService = App.ServiceProvider.GetRequiredService<FileStorageService>();
        }
        public async Task<bool> AddNoteAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            return true;
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            var notes = await Task.Run(() =>_fileStorageService.LoadData<List<Note>>(_fileStorageService.LOCAL_FOLDER, Constants.NOTE_FILE_NAME));

            if (notes == null || notes.Count == 0)
            {
                notes = NoteGenerator.GenerateNotes(20);
            }

            return notes;
        }

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateNoteAsync(int id, Note newNote)
        {
            throw new NotImplementedException();
        }
    }
}
