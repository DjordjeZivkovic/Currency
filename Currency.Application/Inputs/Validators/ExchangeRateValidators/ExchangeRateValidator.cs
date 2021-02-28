using Currency.Application.Inputs.Queries.ExchangeQueries;
using FluentValidation;

namespace Currency.Application.Inputs.Validators.ExchangeRateValidators
{
    public class ExchangeRateValidator : AbstractValidator<ExchangeQuery>
    {
        public ExchangeRateValidator()
        {
            RuleFor(x => x.ExchangeInput.BaseCurrency)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.ExchangeInput.TargetCurrency)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.ExchangeInput.Dates)
                .NotNull()
                .NotEmpty()
                .Must(x => x.Count > 0)
                .WithMessage("Please send at least 1 date");
        }
    }
}
