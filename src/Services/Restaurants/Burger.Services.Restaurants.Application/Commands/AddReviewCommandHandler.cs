using System.Threading;
using System.Threading.Tasks;
using Burger.Common.Authorization;
using Burger.Common.EntityFrameworkCore.Stores;
using Burger.Services.Restaurants.Domain.Aggregates.ReviewAggregate;
using MediatR;

namespace Burger.Services.Restaurants.Application.Commands
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand>
    {
        private readonly IEntityStore<Review> _reviewStore;
        private readonly IUserService _userService;

        public AddReviewCommandHandler(IEntityStore<Review> reviewStore, IUserService userService)
        {
            _reviewStore = reviewStore;
            _userService = userService;
        }

        public async Task<Unit> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            _reviewStore.Add(new Review(
                _userService.User.Id,
                request.MenuItemId,
                new Score(request.Taste, request.Texture, request.VisualPresentation),
                request.Description,
                request.PictureUrl));

            await _reviewStore.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
