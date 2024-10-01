using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._3
{
    public class Card
    {
        public string Name {  get; set; }
        public string ExpirationDate { get; set; }
        public int CVC { get; set; }
        public double Balance { get; set; }
        public Card(string name, string expirationDate, int cvc, double balance)
        {
            Name = name;
            ExpirationDate = expirationDate;
            CVC = cvc;
            Balance = balance;
        }

        public static Card operator +(Card card, double amount)
        {
            card.Balance += amount;
            return card;
        }
        public static Card operator -(Card card, double amount)
        {
            card.Balance -= amount;
            return card;
        }
        public static bool operator ==(Card card1, Card card2)
        {
            return card1.CVC == card2.CVC;
        }
        public static bool operator !=(Card card1, Card card2)
        {
            return card1.CVC != card2.CVC;
        }
        public static bool operator >(Card card1, Card card2)
        {
            return card1.Balance > card2.Balance;
        }

        public static bool operator <(Card card1, Card card2)
        {
            return card1.Balance < card2.Balance;
        }

        public override bool Equals(object obj)
        {
            if (obj is Card card)
            {
                return this.CVC == card.CVC;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return CVC.GetHashCode();
        }

        public override string ToString()
        {
            return $"Card Name: {Name}, Expiration: {ExpirationDate}, CVC: {CVC}, Balance: {Balance}$";
        }
    }
}
