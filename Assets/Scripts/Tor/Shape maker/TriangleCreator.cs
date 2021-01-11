
using UnityEngine;
using System;

public class TriangleCreator : MonoBehaviour
{
    public bool TryTriangleExists(int [] triangle)
    {
        var size = triangle.Length;
        if (size < 3) return false;

        if (size % 3 == 0)
            return true;
        else
            return false;
    }

    public int[] MakeTriangles(Vector3[] vertices)
    {
        var size = vertices.Length;
        int[] triangles = new int[size];
        if (size < 3) return triangles;

        try
        {
            var j = 0;
            for (int i = 0; i < size; i += 2)
            {
                var ii = i + 1;
                var iii = i + 2;

                triangles[j++] = i;
                triangles[j++] = ii;
                triangles[j++] = iii;

                triangles[j++] = iii;
                triangles[j++] = ii;
                triangles[j++] = i + 3;
            }
        }
        catch (IndexOutOfRangeException) {}

        return triangles;
    }
}
