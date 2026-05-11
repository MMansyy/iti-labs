using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case_Answer.Case_Answer_3_LSP
{
    //#region Bad Code
    public interface IPrintable
    {
        void Print();
    }


    public class Document
    {
        public string context { get; set; }
    }



    public class PrintableDocument : Document, IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Printing");
        }

    }


    public class ReadOnlyDoucument : Document
    {

    }

    //#endregion



}
