using Service.Model;
using Service.Persisten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{

    public interface IStudentService
    {
        Task<bool> AddAsync(Student student);
        Task<Student> GetAsync(int id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<bool> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int id);
    }
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var listStudent = new List<Student>();

            try
            {
                listStudent = await _context.students.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return listStudent;
        }

        public async Task<Student> GetAsync(int id)
        {
            var result = new Student();

            try
            {
                result = await _context.students.SingleAsync(x => x.StudentId == id);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }



        public async Task<bool> AddAsync(Student student)
        {
            try
            {
                _context.Add(student);

                var newStudent = await _context.SaveChangesAsync();

                return newStudent == 1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateAsync(Student student)
        {

            try
            {
                var originModel = _context.students
                    .Where(u => u.StudentId == student.StudentId)
                    .SingleOrDefault();

                if (originModel == null)
                {
                    return false;
                }

                originModel.Name = student.Name;
                originModel.LastName = student.LastName;
                originModel.Bio = student.Bio;

                _context.Update(originModel);

                var saveSure = await _context.SaveChangesAsync();

                return saveSure == 1;
            }
            catch (Exception)
            {

                return false;
            }
           
        }


        public async Task<bool> DeleteAsync(int id)
        {

            try
            {
                var originModel = await _context.students.FindAsync(id);

                _context.Remove(originModel);

                var saved = await _context.SaveChangesAsync();

                return saved == 1;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
