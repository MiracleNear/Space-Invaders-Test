using UnityEngine;

public class FixedScreenResolution : MonoBehaviour
{
    [SerializeField] private Vector2 _resolution;

    private Camera _camera;
    
    void Start()
    {
        Screen.SetResolution((int) _resolution.x, (int)_resolution.y, FullScreenMode.Windowed);
    }
}
