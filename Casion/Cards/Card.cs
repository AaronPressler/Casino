﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Card
    {

        public static Value[] values;

        public static Icon[] icons;

        public static List<string> list = new List<string>();

        public Card()
        {

            values = new Value[] { Value.Two, Value.Three, Value.Four, Value.Five, Value.Six, Value.Seven, Value.Eight, Value.Nine, Value.Ten, Value.Jack, Value.Queen, Value.King, Value.Ace, };
            icons = new Icon[4] { Icon.Pik, Icon.Karo, Icon.Kreuz, Icon.Herz };
            FillStack();
        }
        public void FillStack() 
        {
            for (int i = 0; i < 4; i++)
            {
                for (int x = 0; x < values.Length; x++)
                {
                    list.Add($"{icons[i]}-{values[x]}");
                }
            }
        }
        public Stack<string> ReturnStack() 
        {
            Stack<string> stack = new Stack<string>();
            
            Shuffle();
            for (int i = 0; i < list.Count; i++) 
            {
                stack.Push(list[i]);            
            }
            return stack;
        }

        public string[] GetFiveCards()
        {
            string[] five_cards = new string[5];
            for (int i = 0; i < 5; i++)
            {
                five_cards[i] = list[i];
            }

            return five_cards;
        }

        public void Shuffle()
        {
            Random r = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int randomIndex = r.Next(list.Count);
                string temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }

        }
    }
}
