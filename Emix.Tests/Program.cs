namespace Emix.Tests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var game = new MyGame())
            {
                game.Run();
            }
        }
    }
}