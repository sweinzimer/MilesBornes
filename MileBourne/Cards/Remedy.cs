using System.Collections.Generic;
using System.Drawing;

namespace MileBourne.Cards
{
    internal class Remedy:Card
    {
        public List<string> counters = new List<string>();
        public Remedy(string name, int id, string image ) : base(name, id, image) {

            switch (name)
            {
                case "Repairs":
                    counters.Add("Accident");
                    break;

                case "Go":
                    counters.Add("Stop");
                    
                    break;

                case "Gasoline":
                    counters.Add("Out of Gas");
                    break;
                case "Spare Tire":
                    counters.Add("Flat Tire");
                    break;
                case "End of Limit":
                    counters.Add("Speed Limit");
                    break;



            }
        }
    }
}