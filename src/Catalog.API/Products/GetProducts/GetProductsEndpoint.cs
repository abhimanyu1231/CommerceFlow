﻿

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            }).WithName("GetProducts")
        .WithSummary("Get all products")
        .WithDescription("Get all the products from the database"); ;

            
        }
    }
}
