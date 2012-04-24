using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary.Native;
using System.IO;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
#if stats
            Stats();
#else
            if (args.Contains("stats"))
            {
                Stats();
            }
            else
            {
                frmMain frm = new frmMain();
                frm.ShowDialog();
            }
#endif
        }

        private static void Stats()
        {
            int maxRoyalFlush = 10;

            Console.Write("Royal Flushes to get: ");
            maxRoyalFlush = Console.ReadLine().ToIntegerOrDefault(-1);

            Deck deck = new Deck();
            deck.CreateDefaultDeck(false);
            deck.Shuffle();

            var cards = deck.Draw(7).ToList();
            int tryCount = 0;

            int highCard = 0;
            int pair = 0;
            int twoPair = 0;
            int threeKind = 0;
            int fullHouse = 0;
            int straight = 0;
            int flush = 0;
            int straightFlush = 0;
            int fourKind = 0;
            int royalFlush = 0;

            DateTime startTime = DateTime.Now;

            while (royalFlush < maxRoyalFlush)
            {
                tryCount++;
                //for (int i = 0; i < cards.Count; i++)
                //{
                //    Console.Write(cards[i].ToString());

                //    if (i < cards.Count - 1)
                //    {
                //        Console.Write(',');
                //    }
                //    else
                //    {
                //        Console.WriteLine();
                //    }
                //}

                switch (Poker.GetHand(cards))
                {
                    case Poker.Hands.Flush:
                        flush++;
                        break;
                    case Poker.Hands.FourKind:
                        fourKind++;
                        break;
                    case Poker.Hands.FullHouse:
                        fullHouse++;
                        break;
                    case Poker.Hands.Pair:
                        pair++;
                        break;
                    case Poker.Hands.RoyalFlush:
                        royalFlush++;
                        break;
                    case Poker.Hands.Straight:
                        straight++;
                        break;
                    case Poker.Hands.StraightFlush:
                        straightFlush++;
                        break;
                    case Poker.Hands.ThreeKind:
                        threeKind++;
                        break;
                    case Poker.Hands.TwoPair:
                        twoPair++;
                        break;
                    case Poker.Hands.HighCard:
                        highCard++;
                        break;
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(string.Format("Pairs: {0} ({1})\r\n2 Pairs: {2} ({3})\r\nPairs of 3: {4} ({5})\r\nPairs of 4: {6} ({7})\r\nFull Houses: {8} ({9})\r\nFlushes: {10} ({11})\r\nStraights: {12} ({13})\r\nStraight Flushes: {14} ({15})\r\nRoyal Flushes: {16} ({17})\r\nHigh Card: {18} ({19})",
                    pair, ((decimal)pair / (decimal)tryCount).ToString("P9"), twoPair, ((decimal)twoPair / (decimal)tryCount).ToString("P9"), threeKind, ((decimal)threeKind / (decimal)tryCount).ToString("P9"), fourKind, ((decimal)fourKind / (decimal)tryCount).ToString("P9"),
                    fullHouse, ((decimal)fullHouse / (decimal)tryCount).ToString("P9"), flush, ((decimal)flush / (decimal)tryCount).ToString("P9"), straight, ((decimal)straight / (decimal)tryCount).ToString("P9"), straightFlush, ((decimal)straightFlush / (decimal)tryCount).ToString("P9"), royalFlush, ((decimal)royalFlush / (decimal)tryCount).ToString("P9"), highCard, ((decimal)highCard / (decimal)tryCount).ToString("P9")));


                deck.Shuffle();
                cards = deck.Draw(7).ToList();
            }

            TimeSpan difference = DateTime.Now - startTime;

            Console.WriteLine(string.Format("Took {0} tries.", tryCount));

            Console.WriteLine(string.Format("Took {0} seconds ({1}/second)", difference.TotalSeconds, ((decimal)tryCount / (decimal)difference.TotalSeconds).ToString("F5")));

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Pairs: {0} ({1})\r\n2 Pairs: {2} ({3})\r\nPairs of 3: {4} ({5})\r\nPairs of 4: {6} ({7})\r\nFull Houses: {8} ({9})\r\nFlushes: {10} ({11})\r\nStraights: {12} ({13})\r\nStraight Flushes: {14} ({15})\r\nRoyal Flushes: {16} ({17})\r\nHigh Card: {18} ({19})",
                pair, ((decimal)pair / (decimal)tryCount).ToString("P9"), twoPair, ((decimal)twoPair / (decimal)tryCount).ToString("P9"), threeKind, ((decimal)threeKind / (decimal)tryCount).ToString("P9"), fourKind, ((decimal)fourKind / (decimal)tryCount).ToString("P9"),
                fullHouse, ((decimal)fullHouse / (decimal)tryCount).ToString("P9"), flush, ((decimal)flush / (decimal)tryCount).ToString("P9"), straight, ((decimal)straight / (decimal)tryCount).ToString("P9"), straightFlush, ((decimal)straightFlush / (decimal)tryCount).ToString("P9"), royalFlush, ((decimal)royalFlush / (decimal)tryCount).ToString("P9"), highCard, ((decimal)highCard / (decimal)tryCount).ToString("P9")));
            sb.Append("\r\n").Append(string.Format("Took {0} tries.", tryCount)).Append("\r\n");
            sb.Append(string.Format("Took {0} seconds ({1}/second)", difference.TotalSeconds, ((decimal)tryCount / (decimal)difference.TotalSeconds).ToString("F5"))).Append("\r\n\r\n");

            SaveFile(sb.ToString());
        }

        private static void SaveFile(string data)
        {
            using (FileStream fs = new FileStream("Results.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(data);
            }
        }
    }
}
