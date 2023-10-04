using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float sensibility;
    [SerializeField] private float gravityForce;
    [SerializeField] private Fabrik fabrikRightArm;
    [SerializeField] private Transform rightArmPivot;
    [SerializeField] private Fabrik fabrikLeftArm;
    [SerializeField] private Transform leftArmPivot;
    private Transform cam;
    private Vector2 inputRot;
    private Vector3 dir;

    public GameObject SettingsCanvas;
    public static bool _isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        cam = transform.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
                _isPaused = false;
                SettingsCanvas.SetActive(false);
            }
            else if ( _isPaused == false)
            {
                Cursor.lockState = CursorLockMode.None;
                _isPaused = true;
                SettingsCanvas.SetActive(true);
            }
        }
        
        if (_isPaused) return; 
        Movement();
        RotateMouse();

        fabrikRightArm.startPosition = rightArmPivot.position;
        fabrikLeftArm.startPosition = leftArmPivot.position;

    }

    private void Movement()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");

        Vector3 movePlayer = dir.normalized.x * cam.right + dir.normalized.z * transform.forward;

        Vector3 gravity = Vector3.down * Time.deltaTime * gravityForce;

        characterController.Move((movePlayer * Time.deltaTime * maxSpeed) + gravity);
    }

    private void RotateMouse()
    {
        inputRot.x = Input.GetAxis("Mouse X") * sensibility;
        inputRot.y = Input.GetAxis("Mouse Y") * sensibility;

        transform.Rotate(Vector3.up * inputRot.x * sensibility);

        float angle = (cam.localEulerAngles.x - inputRot.y * sensibility + 360) % 360;

        if (angle > 180) angle -= 360;
        angle = Mathf.Clamp(angle, -80, 80);

        cam.localEulerAngles = Vector3.right * angle;
    }
}