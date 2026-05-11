using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Implement_2._2_4_ISP
{
    //#region Bad Code
    public interface IWorker
    {
        void Work();      //Implemented in (Machine , Engineer)
        //void TakeBreak(); //Implemented in (Machine , Engineer)
        //void ClockIn();   //Implemented in (Employee , Engineer)
        //void ClockOut();  //Implemented in (Employee , Engineer)
    }

    public interface IRest
    {
        void TakeBreak();
    }

    public interface IClock
    {
        void ClockIn();
        void ClockOut();
    }


    public class Employee : IWorker, IClock, IRest
    {
        public void ClockIn() { }
        public void ClockOut() { }

        public void TakeBreak() { }
        public void Work() { }
    }

    public class Engineer : Employee
    {
        public void Work() { }
        public void TakeBreak() { }
        public void ClockIn() { }
        public void ClockOut() { }
    }

    public class Machine : IWorker, IRest
    {
        public void Work() { }
        public void TakeBreak() { }
    }
    //#endregion
}
