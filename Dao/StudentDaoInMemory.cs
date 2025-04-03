using WebMVCDao.Models;

namespace WebMVCDao.Dao
{
    public class StudentDaoInMemory : IStudentDao
    {
        private IList<Student> All { get; set; } = new List<Student>()
        {
                new Student ( 1, "Vasya", 18 , "asddadad, adasdad,  asdasdad"),
                new Student ( 2, "Alex", 20, "asddadad, adasdad,  asdasdad" ),
                new Student ( 3, "Coper", 30, "asddadad, adasdad,  asdasdad"),
                new Student (4, "Serega", 45, "asddadad, adasdad,  asdasdad"),
                new Student (   5, "Endik", 19 , "asddadad, adasdad,  asdasdad")
        };
        public Student Add(Student student)
        {
            student.Id = All.Select(x => x.Id).Max() + 1;
            All.Add(student);
            return student;
        }

        public void Delete(int id)
        {
            All.Remove(GetStudentById(id));
        }

        public Student GetStudentById(int id)
        {
            return All.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return All;
        }

        public Student Update(Student student)
        {
            var studentModel = GetStudentById(student.Id);
            if (studentModel != null)
            {
                studentModel.Name = student.Name;
                studentModel.Adress = student.Adress;
                studentModel.Age = student.Age;
            }
            else throw new Exception("Error from Update");
            return studentModel;
        }
    }
}
