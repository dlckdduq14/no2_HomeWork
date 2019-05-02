using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No2_HomeWork
{
    class Program
    {
        public const int PlayerConunt = 4;
        public const int SeedMoney = 1000;
        public const int DebtInit = 0;
        private const int BetMoney = 100;
        static void Main(string[] args)
        {
            // 각 선수들이 시드머니를 가진다.
            List<Player> players = new List<Player>();

            for (int i = 0; i < PlayerConunt; i++)
                players.Add(new Player(SeedMoney, DebtInit, i));

            int round = 1;
            // 선수 중 파산(오링)하는 사람이 있을때 까지 라운드를 진행한다.
            while (true)
            {
                if (CanRanRound(players) == false)
                    break;

                Console.WriteLine($"[Round {round++}]");

                // 라운드를 진행한다. 
                RunRound(players);
                // 선수들이 가진 돈을 출력한다.
                PrintMoney(players);

                Console.WriteLine();

                // 승자와 패자를 가린다.
                Player winner = FindWinner(players);
                Player loser = Loser(players);


                if (loser.Money == 0 && loser.Debt == 500)
                    Console.WriteLine($" P{loser.Name}가 파산했습니다. 승자는 P{winner.Name} 입니다.");

                if (loser.Money == 0 && loser.Debt == 0)
                {
                    Console.WriteLine($" P{winner.Name} 가 이겼습니다. P{loser.Name}에게 충전 하겠습니까? (1.예 , 2.아니오)");
                    string inputText = Console.ReadLine();
                    int input = int.Parse(inputText);

                    if (input == 1)
                    {
                        loser.Money += 500;
                        loser.Debt += 500;
                    }
                }

            }

        }

        private static void PrintMoney(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"P{i} has \\{players[i].Money}");
            }
        }

        private static bool CanRanRound(List<Player> players)
        {
            foreach (Player player in players)
                if (player.Money <= 0)
                    return false;

            return true;
        }

        static void RunRound(List<Player> players)
        {
            // 각 선수가 이전 라운드에서 받은 카드를 클리어한다.
            foreach (Player player in players)
                player.PrepareRound();

            // 선수들이 학교를 간다.(베팅을 한다.)
            int totalBetMoney = 0;

            foreach (Player player in players)
            {
                player.Money -= BetMoney;
                totalBetMoney += BetMoney;
            }
            // 딜러가 각 선수들에게 두장 씩 카드를 돌린다.
            Dealer dealer = new Dealer();

            foreach (Player player in players)
                for (int i = 0; i < 2; i++)
                    player.AddCard(dealer.Draw());

            // 각 선수들의 족보를 계산하고 출력한다.
            for (int i = 0; i < players.Count; i++)
            {
                Player p = players[i];

                players[i].CalculateScore();
                Console.WriteLine($"P{i} ({p[0]},{p[1]}) => {p.Score}");
            }

            // 승자와 패자를 가린다.
            Player winner = FindWinner(players);
            Player loser = Loser(players);
            // 승자에게 모든 베팅 금액을 준다.
            if (winner.Score == loser.Score)
            {
                Console.WriteLine($"[무승부가되어 베팅금액을 반환합니다.]");
                foreach (Player player in players)
                {
                    player.Money += BetMoney;
                    totalBetMoney -= BetMoney;
                }
            }
            else
            { winner.Money += totalBetMoney; }
        }

        private static Player FindWinner(List<Player> players)
        {
            return players.OrderByDescending(x => x.Score).First();
        }

        private static Player Loser(List<Player> players)
        {
            return players.OrderBy(x => x.Score).First();
        }
    }
}
