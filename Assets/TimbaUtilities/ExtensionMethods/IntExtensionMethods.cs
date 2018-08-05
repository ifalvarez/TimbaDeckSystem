using UnityEngine;

public static class IntExtensionMethods
{
    /// <summary>
    /// Returns the same number with a random sign
    /// </summary>
    /// <param name="value"></param>
    /// <param name="negativeProbability"></param>
    /// <returns></returns>
    public static float WithRandomSign(this int value, float negativeProbability = 0.5f)
    {
        return Random.value < negativeProbability ? -value : value;
    }

}