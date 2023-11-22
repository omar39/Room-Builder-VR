using Valve.VR;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [HideInInspector]
    public bool isGrabbed = false;
    [HideInInspector]
    public bool isSelected = false;
    [HideInInspector]
    public Vector3 initialRotation;

    public SteamVR_Action_Boolean Confirm;

    public SteamVR_Action_Boolean Grab;

    //public GameObject Highlighter;
    private void Start()
    {
        //Highlighter.GetComponent<MeshFilter>().mesh = this.gameObject.GetComponent<MeshFilter>().mesh;
        //Highlighter.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);

        initialRotation = transform.rotation.eulerAngles;
    }
    void Update()
    {
        if (isGrabbed)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.Rotate(0, 90f, 0);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                transform.Rotate(0, -90, 0);
            }
            if (Input.GetMouseButtonDown(0) || Confirm.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                transform.parent = null;
                isGrabbed = false;
            }
        }

        if (isSelected)
        {
            //Highlighter.SetActive(true);
        }
       // else
            //Highlighter.SetActive(false);
    }
    //To select the object for edit
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "RayCastSphere" && (Input.GetMouseButtonDown(1) || Grab.GetStateDown(SteamVR_Input_Sources.RightHand)))
        {
            Transform pointerTrans = GameObject.Find("Sphere").transform;
            transform.parent = pointerTrans;
            transform.position = pointerTrans.position - Vector3.up * pointerTrans.localScale.x;
            isGrabbed = true;
            print("the object is grabbed");
        }
        // for selecting the object
        else if(other.tag == "RayCastSphere" && Input.GetKeyDown(KeyCode.Tab))
        {
            isSelected = !isSelected;
            print(isSelected);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "Wall")
    }
}
