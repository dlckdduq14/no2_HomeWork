using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No2_HomeWork
{
    public class Player
    {
        public Player(int money, int debt, int name)
        {
            Name = name;
            Money = money;
            Debt = debt;
            _cards = new List<Card>();
        }
        public int Name { get; set; }
        public int Money { get; set; }

        public int Debt { get; set; }

        private readonly List<Card> _cards; // = 대입연산자를 막음 

        public void CalculateScore()
        {
            if (_cards[0].No == _cards[1].No)
                Score = _cards[0].No * 10;  // 10 ~ 100 
            else
                Score = (_cards[0].No + _cards[1].No) % 10;  // 0 ~ 9   
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }
        public int Score { get; set; }

        //indexer
        public Card this[int index]
        {
            get
            {
                return _cards[index];
            }
        }

        public void PrepareRound()
        {
            _cards.Clear(); //카드 초기화
            Score = 0;
        }

        public void Remove(int i)
        {
            _cards.RemoveAt(i);
        }
    }
}
