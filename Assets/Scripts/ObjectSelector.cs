using UnityEngine;
using Valve.VR;
using System.Collections;

public class ObjectSelector : MonoBehaviour
{
    public string[] ItemsNames;
    public GameObject[] Items;

    public TextMesh text;
    GameObject item;
    int index = 0;
    Transform pointerTrans;

    bool goingDown = false, goingUp = false;

    public SteamVR_Action_Vector2 touchpadAction;
    public SteamVR_Action_Boolean Select;
    public SteamVR_Action_Boolean Abort;
    public SteamVR_Action_Boolean Click;

    private void Start()
    {
        item = null;
        pointerTrans = GameObject.Find("Sphere").transform;
    }

    private void Update()
    {
        Vector2 touchpadVals = touchpadAction.GetAxis(SteamVR_Input_Sources.LeftHand);

        TouchInput(touchpadVals);
        if (Input.GetKeyDown(KeyCode.UpArrow) || goingUp)
        {
            index--;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) || goingDown)
        {
            index++;
        }
        index = Mathf.Clamp(index, 0, Items.Length - 1);
        text.text = "Add a(n) " + ItemsNames[index];
        if(Input.GetKeyDown(KeyCode.Return) || Select.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            SelectItem(index);
        }
        if(Input.GetKeyDown(KeyCode.Escape) || Abort.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            ClearAllSelections();
        }
        goingDown = goingUp = false;
    }
    void SelectItem(int val)
    {
        ClearAllSelections();
        print(val);
        item = Instantiate(Items[val], pointerTrans.position - Vector3.up * pointerTrans.transform.localScale.x, Quaternion.identity);
        item.transform.parent = pointerTrans;
        item.GetComponent<ObjectManager>().isGrabbed = true;    
    }

    void TouchInput(Vector2 touchpadVal)
    {
        if (touchpadVal.y < -0.5f && Click.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            //yield return new WaitForSeconds(0.3f);
            goingDown = true;
            print("falling haard");
        }
        else
            goingDown = false;

        if (touchpadVal.y > 0.5f && (touchpadVal.y > 0 && Click.GetStateDown(SteamVR_Input_Sources.LeftHand)))
        {
            //yield return new WaitForSeconds(0.3f);
            goingUp = true;
            print("going up");
        }
        else
            goingUp = false;


        print(touchpadVal);
    }

    void ClearAllSelections()
    {
        for (int i = 0; i < pointerTrans.childCount; ++i)
        {
            GameObject lala = pointerTrans.GetChild(i).gameObject;
            Destroy(lala);
        }
    }

}
