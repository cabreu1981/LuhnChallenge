using NUnit.Framework;

namespace LuhnChallenge.Tests
{
    [TestFixture]
    public class LuhnTests
    {
        private ILuhnCheck LunhCheck { get; set; }

        [SetUp]
        public void Setup()
        {
            LunhCheck = new LuhnCheckEmpty();
        }

        [TestCase("1", false)]
        [TestCase("4929573765058314", true)] //Visa
        [TestCase("4539430708486429", true)] //Visa
        [TestCase("4556316218022002", true)] //Visa
        [TestCase("4916630025064212", true)] //Visa
        [TestCase("4929939586646530", true)] //Visa
        [TestCase("6011783311084417", true)] //Discover
        [TestCase("6011422615998937", true)] //Discover
        [TestCase("6011277670256609", true)] //Discover
        [TestCase("6011284028336422", true)] //Discover
        [TestCase("6011914730681570", true)] //Discover
        [TestCase("374192384454693", true)] //Amex
        [TestCase("372785140819562", true)] //Amex
        [TestCase("373529507006630", true)] //Amex
        [TestCase("348815065355713", true)] //Amex
        [TestCase("349696456926026", true)] //Amex
        [TestCase("5149855107426494", true)] //Mastercard
        [TestCase("5593652859677858", true)] //Mastercard
        [TestCase("5303834223612644", true)] //Mastercard
        [TestCase("5168469953951393", true)] //Mastercard
        [TestCase("5112180907702181", true)] //Mastercard
        [TestCase("1234567890", false)]
        [TestCase("7945648948166414", false)]
        [TestCase("7943333948166414", false)]
        [TestCase("7945648911116414", false)]
        public void TestLuhnCheck(string cardNumber, bool expectedValue)
        {
            var actualValue = LunhCheck.IsValidCardNumber(cardNumber);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
