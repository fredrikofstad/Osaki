using UnityEngine;
using CMF;

public class AniController : MonoBehaviour
{
    private Player controller;
    private Animator animator;
    private Transform characterMeshTransform;

    private void Start()
    {
        controller = GetComponent<Player>();
    }
    public void GetReferences() //am I making soup??
    {
        animator = GetComponentInChildren<Animator>();
        characterMeshTransform = animator.transform;
    }

    private void Update()
    {
        if(animator != null)
        {
        //Handle grounded state
        bool _isGrounded = controller.IsGrounded();
        animator.SetBool("isGrounded", _isGrounded);
        //Handle movement velocity
        Vector3 _movementVelocity = controller.GetMovementVelocity();
        float _forwardSpeed = VectorMath.GetDotProduct(_movementVelocity, characterMeshTransform.forward);
        animator.SetFloat("speedForward", _forwardSpeed);
        }
    }

    public void OnPause()
    {
        if(!controller.isSitting) GetComponentInChildren<Animator>().SetTrigger("isPaused");
    }
    public void OnResume()
    {
        if (!controller.isSitting) GetComponentInChildren<Animator>().SetTrigger("isResumed");
    }
}
