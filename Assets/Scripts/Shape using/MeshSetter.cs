
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshSetter : MonoBehaviour
{
    [SerializeField]
    private bool isFront = false;

    private void Start()
    {
        var creator = GetComponentInParent<MeshCreator>();
        var filter = GetComponent<MeshFilter>();
        var renderer = GetComponent<MeshRenderer>();

        filter.mesh = creator.MeshBack;
        renderer.material.color = Color.white;

        if (isFront)
        {
            filter.mesh = creator.MeshFront;
            renderer.material.color = Color.black;
        }
    }
}
