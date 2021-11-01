using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Controls controls = null;

    public Transform target;
    public Transform pivot;
    public Vector3 distance;
    public float maxAngle = 60f;
    public float minAngle = 60f;
    public bool setValue = false;
    public bool invertY = true; //hvem vil ha false?
    //invert x også?

    Vector2 rotate;
    public float rotateSpeed;
    private float targetXAngle, targetYAngle;
    private void Awake()
    {
        controls = new Controls();
        controls.Player.Camera.performed += context => rotate = context.ReadValue<Vector2>() * rotateSpeed;
        controls.Player.Camera.canceled += context => rotate = Vector2.zero;
    }
    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();
    void Start()
    {
        if (!setValue) 
        {
            distance = target.position - transform.position;
        }
        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
        
    }
    void  LateUpdate()
    {

        pivot.transform.position = target.transform.position;
        transform.LookAt(target);

        pivot.Rotate(0, rotate.x, 0);

        if (invertY) //gyaku?
        {
            pivot.Rotate(-rotate.y, 0, 0);
        } else
        {
            pivot.Rotate(rotate.y, 0, 0);
        }

        // move the camera based on the current rotation of the target and the original offset
        float desiredYAngle = pivot.eulerAngles.y;

        float desiredXAngle = pivot.eulerAngles.x;

        //Limit the up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxAngle, desiredYAngle, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minAngle, desiredYAngle, 0);
        }

        //limit pivot , change to public var angle
        /*
        if (pivot.rotation.eulerAngles.x > maxAngle && pivot.rotation.eulerAngles.x < 180.0f)
        {
            pivot.rotation = Quaternion.Euler(maxAngle, pivot.eulerAngles.y, 0.0f);
        }

        if (pivot.rotation.eulerAngles.x > 180.0f && pivot.rotation.eulerAngles.x < 360f + minAngle)
        {
            pivot.rotation = Quaternion.Euler(360.0f + minAngle, pivot.eulerAngles.y, 0.0f);
        }*/

        targetYAngle = pivot.eulerAngles.y;
        targetXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(targetXAngle,targetYAngle,0);
        transform.position = target.position - (rotation * distance);
        
        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(
                transform.position.x, 
                target.position.y - 0.5f, 
                transform.position.z);
        }


    }

}
