using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OPlab5
{
    /// <summary>
    /// Main class
    /// </summary>
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// Page load
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<Professor> professors = InOut.ReadProfessorsFromFile(Server.MapPath("destytojai"));
                List<string> surnames = TaskUtils.GetAllSurnames(professors);
                if (DropDownList1.Items.Count == 0)
                {
                    for (int i = 0; i < surnames.Count; i++)
                    {
                        DropDownList1.Items.Add(surnames[i]);
                    }
                }
            }catch(Exception ex)
            {
                File.AppendAllText(Server.MapPath("Rezultatai.txt"), string.Format("{0} Exception caught.", ex));
            }
        }

        /// <summary>
        /// first button click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Server.MapPath("rezultatai.txt")))
                    File.Delete(Server.MapPath("rezultatai.txt"));

                List<Student> students = InOut.ReadStudentsFromFile(Server.MapPath("studentai"));
                List<Professor> professors = InOut.ReadProfessorsFromFile(Server.MapPath("destytojai"));
                InOut.FormTable(Table1, students);
                InOut.FormTable2(Table2, professors);

                InOut.PrintStudentsToFile(students, Server.MapPath("rezultatai.txt"), "Studentų sąrašas");
                InOut.PrintProfessorsToFile(professors, Server.MapPath("rezultatai.txt"), "Dėstytojų sąrašas");
            }
            catch (Exception ex)
            {
                File.AppendAllText(Server.MapPath("Rezultatai.txt"), string.Format("{0} Exception caught.", ex));
            }

        }

        /// <summary>
        /// Second button click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                List<Student> students = InOut.ReadStudentsFromFile(Server.MapPath("studentai"));
                List<Professor> professors = InOut.ReadProfessorsFromFile(Server.MapPath("destytojai"));
                var professorsLoad = TaskUtils.CountLoad(students, professors);
                InOut.FormTable(Table1, students);
                InOut.FormTable2(Table2, professors);
                InOut.FormProfessorsTable(Table3, professorsLoad);
                InOut.PrintProfessorsToFile(professorsLoad, Server.MapPath("rezultatai.txt"), "Dėstytojų krūviai");
            }
            catch (Exception ex)
            {
                File.AppendAllText(Server.MapPath("Rezultatai.txt"), string.Format("{0} Exception caught.", ex));
            }
        }

        /// <summary>
        /// Third button click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                List<Student> students = InOut.ReadStudentsFromFile(Server.MapPath("studentai"));
                List<Professor> professors = InOut.ReadProfessorsFromFile(Server.MapPath("destytojai"));
                var getStudents = TaskUtils.GetStudentsByProfessor(students, professors, DropDownList1.Text);
                InOut.FormTable(Table1, students);
                InOut.FormTable2(Table2, professors);
                InOut.FormStudentsTable(Table3, getStudents);
                InOut.PrintFilteredStudentsToFile(getStudents, Server.MapPath("rezultatai.txt"), String.Format("Dėstytoja/-as {0} ir studentų sąrašas:", DropDownList1.Text));
            }
            catch (Exception ex)
            {
                File.AppendAllText(Server.MapPath("Rezultatai.txt"), string.Format("{0} Exception caught.", ex));
            }
        }
    }
}