using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab2
{
    public static class TaskUtils
    {
        /// <summary>
        /// Method to count how much each worker got money for every topic
        /// </summary>
        /// <param name="awardsList">Linked list with awards</param>
        /// <param name="workersList">Linked list with workers</param>
        public static void CountExactAmountOfMoney(LinkedList<Award> awardsList, LinkedList<Worker> workersList)
        {
            List<double> amountOfMoney = awardsList.Get(0).AmountOfMoney;
            for (int i = 0; i < amountOfMoney.Count(); i++)
            {
                List<double> money = new List<double>();
                foreach (Worker worker in workersList)
                {
                    double countedMoney = 0;
                    List<int> inputOfWork = worker.inputToWork;
                    if (CountPercentages(workersList, i))
                    {
                        double first = amountOfMoney[i];
                        double second = inputOfWork[i] * 0.01;
                        countedMoney = first * second;
                    }
                    worker.MoneyForWork.Add(countedMoney);
                }
            }
        }


        

        /// <summary>
        /// Method to count overall rewards sum 
        /// </summary>
        /// <param name="workersList">Linked list with worker</param>
        public static void CountSumOfWonAward(LinkedList<Worker> workersList)
        {
            foreach(Worker worker in workersList)
            {
                double sum = 0;
                List<double> awards = worker.MoneyForWork;
                for (int j = 0; j < awards.Count; j++)
                {
                    sum += awards[j];
                }
                worker.SumOfMoney = sum;
            }
        }

        /// <summary>
        /// Counts average amount of won money
        /// </summary>
        /// <param name="awardsList">List of awards</param>
        /// <returns>Returs average</returns>
        public static double CountAverage(LinkedList<Award> awardsList)
        {
            double average = 0;
            double sum = 0;
            List<double> awards = awardsList.Get(0).AmountOfMoney;
            for (int i = 0; i < awards.Count; i++)
            {
                sum += awards[i];
            }
            average = sum / awards.Count;
            return average;
        }

        /// <summary>
        /// Method which finds workers who got less than average
        /// </summary>
        /// <param name="workersList">Linked list with workers</param>
        /// <param name="average">Average amount of money</param>
        /// <returns>Linked list with filtered workers</returns>
        public static LinkedList<Worker> FilterByAverage(LinkedList<Worker> workersList, double average)
        {
            LinkedList<Worker> lessThanAverage = new LinkedList<Worker>();
            foreach(Worker worker in workersList)
            {
                double money = worker.SumOfMoney;
                if (money < average)
                {
                    lessThanAverage.Add(worker);
                }
            }
            return lessThanAverage;
        }

        /// <summary>
        /// Method which finds workers who worked on specific topic
        /// </summary>
        /// <param name="workersList">Linked list with workers</param>
        /// <param name="text">Name of theme</param>
        /// <returns>Linked list with workers who worked on specific topic</returns>
        public static LinkedList<Worker> FindByTheme(LinkedList<Worker> workersList, string text)
        {
            Dictionary<string, int> themes = new Dictionary<string, int>();
            themes.Add("GAMTA", 0);
            themes.Add("FIZIKA", 1);
            themes.Add("CHEMIJA", 2);
            themes.Add("IT", 3);

            LinkedList<Worker> searchedByTheme = new LinkedList<Worker>();
            foreach (Worker worker in workersList)
            {
                List<int> inputToWork = worker.inputToWork;
                if (inputToWork[themes[text]] > 0)
                {
                    searchedByTheme.Add(worker);
                }
            }
            return searchedByTheme;
        }

        /// <summary>
        /// Method to check if info about amount of input was given correctly
        /// </summary>
        /// <param name="workersList">Linked list with workers</param>
        /// <param name="index">Index of theme</param>
        /// <returns>True if 100%, otherwise false</returns>
        public static bool CountPercentages(LinkedList<Worker> workersList, int index)
        {
            int percentage = 0;
            foreach(Worker worker in workersList)
            {
                List<int> inputToWork = worker.inputToWork;
                if (inputToWork[index] > 0)
                {
                    percentage += inputToWork[index];
                }
            }
            if (percentage == 100)
            {
                return true;
            }
            return false;
        }

    }
}