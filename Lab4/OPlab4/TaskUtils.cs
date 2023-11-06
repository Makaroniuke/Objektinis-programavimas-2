using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab4
{
    /// <summary>
    /// Counting class
    /// </summary>
    public class TaskUtils
    {
        /// <summary>
        /// Finds streets where most houses/flats are for sell
        /// </summary>
        /// <param name="allHouses"></param>
        /// <returns></returns>
        public static Dictionary<string, int> FindMostHousesInOneStreet(List<RealEstate> allHouses)
        {
            Dictionary<string, int> streets = new Dictionary<string, int>();
            for (int i = 0; i < allHouses.Count; i++)
            {
                if (!streets.ContainsKey(allHouses[i].Street))
                {
                    streets.Add(allHouses[i].Street, 1);
                }
                else
                {
                    streets[allHouses[i].Street]++;
                }
            }
            return streets;
        }

        /// <summary>
        /// Finds oldest house
        /// </summary>
        /// <param name="allHouses">list of houses/flats</param>
        /// <returns>oldest house/flat</returns>
        public static RealEstate FindOldest(List<RealEstate> allHouses)
        {
            int oldest = 3000;
            RealEstate oldestHouse = allHouses[0];
            for (int i = 1; i < allHouses.Count; i++)
            {
                if(allHouses[i].Year < oldest)
                {
                    oldest = allHouses[i].Year;
                    oldestHouse = allHouses[i];
                }
            }
            return oldestHouse;
        }

        /// <summary>
        /// finds all oldest houses/flats
        /// </summary>
        /// <param name="allHouses">list of houses/flats</param>
        /// <param name="oldest">oldest house</param>
        /// <returns>all oldest houses/flats</returns>
        public static List<RealEstate> FindAllOldestHouses(List<RealEstate> allHouses, RealEstate oldest)
        {
            List<RealEstate> allOldests = new List<RealEstate>();
            for (int i = 0; i < allHouses.Count; i++)
            {
                if(allHouses[i].Year == oldest.Year)
                {
                    if(!allOldests.Contains(allHouses[i]))
                        allOldests.Add(allHouses[i]);
                }
            }
            return allOldests;
        }

        /// <summary>
        /// Finds duplicates in 2 offices
        /// </summary>
        /// <param name="firstList">list of houses/flats</param>
        /// <returns>list of duplicates</returns>
        public static List<RealEstate> FindDuplicates(List<RealEstate> firstList)
        {
            List<RealEstate> duplicates = new List<RealEstate>();
            for (int i = 0; i < firstList.Count; i++)
            {
                for (int j = 1; j < firstList.Count; j++)
                {
                    if (!firstList[i].ReturnOfficeName().Equals(firstList[j].ReturnOfficeName()))
                    {
                        if (firstList[i].Equals(firstList[j]))
                        {
                            if(!duplicates.Contains(firstList[j]))
                                duplicates.Add(firstList[j]);
                        }
                    }                 
                }
            }
            return duplicates;
        }

        /// <summary>
        /// Finds all big houses/flats
        /// </summary>
        /// <param name="allHouses">list of houses/flats</param>
        /// <returns>list of big houses/flats</returns>
        public static List<RealEstate> FindBigHouses(List<RealEstate> allHouses)
        {
            List<RealEstate> bigHouses = new List<RealEstate>();
            for (int i = 0; i < allHouses.Count; i++)
            {
                if (!bigHouses.Contains(allHouses[i]))
                {
                    if (allHouses[i] is Flat && allHouses[i].Area > 90)
                        bigHouses.Add(allHouses[i]);
                    else if (allHouses[i] is House && allHouses[i].Area > 200)
                        bigHouses.Add(allHouses[i]);
                }
            }
            return bigHouses;
        }




    }
}