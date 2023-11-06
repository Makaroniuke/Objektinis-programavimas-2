using System;
using System.Collections;
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
    public class InOutUtils
    {
        /// <summary>
        /// Reads workers from file
        /// </summary>
        /// <param name="fin">file</param>
        /// <returns>linked list with workers</returns>
        public static LinkedList<Worker> ReadFromFile(Stream fin)
        {
            LinkedList<Worker> workerList = new LinkedList<Worker>();
            string line = null;
            using (StreamReader reader = new StreamReader(fin))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    int idCode = int.Parse(parts[0]);
                    string surname = parts[1];
                    string name = parts[2];
                    string bankName = parts[3];
                    string bankNumer = parts[4];
                    Worker worker = new Worker(idCode, surname, name, bankName, bankNumer);
                    workerList.Add(worker);
                }
            }

            return workerList;
        }

        /// <summary>
        /// Prints list
        /// </summary>
        /// <param name="fileName">file name to print</param>
        /// <param name="list">linked list</param>
        /// <param name="header">text, file description</param>
        /// <param name="line">extra line</param>
        public static void PrintToFile(string fileName, IEnumerable list, string header, string line) 
        {
            using(var file = new StreamWriter(fileName, true))
            {
                file.WriteLine(header);
                file.WriteLine(new string('-', 169));
                file.WriteLine(line);
                file.WriteLine(new string('-', 169));
                foreach(var item in list)
                {
                    file.WriteLine(item.ToString());
                }
                file.WriteLine(new string('-', 169));
                file.WriteLine(" ");
            }
        }
       
        /// <summary>
        /// Reads awards from file
        /// </summary>
        /// <param name="fin">file</param>
        /// <returns>linked list with awards</returns>
        public static LinkedList<Award> ReadAwards(Stream fin)
        {
            LinkedList<Award> awardsList = new LinkedList<Award>();
            List<double> amountOfMoney = new List<double>();
            string line = null;
            using (StreamReader reader = new StreamReader(fin))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        for (int i = 0; i < parts.Length; i++)
                        {
                            amountOfMoney.Add(int.Parse(parts[i]));
                        }
                    }
                    else
                    {
                        int idCode = int.Parse(parts[0]);

                        List<int> amountOfInput = new List<int>();
                        amountOfInput.Add(int.Parse(parts[1]));
                        amountOfInput.Add(int.Parse(parts[2]));
                        amountOfInput.Add(int.Parse(parts[3]));
                        amountOfInput.Add(int.Parse(parts[4]));

                        Award award = new Award(amountOfMoney, idCode, amountOfInput);
                        awardsList.Add(award);
                    }
                    
                }
            }
            return awardsList;
        }

        /// <summary>
        /// Add input to workers
        /// </summary>
        /// <param name="workersList">list with workers</param>
        /// <param name="awardsList">list with awrads</param>
        public static void AddInputToWorker(LinkedList<Worker> workersList, LinkedList<Award> awardsList)
        {
            foreach (Award award in awardsList)
            {
                foreach (Worker worker in workersList)
                {
                    if (award.WorkersID == worker.IdCode)
                    {
                        worker.inputToWork = award.InputToWork;
                    }
                }
            }
        }


    }
}