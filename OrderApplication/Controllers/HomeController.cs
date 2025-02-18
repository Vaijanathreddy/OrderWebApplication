using OrderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //this method will send data to ui and calculate total amount
        public JsonResult GetOrderData(decimal Amount, string CustomerType)
        {
            // Your business logic to calculate the discount and final total
            var discount = CalculateDiscount(Amount, CustomerType);
            var finalTotal = Amount - discount;

            var result = new
            {
                CustomerType = CustomerType,
                Amount = Amount,
                Discount = discount,
                FinalTotal = finalTotal
            };

            return Json(result);
        }

        // this method check customer is new or loyal based on that discount will be added
        public decimal CalculateDiscount(decimal Amount, string CustomerType)
        {
            OrderProcess order = new OrderProcess();
            order.Amount = Amount;
            order.CustomerType = CustomerType;
            if (Amount != 0 || CustomerType != null)
            {
                if (Amount >= 100 && CustomerType == "Loyal")
                {
                    order.Discount = order.Amount * 0.10m;
                }
                else
                {
                    order.Discount = 0;
                }

                order.FinalTotal = order.Amount - order.Discount;

                return order.Discount;
            }
            return 0;
        }

    }
}