using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MileBourne.Cards
{
     class DistanceCard: Card
    {
        public int CardMiles;
        public DistanceCard(string name, int id, string image, int miles):base(name, id, image) {
            CardMiles = miles;
        }

     
    }
}
