using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2
{
    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        
        public City(string name, string country, int population)
        {
            Name = name;
            Country = country;
            Population = population;
        }

        public static City operator +(City city, int amount)
        {
            city.Population += amount;
            return city;
        }
        public static City operator -(City city, int amount)
        {
            city.Population -= amount;
            return city;
        }
        public static bool operator ==(City city1, City city2)
        {
            return city1.Population == city2.Population;
        }
        public static bool operator !=(City city1, City city2)
        {
            return city1.Population != city2.Population;
        }
        public static bool operator >(City city1, City city2)
        {
            return city1.Population > city2.Population;
        }
        public static bool operator <(City city1, City city2)
        {
            return city1.Population < city2.Population;
        }
        public override bool Equals(object obj)
        {
            if (obj is City city)
            {
                return this.Population == city.Population;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Population.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name}, {Country} - Population: {Population}";
        }
    }
}
