using StarWars.App.Domain.Exceptions;
using StarWars.App.Services.Helper;
using System;
using System.Runtime.Serialization;

namespace StarWars.App.Domain.Entities
{
    [DataContract]
    public class StarShip
    {
        public StarShip(string name, string megalights, string consumables)
        { 
            Name = name;
            Megalights = long.TryParse(megalights, out long ConvertedMegalights) ? ConvertedMegalights : -1;
            Consumables = consumables;
        }
         
        public string Name { get; private set; }
         
        public long Megalights { get; private set; }
         
        public string Consumables { get; private set; }

        public double GetStops(int distance)
        {
            const string unknown = "unknown";

            if (Megalights < 0 || Consumables == unknown)
                 throw new DomainException(unknown);

            var consumables = Consumables.Split(' ');

            if (consumables.Length <= 0 || !int.TryParse(consumables[0], out int quantity))
                throw new DomainException(unknown);

            var durationUnit = consumables[1]; 
            var totalHours = GetTotalhours(durationUnit, quantity);

            if (totalHours <= 0)
                throw new DomainException(unknown);

            var distanceBetweenStops = totalHours * Megalights;
            return Math.Round(distance / distanceBetweenStops, MidpointRounding.AwayFromZero);
        }

        private double GetTotalhours(string duration, int quantity)
        {
            var startDate = DateTime.Now;
            var endDate = startDate;

            if (TimeUnit.IsDay(duration))
                endDate = startDate.AddDays(quantity);
  
            else if (TimeUnit.IsWeek(duration))
                endDate = startDate.AddDays(quantity * 7);

            else if (TimeUnit.IsMonth(duration))
                endDate = startDate.AddMonths(quantity);

            else if (TimeUnit.IsYear(duration))
                endDate = startDate.AddYears(quantity);
          
            return (endDate - startDate).TotalHours;
        }
    } 
}
