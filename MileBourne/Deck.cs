
using System;
using System.Collections.Generic;
using System.Linq;
using ExtensionMethods;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace MileBourne
{
    internal class Deck : INotifyPropertyChanged
    {

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }

        }
        private List<Cards.Card> drawStack = new List<Cards.Card>();
        private List<Cards.Card> discardStack = new List<Cards.Card>();

        public event PropertyChangedEventHandler PropertyChanged;

        public Deck()
        {

            string path = System.IO.Directory.GetDirectories(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))[0]; 
                
                path+= "\\Images\\";
            int nextCardID = 0;
            for (int i=1; i < 11; i++)
            {
              
               
                Cards.Card new25 = new Cards.DistanceCard("25 Mile", nextCardID++,path+"MB-25.png", 25);
                Cards.Card new50 = new Cards.DistanceCard("50 Mile", nextCardID++, path+"MB-50.png", 50);
                Cards.Card new75 = new Cards.DistanceCard("75 Mile", nextCardID++, path+"MB-75.png", 75);
                drawStack.Add(new25);
                drawStack.Add(new50);
                drawStack.Add(new75);

            }
            for (int i = 1; i < 13; i++)
            {
                Cards.Card new100 = new Cards.DistanceCard("100 Mile", nextCardID++, path+ "MB-100.png", 100);
                drawStack.Add(new100);


            }

            for (int i = 1; i < 5; i++)
            {
                Cards.Card new200 = new Cards.DistanceCard("200 Mile", nextCardID++, path+ "MB-200.png", 200);
                drawStack.Add(new200);


            }

            for (int i =1; i < 4; i++)
            {
                Cards.Card newAccident = new Cards.Hazard("Accident", nextCardID++, path + "MB-crash.png");
                Cards.Card newGas = new Cards.Hazard("Out of Gas", nextCardID++, path + "MB-empty.png");
                Cards.Card newFlat = new Cards.Hazard("Flat Tire", nextCardID++, path + "MB-flat.png");
                drawStack.Add(newAccident);
                drawStack.Add(newGas);
                drawStack.Add(newFlat);

            }

            for (int i = 1; i < 5; i++)
            {
                Cards.Card newSpeedLimit = new Cards.Hazard("Speed Limit", nextCardID++, path + "MB-limit.png");
                drawStack.Add(newSpeedLimit);

            }

            for (int i = 1; i < 6; i++)
            {
                Cards.Card newStop = new Cards.Hazard("Stop", nextCardID++, path + "MB-stop.png");
                drawStack.Add(newStop);

            }

            for (int i = 1; i < 7; i++)
            {
                Cards.Card newRep = new Cards.Remedy("Repairs", nextCardID++, path + "MB-repair.png");
                Cards.Card newGas = new Cards.Remedy("Gasoline", nextCardID++, path + "MB-gas.png");
                Cards.Card newSpare = new Cards.Remedy("Spare Tire", nextCardID++, path + "MB-spare.png");
                Cards.Card newEnd = new Cards.Remedy("End of Limit", nextCardID++, path + "MB-unlimited.png");
              

                drawStack.Add(newRep);
                drawStack.Add(newGas);
                drawStack.Add(newSpare);
                drawStack.Add(newEnd);

            }
            for (int i = 1; i < 17; i++)
            {
                Cards.Card newGo = new Cards.Remedy("Go", nextCardID++, path + "MB-roll.png");
             
               
                drawStack.Add(newGo);

            }

            Cards.Card newRepSafe = new Cards.Saftie("Driving Ace", nextCardID++, path + "MB-ace.png");
            Cards.Card newRightSafe = new Cards.Saftie("Right of Way", nextCardID++, path + "MB-emergency.png");
            Cards.Card newSpareSafe = new Cards.Saftie("Puncture Proof", nextCardID++, path + "MB-sealant.png");
            Cards.Card newGasSafe = new Cards.Saftie("Extra Tank", nextCardID++, path + "MB-tanker.png");

            drawStack.Add(newRepSafe);
            drawStack.Add(newGasSafe);
            drawStack.Add(newSpareSafe);
            drawStack.Add(newRightSafe);
            Shuffle();

        }

        public int CardCount()
        {
            return drawStack.Count;
        }

        public void Shuffle()
        {
            var rnd = new System.Random(DateTime.Now.Millisecond);
            drawStack.Shuffle();
            
        }

        public Cards.Card DiscardTop
        {
            get
            {
                return discardStack.LastOrDefault();
            }
        }


        public Cards.Card Draw() {
            Cards.Card drawCard = drawStack.FirstOrDefault();
            if(drawCard == null)
            {
                return null;
            }
            else
            {
                drawStack.Remove(drawCard);
                return drawCard;
            }

        }
        public void Discard(Cards.Card discardCard) {
            discardStack.Add(discardCard);
            OnPropertyChanged(nameof(DiscardTop));

        }






    }
}