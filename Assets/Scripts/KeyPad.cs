using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;
using UnityEngine.UI;
public class KeyPad : MonoBehaviour
{
    public float rayMaxDistance = 1000;
    public float RayOffset = 0.5f;
    public LayerMask KeyLayer;
    public LayerMask hitLayers;
    public SteamVR_Action_Boolean trigger;

    GameObject sphere;
    InputField textBox;
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
        bool ok = Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, hitLayers);
        SetRayInfo(hit);
        print(ok);

        if(trigger.GetStateDown(SteamVR_Input_Sources.LeftHand) || Input.GetKeyDown(KeyCode.X))
        {
            CheckInputField(hit);
            CheckButtonPressed(hit);
        }
    }
    void SetRayInfo(RaycastHit hit)
    {
        line.SetPosition(0, transform.position);
        line.SetPositions(new Vector3[] { transform.position + (Vector3.forward + Vector3.down) * RayOffset, hit.point });
        sphere.transform.position = hit.point;
    }
    void CheckInputField(RaycastHit hit)
    {
        if (hit.collider.tag == "EditorOnly")
        {
            GameObject tmp = hit.collider.gameObject.transform.parent.gameObject;
            if (tmp.name.Contains("InputField"))
            {
                textBox = tmp.GetComponent<InputField>();
                textBox.Select();
            }

        }
    }
    void CheckButtonPressed(RaycastHit hit)
    {
        if (textBox == null)
            return;
        print("hit layer is: " + hit.collider.gameObject.layer);
        print((KeyLayer.value >> hit.collider.gameObject.layer));
        if((KeyLayer.value >> hit.collider.gameObject.layer) == 1)
        {
            string Key = hit.collider.name;
            print(Key);
            switch(Key)
            {
                case "1":
                    textBox.text += "1";
                    break;
                case "2":
                    textBox.text += "2";
                    break;
                case "3":
                    textBox.text += "3";
                    break;
                case "4":
                    textBox.text += "4";
                    break;
                case "5":
                    textBox.text += "5";
                    break;
                case "6":
                    textBox.text += "6";
                    break;
                case "7":
                    textBox.text += "7";
                    break;
                case "8":
                    textBox.text += "8";
                    break;
                case "9":
                    textBox.text += "9";
                    break;
                case "0":
                    textBox.text += "0";
                    break;
                case "delete":
                    if(textBox.text.Length > 0)
                        textBox.text = textBox.text.Remove(textBox.text.Length - 1);
                    break;
                case "dot":
                    textBox.text += ".";
                    break;
               
            }
        }
    }
}
