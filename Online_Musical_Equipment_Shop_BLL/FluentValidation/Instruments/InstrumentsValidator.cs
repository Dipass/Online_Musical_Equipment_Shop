using FluentValidation;
using Online_Musical_Equipment_Shop_BLL.DTOs.RequestsDTOs;

namespace OnlineMusicalEquipmentShopAPI.FluentValidation.Instruments
{
    public class InstrumentsValidator : AbstractValidator<InsertInstrumentsDTO>
    {
        public InstrumentsValidator()
        {
            RuleFor(dto => dto.InstrumentTitle)
               .NotEmpty().WithMessage("Instrument title is required.")
               .MaximumLength(50).WithMessage("Instrument title cannot exceed 50 characters.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");

            RuleFor(dto => dto.CategoriesId)
                .NotEmpty().WithMessage("Categories ID is required.");

            RuleFor(dto => dto.ManufacturerId)
                .NotEmpty().WithMessage("Manufacturer ID is required.");
        }
    }
}
