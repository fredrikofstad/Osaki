using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;

public class Player : AdvancedWalkerController
{
    //states
    private bool paused; //not the same as regular pause, used in cutscenes and talking
    private bool isSitting; //if need be in future make state enum?

    //for switching camera
    private Quaternion lastCameraFacing;
    private Vector2 lastCameraInput;
    private bool changedCamera;

    //child references
    [SerializeField] private GameObject modelRoot;
    public Transform cameraControl; //used in PlayerCam
    public Transform cameraTarget; //used in PlayerCam

    //movement variables
    [SerializeField] private float runSpeed = 6;
    [SerializeField] private float walkSpeed = 2;

    protected override void Update()
    {
        base.Update();
        cameraTransform = Camera.allCameras[0].transform;

        if (Input.GetKey(KeyCode.LeftShift)) //make input class?
        {
            movementSpeed = walkSpeed;
        }
        else
        {
            movementSpeed = runSpeed;
        }

    }

    protected override Vector3 CalculateMovementDirection()
    {
        if(GameManager.instance.inCutscene)
            return Vector3.zero;
        if (paused)
            return Vector3.zero;
        if (characterInput == null)
            return Vector3.zero;

        var input = new Vector2(characterInput.GetHorizontalMovementInput(), characterInput.GetVerticalMovementInput());

        if (changedCamera)
        {
            lastCameraInput = input;

            if (Vector3.Dot(input, lastCameraInput) <= 0f)
            {
                lastCameraFacing = cameraTransform.rotation;
                changedCamera = false;
            }
        }
        else
        {
            lastCameraFacing = cameraTransform.rotation;
        }
        
        Vector3 _velocity = Vector3.zero;

        //for no camera
        if (cameraTransform == null)
        {
            _velocity += tr.right * input.x;
            _velocity += tr.forward * input.y;
        }
        else
        {
            _velocity += Vector3.ProjectOnPlane(lastCameraFacing * Vector3.right, tr.up).normalized * input.x;
            _velocity += Vector3.ProjectOnPlane(lastCameraFacing * Vector3.forward, tr.up).normalized * input.y;
        }
        if (_velocity.magnitude > 1f)
            _velocity.Normalize();

        return _velocity;

    }
    protected override bool IsJumpKeyPressed()
    {
        if(GameManager.instance.inCutscene)
            return false;
        if (paused)
            return false;
        return base.IsJumpKeyPressed();
    }
    public void Pause()
    {
        paused = true;
    }
    public void UnPause()
    {
        paused = false;
    }
    public void ChangeCamera()
    {
        changedCamera = true;
    }
    public void Talk(GameObject target)
    {
        Pause();
        var adjusted = target.transform.position;
        adjusted.y = transform.GetChild(0).transform.position.y;
        transform.GetChild(0).transform.LookAt(adjusted);
        var adjustedPlayer = transform.position;
        adjustedPlayer.y = target.transform.position.y;
        target.transform.LookAt(adjustedPlayer);
    }
    public void SitDown(Vector3 pos, Quaternion rot)
    {
        if (!isSitting)
        {
            Pause();
            GetComponentInChildren<Animator>().SetTrigger("isSitting");
            modelRoot.transform.rotation = rot;
            transform.position = new Vector3(pos.x, transform.position.y, pos.z);
            isSitting = true;
        }
    }
    public void StandUp()
    {
        GetComponentInChildren<Animator>().SetTrigger("doneSitting");
        Invoke("UnPause", 2.3f);
        isSitting = false;
    }
    public void OpenDoor(Vector3 pos, Quaternion rot)
    {
        Pause();
        GetComponentInChildren<Animator>().SetTrigger("isOpening");
        modelRoot.transform.rotation = rot;
        transform.position = new Vector3(pos.x, pos.y - 0.2f, pos.z);
    }
    public void Dance(bool on = true)
    {
        if(on)
        {
            Pause();
            GetComponentInChildren<Animator>().SetTrigger("isDancing");
        }
        else
        {
            UnPause();
            GetComponentInChildren<Animator>().SetTrigger("doneDancing");
        }
    }

}
