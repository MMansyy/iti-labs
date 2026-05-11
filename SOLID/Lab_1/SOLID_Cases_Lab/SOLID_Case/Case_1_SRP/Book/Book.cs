using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case_Answer.Case_Answer_1_SRP
{
    #region Bad Code
    //public class Book
    //{
    //    public string Title { get; set; }
    //    public string Author { get; set; }

    //    public void Print()
    //    {
    //        Console.WriteLine($"Title: {Title}, Author: {Author}");
    //    }

    //    public void Save()
    //    {
    //        // Code to save book to database
    //    }
    //}



    #endregion

    #region Good Code

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }

    #endregion



}
