using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab5
{
    /// <summary>
    /// Professor object 
    /// </summary>
    public class Professor
    {
        public string ModuleName { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public int Load { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="moduleName">module name</param>
        /// <param name="surname">surname</param>
        /// <param name="name">name</param>
        /// <param name="credits">credits of module</param>
        public Professor(string moduleName, string surname, string name, int credits)
        {
            this.ModuleName = moduleName;
            this.Surname = surname;
            this.Name = name;
            this.Credits = credits;
        }

        /// <summary>
        /// Forms line 
        /// </summary>
        /// <returns>formatted line</returns>
        public override string ToString()
        {
            return String.Format("| {0, -25} | {1, -13} | {2, -13} | {3, -20} |",
                this.ModuleName, this.Surname, this.Name, this.Credits);
        }
    }
}