using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 1f;
    [SerializeField] private float _xTurnSpeed = 3f;
    [SerializeField] private float _yTurnSpeed = 3f;
    [SerializeField] private ForceMode _forceMode;
    private Rigidbody rb;
    //Creating a player singleton for easy access to the player all the time ( Since there will only be one player )
    public static PlayerMovement player { get; private set; }

    void Awake()
    {
        if (player == null) //Setting the player to this game object if it's not already assigned ( Doing this in Awake ensures that any other object will be able to find the player. )
            player = this;
        rb = GetComponent<Rigidbody>();
        _forceMode = ForceMode.VelocityChange;
    }
    // Start is called before the first frame update
    void Start() //Create ground check and add different type of controls for each(so that you can use moving platforms)
    {

    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Input.GetAxis("Horizontal") * playerSpeed * Time.fixedDeltaTime, 0, Input.GetAxis("Vertical") * playerSpeed * Time.fixedDeltaTime, _forceMode); //Is this good?
    }

    //void RotatePlayer()
    //{
    //    float mouseX = Input.GetAxis("Mouse X");
    //    float mouseY = Input.GetAxis("Mouse Y");

    //    Vector3 rotation = new Vector3(
    //        mouseY * _yTurnSpeed * Time.deltaTime,
    //        mouseX * _xTurnSpeed * Time.deltaTime,
    //        0
    //    );

    //    transform.Rotate(rotation, Space.Self);

    //}

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * _xTurnSpeed, 0, Space.World);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Deadly")
    //    {
    //        PlayerHealth.playerHealth.TakeDamage();
    //    }
    //}

    void OnDestroy()
    {
        player = null;
    }
}
