using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using NHibernate.Type;
using NoteBookApp.Logic.Domain;
using NoteBookApp.Shared;

namespace NoteBookApp.Logic.Handlers.Notes
{
    public class CreateNoteHandler : HandlerBase<CreateNoteCommand>
    {

        public CreateNoteHandler(ISession session, SecurityInfo securityInfo, IMapper mapper, IDateTimeProvider dateTimeProvider) : base(session, securityInfo, mapper, dateTimeProvider)
        {
        }

        protected override async Task Execute(ISession session, CreateNoteCommand param)
        {
            var dbNote = new Note();
            dbNote.CreatedDateTime = _dateTimeProvider.UtcNow;
            dbNote.Content = param.Content;
            dbNote.User = _securityInfo.User;
            await session.SaveAsync(dbNote).ConfigureAwait(false);
        }
    }
}