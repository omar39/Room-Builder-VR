using UnityEngine;

public class RayCasstHandler : MonoBehaviour
{

    public float rayMaxDistance = 1000;
    public float RayOffset = 0.5f;
    public LayerMask AvailLayers;
    GameObject sphere;

    LineRenderer line;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
        sphere = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        bool ok = Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, AvailLayers);
        SetRayInfo(hit);
        print(ok);
    }
    void SetRayInfo(RaycastHit hit)
    {
        line.SetPosition(0, transform.position);
        line.SetPositions(new Vector3[] { transform.position + (Vector3.forward + Vector3.down) * RayOffset, hit.point });
        sphere.transform.position = hit.point;
    }
}
