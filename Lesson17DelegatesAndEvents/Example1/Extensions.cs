namespace Lesson17DelegatesAndEvents.Example1;

public static class Extensions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        if (!collection.Any()) return null;

        T maxElement = null;
        float maxValue = float.MinValue;

        foreach (var element in collection)
        {
            float value = convertToNumber(element);
            if (maxElement == null || value > maxValue)
            {
                maxValue = value;
                maxElement = element;
            }
        }

        return maxElement;
    }
}
