using UnityEngine;

public static class VectorExtensionMethods {

    /// <summary>
    /// Returns a Vector2 with the x and y values of this Vector3
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
	public static Vector2 xy(this Vector3 v) {
		return new Vector2(v.x, v.y);
	}

    /// <summary>
    /// Return a copy of this vector with the x value changed
    /// </summary>
    /// <param name="v"></param>
    /// <param name="x"></param>
    /// <returns></returns>
	public static Vector3 WithX(this Vector3 v, float x) {
		return new Vector3(x, v.y, v.z);
	}

    /// <summary>
    /// Return a copy of this vector with the y value changed
    /// </summary>
    /// <param name="v"></param>
    /// <param name="x"></param>
    /// <returns></returns>
	public static Vector3 WithY(this Vector3 v, float y) {
		return new Vector3(v.x, y, v.z);
	}

    /// <summary>
    /// Return a copy of this vector with the z value changed
    /// </summary>
    /// <param name="v"></param>
    /// <param name="x"></param>
    /// <returns></returns>
	public static Vector3 WithZ(this Vector3 v, float z) {
		return new Vector3(v.x, v.y, z);
	}

    /// <summary>
    /// Return a copy of this vector with the x value changed
    /// </summary>
    /// <param name="v"></param>
    /// <param name="x"></param>
    /// <returns></returns>
	public static Vector2 WithX(this Vector2 v, float x) {
		return new Vector2(x, v.y);
	}

    /// <summary>
    /// Return a copy of this vector with the y value changed
    /// </summary>
    /// <param name="v"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public static Vector2 WithY(this Vector2 v, float y) {
		return new Vector2(v.x, y);
	}
	
    /// <summary>
    /// Converts this Vector2 into a Vector 3 with the given z value
    /// </summary>
    /// <param name="v"></param>
    /// <param name="z"></param>
    /// <returns></returns>
	public static Vector3 WithZ(this Vector2 v, float z) {
		return new Vector3(v.x, v.y, z);
        }

    /// <summary>
    /// Find the nearest point on an axis for a given point.
    /// The axis is a line in direction of axisDirection that passes through the origin.
    /// </summary>
    /// <param name="axisDirection">unit vector in direction of an axis (eg, defines a line that passes through zero)</param>
    /// <param name="point">the point to find nearest on line for</param>
    /// <param name="isNormalized"></param>
    /// <returns></returns>
    public static Vector3 NearestPointOnAxis(this Vector3 axisDirection, Vector3 point, bool isNormalized = false)
	{
	    if (!isNormalized) axisDirection.Normalize();
	    var d = Vector3.Dot(point, axisDirection);
	    return axisDirection * d;
	}

    /// <summary>
    /// Find the nearest point in a line in space to a given point
    /// </summary>
    /// <param name="lineDirection">unit vector in direction of line</param>
    /// <param name="pointOnLine">a point on the line (allowing us to define an actual line in space)</param>
    /// <param name="point">the point to find nearest on line for</param>
    /// <param name="isNormalized"></param>
    /// <returns></returns>
    public static Vector3 NearestPointOnLine(this Vector3 lineDirection, Vector3 pointOnLine, Vector3 point, bool isNormalized = false)
    {
        if (!isNormalized) lineDirection.Normalize();
        var d = Vector3.Dot(point - pointOnLine, lineDirection);
        return pointOnLine + (lineDirection * d);
    }
}
