
using UnityEngine;
using System;

[RequireComponent(typeof(TorDimension))]

public class VerticesCreator : MonoBehaviour
{
    private TorDimension dimension;
    private readonly int step = 6;

    private void Awake()
    {
        dimension = GetComponent<TorDimension>();
    }

    public Vector3[] GetTor(int alpha, int beta)
    {
        var centr = transform.position;
        Vector3[] vertices = new Vector3[360];
        int j = 0;

        try
        {
            for (int i = alpha; i <= beta; i += step)
                AddVertex(i, ref j, centr, vertices);
        }
        catch (IndexOutOfRangeException) {}

        return vertices;
    }

    private void AddVertex(int i, ref int j, Vector3 centr, Vector3[] vertices)
    {
        GetVertexes(centr, i, out Vector3 outsideVertex, out Vector3 insideVertex);
        vertices[j++] = outsideVertex;
        vertices[j++] = insideVertex;
    }

    private void GetVertexes(Vector3 centr, int i, out Vector3 outsideVertex, out Vector3 insideVertex)
    {
        var angle = i * Mathf.Deg2Rad;
        var radius = dimension.Radius;
        var thickness = dimension.Thickness;
        var ridiusSmall = radius - thickness;
        var cos = Mathf.Cos(angle);
        var sin = Mathf.Sin(angle);

        var xOutside = centr.x + cos * radius;
        var yOutside = centr.y + sin * radius;
        var xInside = centr.x + cos * ridiusSmall;
        var yInside = centr.y + sin * ridiusSmall;

        outsideVertex = new Vector3(xOutside, yOutside, 0);
        insideVertex = new Vector3(xInside, yInside, 0);
    }
}
