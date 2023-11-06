using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OPlab2
{
    /// <summary>
    /// Main class
    /// </summary>
    public partial class lab2 : System.Web.UI.Page
    {
        public LinkedList<Worker> workersList;
        public LinkedList<Award> awardsList;

        /// <summary>
        /// Method which loads things when page is opened
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e event args</param>
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Add("GAMTA");
                DropDownList1.Items.Add("FIZIKA");
                DropDownList1.Items.Add("CHEMIJA");
                DropDownList1.Items.Add("IT");
            }
        }

        /// <summary>
        /// Main method to start all calculations
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e event args</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            

            if (File.Exists(Server.MapPath("Rezultatai.txt")))
            {
                File.Delete(Server.MapPath("Rezultatai.txt"));
            }

            if (FileUpload1.HasFile &&
                FileUpload1.FileName.EndsWith(".txt"))
            {
                workersList = InOutUtils.ReadFromFile(FileUpload1.FileContent);
            }

            if (FileUpload2.HasFile &&
                FileUpload2.FileName.EndsWith(".txt"))
            {
                awardsList = InOutUtils.ReadAwards(FileUpload2.FileContent);
            }

            InOutUtils.PrintToFile(Server.MapPath("Rezultatai.txt"), workersList, "Darbuotojų informacija", "Asmens kodas | Pavardė | Vardas | Bankas | Sąskaitos nr. | c Atskiros sumos | Gauta bendra suma |");
            InOutUtils.PrintToFile(Server.MapPath("Rezultatai.txt"), awardsList, "Premijų informacija", "Asmens kodas | Indėlis į darbą (gamta, fizika, chemija, IT) |");

            InOutUtils.AddInputToWorker(workersList, awardsList);
            TaskUtils.CountExactAmountOfMoney(awardsList, workersList);
            TaskUtils.CountSumOfWonAward(workersList);

            InOutUtils.PrintToFile(Server.MapPath("Rezultatai.txt"), workersList, "Darbuotojų informacija", "Asmens kodas | Pavardė | Vardas | Bankas | Sąskaitos nr. | Indėlis į darbą (gamta, fizika, chemija, IT) | Atskiros sumos | Gauta bendra suma |");

            double average = TaskUtils.CountAverage(awardsList);
            TextBox1.Text = average.ToString();

            LinkedList<Worker> lessThanAverage = TaskUtils.FilterByAverage(workersList, average);
            lessThanAverage.SortBubble();
            InOutUtils.PrintToFile(Server.MapPath("Rezultatai.txt"), lessThanAverage, "Darbuotojai gavę mažiau nei vidurkis", "Asmens kodas | Pavardė | Vardas | Bankas | Sąskaitos nr. | Indėlis į darbą (gamta, fizika, chemija, IT) | Atskiros sumos | Gauta bendra suma |");
            
            FormTable(Table1, lessThanAverage);

            string text = DropDownList1.Text;
            LinkedList<Worker> searchedByTheme = TaskUtils.FindByTheme(workersList, text);
            searchedByTheme.SortBubble();
            InOutUtils.PrintToFile(Server.MapPath("Rezultatai.txt"), searchedByTheme, "Filtruoti pagal temą", "Asmens kodas | Pavardė | Vardas | Bankas | Sąskaitos nr. | Indėlis į darbą (gamta, fizika, chemija, IT) | Atskiros sumos | Gauta bendra suma |");

            FormTable(Table2, searchedByTheme);


        }

        /// <summary>
        /// Method to form table with data
        /// </summary>
        /// <param name="table">Table where info will be stored</param>
        /// <param name="workersList">Linked list with workers</param>
        public static void FormTable(Table table, LinkedList<Worker> workersList)
        {
            TableRow row1 = new TableRow();
            TableCell surname1 = new TableCell();
            surname1.Text = "<b>Pavardė</b>";
            row1.Cells.Add(surname1);
            TableCell name1 = new TableCell();
            name1.Text = "<b>Vardas</b>";
            row1.Cells.Add(name1);
            TableCell input1 = new TableCell();
            input1.Text = "<b>Indėlis į darbą (gamta, fizika, chemija, IT)</b>";
            row1.Cells.Add(input1);
            TableCell moneyForWork1 = new TableCell();
            moneyForWork1.Text = "<b>Pinigai už darbą (gamta, fizika, chemija, IT)</b>";
            row1.Cells.Add(moneyForWork1);
            TableCell money1 = new TableCell();
            money1.Text = "<b>Galutinė suma</b>";
            row1.Cells.Add(money1);

            table.Rows.Add(row1);
            foreach(Worker worker in workersList)
            {
                TableRow row = new TableRow();
                TableCell surname = new TableCell();
                surname.Text = worker.Surname;
                TableCell name = new TableCell();
                name.Text = worker.Name;
                TableCell input = new TableCell();
                input.Text = worker.ReturnInputToWork();
                TableCell moneyForWork = new TableCell();
                moneyForWork.Text = worker.ReturnMoneyToWork();
                TableCell money = new TableCell();
                money.Text = worker.SumOfMoney.ToString();


                row.Cells.Add(surname);
                row.Cells.Add(name);
                row.Cells.Add(input);
                row.Cells.Add(moneyForWork);
                row.Cells.Add(money);

                table.Rows.Add(row);
            }
        }
    }
}