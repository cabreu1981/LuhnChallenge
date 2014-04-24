using LuhnChallenge;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LuhnCheckEmpty lce = new LuhnCheckEmpty();
            lce.IsValidCardNumber("348815065355713");
        }
    }
}
