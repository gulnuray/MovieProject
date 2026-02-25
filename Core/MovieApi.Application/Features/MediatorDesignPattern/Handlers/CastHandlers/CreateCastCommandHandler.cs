using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApiPersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
	public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
	{
		private readonly MovieContext _context;

		public CreateCastCommandHandler(MovieContext context)
		{
			_context = context;
		}

		public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
		{
			_context.Casts.Add(new Domain.Entities.Cast
			{
				Biography = request.Biography,
				ImageUrl = request.ImageUrl,
				Name = request.Name,
				Overwiew = request.Overwiew,
				Surname = request.Surname,
				Title = request.Title
			});
			await _context.SaveChangesAsync();
		}
	}
}
