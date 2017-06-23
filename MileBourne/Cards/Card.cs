using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace MileBourne.Cards
{
    abstract public class Card: INotifyPropertyChanged
    {

        public String CardName { get; }
        public int CardID { get; }
        public string CardImage { get; }
        public  bool canPlay { get; set; }
        public Card(string name, int id, string image)
        {
            CardName = name;
            CardID = id;
            CardImage = image;
        }

     
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
