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
        public static void CountExactAmountOfMoney(LinkedListAwards awardsList, LinkedList workersList)
        {
            List<double> amountOfMoney = awardsList.Get(0).AmountOfMoney;
            for (int i = 0; i < amountOfMoney.Count(); i++)
            {
                List<double> money = new List<double>();
                for (int j = 0; j < workersList.Count(); j++)
                {
                    double countedMoney = 0;
                    List<int> inputOfWork = workersList.Get(j).inputToWork;
                    if (CountPercentages(workersList, i)) {
                        double first = amountOfMoney[i];
                        double second = inputOfWork[i] * 0.01;
                        countedMoney = first * second;                      
                    }
                    workersList.Get(j).MoneyForWork.Add(countedMoney);
                }
            }
        }

        /// <summary>
        /// Method to count overall rewards sum 
        /// </summary>
        /// <param name="workersList">Linked list with worker</param>
        public static void CountSumOfWonAward(LinkedList workersList)
        {
            for (int i = 0; i < workersList.Count(); i++)
            {
                double sum = 0;
                List<double> awards = workersList.Get(i).MoneyForWork;
                for (int j = 0; j < awards.Count; j++)
                {
                    sum += awards[j];
                }
                workersList.Get(i).SumOfMoney = sum;
            }
        }

        /// <summary>
        /// Counts average amount of won money
        /// </summary>
        /// <param name="awardsList"></param>
        /// <returns></returns>
        public static double CountAverage(LinkedListAwards awardsList)
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
        public static LinkedList FilterByAverage(LinkedList workersList, double average)
        {
            LinkedList lessThanAverage = new LinkedList();
            for (int i = 0; i < workersList.Count(); i++)
            {
                double money = workersList.Get(i).SumOfMoney;
                if (money < average)
                {
                    lessThanAverage.Add(workersList.Get(i));
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
        public static LinkedList FindByTheme (LinkedList workersList, string text)
        {           
            Dictionary<string, int> themes = new Dictionary<string, int>();
            themes.Add("GAMTA", 0);
            themes.Add("FIZIKA", 1);
            themes.Add("CHEMIJA", 2);
            themes.Add("IT", 3);

            LinkedList searchedByTheme = new LinkedList();
            for (int i = 0; i < workersList.Count(); i++)
            {
                List<int> inputToWork = workersList.Get(i).inputToWork;
                if (inputToWork[themes[text]] > 0)
                {
                    searchedByTheme.Add(workersList.Get(i));
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
        public static bool CountPercentages(LinkedList workersList, int index)
        {
            int percentage = 0;
            for (int i = 0; i < workersList.Count(); i++)
            {
                List<int> inputToWork = workersList.Get(i).inputToWork;
                if (inputToWork[index] > 0)
                {
                    percentage += inputToWork[index];
                }
            }
            if(percentage == 100)
            {
                return true;
            }
            return false;
        }

    }
}