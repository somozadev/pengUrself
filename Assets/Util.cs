using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static void ResetTransform(this Transform _transform)
    {
        _transform.localPosition = Vector3.zero;
        _transform.localEulerAngles = Vector3.zero;
        _transform.localScale = Vector3.one;
    }

    public static void HatsResetTransform(this Transform _transform)
    {
        _transform.localPosition = Vector3.zero;
        _transform.localEulerAngles = new Vector3(90,0,0);
        _transform.localScale = Vector3.one;
    }
}


[System.Serializable]
public class Point
{
    public List<Color32> list;
    public Point()
    {
        list = new List<Color32>();
    }
}
[System.Serializable]
public class PointList
{
    public List<Point> list;
    public PointList()
    {
        list = new List<Point>();
    }
}