namespace Solid.Serviсes;

internal class NumberGeneratorService : INumberGeneratorServiсe
{
    public int GenerateRandomNumber(int minValue, int maxValue)
    {
        Random rnd = new Random();
        return rnd.Next(minValue, maxValue);
    }
}
