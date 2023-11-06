using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab4
{
    /// <summary>
    /// House class
    /// </summary>
    public class House : RealEstate, IComparable<RealEstate>, IEquatable<RealEstate>
    {
        public string HeatingType { get; set; }

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
        /// <param name="heatingType">heating type</param>
        public House(NTOffice office,string city, string neigh, string street, int number, string type, int year, double area, int roomsNumber, string heatingType) : base(office,city, neigh, street, number, type, year, area, roomsNumber)
        {
            this.HeatingType = heatingType;
        }

        /// <summary>
        /// Forms line
        /// </summary>
        /// <returns>formated line</returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                this.Office, this.City, this.Neighborhood, this.Street, this.HouseNumber, this.Type, this.Year, this.Area, this.NumberOfRooms, this.HeatingType, "-");
        }

        /// <summary>
        /// To compare two objects
        /// </summary>
        /// <param name="other">second object</param>
        /// <returns>0 if equal, otherwise 1 or -1</returns>
        public override int CompareTo(RealEstate other)
        {
            House house = other as House;
            if (house == null) return 1;
            if (this.Area.CompareTo(house.Area) == 0)
                return this.HeatingType.CompareTo(house.HeatingType);
            return this.Area.CompareTo(house.Area);
        }

        /// <summary>
        /// Abstract equals method
        /// </summary>
        /// <param name="other">second object</param>
        /// <returns>true if equal or false</returns>
        public override bool Equals(RealEstate other)
        {
            House house = other as House;
            if (house == null) return false;
            if (this.City.Equals(house.City) &&
                this.Neighborhood.Equals(house.Neighborhood) &&
                this.Street.Equals(house.Street) &&
                this.HouseNumber == house.HouseNumber)
                return true;
            return false;
        }
    }
}