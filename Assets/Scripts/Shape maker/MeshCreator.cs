
using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    public Mesh MeshBack { get; private set; }
    public Mesh MeshFront { get; private set; }

    private void Awake()
    {
        MeshBack = new Mesh();
        MeshFront = new Mesh();
    }
}
