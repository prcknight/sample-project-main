using Core.Services.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;
        //private readonly IValidateUserService _validateUserService;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService,
            IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            HttpResponseMessage result = null;

            // Check to see if this order id exists
            if (_getOrderService.GetOrder(orderId) == null)
            {
                // Order id does not exist so create the new user
                var order = _createOrderService.Create(orderId, model.OrderNumber, model.Vendor, model.OrderItems);
                result = Found(new OrderData(order));
            }
            else
            {
                // Order id does exist, so return an error
                result = Found($"Order {orderId} exists");
            }

            return result;
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            HttpResponseMessage result = null;

            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }

            //List<string> errors = _validateUserService.Validate(model.Name, model.Email, model.Type, model.AnnualSalary, model.Tags);

            _updateOrderService.Update(order, model.OrderNumber, model.Vendor, model.OrderItems);
            result = Found(new OrderData(order));

            return result;
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }

            _deleteOrderService.Delete(order);
            return Found();
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllUsers()
        {
            _deleteOrderService.DeleteAll();
            return Found();
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            return Found(new OrderData(order));
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAllOrders()
        {
            var orders = _getOrderService.GetAllOrders();

            return Found(orders);
        }

        [Route("getorders")]
        [HttpGet]
        public HttpResponseMessage GetOrders(string ordernumber = null, string vendor = null)
        {
            var orders = _getOrderService.GetOrders(ordernumber, vendor);
            return Found(orders);
        }
    }
}
