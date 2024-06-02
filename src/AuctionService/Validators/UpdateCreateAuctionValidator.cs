using AuctionService.DTO;
using FluentValidation;

namespace AuctionService.Validators;

public class UpdateAuctionValidator : AbstractValidator<UpdateAuctionDto>
{
    public UpdateAuctionValidator()
    {
        // Make is optional, but if provided, must be between 2 and 50 characters
        RuleFor(dto => dto.Make)
            .Length(2, 50).When(dto => !string.IsNullOrEmpty(dto.Make))
            .WithMessage("Make must be between 2 and 50 characters when provided.");

        // Model is optional, but if provided, must be between 2 and 50 characters
        RuleFor(dto => dto.Model)
            .Length(2, 50).When(dto => !string.IsNullOrEmpty(dto.Model))
            .WithMessage("Model must be between 2 and 50 characters when provided.");

        // Year must be a valid year if provided
        RuleFor(dto => dto.Year)
            .InclusiveBetween(1900, DateTime.Now.Year).When(dto => dto.Year > 0)
            .WithMessage("Year must be between 1900 and the current year when provided.");

        // Type is optional, but if provided, must be between 2 and 50 characters
        RuleFor(dto => dto.Type)
            .Length(2, 50).When(dto => !string.IsNullOrEmpty(dto.Type))
            .WithMessage("Type must be between 2 and 50 characters when provided.");

        // Color is optional, but if provided, must be between 3 and 30 characters
        RuleFor(dto => dto.Color)
            .Length(3, 30).When(dto => !string.IsNullOrEmpty(dto.Color))
            .WithMessage("Color must be between 3 and 30 characters when provided.");

        // CelebrityOwned is optional, but if provided, must be 'Yes' or 'No'
        RuleFor(dto => dto.CelebrityOwned)
            .Must(value => value == "Yes" || value == "No" || string.IsNullOrEmpty(value))
            .WithMessage("CelebrityOwned must be 'Yes' or 'No' when provided.");

        // HasCelebritySignature is a boolean and does not need a custom validation message

        // SignatureDetails is optional, but if HasCelebritySignature is true, it must be provided
        RuleFor(dto => dto.SignatureDetails)
            .NotEmpty().When(dto => dto.HasCelebritySignature)
            .WithMessage("SignatureDetails is required when HasCelebritySignature is true.");

        // Condition is optional, but if provided, must be between 5 and 100 characters
        RuleFor(dto => dto.Condition)
            .Length(5, 100).When(dto => !string.IsNullOrEmpty(dto.Condition))
            .WithMessage("Condition must be between 5 and 100 characters when provided.");

        // Description is optional, but if provided, must be between 10 and 1000 characters
        RuleFor(dto => dto.Description)
            .Length(10, 1000).When(dto => !string.IsNullOrEmpty(dto.Description))
            .WithMessage("Description must be between 10 and 1000 characters when provided.");
    }
}
