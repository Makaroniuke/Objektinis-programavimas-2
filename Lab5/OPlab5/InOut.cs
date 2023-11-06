using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace OPlab5
{
    /// <summary>
    /// Class for reading printing to file
    /// </summary>
    public class InOut
    {
        /// <summary>
        /// Reads students from directory
        /// </summary>
        /// <param name="directoryPath">directory path</param>
        /// <returns>list of students</returns>
        public static List<Student> ReadStudentsFromFile(string directoryPath)
        {
            List<Student> allModules = new List<Student>();

            foreach (string file in Directory.EnumerateFiles(directoryPath, "*.txt"))
            {
                string[] contents = File.ReadAllLines(file);
                string faculty = contents[0];
                for (int i = 1; i < contents.Length; i++)
                {
                    string[] values = contents[i].Split(',');

                    string moduleName = values[0];
                    string surname = values[1];
                    string name = values[2];
                    string group = values[3];

                    Student module = new Student(faculty, moduleName, surname, name, group);
                    allModules.Add(module);
                }
            }
            return allModules;
        }

        /// <summary>
        /// Reads professors from directory
        /// </summary>
        /// <param name="directoryPath">diretory path</param>
        /// <returns>list of professors</returns>
        public static List<Professor> ReadProfessorsFromFile(string directoryPath)
        {
            List<Professor> professors = new List<Professor>();
            foreach (string file in Directory.EnumerateFiles(directoryPath, "*.txt"))
            {
                string[] contents = File.ReadAllLines(file);
                for (int i = 0; i < contents.Length; i++)
                {
                    string[] values = contents[i].Split(',');

                    string moduleName = values[0];
                    string surname = values[1];
                    string name = values[2];
                    int credits = int.Parse(values[3]);

                    Professor professor = new Professor(moduleName, surname, name, credits);
                    professors.Add(professor);
                }
            }
            return professors;
        }

        /// <summary>
        /// Forms table with students info
        /// </summary>
        /// <param name="table">seleted table</param>
        /// <param name="students">list of students</param>
        public static void FormTable(Table table, List<Student> students)
        {
            TableRow row1 = new TableRow();
            TableCell faculty = new TableCell();
            faculty.Text = "<b>Fakultetas</b>";
            row1.Cells.Add(faculty);
            TableCell moduleName = new TableCell();
            moduleName.Text = "<b>Modulio pav.</b>";
            row1.Cells.Add(moduleName);
            TableCell surname = new TableCell();
            surname.Text = "<b>Pavardė</b>";
            row1.Cells.Add(surname);
            TableCell name = new TableCell();
            name.Text = "<b>Vardas</b>";
            row1.Cells.Add(name);
            TableCell group = new TableCell();
            group.Text = "<b>Grupė</b>";
            row1.Cells.Add(group);

            table.Rows.Add(row1);
            for (int i = 0; i < students.Count(); i++)
            {
                TableRow row = new TableRow();
                TableCell faculty1 = new TableCell();
                faculty1.Text = students[i].Faculty;
                TableCell moduleName1 = new TableCell();
                moduleName1.Text = students[i].ModuleName;
                TableCell surname1 = new TableCell();
                surname1.Text = students[i].Surname;
                TableCell name1 = new TableCell();
                name1.Text = students[i].Name;
                TableCell group1 = new TableCell();
                group1.Text = students[i].Group;

                row.Cells.Add(faculty1);
                row.Cells.Add(moduleName1);
                row.Cells.Add(surname1);
                row.Cells.Add(name1);
                row.Cells.Add(group1);

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Forms table with professors info
        /// </summary>
        /// <param name="table">selected table</param>
        /// <param name="professors">list of professors</param>
        public static void FormTable2(Table table, List<Professor> professors)
        {
            TableRow row1 = new TableRow();
            TableCell moduleName = new TableCell();
            moduleName.Text = "<b>Modulio pav.</b>";
            row1.Cells.Add(moduleName);
            TableCell surname = new TableCell();
            surname.Text = "<b>Pavardė</b>";
            row1.Cells.Add(surname);
            TableCell name = new TableCell();
            name.Text = "<b>Vardas</b>";
            row1.Cells.Add(name);
            TableCell credits = new TableCell();
            credits.Text = "<b>Kreditai</b>";
            row1.Cells.Add(credits);

            table.Rows.Add(row1);
            for (int i = 0; i < professors.Count(); i++)
            {
                TableRow row = new TableRow();
                TableCell moduleName1 = new TableCell();
                moduleName1.Text = professors[i].ModuleName;
                TableCell surname1 = new TableCell();
                surname1.Text = professors[i].Surname;
                TableCell name1 = new TableCell();
                name1.Text = professors[i].Name;
                TableCell credits1 = new TableCell();
                credits1.Text = professors[i].Credits.ToString();

                row.Cells.Add(moduleName1);
                row.Cells.Add(surname1);
                row.Cells.Add(name1);
                row.Cells.Add(credits1);

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Forms table with professors loads info
        /// </summary>
        /// <param name="table">selected table</param>
        /// <param name="professors">list of professors</param>
        public static void FormProfessorsTable(Table table, IEnumerable<Load> professors)
        {
            TableRow row1 = new TableRow();
            TableCell moduleName = new TableCell();
            moduleName.Text = "<b>Modulio pav.</b>";
            row1.Cells.Add(moduleName);
            TableCell surname = new TableCell();
            surname.Text = "<b>Pavardė</b>";
            row1.Cells.Add(surname);
            TableCell name = new TableCell();
            name.Text = "<b>Vardas</b>";
            row1.Cells.Add(name);
            TableCell credits = new TableCell();
            credits.Text = "<b>Krūvis</b>";
            row1.Cells.Add(credits);

            table.Rows.Add(row1);
            foreach(var professor in professors)
            {
                TableRow row = new TableRow();
                TableCell moduleName1 = new TableCell();
                moduleName1.Text = professor.ProfessorModule;
                TableCell surname1 = new TableCell();
                surname1.Text = professor.ProfessorSurname;
                TableCell name1 = new TableCell();
                name1.Text = professor.ProfessorName;
                TableCell load = new TableCell();
                load.Text = professor.LoadNumber.ToString();

                row.Cells.Add(moduleName1);
                row.Cells.Add(surname1);
                row.Cells.Add(name1);
                row.Cells.Add(load);

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Forms table with filtered students info
        /// </summary>
        /// <param name="table">selected table</param>
        /// <param name="students">list of students</param>
        public static void FormStudentsTable(Table table, IEnumerable<Student> students)
        {
            TableRow row1 = new TableRow();
            TableCell moduleName = new TableCell();
            moduleName.Text = "<b>Vardas</b>";
            row1.Cells.Add(moduleName);
            TableCell surname = new TableCell();
            surname.Text = "<b>Pavardė</b>";
            row1.Cells.Add(surname);
            TableCell group = new TableCell();
            group.Text = "<b>Pavardė</b>";
            row1.Cells.Add(group);
            table.Rows.Add(row1);
            foreach (var student in students)
            {
                TableRow row = new TableRow();
                TableCell moduleName1 = new TableCell();
                moduleName1.Text = student.Name;
                TableCell surname1 = new TableCell();
                surname1.Text = student.Surname;
                TableCell group1 = new TableCell();
                group1.Text = student.Group;
                row.Cells.Add(moduleName1);
                row.Cells.Add(surname1);
                row.Cells.Add(group1);

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Prints to file students
        /// </summary>
        /// <param name="students">list of students</param>
        /// <param name="fileName">file name</param>
        /// <param name="header">header line</param>
        public static void PrintStudentsToFile(List<Student> students, string fileName, string header)
        {
            string[] lines = new string[students.Count() + 10];
            lines[0] = header;
            lines[1] = new string('-', 110);
            lines[2] = String.Format("| {0, -30} | {1, -25} | {2, -13} | {3, -10} | {4, -15} | ",
                "Fakultetas", "Modulis", "Pavardė", "Vardas", "Grupė");
            lines[3] = new string('-', 110);
            for (int i = 0; i < students.Count(); i++)
            {
                lines[4 + i] = students[i].ToString();
            }
            lines[students.Count() + 4] = new string('-', 110);
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Prints professors to file
        /// </summary>
        /// <param name="list">list of professors</param>
        /// <param name="fileName">file name</param>
        /// <param name="header">header line</param>
        public static void PrintProfessorsToFile(IEnumerable list, string fileName, string header)
        {
            using (var file = new StreamWriter(fileName, true))
            {
                file.WriteLine(header);
                file.WriteLine(new string('-', 84));
                file.WriteLine(String.Format("| {0, -25} | {1, -13} | {2, -13} | {3, -20} |",
                "Modulis", "Pavardė", "Vardas", "Kreditai/Krūvis"));
                file.WriteLine(new string('-', 84));
                foreach (var item in list)
                {
                    file.WriteLine(item.ToString());
                }
                file.WriteLine(new string('-', 84));
                file.WriteLine(" ");
            }
        }

        /// <summary>
        /// Prints filtered students
        /// </summary>
        /// <param name="list">list of students</param>
        /// <param name="fileName">file name</param>
        /// <param name="header">header text</param>
        public static void PrintFilteredStudentsToFile(IEnumerable list, string fileName, string header)
        {
            using (var file = new StreamWriter(fileName, true))
            {
                file.WriteLine(header);
                file.WriteLine(new string('-', 50));
                file.WriteLine(String.Format("| {0, -12} | {1, -13} |",
                "Vardas", "Pavardė"));
                file.WriteLine(new string('-', 50));
                foreach (var item in list)
                {
                    file.WriteLine(item.ToString());
                }
                file.WriteLine(new string('-', 50));
                file.WriteLine(" ");
            }
        }


    }
}