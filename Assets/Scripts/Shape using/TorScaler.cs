
using UnityEngine;

public class TorScaler : MonoBehaviour
{
    private Transform form;
    private float evalute = 1f;
    private readonly float step = 0.003f;

    private void Awake()
    {
        form = GetComponent<Transform>();
    }

    private void Update()
    {
        evalute -= step;
        form.localScale = new Vector3(evalute, evalute, 0);
    }

    public float GetStep()
    {
        return step;
    }

    public float GetMaxEvalute()
    {
        return 1f;
    }
}
