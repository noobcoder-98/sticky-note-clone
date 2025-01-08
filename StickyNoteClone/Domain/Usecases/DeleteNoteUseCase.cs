using StickyNoteClone.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteClone.Domain.Usecases
{
    public class DeleteNoteUseCase
    {
        private readonly INoteRepository _noteRepository;
        public DeleteNoteUseCase(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> ExecuteAsync(int id)
        {
            return await _noteRepository.DeleteNoteAsync(id);
        }
    }
}
