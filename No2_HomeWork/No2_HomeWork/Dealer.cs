using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No2_HomeWork
{
    public class Dealer
    {
        public Dealer()
        {
            _cards = new List<Card>();
            for (int i = 0; i < 10; i++)
            {
                int no = i + 1;

                for (int j = 0; j < 2; j++)
                {
                    bool isKwang = j == 0 && (no == 1 || no == 3 || no == 8);

                    Card card = new Card(no, isKwang);
                    _cards.Add(card);
                }
            }
            // shuffle
            _cards = _cards.OrderBy(x => Guid.NewGuid()).ToList();
        }

        private List<Card> _cards;

        private int _currentCartIndex = 0;
        public Card Draw()
        {
            Card card = _cards[_currentCartIndex];
            _currentCartIndex++;

            return card;

            //return _cards[_currentCartIndex++];
        }
    }
}
