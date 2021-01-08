
using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] 
    private GameObject tor;
    private float time;

    private void Awake()
    {
        var scaler = tor.GetComponent<TorScaler>();
        var evalute = scaler.GetMaxEvalute();
        var step = scaler.GetStep();

        time = (step / evalute) * 600f;
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        SpawnTor();
        yield return new WaitForSeconds(time);
        StartCoroutine(Respawn());
    }

    private void SpawnTor()
    {
        var obstacle = Instantiate(tor);
        Destroy(obstacle, time);
    }
}
