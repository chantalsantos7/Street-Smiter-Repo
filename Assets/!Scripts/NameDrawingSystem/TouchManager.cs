using UnityEngine;
using UnityEngine.InputSystem;
using StreetSmiter.Utilities;

[DefaultExecutionOrder(-1)]
public class TouchManager : MonoBehaviour
{
    public static TouchManager Instance;
    public DrawingTouchControls touchControls;
    private Camera mainCamera;
    public bool touchActive;

    #region Events
    public delegate void StartTouch(Vector2 position, bool touchActive);
    public event StartTouch OnStartTouch;

    public delegate void EndTouch(Vector2 position);
    public event EndTouch OnEndTouch;
    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        touchControls = new DrawingTouchControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        touchControls.Touch.PrimaryContact.started += StartTouchPrimary;
        touchControls.Touch.PrimaryContact.canceled += EndTouchPrimary;
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(Utils.ScreenToWorld(mainCamera, touchControls.Touch.PrimaryPosition.ReadValue<Vector2>()), true);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(Utils.ScreenToWorld(mainCamera, touchControls.Touch.PrimaryPosition.ReadValue<Vector2>()));
    }

    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCamera, touchControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}
