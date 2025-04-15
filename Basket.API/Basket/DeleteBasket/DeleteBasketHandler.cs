using Basket.API.Data;
using BuildingBlocks.CQRS;
using FluentValidation;
using System.Windows.Input;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommmand(string UserName):ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool isSuccess);

    public class DeleteBasketValidator : AbstractValidator<DeleteBasketCommmand>
    {
        public DeleteBasketValidator() {
            RuleFor(x => x.UserName).NotNull().WithMessage("Username cannot be null");
        }
    }
    public class DeleteBasketHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommmand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommmand request, CancellationToken cancellationToken)
        {
            var isSuccess = await repository.DeleteBasket(request.UserName, cancellationToken);

            return new DeleteBasketResult(isSuccess);

        }
    }
}
