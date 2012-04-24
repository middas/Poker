using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cards
{
    public partial class frmMain : Form
    {
        private Deck Deck
        {
            get;
            set;
        }

        public frmMain()
        {
            InitializeComponent();

            Deck = new Deck();
            Deck.CreateDefaultDeck(false);
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            DrawCards();
        }

        private void DrawCards()
        {
            Deck.Shuffle();

            List<Card> player1 = new List<Card>();
            List<Card> player2 = new List<Card>();

            player1.Add(Deck.Draw());
            player2.Add(Deck.Draw());
            player1.Add(Deck.Draw());
            player2.Add(Deck.Draw());

            List<Card> common = Deck.Draw(5).ToList();

            player1.AddRange(common);
            player2.AddRange(common);

            ucCard1.Card = common[0];
            ucCard2.Card = common[1];
            ucCard3.Card = common[2];
            ucCard4.Card = common[3];
            ucCard5.Card = common[4];
            ucCard6.Card = player1[0];
            ucCard7.Card = player1[1];
            ucCard8.Card = player2[0];
            ucCard9.Card = player2[1];

            int points1;
            int points2;

            var hand1 = Poker.GetHand(player1, out points1);
            var hand2 = Poker.GetHand(player2, out points2);

            string winner = "";
            Comparer<int> comparer = Comparer<int>.Default;

            switch (comparer.Compare((int)hand1, (int)hand2))
            {
                case -1:
                    winner = "P2";
                    break;
                case 0:
                    if (points1 > points2)
                    {
                        winner = "P1";
                    }
                    else if (points1 < points2)
                    {
                        winner = "P2";
                    }
                    else
                    {
                        winner = "Tie";
                    }
                    break;
                case 1:
                    winner = "P1";
                    break;
            }

            lblWinner.Text = string.Format("Winner: {0}", winner);
            lblHand.Text = string.Format("P1 Hand: {0}", hand1.ToString());
            lblHand2.Text = string.Format("P2 Hand: {0}", hand2.ToString());
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawCards();
        }
    }
}
