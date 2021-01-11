
using UnityEngine;

[RequireComponent(typeof(TriangleCreator))]
[RequireComponent(typeof(VerticesCreator))]
[RequireComponent(typeof(MeshCreator))]
[RequireComponent(typeof(AngleRange))]

public class TorBuilder : MonoBehaviour
{
    private TriangleCreator triangleMaker;

    private void Start()
    {
        triangleMaker = GetComponent<TriangleCreator>();

        var verticesMaker = GetComponent<VerticesCreator>();
        var meshMaker = GetComponent<MeshCreator>();
        var range = GetComponent<AngleRange>();

        var verticesForFirstTor = verticesMaker.GetTor(0, 360);
        var verticesForSecondTor = verticesMaker.GetTor(range.Alpha, range.Beta);

        var trianglesForFirstTor = triangleMaker.MakeTriangles(verticesForFirstTor);
        var trianglesForSecondTor = triangleMaker.MakeTriangles(verticesForSecondTor);

        ApplyTorChanges(trianglesForFirstTor, meshMaker.MeshBack, verticesForFirstTor);
        ApplyTorChanges(trianglesForSecondTor, meshMaker.MeshFront, verticesForSecondTor);
    }

    private void ApplyTorChanges(int[] triangles, Mesh mesh, Vector3[] vectors)
    {
        if (triangleMaker.TryTriangleExists(triangles))
        {
            mesh.vertices = vectors;
            mesh.triangles = triangles;
        }
    }
}
