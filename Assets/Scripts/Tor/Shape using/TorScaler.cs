
using UnityEngine;

public class TorScaler : MonoBehaviour
{
    [SerializeField]
    private Spawner spawner;
    private Player player;
    private float evalute = 1f;
    private readonly float step = 0.003f;
    private readonly float minEvalute = 0.06f;
    private Transform form;

    public float MaxEvalute => 1f;
    public float Step => step;

    private void Awake()
    {
        var manager = GameObject.FindGameObjectWithTag("Player");
        player = manager.GetComponent<Player>();
        form = GetComponent<Transform>();
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

        if (evalute <= minEvalute) 
        {
            Destroy(gameObject);
        }

        form.localScale = new Vector3(evalute, evalute, 0);
    }
}
