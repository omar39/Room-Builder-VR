using UnityEngine;

public class SphereMeta : MonoBehaviour
{
    Transform childPosition;
    private void Start()
    {
        childPosition = transform;
        childPosition.position = transform.position - Vector3.up * transform.localScale.x;
    }
    public Transform getChildPosition()
    {
        return childPosition;
    }
}
