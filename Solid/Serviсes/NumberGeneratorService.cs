namespace Solid.Serviсes;

internal class NumberGeneratorService 
{
    public static int GenerateRandomNumber(int minValue, int maxValue)
    {
        Random rnd = new Random();
        return rnd.Next(minValue, maxValue);
    }
}
