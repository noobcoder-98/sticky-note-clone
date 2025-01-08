using StickyNoteClone.Domain.IRepositories;
using StickyNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteClone.Domain.Usecases;

public class GetAllNotesUseCase
{
    private readonly INoteRepository _noteRepository;

    public GetAllNotesUseCase(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<List<Note>> ExecuteAsync()
    {
        return await _noteRepository.GetAllNotesAsync();
    }
}
