using UnityEngine;

public static class FloatExtensionMethods
{
    /// <summary>
    /// Translates one value in a range into the corresponding value of a new range
    /// </summary>
    /// <param name="value"></param>
    /// <param name="valueRangeMin"></param>
    /// <param name="valueRangeMax"></param>
    /// <param name="newRangeMin"></param>
    /// <param name="newRangeMax"></param>
    /// <returns></returns>
    public static float LinearRemap(this float value,
                                     float valueRangeMin, float valueRangeMax,
                                     float newRangeMin, float newRangeMax)
    {
        return (value - valueRangeMin) / (valueRangeMax - valueRangeMin) * (newRangeMax - newRangeMin) + newRangeMin;
    }

    /// <summary>
    /// Returns the same number with random sign
    /// </summary>
    /// <param name="value"></param>
    /// <param name="negativeProbability"></param>
    /// <returns></returns>
    public static float WithRandomSign(this int value, float negativeProbability = 0.5f)
    {
        return Random.value < negativeProbability ? -value : value;
    }

}