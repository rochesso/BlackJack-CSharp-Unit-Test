using BlackJackGame;

namespace BlackJackTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        Deck deck = new Deck();
        int expectedLength = 52;

        // Act
        int deckLength = deck.ShuffledDeck.Count;

        // Assert
        Assert.AreEqual(expectedLength, deckLength, 0, "Deck has 52 cards!");
    }

    [TestMethod]
    public void TestMethod2()
    {
        // Arrange
        Deck deck = new Deck();

        // Act
        Card card = deck.Deal();

        // Assert
        Assert.IsTrue((card.Value > 0), "Card value is bigger than 0!");
        Assert.IsTrue((card.Value < 12), "Card value is smaller than 12!");
        Assert.IsTrue((deck.ShuffledDeck.Count == 51), "Deck has 51 cards now!");
    }

    [TestMethod]
    public void TestMethod3()
    {
        // Arrange
        string name = "Test";
        Deck deck = new Deck();
        Hand hand = new Hand(name);

        // Act
        hand.Hit(deck);

        // Assert
        Assert.AreEqual(name, hand.Name, "Hand name is Test");
        Assert.IsTrue((hand.Value > 0), "Hand value is bigger than 0!");
        Assert.IsTrue((hand.Value < 12), "Hand value is smaller than 12!");
        Assert.IsTrue((deck.ShuffledDeck.Count == 51), "Deck has 51 cards now!");
    }

    [TestMethod]
    public void TestMethod4()
    {
        // Arrange
        Deck deck = new Deck();
        int expected = 45;

        // Act
        deck.Deal();
        deck.Deal();
        deck.Deal();
        deck.Deal();
        deck.Deal();
        deck.Deal();
        deck.Deal();

        // Assert
        Assert.AreEqual(
            expected,
            deck.ShuffledDeck.Count,
            $"Deck should have {expected} cards now!"
        );
    }
}
