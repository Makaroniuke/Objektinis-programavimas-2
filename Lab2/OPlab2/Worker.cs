using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab2
{
    /// <summary>
    /// Workers object
    /// </summary>
    public class Worker
    {
        public int IdCode { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }

        public List<int> inputToWork { get; set; }
        public List<double> MoneyForWork { get; set; }
        public double SumOfMoney { get; set; }

        /// <summary>
        /// Worker constructor
        /// </summary>
        /// <param name="idcode">Worker's id code</param>
        /// <param name="surname">Worker's surname</param>
        /// <param name="name">Worker's name</param>
        /// <param name="bankName">Worker's bank name</param>
        /// <param name="accountNumber">Worker's account number</param>
        public Worker(int idcode, string surname, string name, string bankName, string accountNumber)
        {
            this.IdCode = idcode;
            this.Surname = surname;
            this.Name = name;
            this.BankName = bankName;
            this.AccountNumber = accountNumber;
            this.inputToWork = new List<int>();
            this.MoneyForWork = new List<double>();
            this.SumOfMoney = 0;
        }

        /// <summary>
        /// Overrides ToString method
        /// </summary>
        /// <returns>Formated line</returns>
        public override string ToString()
        {
            return string.Format("| {0, -12} | {1, -13} | {2, -13} | {3, -10} | {4, -15} | {5, -44} | {6, -17} | {7, -20} |", 
                this.IdCode, this.Surname, this.Name, this.BankName, this.AccountNumber, ReturnInputToWork(), ReturnMoneyToWork(), this.SumOfMoney);
        }
        
        /// <summary>
        /// Formates line with input to work data
        /// </summary>
        /// <returns>Formated line</returns>
        public string ReturnInputToWork()
        {
            string line = "";
            for (int i = 0; i < inputToWork.Count; i++)
            {
                line += inputToWork[i] + " ";
            }
            return line;
        }

        /// <summary>
        /// Formates line with money to work
        /// </summary>
        /// <returns>Formated line</returns>
        public string ReturnMoneyToWork()
        {
            string line = "";
            for (int i = 0; i < MoneyForWork.Count; i++)
            {
                line += MoneyForWork[i] + " ";
            }
            return line;
        }

        /// <summary>
        /// Operator to compare
        /// </summary>
        /// <param name="firstWorker">First worker to compare</param>
        /// <param name="secondWorker">Second worker to compare</param>
        /// <returns>True if first worker is higher, otherwise false</returns>
        public static bool operator >(Worker firstWorker, Worker secondWorker)
        {
            if (firstWorker.Surname.CompareTo(secondWorker.Surname) == 0)
            {
                if (firstWorker.Name.CompareTo(secondWorker.Name) == 0)
                {
                    return firstWorker.SumOfMoney < secondWorker.SumOfMoney;
                }
                else
                {
                    return firstWorker.Name.CompareTo(secondWorker.Name) > 0;
                }
            }
            else
            {
                return firstWorker.Surname.CompareTo(secondWorker.Surname) > 0;
            }
        }


        /// <summary>
        /// Operator to compare
        /// </summary>
        /// <param name="firstWorker">First worker to compare</param>
        /// <param name="secondWorker">Second worker to compare</param>
        /// <returns>True if second worker is higher, otherwise false</returns>
        public static bool operator <(Worker firstWorker, Worker secondWorker)
        {
            if (firstWorker.Surname.CompareTo(secondWorker.Surname) == 0)
            {
                if (firstWorker.Name.CompareTo(secondWorker.Name) == 0)
                {
                    return firstWorker.SumOfMoney < secondWorker.SumOfMoney;
                }
                else
                {
                    return firstWorker.Name.CompareTo(secondWorker.Name) < 0;
                }
            }
            else
            {
                return firstWorker.Surname.CompareTo(secondWorker.Surname) < 0;
            }
        }

    }
}