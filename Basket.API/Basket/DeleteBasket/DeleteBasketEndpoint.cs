﻿using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.DeleteBasket
{

    public record DeleteBasketResponse(bool isSuccess);
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
            {
              
                var result = await sender.Send(new DeleteBasketCommmand(userName));

                var response = result.Adapt<DeleteBasketResponse>();

                return Results.Ok(response);
            })
 .WithName("DeleteProduct")
 .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
 .ProducesProblem(StatusCodes.Status400BadRequest)
 .ProducesProblem(StatusCodes.Status404NotFound)
 .WithSummary("Delete Product")
 .WithDescription("Delete Product");

        }
    }
}
