using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace OPlab4
{
    /// <summary>
    /// Class for reading and printing data
    /// </summary>
    public class InOut
    {
        /// <summary>
        /// Reads directory and creates list with house and flat objects
        /// </summary>
        /// <param name="directoryPath">path to directory</param>
        /// <returns>list of houses and flats</returns>
        public static List<RealEstate> ReadFromFile(string directoryPath)
        {
            List<RealEstate> AllHouses = new List<RealEstate>();
            foreach (string file in Directory.EnumerateFiles(directoryPath, "*.txt"))
            {
                string[] contents = File.ReadAllLines(file);
                NTOffice office = new NTOffice(contents[0], contents[1], int.Parse(contents[2]));
                for (int i = 3; i < contents.Length; i++)
                {
                    string[] values = contents[i].Split(',');
                    if (values[4] == "namas")
                    {

                        string city = values[0];
                        string neighborhood = values[1];
                        string street = values[2];
                        int houseNumber = int.Parse(values[3]);
                        string type = values[4];
                        int year = int.Parse(values[5]);
                        double area = int.Parse(values[6]);
                        int numberOfRooms = int.Parse(values[7]);
                        string heating = values[8];

                        House house = new House(office, city, neighborhood, street, houseNumber, type, year, area, numberOfRooms, heating);

                        AllHouses.Add(house);
                    }
                    else if (values[4] == "butas")
                    {

                        string city = values[0];
                        string neighborhood = values[1];
                        string street = values[2];
                        int houseNumber = int.Parse(values[3]);
                        string type = values[4];
                        int year = int.Parse(values[5]);
                        double area = int.Parse(values[6]);
                        int numberOfRooms = int.Parse(values[7]);
                        int floor = int.Parse(values[8]);

                        Flat house = new Flat(office, city, neighborhood, street, houseNumber, type, year, area, numberOfRooms, floor);

                        AllHouses.Add(house);

                    }
                    else
                    {
                        throw new Exception(string.Format("Klaida tekstiniame faile"));
                    }
                }
            }
            return AllHouses;

        }

        /// <summary>
        /// Prints houses and flats to file
        /// </summary>
        /// <param name="allHouses">houses/flats list</param>
        /// <param name="fileName">file name</param>
        /// <param name="header">header line</param>
        public static void PrintHousesToFile(List<RealEstate> allHouses, string fileName, string header)
        {
            string[] lines = new string[allHouses.Count() + 10];
            lines[0] = header;
            lines[1] = new string('-', 169);
            lines[2] = String.Format("| {0, -12} | {1, -13} | {2, -13} | {3, -10} | {4, -15} | {5, -44} | {6, -17} | {7, -20} | {8, -20} | {9, -20} | {10, -20} |",
                "NT agentūra", "Miestas", "Mikrorajonas", "Gatvė", "Namo nr.", "Tipas", "Pastatymo metai", "Plotas", "Kambarių sk.", "Šildymo tipas", "Aukštas");
            lines[3] = new string('-', 169);
            for (int i = 0; i < allHouses.Count(); i++)
            {
                lines[4 + i] = allHouses[i].ToString();
            }
            lines[allHouses.Count() + 4] = new string('-', 169);
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Prints streets to file
        /// </summary>
        /// <param name="allHouses">houses/flats list</param>
        /// <param name="fileName">file name</param>
        /// <param name="header">header line</param>
        public static void PrintStreetsToFile(Dictionary<string, int> allHouses, string fileName, string header)
        {
            List<string> lines = new List<string>();
            lines.Add(header);
            lines.Add(new string('-', 30));
            lines.Add(string.Format("{0, 15} | {1, 20}", "Gatvės pav.", "Parduodamų skaičius"));
            var str = allHouses.First();
            foreach(var street in allHouses)
            {
                if (street.Value == str.Value)
                    lines.Add(string.Format("{0, 15} | {1, 10}", street.Key, street.Value));
                else
                    break;
            }
            lines.Add("");
            File.AppendAllLines(fileName, lines);
        }


    }
}