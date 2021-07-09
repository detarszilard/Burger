using System.Collections.Generic;
using Burger.Common.Exceptions;
using Burger.Common.SeedWork;
using Burger.Services.Restaurants.Domain.Constants;

namespace Burger.Services.Restaurants.Domain.Aggregates.ReviewAggregate
{
    public class Score : ValueObject
    {
        private int _taste;
        private int _texture;
        private int _visualPresentation;

        public int Taste => _taste;

        public int Texture => _texture;

        public int VisualPresentation => _visualPresentation;

        protected Score() { }

        public Score(int taste, int texture, int visualPresentation)
        {
            ValidateScore(taste);
            ValidateScore(texture);
            ValidateScore(visualPresentation);

            _taste = taste;
            _texture = texture;
            _visualPresentation = visualPresentation;
        }

        private void ValidateScore(int score)
        {
            if (score < 0 || score > 5)
            {
                throw new DomainException(ReviewErrorCodes.ScoreOutOfRange);
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _taste;
            yield return _texture;
            yield return _visualPresentation;
        }
    }
}
