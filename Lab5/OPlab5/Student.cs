using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab5
{
    /// <summary>
    /// Student object
    /// </summary>
    public class Student
    {
        public string Faculty { get; set; }
        public string ModuleName { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="faculty">faculty name</param>
        /// <param name="moduleName">module name</param>
        /// <param name="surname">surname</param>
        /// <param name="name">name</param>
        /// <param name="group">group</param>
        public Student(string faculty, string moduleName, string surname, string name, string group)
        {
            this.Faculty = faculty;
            this.ModuleName = moduleName;
            this.Surname = surname;
            this.Name = name;
            this.Group = group;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="surname">surname</param>
        /// <param name="name">name</param>
        /// /// <param name="group">group</param>
        public Student(string surname, string name, string group)
        {
            this.Surname = surname;
            this.Name = name;
            this.Group = group;
        }

        /// <summary>
        /// Forms line 
        /// </summary>
        /// <returns>formatted line</returns>
        public override string ToString()
        {
            return String.Format("| {0, -30} | {1, -25} | {2, -13} | {3, -10} | {4, -15} | ",
                this.Faculty, this.ModuleName, this.Surname, this.Name, this.Group);
        }
    }
}