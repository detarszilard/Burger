using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Burger.Services.Restaurants.Application.ResponseModels;
using Burger.Services.Restaurants.Infrastructure.Stores;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Burger.Services.Restaurants.Application.Queries
{
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, IEnumerable<ReviewModel>>
    {
        private readonly ReviewStore _reviewStore;

        public GetReviewsQueryHandler(ReviewStore reviewStore)
        {
            _reviewStore = reviewStore;
        }

        public async Task<IEnumerable<ReviewModel>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _reviewStore
                .GetQueryable(skipAuthorization: true)
                .Where(r => r.MenuItemId == request.MenuItemId)
                .Select(r => new ReviewModel
                {
                    Description = r.Description,
                    PictureUrl = r.PictureUrl,
                    Taste = r.Score.Taste,
                    Texture = r.Score.Texture,
                    VisualPresentation = r.Score.VisualPresentation
                })
                .ToListAsync(cancellationToken);
        }
    }
}
