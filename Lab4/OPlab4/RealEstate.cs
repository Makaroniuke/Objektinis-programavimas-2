using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab4
{

    /// <summary>
    /// Abstract Real Estate class
    /// </summary>
    public abstract class RealEstate : IComparable<RealEstate>, IEquatable<RealEstate>
    {
        public NTOffice Office { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public double Area { get; set; }
        public int NumberOfRooms { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="office">office name</param>
        /// <param name="city">city</param>
        /// <param name="neigh">neighborhood</param>
        /// <param name="street">street</param>
        /// <param name="number">house number</param>
        /// <param name="type">type</param>
        /// <param name="year">built year</param>
        /// <param name="area">area</param>
        /// <param name="roomsNumber">number of rooms</param>
        public RealEstate(NTOffice office, string city, string neigh, string street, int number, string type, int year, double area, int roomsNumber)
        {
            this.Office = office;
            this.City = city;
            this.Neighborhood = neigh;
            this.Street = street;
            this.HouseNumber = number;
            this.Type = type;
            this.Year = year;
            this.Area = area;
            this.NumberOfRooms = roomsNumber;
        }

        /// <summary>
        /// Get office name
        /// </summary>
        /// <returns>office name</returns>
        public string ReturnOfficeName()
        {
            return Office.Name;
        }

        /// <summary>
        /// Methos ToString
        /// </summary>
        /// <returns>formated line</returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                this.Office, this.City, this.Neighborhood, this.Street, this.HouseNumber, this.Type, this.Year, this.Area, this.NumberOfRooms);
        }

        /// <summary>
        /// To compare two objects
        /// </summary>
        /// <param name="other">second object</param>
        /// <returns>0 if equal, otherwise 1 or -1</returns>
        public virtual int CompareTo(RealEstate other)
        {
            if (this.Street.CompareTo(other.Street) == 0)
                return this.HouseNumber.CompareTo(other.HouseNumber);
            return this.Street.CompareTo(other.Street);
        }

        /// <summary>
        /// Abstract equals method
        /// </summary>
        /// <param name="other">second object</param>
        /// <returns>true if equal or false</returns>
        public abstract bool Equals(RealEstate other);

        
    }
}