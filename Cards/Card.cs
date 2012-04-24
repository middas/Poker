using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Cards
{
    public class Card
    {
        private const int Horizontal = 23;
        private const int High = -53;
        private const int Mid = -27;
        private const int QuadMid = -18;

        public string Suit
        {
            get;
            set;
        }

        public Color Color
        {
            get
            {
                return Suit == Suits.Diamond || Suit == Suits.Heart ? Color.Red : Color.Black;
            }
        }

        public string Number
        {
            get
            {
                string value;

                switch (NumberValue)
                {
                    case 1:
                        value = "A";
                        break;
                    case 11:
                        value = "J";
                        break;
                    case 12:
                        value = "Q";
                        break;
                    case 13:
                        value = "K";
                        break;
                    default:
                        value = NumberValue.ToString();
                        break;
                }

                return value;
            }
        }

        private int _NumberValue;
        public int NumberValue
        {
            get
            {
                return _NumberValue;
            }
            set
            {
                _NumberValue = value;
                SetSuitPoints();

                if (_NumberValue == 1)
                {
                    Points = (int)Math.Pow(14, 2);
                }
                else
                {
                    Points = (int)Math.Pow(_NumberValue, 2);
                }
            }
        }

        public int Points
        {
            get;
            set;
        }

        private void SetSuitPoints()
        {
            SuitPoints = new List<Point>();
            InversedSuitPoints = new List<Point>();

            switch (NumberValue)
            {
                case 2:
                    SuitPoints.Add(new Point(0, High));
                    InversedSuitPoints.Add(new Point(0, High));
                    break;
                case 3:
                    SuitPoints.Add(new Point(0, High));
                    SuitPoints.Add(new Point(0, 0));
                    InversedSuitPoints.Add(new Point(0, High));
                    break;
                case 4:
                    SuitPoints.Add(new Point(Horizontal, High));
                    SuitPoints.Add(new Point(-Horizontal, High));
                    InversedSuitPoints.Add(new Point(Horizontal, High));
                    InversedSuitPoints.Add(new Point(-Horizontal, High));
                    break;
                case 5:
                    SuitPoints.Add(new Point(Horizontal, High));
                    SuitPoints.Add(new Point(-Horizontal, High));
                    InversedSuitPoints.Add(new Point(Horizontal, High));
                    InversedSuitPoints.Add(new Point(-Horizontal, High));
                    SuitPoints.Add(new Point(0, 0));
                    break;
                case 6:
                    SuitPoints.Add(new Point(Horizontal, High));
                    SuitPoints.Add(new Point(Horizontal, 0));
                    SuitPoints.Add(new Point(-Horizontal, High));
                    SuitPoints.Add(new Point(-Horizontal, 0));
                    InversedSuitPoints.Add(new Point(Horizontal, High));
                    InversedSuitPoints.Add(new Point(-Horizontal, High));
                    break;
                case 7:
                    SuitPoints.Add(new Point(Horizontal, High));
                    SuitPoints.Add(new Point(Horizontal, 0));
                    SuitPoints.Add(new Point(-Horizontal, High));
                    SuitPoints.Add(new Point(-Horizontal, 0));
                    SuitPoints.Add(new Point(0, Mid));
                    InversedSuitPoints.Add(new Point(Horizontal, High));
                    InversedSuitPoints.Add(new Point(-Horizontal, High));
                    break;
                case 8:
                    SuitPoints.Add(new Point(Horizontal, High));
                    SuitPoints.Add(new Point(Horizontal, 0));
                    SuitPoints.Add(new Point(-Horizontal, High));
                    SuitPoints.Add(new Point(-Horizontal, 0));
                    SuitPoints.Add(new Point(0, Mid));
                    InversedSuitPoints.Add(new Point(Horizontal, High));
                    InversedSuitPoints.Add(new Point(-Horizontal, High));
                    InversedSuitPoints.Add(new Point(0, Mid));
                    break;
                case 9:
                    SuitPoints.Add(new Point(Horizontal, High));
                    SuitPoints.Add(new Point(Horizontal, QuadMid));
                    SuitPoints.Add(new Point(-Horizontal, High));
                    SuitPoints.Add(new Point(-Horizontal, QuadMid));
                    SuitPoints.Add(new Point(0, 0));
                    InversedSuitPoints.Add(new Point(Horizontal, High));
                    InversedSuitPoints.Add(new Point(-Horizontal, High));
                    InversedSuitPoints.Add(new Point(Horizontal, QuadMid));
                    InversedSuitPoints.Add(new Point(-Horizontal, QuadMid));
                    break;
                case 10:
                    SuitPoints.Add(new Point(Horizontal, High));
                    SuitPoints.Add(new Point(Horizontal, QuadMid));
                    SuitPoints.Add(new Point(-Horizontal, High));
                    SuitPoints.Add(new Point(-Horizontal, QuadMid));
                    SuitPoints.Add(new Point(0, Mid));
                    InversedSuitPoints.Add(new Point(0, Mid));
                    InversedSuitPoints.Add(new Point(Horizontal, High));
                    InversedSuitPoints.Add(new Point(-Horizontal, High));
                    InversedSuitPoints.Add(new Point(Horizontal, QuadMid));
                    InversedSuitPoints.Add(new Point(-Horizontal, QuadMid));
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\r\n{1}", Number, Suit);
        }

        public List<Point> SuitPoints
        {
            get;
            private set;
        }

        public List<Point> InversedSuitPoints
        {
            get;
            private set;
        }

        public class Suits
        {
            public const string Heart = "♥";
            public const string Diamond = "♦";
            public const string Spade = "♠";
            public const string Club = "♣";

            public static string[] AllSuits = { Heart, Diamond, Spade, Club };
        }
    }
}
