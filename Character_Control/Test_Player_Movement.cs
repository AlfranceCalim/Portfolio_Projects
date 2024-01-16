using UnityEngine;

public class Test_Player_Movement : MonoBehaviour
{
    [Header("Main Components")]
    [SerializeField] CharacterController playerController;
    [SerializeField] Transform groundCheck;

    [Header("Variables")]
    [SerializeField] float speed = 12;                // default value
    [SerializeField] float gravity = -9.81f;          // default value
    [SerializeField] float groundDistance = 0.4f;     // default value
    [SerializeField] LayerMask groundMask;

    // private variables
    Vector3 velocity;
    bool isGrounded;
    Animator playerAnim;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // check if character is grounded and has velocity of y less than 0. if true, velocity in y axis resets to -2f. 
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // check if character is grounded. if true 
        if (isGrounded)
            WalkAnim(x, z);

        Vector3 move = transform.right * x + transform.forward * z;

        velocity.y += gravity * Time.deltaTime;

        playerController.Move(move * speed * Time.deltaTime);

    }

    // called method for walking animation
    void WalkAnim(float x, float y)
    {
        playerAnim.SetFloat("VelX", x);
        playerAnim.SetFloat("VelY", y);
    }
}
