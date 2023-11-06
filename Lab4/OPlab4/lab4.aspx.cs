using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OPlab4
{   /// <summary>
/// Main
/// </summary>
    public partial class lab4 : System.Web.UI.Page
    {
        /// <summary>
        /// page load
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// Prints data
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Button1_Click(object sender, EventArgs e) 
        {
            try
            {
                if (File.Exists(Server.MapPath("Rezultatai.txt")))
                {
                    File.Delete(Server.MapPath("Rezultatai.txt"));
                }
                List<RealEstate> allHouses = InOut.ReadFromFile(Server.MapPath("duomenys"));
                InOut.PrintHousesToFile(allHouses, Server.MapPath("Rezultatai.txt"), "Visi namai/butai");

                FormTable(Table1, allHouses);
            }catch(Exception ex)
            {
                File.AppendAllText(Server.MapPath("Rezultatai.txt"),string.Format("{0} Exception caught.", ex));
            }
        }

        /// <summary>
        /// Prints streets
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<RealEstate> allHouses = InOut.ReadFromFile(Server.MapPath("duomenys"));

                Dictionary<string, int> streets = TaskUtils.FindMostHousesInOneStreet(allHouses);
                InOut.PrintStreetsToFile(streets, Server.MapPath("Rezultatai.txt"), "Daugiausia vienoje gatvėje");
                FormTable1(Table1, streets);
            }
            catch (Exception ex)
            {
                File.AppendAllText(Server.MapPath("Rezultatai.txt"), string.Format("{0} Exception caught.", ex));
            }
        }

        /// <summary>
        /// Prints oldests objects
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"e></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            List<RealEstate> allHouses = InOut.ReadFromFile(Server.MapPath("duomenys"));

            RealEstate oldest = TaskUtils.FindOldest(allHouses);
            List<RealEstate> allOldests = TaskUtils.FindAllOldestHouses(allHouses, oldest);
            InOut.PrintHousesToFile(allOldests, Server.MapPath("Rezultatai.txt"), "Seniausi namai/butai");
            //File.AppendAllText(Server.MapPath("Rezultatai.txt"), oldest.ToString());

            FormTable(Table1, allOldests);
        }

        /// <summary>
        /// Forms table
        /// </summary>
        /// <param name="table">table</param>
        /// <param name="allHouses">list of objects</param>
        public static void FormTable(Table table, List<RealEstate> allHouses)
        {
            TableRow row1 = new TableRow();
            TableCell city = new TableCell();
            city.Text = "<b>Miestas</b>";
            row1.Cells.Add(city);
            TableCell neighborhood = new TableCell();
            neighborhood.Text = "<b>Mikrorajonas</b>";
            row1.Cells.Add(neighborhood);
            TableCell street = new TableCell();
            street.Text = "<b>Gatvė</b>";
            row1.Cells.Add(street);
            TableCell houseNumber = new TableCell();
            houseNumber.Text = "<b>Namo nr.</b>";
            row1.Cells.Add(houseNumber);
            TableCell type = new TableCell();
            type.Text = "<b>Tipas</b>";
            row1.Cells.Add(type);
            TableCell year = new TableCell();
            year.Text = "<b>Pastatymo metai</b>";
            row1.Cells.Add(year);
            TableCell area = new TableCell();
            area.Text = "<b>Plotas</b>";
            row1.Cells.Add(area);
            TableCell numberOfRooms = new TableCell();
            numberOfRooms.Text = "<b>Kambarių sk.</b>";
            row1.Cells.Add(numberOfRooms);


            table.Rows.Add(row1);
            for (int i = 0; i < allHouses.Count(); i++)
            {
                TableRow row = new TableRow();
                TableCell city1 = new TableCell();
                city1.Text = allHouses[i].City;
                TableCell neighborhood1 = new TableCell();
                neighborhood1.Text = allHouses[i].Neighborhood;
                TableCell street1 = new TableCell();
                street1.Text = allHouses[i].Street;
                TableCell houseNumber1 = new TableCell();
                houseNumber1.Text = allHouses[i].HouseNumber.ToString();
                TableCell type1 = new TableCell();
                type1.Text = allHouses[i].Type;
                TableCell year1 = new TableCell();
                year1.Text = allHouses[i].Year.ToString();
                TableCell area1 = new TableCell();
                area1.Text = allHouses[i].Area.ToString();
                TableCell numberOfRooms1 = new TableCell();
                numberOfRooms1.Text = allHouses[i].NumberOfRooms.ToString();

                row.Cells.Add(city1);
                row.Cells.Add(neighborhood1);
                row.Cells.Add(street1);
                row.Cells.Add(houseNumber1);
                row.Cells.Add(type1);
                row.Cells.Add(year1);
                row.Cells.Add(area1);
                row.Cells.Add(numberOfRooms1);

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Forms streets table
        /// </summary>
        /// <param name="table">table</param>
        /// <param name="allHouses">list of streets</param>
        public static void FormTable1(Table table, Dictionary<string, int> allHouses)
        {
            TableRow row1 = new TableRow();
            TableCell name = new TableCell();
            name.Text = "<b>Gatvė</b>";
            row1.Cells.Add(name);
            TableCell count = new TableCell();
            count.Text = "<b>Kiekis</b>";
            row1.Cells.Add(count);
            table.Rows.Add(row1);
             foreach(var street in allHouses)
            {
                TableRow row = new TableRow();
                TableCell name1 = new TableCell();
                name1.Text = street.Key;
                row.Cells.Add(name1);
                TableCell count1 = new TableCell();
                count1.Text = street.Value.ToString();
                row.Cells.Add(count1);
                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Prints duplicates
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            List<RealEstate> allHouses = InOut.ReadFromFile(Server.MapPath("duomenys"));
            List<RealEstate> duplicates = TaskUtils.FindDuplicates(allHouses);
            if (File.Exists(Server.MapPath("Kartojasi.csv")))
            {
                File.Delete(Server.MapPath("Kartojasi.csv"));
            }
            InOut.PrintHousesToFile(duplicates, Server.MapPath("Kartojasi.csv"), "Kartojasi");
            FormTable(Table1, duplicates);
        }

        /// <summary>
        /// Prints big houses
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            List<RealEstate> allHouses = InOut.ReadFromFile(Server.MapPath("duomenys"));
            List<RealEstate> bigHouses = TaskUtils.FindBigHouses(allHouses);
            if (File.Exists(Server.MapPath("Dideli.csv")))
            {
                File.Delete(Server.MapPath("Dideli.csv"));
            }
            InOut.PrintHousesToFile(bigHouses, Server.MapPath("Dideli.csv"), "Dideli namai ir butai");
            FormTable(Table1, bigHouses);
        }
    }
}