using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
	public class GetTagByIdQueryResult:IRequest<GetTagByIdQueryResult>
	{
		public int TagId { get; set; }

		public GetTagByIdQueryResult(int tagId)
		{
			TagId = tagId;
		}
	}
}
