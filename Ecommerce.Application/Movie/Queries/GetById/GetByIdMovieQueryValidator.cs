using FluentValidation;

namespace Ecommerce.Application.Movie.Queries.GetById
{
    public class GetByIdMovieQueryValidator : AbstractValidator<GetByIdMovieQuery>
    {
        public GetByIdMovieQueryValidator()
        {
            RuleFor(e => e.Id).NotEqual(0).WithMessage("Invalid Id");
        }
    }
}
