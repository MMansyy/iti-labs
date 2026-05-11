using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case_Answer.Case_Answer_4_ISP
{
    #region Bad Code
    public interface IMultiFunctionDevice
    {
        void Print();
        void Scan();
        void Fax();
    }

    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScanner
    {
        void Scan(Document document);
    }

    public interface IFax
    {
        void Fax(Document document);
    }

    public class OldPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing");
        }

        //public void Scan()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Fax()
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class ModernPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Printing");
        }

        public void Scan()
        {
            Console.WriteLine("Scanning");
        }

        public void Fax()
        {
            Console.WriteLine("Fax");
        }
    }


    #endregion

}
