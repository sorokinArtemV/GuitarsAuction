using AuctionService.DTO;
using FluentValidation;

namespace AuctionService.Validators;

public class CreateAuctionValidator : AbstractValidator<CreateAuctionDto>
{
    public CreateAuctionValidator()
    {
        // Make cannot be empty and must be between 2 and 50 characters
        RuleFor(dto => dto.Make)
            .NotEmpty().WithMessage("Make is required.")
            .Length(2, 50).WithMessage("Make must be between 2 and 50 characters.");

        // Model cannot be empty and must be between 2 and 50 characters
        RuleFor(dto => dto.Model)
            .NotEmpty().WithMessage("Model is required.")
            .Length(2, 50).WithMessage("Model must be between 2 and 50 characters.");

        // Year must be a valid year
        RuleFor(dto => dto.Year)
            .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Year must be between 1900 and the current year.");

        // Type cannot be empty and must be between 2 and 50 characters
        RuleFor(dto => dto.Type)
            .NotEmpty().WithMessage("Type is required.")
            .Length(2, 50).WithMessage("Type must be between 2 and 50 characters.");

        // Color validation is optional, but if provided, it must be between 3 and 30 characters
        RuleFor(dto => dto.Color)
            .Length(3, 30).When(dto => !string.IsNullOrEmpty(dto.Color))
            .WithMessage("Color must be between 3 and 30 characters.");

        // CelebrityOwned must be a boolean value
        RuleFor(dto => dto.CelebrityOwned)
            .NotNull().WithMessage("CelebrityOwned must be provided as a boolean value.");

        // SignatureDetails is required if HasCelebritySignature is true
        RuleFor(dto => dto.SignatureDetails)
            .NotEmpty().When(dto => dto.HasCelebritySignature)
            .WithMessage("SignatureDetails is required when the item has a celebrity signature.");

        // Condition cannot be empty and must be between 4 and 100 characters
        RuleFor(dto => dto.Condition)
            .NotEmpty().WithMessage("Condition is required.")
            .Length(4, 100).WithMessage("Condition must be between 4 and 100 characters.");

        // Description cannot be empty and must be between 10 and 1000 characters
        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.")
            .Length(10, 1000).WithMessage("Description must be between 10 and 1000 characters.");

        // ImageUrl must be a valid URL format
        RuleFor(dto => dto.ImageUrl)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out var _))
            .When(dto => !string.IsNullOrEmpty(dto.ImageUrl))
            .WithMessage("ImageUrl must be a valid URL.");

        // ReservePrice must be greater than 0
        RuleFor(dto => dto.ReservePrice)
            .GreaterThan(0).WithMessage("ReservePrice must be greater than 0.");

        // AuctionEnd must be a future date
        RuleFor(dto => dto.AuctionEnd)
            .GreaterThan(DateTime.Now).WithMessage("AuctionEnd must be a future date.");
    }
}



