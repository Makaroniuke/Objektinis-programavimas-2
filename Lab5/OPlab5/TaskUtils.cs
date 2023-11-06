using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab5
{
    /// <summary>
    /// Class for counting 
    /// </summary>
    public class TaskUtils
    {
        /// <summary>
        /// Counts each professor load
        /// </summary>
        /// <param name="students">list of students</param>
        /// <param name="professors">list of professors</param>
        /// <returns>list of professors and their load</returns>
        public static IEnumerable<Load> CountLoad(List<Student> students, List<Professor> professors)
        {
            var getModuleAndStudents = from student in students group student by student.ModuleName 
                           into studentGroup select new { Module=studentGroup.Key, Count=studentGroup.Count()};

            var countProfessorsLoad = from module in getModuleAndStudents
                                      join professor in professors on module.Module equals professor.ModuleName
                                      select new Load
                                      (professor.Name, professor.Surname, professor.ModuleName, module.Count * professor.Credits);
            return countProfessorsLoad;
        }

        /// <summary>
        /// Gets all professors surnames
        /// </summary>
        /// <param name="professors">list of professors</param>
        /// <returns>list of surnames</returns>
        public static List<string> GetAllSurnames(List<Professor> professors)
        {
            var getSurnames = professors.Select(s => s.Surname).Distinct().ToList();
            return getSurnames;
        }

        /// <summary>
        /// Gets list of students who go to specific professor modules
        /// </summary>
        /// <param name="students">list of students</param>
        /// <param name="professors">list of professors</param>
        /// <param name="surname">professors surname</param>
        /// <returns>filtered and sorted list of students</returns>
        public static IEnumerable<Student> GetStudentsByProfessor(List<Student> students, List<Professor> professors, string surname)
        {
            var getStudents = from professor in professors
                               join student in students on professor.ModuleName equals student.ModuleName
                               where professor.Surname.Equals(surname) orderby student.Group, student.Surname
                               select new Student(student.Name, student.Surname, student.Group);
            return getStudents;
        }
        
    }
}