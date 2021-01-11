
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Spawner spawner;
    private bool hasCanClick = false;
    private Camera currentCamera;

    private void Start()
    {
        currentCamera = Camera.main;
    }

    private void Update()
    {
        if (hasCanClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (spawner.Tor != null)
                {
                    if (OnSectorClick())
                    {
                        ChangeTorColor(Color.green);
                        hasCanClick = false;
                    }
                    else
                        ChangeTorColor(Color.red);
                }
            }
        }
    }

    private void OnEnable()
    {
        spawner.NewTor += SetCanClick;
    }

    private void OnDisable()
    {
        spawner.NewTor -= SetCanClick;
    }

    private void SetCanClick()
    {
        hasCanClick = true;
    }

    private bool OnSectorClick()
    {
        var range = spawner.Tor.GetComponent<AngleRange>();
        var mouseScreen = Input.mousePosition;
        var mouseWorld = currentCamera.ScreenToWorldPoint(mouseScreen);
        mouseWorld.Set(mouseWorld.x, mouseWorld.y, 0);
        var angle = Vector3.SignedAngle(mouseWorld, Vector3.right, Vector3.back);
        if (angle < 0) angle = Mathf.Abs(angle + 180) + 180;

        return angle >= range.Alpha && angle <= range.Beta;
    }

    private void ChangeTorColor(Color color)
    {
        var renderers = spawner.Tor.GetComponentsInChildren<MeshRenderer>();

        foreach (var renderer in renderers)
        {
            var material = renderer.material;
            material.color = color;
        }
    }
}
