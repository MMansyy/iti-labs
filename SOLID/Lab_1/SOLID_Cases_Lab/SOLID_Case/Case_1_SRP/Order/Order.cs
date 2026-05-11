using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case_Answer.Case_Answer_1_SRP
{
    #region Bad Code
    //class Order
    //{
    //    public void CalculateTotalPrice() { }
    //    public void PrintInvoice() { }
    //}


    #endregion


    #region Good Code

    class Order
    {
        public decimal Total { get; set; }
    }

    class OrderCalculator
    {
        public void CalculateTotalPrice(Order order)
        {
            // Calculate total price logic
        }
    }

    class InvoicePrinter
    {
        public void PrintInvoice(Order order)
        {
            // Print invoice logic
        }
    }

    #endregion
}
