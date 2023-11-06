using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab5
{
    /// <summary>
    /// Extra class for creating load object
    /// </summary>
    public class Load
    {
        public string ProfessorName { get; set; }
        public string ProfessorSurname { get; set; }
        public string ProfessorModule { get; set; }
        public int LoadNumber { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">professor name</param>
        /// <param name="surname">professor surname</param>
        /// <param name="module">module name</param>
        /// <param name="load">counted load</param>
        public Load(string name, string surname, string module, int load)
        {
            this.ProfessorName = name;
            this.ProfessorSurname = surname;
            this.ProfessorModule = module;
            this.LoadNumber = load;
        }

        /// <summary>
        /// Forms line 
        /// </summary>
        /// <returns>formatted line</returns>
        public override string ToString()
        {
            return String.Format("| {0, -25} | {1, -13} | {2, -13} | {3, -20} |",
                this.ProfessorModule, this.ProfessorSurname, this.ProfessorName, this.LoadNumber);
        }
    }
}