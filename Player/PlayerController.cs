using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jump;
    public float gravityScale;

    public CharacterController player;
    public GameObject playerModel;
    public Animator anime;
    public Transform pivot;
    public float rotateSpeed;

    private Controls controls = null;
    private Vector3 movement = new Vector3().normalized;
    private Vector2 movementInput;

    private void Awake()
    {
        player = GetComponent<CharacterController>();
        controls = new Controls();
        controls.Player.Jump.performed += context => Jump();
        controls.Player.Movement.performed += context => movementInput = context.ReadValue<Vector2>();
        controls.Player.Movement.canceled += context => movementInput = Vector2.zero;


    }
    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();
    void Update()
    {
        Move();
        Animate();
    }
    private void Move()
    {

        //movement.x = movementInput.x * moveSpeed;
        //movement.z = movementInput.y * moveSpeed;

        float yStore = movement.y;

        movement = (transform.forward * movementInput.y) + (transform.right * movementInput.x);
        movement = movement.normalized * moveSpeed;

        movement.y = yStore + (Physics.gravity.y * gravityScale * Time.deltaTime);

        player.Move(movement * Time.deltaTime);
        if (player.isGrounded)
        {
            movement.y = 0;
        }

        //face pivot point
        if(movementInput.x != 0 || movementInput.y != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(movement.x, 0f, movement.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
    private void Animate()
    {
        anime.SetBool("isGrounded",player.isGrounded);
        anime.SetFloat("Speed", (Mathf.Abs(movementInput.y)) + (Mathf.Abs(movementInput.x)));
    }
    public void Jump()
    {
        if(player.isGrounded)
        {
            movement.y = jump;
        }
        
    }

}
