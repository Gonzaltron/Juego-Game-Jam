using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name Reference")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name References")]
    [SerializeField] private string movement = "Move";
    [SerializeField] private string rotation = "Look";
    [SerializeField] private string heart = "Heart";
    [SerializeField] private string lungs = "Lungs";
    [SerializeField] private string leftEye = "LeftEye";
    [SerializeField] private string rightEye = "RightEye";
    [SerializeField] private string pause = "Pause";


    private InputAction movementAction;
    private InputAction rotationAction;
    private InputAction heartAction;
    private InputAction lungsAction;
    private InputAction leftEyeAction;
    private InputAction rightEyeAction;
    private InputAction pauseAction;

    public Vector2 MovementInput { get; private set; }
    public Vector2 RotationInput { get; private set; }
    public bool HeartTriggered { get; private set; }
    public bool LungsTriggered { get; private set; }
    public bool LeftEyeTriggered { get; private set; }
    public bool RightEyeTriggered { get; private set; }
    public bool PauseTriggered { get; set; }

    private void Awake()
    {
        InputActionMap mapReference = playerControls.FindActionMap(actionMapName);

        movementAction = mapReference.FindAction(movement);
        rotationAction = mapReference.FindAction(rotation);
        heartAction = mapReference.FindAction(heart);
        lungsAction = mapReference.FindAction(lungs);
        leftEyeAction = mapReference.FindAction(leftEye);
        rightEyeAction = mapReference.FindAction(rightEye);
        pauseAction = mapReference.FindAction(pause);

        SubscribeActionValuesToInputEvents();
    }

    private void SubscribeActionValuesToInputEvents()
    {
        movementAction.performed += inputInfo => MovementInput = inputInfo.ReadValue<Vector2>();
        movementAction.canceled += inputInfo => MovementInput = Vector2.zero;

        rotationAction.performed += inputInfo => RotationInput = inputInfo.ReadValue<Vector2>();
        rotationAction.canceled += inputInfo => RotationInput = Vector2.zero;

        heartAction.performed += inputInfo => HeartTriggered = true;
        heartAction.canceled += inputInfo => HeartTriggered = false;

        lungsAction.performed += inputInfo => LungsTriggered = true;
        lungsAction.canceled += inputInfo => LungsTriggered = false;

        leftEyeAction.performed += inputInfo => LeftEyeTriggered = true;
        leftEyeAction.canceled += inputInfo => LeftEyeTriggered = false;

        rightEyeAction.performed += inputInfo => RightEyeTriggered = true;
        rightEyeAction.canceled += inputInfo => RightEyeTriggered = false;

        pauseAction.performed += inputInfo => PauseTriggered = true;
        pauseAction.canceled += inputInfo => PauseTriggered = false;

    }

    private void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    private void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.TryCompleteTask(other);
    }
}
