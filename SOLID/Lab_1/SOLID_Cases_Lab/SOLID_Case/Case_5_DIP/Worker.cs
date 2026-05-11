using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Implement_2._2_5_DIP
{
    #region Bad Code

    public interface ITaskAssigner
    {
        void AssignTask();
    }


    public class Manager : ITaskAssigner
    {
        public void AssignTask() { }
    }

    public class Worker
    {
        private ITaskAssigner _taskAssigner;

        public Worker(ITaskAssigner taskAssigner)
        {
            _taskAssigner = taskAssigner;
        }

        public void DoTask()
        {
            _manager.AssignTask();
        }
    }
    #endregion
}
