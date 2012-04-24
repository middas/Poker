using Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CommonLibrary.Native;
using System.Linq;

namespace Cards.Tests
{


    /// <summary>
    ///This is a test class for PokerTest and is intended
    ///to contain all PokerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PokerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetHand
        ///</summary>
        [TestMethod()]
        public void GetHandTest()
        {
            List<Card> cards = new List<Card>(); // TODO: Initialize to an appropriate value

            cards.Add(new Card()
            {
                NumberValue = 12,
                Suit = Card.Suits.Diamond
            });
            cards.Add(new Card()
            {
                NumberValue = 9,
                Suit = Card.Suits.Spade
            });
            cards.Add(new Card()
            {
                NumberValue = 1,
                Suit = Card.Suits.Spade
            });
            cards.Add(new Card()
            {
                NumberValue = 1,
                Suit = Card.Suits.Club
            });
            cards.Add(new Card()
            {
                NumberValue = 1,
                Suit = Card.Suits.Diamond
            });
            cards.Add(new Card()
            {
                NumberValue = 12,
                Suit = Card.Suits.Spade
            });
            cards.Add(new Card()
            {
                NumberValue = 11,
                Suit = Card.Suits.Diamond
            });

            int points; // TODO: Initialize to an appropriate value
            int pointsExpected = 876876; // TODO: Initialize to an appropriate value
            Poker.Hands expected = Poker.Hands.FullHouse; // TODO: Initialize to an appropriate value
            Poker.Hands actual;
            actual = Poker.GetHand(cards, out points);
            Assert.AreEqual(pointsExpected, points);
            Assert.AreEqual(expected, actual);
        }
    }
}
