using StickyNoteClone.Domain.IRepositories;
using StickyNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteClone.Domain.Usecases;

public class AddNoteUseCase
{
    private readonly INoteRepository _noteRepository;
    public AddNoteUseCase(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public Task<bool> ExecuteAsync(Note note)
    {
        return _noteRepository.AddNoteAsync(note);
    }
}