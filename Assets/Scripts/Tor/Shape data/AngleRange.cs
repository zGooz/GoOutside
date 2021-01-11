
using UnityEngine;

public class AngleRange : MonoBehaviour
{
    private readonly int range = 60;

    public int Alpha { get; private set; }
    public int Beta { get; private set; }

    private void Awake()
    {
        var r = new System.Random();
        var next = r.Next(0, 360 - range);
        Alpha = next;
        Beta = Alpha + range;
    }
}
