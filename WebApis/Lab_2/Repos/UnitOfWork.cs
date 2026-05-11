using Lab_2.Models;

namespace Lab_2.Repos
{
    public class UnitOfWork
    {
        protected readonly ITIContext _context;
        protected EntityRepo<Student> _studentRepo;
        protected EntityRepo<Department> _departmentRepo;


        public UnitOfWork(ITIContext context)
        {
            _context = context;
        }

        public EntityRepo<Student> StudentRepo
        {
            get
            {
                if (_studentRepo == null)
                    _studentRepo = new EntityRepo<Student>(_context);
                return _studentRepo;
            }
        }

        public EntityRepo<Department> DepartmentRepo
        {
            get
            {
                if (_departmentRepo == null)
                    _departmentRepo = new EntityRepo<Department>(_context);
                return _departmentRepo;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
