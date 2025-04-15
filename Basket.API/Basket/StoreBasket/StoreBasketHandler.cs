using Basket.API.Data;
using Basket.API.Models;
using BuildingBlocks.CQRS;
using FluentValidation;
using System.Windows.Input;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart ShoppingCart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.ShoppingCart).NotNull().WithMessage("Cart cannot be null");
            RuleFor(x => x.ShoppingCart.UserName).NotNull().WithMessage("Username cannot be null");
        }
    }
        public class StoreBasketCommandHandler(IBasketRepository repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
        {

            public  async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
            {
             ShoppingCart cart = request.ShoppingCart;
             await repository.StoreBasket(cart);

            return new StoreBasketResult(cart.UserName);
            }
        }
    
}
