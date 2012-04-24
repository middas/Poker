using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cards
{
    public partial class ucCard : UserControl
    {
        private Card _Card;
        public Card Card
        {
            get
            {
                return _Card;
            }
            set
            {
                _Card = value;
                this.Invalidate();
            }
        }

        public ucCard()
        {
            InitializeComponent();
        }

        private void ucCard_Paint(object sender, PaintEventArgs e)
        {
            if (Card != null)
            {
                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                using (SolidBrush brush = new SolidBrush(Card.Color))
                {
                    using (Font font = new Font("Arial", 12, FontStyle.Bold))
                    {
                        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                        e.Graphics.DrawString(Card.ToString(), font, brush, 0, 0);
                        e.Graphics.RotateTransform(180);
                        e.Graphics.DrawString(Card.ToString(), font, brush, -109, -150);
                        e.Graphics.ResetTransform();
                    }

                    e.Graphics.TranslateTransform(Width / 2, Height / 2);

                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;

                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                    if (Card.NumberValue == 1 || Card.NumberValue > 10)
                    {
                        using (Font font = new Font("Arial", 60, FontStyle.Bold))
                        {
                            if (Card.NumberValue == 1)
                            {
                                e.Graphics.DrawString(Card.Suit, font, brush, 0, 0, stringFormat);
                            }
                            else
                            {
                                e.Graphics.DrawString(Card.Number, font, brush, 0, 0, stringFormat);
                            }
                        }
                    }
                    else
                    {
                        using (Font font = new Font("Arial", 30, FontStyle.Bold))
                        {
                            foreach (Point p in Card.SuitPoints)
                            {
                                e.Graphics.DrawString(Card.Suit, font, brush, p.X, p.Y, stringFormat);
                            }

                            e.Graphics.RotateTransform(180);

                            foreach (Point p in Card.InversedSuitPoints)
                            {
                                e.Graphics.DrawString(Card.Suit, font, brush, p.X, p.Y, stringFormat);
                            }
                        }
                    }
                }
            }
        }
    }
}
