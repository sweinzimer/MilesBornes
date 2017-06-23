using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MileBourne.Cards
{
    class Saftie:Card
    {
        public List<string> counters = new List<string>();
        public bool coup { get; set; } = false;
        
        public Saftie(string name, int id, string image):base(name, id, image) {
           switch( name)
            {
                case "Driving Ace":
                    counters.Add("Accident");
                    break;

                case "Right of Way":
                    counters.Add("Stop");
                    counters.Add("Speed Limit");
                    break;

                case "Extra Tank":
                    counters.Add("Out of Gas");
                   break;
                case "Puncture Proof":
                    counters.Add("Flat Tire");
                    break;



            }
               
        }
    }
}
