using FluentValidation;

namespace Ecommerce.Application.Movie.Commands.Edit
{
    public class EditMovieCommandValidator : AbstractValidator<EditMovieCommand>
    {
        public EditMovieCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty().WithMessage("Id is empty");
            RuleFor(e => e.MovieName).NotEmpty().WithMessage("Movie Name is empty");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Description is empty");
            RuleFor(e => e.StartDate).NotEmpty().WithMessage("StartDate is empty");
            RuleFor(e => e.EndDate).NotEmpty().WithMessage("EndDate is empty");
            RuleFor(e => e.Price).NotEmpty().WithMessage("price is empty");
            RuleFor(e => e.MovieStatusId).NotEmpty().WithMessage("Movie status is empty");
            RuleFor(e => e.MovieCategoryId).NotEmpty().WithMessage("Movie category is empty");
            RuleFor(e => e.CinemaId).NotEmpty().WithMessage("cinema is empty");
        }
    }
}
