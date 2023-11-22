using UnityEngine;

public class LightManager : MonoBehaviour
{
    private void Awake()
    {
        Light light = GetComponent<Light>();
        light.range += light.range * ((RoomData.GetWidth() + RoomData.GetHeight() + RoomData.GetLength()) / 3.0f);

    }
}
