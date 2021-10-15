using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NHibernate;
using NoteBookApp.Logic.Domain;
using NoteBookApp.Shared;

namespace NoteBookApp.Logic.Handlers
{
    public abstract class HandlerBase<T> : IRequestHandler<T> where T : IRequest
    {
        private readonly ISession _session;
        protected readonly SecurityInfo _securityInfo;
        protected readonly IDateTimeProvider _dateTimeProvider;
        protected readonly IMapper _mapper;
        protected HandlerBase(ISession session, SecurityInfo securityInfo, IMapper mapper, IDateTimeProvider dateTimeProvider)
        {
            _session = session;
            _securityInfo = securityInfo;
            _mapper = mapper;
            _dateTimeProvider = dateTimeProvider;
        }
        

        protected abstract Task Execute(ISession session, T param);

        protected virtual Task AfterHandle(ISession session)
        {
            return Task.CompletedTask;
        }

        public async Task<Unit> Handle(T request, CancellationToken cancellationToken = default)
        {
            using (var trans = _session.BeginTransaction())
            {
                await Execute(_session, request).ConfigureAwait(false);
                await trans.CommitAsync(cancellationToken).ConfigureAwait(false);
            }

            await AfterHandle(_session).ConfigureAwait(false);
            return Unit.Value;
        }
    }
}