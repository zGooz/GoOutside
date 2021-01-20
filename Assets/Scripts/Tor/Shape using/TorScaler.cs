
using UnityEngine;

public class TorScaler : MonoBehaviour
{
    [SerializeField]
    private Spawner spawner;
    private Player player;
    private float evalute = 1f;
    private readonly float step = 0.003f;

    private void Awake()
    {
        var manager = GameObject.FindGameObjectWithTag("Player");
        player = manager.GetComponent<Player>();
    }

    private void OnDestroy()
    {
        spawner.Tor = null;

        if (player.GetCanClick())
        {
            player.ReloadGame(false);
        }
    }

    private void Update()
    {
        evalute -= step;
        transform.localScale = new Vector3(evalute, evalute, 0);
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
