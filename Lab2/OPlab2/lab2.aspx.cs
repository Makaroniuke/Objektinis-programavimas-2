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
            LinkedList workersList = InOutUtils.ReadFromFile(Server.MapPath("U6a.txt"));
            InOutUtils.PrintWorkersToFile(workersList, Server.MapPath("Rezultatai.txt"), "Darbuotojų informacija");
            LinkedListAwards awardsList = InOutUtils.ReadAwards(Server.MapPath("U6b.txt"));
            InOutUtils.PrintAwardsToFile(awardsList, Server.MapPath("Rezultatai.txt"), "Premijų informacija");

            InOutUtils.AddInputToWorker(workersList, awardsList);
            TaskUtils.CountExactAmountOfMoney(awardsList, workersList);
            TaskUtils.CountSumOfWonAward(workersList);

            //InOutUtils.PrintWorkersToFile(workersList, Server.MapPath("Rezultatai.txt"), "Darbuotojų informacija");

            double average = TaskUtils.CountAverage(awardsList);
            TextBox1.Text = average.ToString();

            LinkedList lessThanAverage = TaskUtils.FilterByAverage(workersList, average);
            lessThanAverage.sortBubble();
            InOutUtils.PrintWorkersToFile(lessThanAverage, Server.MapPath("Rezultatai.txt"), "Darbuotojai gavę mažiau nei vidurkis");
            
            FormTable(Table1, lessThanAverage);

            string text = DropDownList1.Text;
            LinkedList searchedByTheme = TaskUtils.FindByTheme(workersList, text);
            searchedByTheme.sortBubble();
            InOutUtils.PrintWorkersToFile(searchedByTheme, Server.MapPath("Rezultatai.txt"), "Filtruoti pagal temą");

            FormTable(Table2, searchedByTheme);


        }

        /// <summary>
        /// Method to form table with data
        /// </summary>
        /// <param name="table">Table where info will be stored</param>
        /// <param name="workersList">Linked list with workers</param>
        public static void FormTable(Table table, LinkedList workersList)
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
            for (int i = 0; i < workersList.Count(); i++)
            {
                TableRow row = new TableRow();
                TableCell surname = new TableCell();
                surname.Text = workersList.Get(i).Surname;
                TableCell name = new TableCell();
                name.Text = workersList.Get(i).Name;
                TableCell input = new TableCell();
                input.Text = workersList.Get(i).ReturnInputToWork();
                TableCell moneyForWork = new TableCell();
                moneyForWork.Text = workersList.Get(i).ReturnMoneyToWork();
                TableCell money = new TableCell();
                money.Text = workersList.Get(i).SumOfMoney.ToString();


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