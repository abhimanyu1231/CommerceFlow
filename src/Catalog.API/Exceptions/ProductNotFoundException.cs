namespace Catalog.API.Exceptions
{
    public class ProductNotFoundException:Exception
    {
        public ProductNotFoundException():base("Product has not been found"){
            }
    }
}
