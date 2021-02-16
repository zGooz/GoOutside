
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tor;
    private Button button;
    private float time;

    public event UnityAction NewTor;
    public GameObject Tor { get; set; } = null;

    private void Awake()
    {
        var widget = GameObject.FindGameObjectWithTag("Buttons");
        button = widget.GetComponent<Button>();

        var scaler = tor.GetComponent<TorScaler>();
        var evalute = scaler.MaxEvalute;
        var step = scaler.Step;

        time = (step / evalute) * 600f;
    }

    private void OnEnable()
    {
        button.Click += RunSpawn;
    }

    private void OnDisable()
    {
        button.Click -= RunSpawn;
    }

    private void RunSpawn()
    {
        StartCoroutine(Respawn());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(time);
        SpawnTor();
        StartCoroutine(Respawn());
    }

    private void SpawnTor()
    {
        var obstacle = Instantiate(tor);
        Destroy(obstacle, time);
        Tor = obstacle;
        NewTor?.Invoke();
    }
}
