using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab2
{
    /// <summary>
    /// Workers object
    /// </summary>
    public class Worker : IComparable<Worker>, IEquatable<Worker>
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
        /// Checks if two objects are equal
        /// </summary>
        /// <param name="other">worker object</param>
        /// <returns>true if equal, otherwise false</returns>
        public bool Equals(Worker other)
        {
            if (other == null)
                return false;
            if (this.IdCode == other.IdCode &&
                this.Surname == other.Surname &&
                this.Name == other.Name &&
                this.BankName == other.BankName &&
                this.AccountNumber == other.AccountNumber)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Compares two objects
        /// </summary>
        /// <param name="other">worker object</param>
        /// <returns>1 if first object is higher, -1 if lower, 0 if equal</returns>
        public int CompareTo(Worker other)
        {
            if(other == null) return 1;
            if (this.Surname.CompareTo(other.Surname) == 0)
                if (this.Name.CompareTo(other.Name) == 0)
                    return this.SumOfMoney.CompareTo(other.SumOfMoney);
                else
                    return this.Name.CompareTo(other.Name);
            else
                return this.Surname.CompareTo(other.Surname);
        }

    }
}