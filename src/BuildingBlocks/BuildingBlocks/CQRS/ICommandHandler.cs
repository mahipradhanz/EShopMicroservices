using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    public interface ICommandHandler<in Tcommand>
        : ICommandHandler<Tcommand, Unit>
        where Tcommand : ICommand<Unit>
    {
    }
    public interface ICommandHandler<in Tcommand, TResponse>
    : IRequestHandler<Tcommand, TResponse>
        where Tcommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}
