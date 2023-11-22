using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejctRegulator : MonoBehaviour
{
    public Vector3 rotation;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "RayCastSphere")
        {
            if(collision.gameObject.transform.childCount > 0)
            {
                GameObject tmp = collision.gameObject.transform.GetChild(0).gameObject;
                if (rotation==(Vector3.zero))
                {
                    tmp.transform.rotation = Quaternion.Euler(tmp.GetComponent<ObjectManager>().initialRotation);
                }
                tmp.transform.rotation = Quaternion.Euler(rotation);  
            }
        }
        print("collision detected");
    }
}
