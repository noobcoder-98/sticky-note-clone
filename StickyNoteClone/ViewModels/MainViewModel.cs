using CommunityToolkit.Mvvm.ComponentModel;
using StickyNoteClone.Domain.Usecases;
using StickyNoteClone.Models;
using StickyNoteClone.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace StickyNoteClone
{
    internal partial class MainViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<Note> _notes = [];

        private readonly AddNoteUseCase _addNoteUseCase;
        private readonly GetAllNotesUseCase _getAllNotesUseCase;
        private readonly DeleteNoteUseCase _deleteNoteUseCase;

        public MainViewModel(AddNoteUseCase addNoteUseCase, GetAllNotesUseCase getAllNotesUseCase, DeleteNoteUseCase deleteNoteUseCase)
        {
            _addNoteUseCase = addNoteUseCase;
            _getAllNotesUseCase = getAllNotesUseCase;
            _deleteNoteUseCase = deleteNoteUseCase;

            GetData();
        }

        private async void GetData()
        {
            Notes = new ObservableCollection<Note>(await _getAllNotesUseCase.ExecuteAsync());
        }
    }
}
