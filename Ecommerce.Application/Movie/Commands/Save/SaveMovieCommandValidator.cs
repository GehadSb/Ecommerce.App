using FluentValidation;

namespace Ecommerce.Application.Movie.Commands.Save
{
    public class SaveMovieCommandValidator : AbstractValidator<SaveMovieCommand>
    {
        public SaveMovieCommandValidator()
        {
            RuleFor(e => e.MovieName).NotEmpty().WithMessage("Movie Name is invalid");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Description is invalid");
            RuleFor(e => e.StartDate).NotEmpty().WithMessage("StartDate is invalid");
            RuleFor(e => e.EndDate).NotEmpty().WithMessage("EndDate is invalid");
            RuleFor(e => e.Price).NotEmpty().WithMessage("price is invalid");
            RuleFor(e => e.MovieStatusId).NotEmpty().WithMessage("Movie status is invalid");
            RuleFor(e => e.MovieCategoryId).NotEmpty().WithMessage("Movie category is invalid");
            RuleFor(e => e.CinemaId).NotEmpty().WithMessage("cinema is invalid");
        }
    }
}
