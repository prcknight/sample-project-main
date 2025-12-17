using Core.Services.Products;
using Core.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.Models;
using WebApi.Models.Products;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductService _getProductService;
        private readonly IUpdateProductService _updateProductService;
        //private readonly IValidateUserService _validateUserService;

        public ProductController(ICreateProductService createProductService, IDeleteProductService deleteProductService, IGetProductService getProductService, IUpdateProductService updateProductService)
        {
            _createProductService = createProductService;
            _deleteProductService = deleteProductService;
            _getProductService = getProductService;
            _updateProductService = updateProductService;
        }

        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {
            HttpResponseMessage result = null;

            // Check to see if this product id exists
            if (_getProductService.GetProduct(productId) == null)
            {
                // Product id does not exist so create the new user
                var product = _createProductService.Create(productId, model.Name, model.Description, model.Categories, model.UnitPrice, model.Quantity, model.OrderUnit, model.CountUnit);
                result = Found(new ProductData(product));
            }
            else
            {
                // Product id does exist, so return an error
                result = Found($"Product {productId} exists");
            }

            return result;
        }

        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {
            HttpResponseMessage result = null;

            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }

            //List<string> errors = _validateUserService.Validate(model.Name, model.Email, model.Type, model.AnnualSalary, model.Tags);

            _updateProductService.Update(product, model.Name, model.Description, model.Categories, model.UnitPrice,
                model.Quantity, model.OrderUnit, model.CountUnit);
            result = Found(new ProductData(product));

            return result;
        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _deleteProductService.Delete(product);
            return Found();
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllUsers()
        {
            _deleteProductService.DeleteAll();
            return Found();
        }

        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);
            return Found(new ProductData(product));
        }

        [Route("getproducts")]
        [HttpGet]
        public HttpResponseMessage GetProducts(string name = null, string category = null, string countunit = null)
        {
            var products = _getProductService.GetProducts(name, category, countunit);
            return Found(products);
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAllProducts()
        {
            var products = _getProductService.GetAllProducts();

            return Found(products);
        }
    }
}
