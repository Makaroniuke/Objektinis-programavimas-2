using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace OPlab2
{
    /// <summary>
    /// Class to read/print to file
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// Reads info about workers from file
        /// </summary>
        /// <param name="filename">File name</param>
        /// <returns>Linked list with workers</returns>
        public static LinkedList ReadFromFile(string filename)
        {
            LinkedList workerList = new LinkedList();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                int idCode = int.Parse(parts[0]);
                string surname = parts[1];
                string name = parts[2];
                string bankName = parts[3];
                string bankNumer = parts[4];
                Worker worker = new Worker(idCode, surname, name, bankName, bankNumer);
                workerList.Add(worker);
            }

            return workerList;
        }

        /// <summary>
        /// Print workers info to file
        /// </summary>
        /// <param name="workersList">Linked list with workers</param>
        /// <param name="fileName">File name</param>
        /// <param name="header">Table's header</param>
        public static void PrintWorkersToFile(LinkedList workersList, string fileName, string header)
        {
            string[] lines = new string[workersList.Count() + 10];
            lines[0] = header;
            lines[1] = new string('-', 169);
            lines[2] = String.Format("| {0, -12} | {1, -13} | {2, -13} | {3, -10} | {4, -15} | {5, -44} | {6, -17} | {7, -20} |", 
                "Asmens kodas", "Pavardė", "Vardas", "Bankas", "Sąskaitos nr.", "Indėlis į darbą (gamta, fizika, chemija, IT)", "Atskiros sumos", "Gauta bendra suma");
            lines[3] = new string('-', 169);
            for (int i = 0; i < workersList.Count(); i++)
            {
                lines[4 + i] = workersList.Get(i).ToString();
            }
            lines[workersList.Count() + 4] = new string('-', 169);
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Reads awards info from file
        /// </summary>
        /// <param name="filename">File name</param>
        /// <returns>Linked list with awards</returns>
        public static LinkedListAwards ReadAwards(string filename)
        {
            LinkedListAwards awardsList = new LinkedListAwards();
            List<double> amountOfMoney = new List<double>();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            string[] firstLine = lines[0].Split(',');
            for (int i = 0; i < firstLine.Length; i++)
            {
                amountOfMoney.Add(int.Parse(firstLine[i]));
            }
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                int idCode = int.Parse(parts[0]);
                
                List<int> amountOfInput = new List<int>();
                amountOfInput.Add(int.Parse(parts[1]));
                amountOfInput.Add(int.Parse(parts[2]));
                amountOfInput.Add(int.Parse(parts[3]));
                amountOfInput.Add(int.Parse(parts[4]));

                Award award = new Award(amountOfMoney, idCode, amountOfInput);
                awardsList.Add(award);
            }

            return awardsList;
        }

        /// <summary>
        /// Print awards info to file
        /// </summary>
        /// <param name="awardsList">Linked list with awards</param>
        /// <param name="fileName">File name</param>
        /// <param name="header">Table's header</param>
        public static void PrintAwardsToFile(LinkedListAwards awardsList, string fileName, string header)
        {
            string[] lines = new string[awardsList.Count() + 10];
            lines[0] = header;
            lines[1] = new string('-', 63);
            lines[2] = "Premijų sumos(gamta, fizika, chemija, IT):";
            lines[3] = new string('-', 63);
            lines[4] = awardsList.Get(0).ReturnAmountOfMoney();
            lines[5] = new string('-', 63);
            lines[6] = String.Format("| {0, -12} | {1, -44} | ",
                "Asmens kodas", "Indėlis į darbą (gamta, fizika, chemija, IT)");
            lines[7] = new string('-', 63);
            for (int i = 0; i < awardsList.Count(); i++)
            {
                lines[7 + i] = awardsList.Get(i).ToString();
            }
            lines[awardsList.Count() + 7] = new string('-', 63);
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Add for worker information about their input to work
        /// </summary>
        /// <param name="workersList">Linked list with workers</param>
        /// <param name="awardsList">Linked list with awards</param>
        public static void AddInputToWorker(LinkedList workersList, LinkedListAwards awardsList)
        {
            for (int i = 0; i < awardsList.Count(); i++)
            {
                for (int j = 0; j < workersList.Count(); j++)
                {
                    Award award = awardsList.Get(i);
                    Worker worker = workersList.Get(i);
                    if (award.WorkersID == worker.IdCode)
                    {
                        worker.inputToWork = award.InputToWork;
                    }
                }
            }
        }


    }
}