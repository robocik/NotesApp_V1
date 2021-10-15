using AutoMapper;
using NoteBookApp.Logic.Domain;
using NoteBookApp.Logic.Handlers.Notes;
using NoteBookApp.Shared;

namespace NoteBookApp.Server.Infrastructure
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Note, NoteDto>();
            CreateMap<GetNotesParam, GetNotesQuery>();
            CreateMap<CreateNoteParam, CreateNoteCommand>();
            CreateMap<UpdateNoteParam, UpdateNoteCommand>();
        }
    }
}