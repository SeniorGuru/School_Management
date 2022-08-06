using CRUDOperationsDemo.Models;

namespace School.Models
{
    public class EnrollmentViewModel
    {
        public IEnumerable<User> users { get; set; }

        public IEnumerable<Subject> subjects { get; set; }

        public IEnumerable<Enrollment> enrolls { get; set; }
    }
}
