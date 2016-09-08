using UnityEngine;
using System.Collections;

public class ChrecterController : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update() 
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            if (PlayerMovement.playerDirection == PlayerDirection.FORWARD)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }
            else
            {
                moveDirection = new Vector3(-(Input.GetAxis("Horizontal")), 0, Input.GetAxis("Vertical"));
            }
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        Debug.Log("controller");
    }
}
