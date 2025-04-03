using WebMVCDao.Models;

namespace WebMVCDao.Dao
{
    public interface IStudentDao
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudentById(int id);
        public Student Add(Student student);
        public Student Update(Student student);
        public void Delete(int id);

    }
}
