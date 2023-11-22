using Valve.VR;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VRButtonHandler : MonoBehaviour
{
    public InputField length, width, height;

    public void StartTweaking()
    {
        RoomData.SetLength(float.Parse(length.text));
        RoomData.SetWidth(float.Parse(width.text));
        RoomData.SetHeight(float.Parse(height.text));
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
