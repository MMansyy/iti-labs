using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case_Answer.Case_Answer_2_OCP
{
    #region Bad Code
    //class PaymentProcessor
    //{
    //    public void ProcessPayment(string paymentType)
    //    {
    //        if (paymentType == "CreditCard")
    //        {
    //            // Process credit card payment
    //        }
    //        else if (paymentType == "PayPal")
    //        {
    //            // Process PayPal payment
    //        }
    //    }
    //}

    #endregion

    #region Good Code


    // مش عارف كلاس ولا انترفيس اصح
    public abstract Payment
    {
        void ProcessPayment();
    }

    class CreditCardPayment : Payment
    {
        public override void ProcessPayment()
        {
            // Credit card payment logic
        }
    }

    class PayPalPayment : Payment
    {
        public override void ProcessPayment()
        {
            // PayPal payment logic
        }
    }

    class PaymentProcessor
    {
        public void Process(Payment payment)
        {
            payment.ProcessPayment();
        }
    }

    #endregion
}
