using UnityEngine;
using UnityEngine.UI;

public class ItemSelector : MonoBehaviour
{
    public Dropdown itemList;
    public GameObject[] Items;

    GameObject item = null;
    public void SelectItem(int val)
    {
        print(val);
        Transform pointerTrans = GameObject.Find("Sphere").transform;
        for (int i = 0; i < pointerTrans.childCount; ++i)
        {
            GameObject lala = pointerTrans.GetChild(i).gameObject;
            Destroy(lala);
        }
        

        

        //if (val == 0)
          //  return;

        item = Instantiate(Items[val - 1], pointerTrans.position - Vector3.up * pointerTrans.localScale.x, Quaternion.identity);
        item.transform.parent = pointerTrans;
        item.GetComponent<ObjectManager>().isGrabbed = true;

        //itemList.value = 0;
    }
}
