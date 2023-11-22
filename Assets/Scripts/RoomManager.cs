using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject Room;
    private void Awake()
    {
        Vector3 size = new Vector3(RoomData.GetWidth(), RoomData.GetHeight() , RoomData.GetLength());
        GameObject instance = Instantiate(Room, Room.transform);
        instance.transform.localScale = size;
    }
}
