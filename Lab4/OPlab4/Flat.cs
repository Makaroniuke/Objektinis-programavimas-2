using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab4
{
    /// <summary>
    /// Flat class
    /// </summary>
    public class Flat : RealEstate, IComparable<RealEstate>, IEquatable<RealEstate>
    {
        public int Floor { get; set; }

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
        /// <param name="floor">floor</param>
        public Flat(NTOffice office,string city, string neigh, string street, int number, string type, int year, double area, int roomsNumber, int floor) : base(office,city, neigh, street, number, type, year, area, roomsNumber)
        {
            this.Floor = floor;           
        }

        /// <summary>
        /// Forms line
        /// </summary>
        /// <returns>Formated line</returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                this.Office, this.City, this.Neighborhood, this.Street, this.HouseNumber, this.Type, this.Year, this.Area, this.NumberOfRooms, "-",this.Floor);
        }

        /// <summary>
        /// To compare two objects
        /// </summary>
        /// <param name="other">second object</param>
        /// <returns>0 if equal, otherwise 1 or -1</returns>
        public override int CompareTo(RealEstate other)
        {
            Flat flat = other as Flat;
            if (flat == null) return 1;
            if (this.Area.CompareTo(flat.Area) == 0)
                return this.Floor.CompareTo(flat.Floor);
            return this.Area.CompareTo(flat.Area);
        }

        /// <summary>
        /// Abstract equals method
        /// </summary>
        /// <param name="other">second object</param>
        /// <returns>true if equal or false</returns>
        public override bool Equals(RealEstate other)
        {
            Flat flat = other as Flat;
            if (flat == null) return false;
            if (this.City.Equals(flat.City) &&
                this.Neighborhood.Equals(flat.Neighborhood) &&
                this.Street.Equals(flat.Street) &&
                this.HouseNumber == flat.HouseNumber)
                return true;
            return false;
        }

        // cia naudoti su as (other as Flat), kad zinoti ar tokio pacio tipo objektai, rikiavima parasyti task utils klasej, isimciu kontrole 
        // tai kiek throw new, tiek try catch panaudoti
        // istestuoti galima bet kokia klase
    }
}