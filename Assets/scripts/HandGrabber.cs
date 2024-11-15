using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR;


public class HandGrabber : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor directInteractor; // The interactor component that handles direct interaction.
    public Transform handTransform;             // The transform representing the tracked hand.

    private UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable grabbedObject; // The current object being grabbed.

    private void Start()
    {
        if (directInteractor == null)
        {
            directInteractor = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor>();
        }
    }

    private void Update()
    {
        if (IsPinchGestureDetected())
        {
            TryGrabObject();
        }
        else if (grabbedObject != null)
        {
            ReleaseObject();
        }
    }

    // Replace this method with actual hand tracking gesture detection logic.
    private bool IsPinchGestureDetected()
    {
        // Example: Check if a pinch gesture is being performed (this is simplified logic).
        // Use actual hand tracking data or API calls for precise detection.
        bool isPinching = XRHandSubsystem.TryGetJoint(XRHandJointID.IndexTip, out XRHandJoint joint);
        return (!isPinching && !joint.TryGetPose(out Pose pose));// Simulate pinch with left mouse button for testing.
    }

    private void TryGrabObject()
    {
        if (grabbedObject == null && directInteractor.hasHover)
        {
            // Check for the closest interactable object.
            UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable interactable = directInteractor.firstInteractableSelected;
            if (interactable != null)
            {
                grabbedObject = interactable;
                directInteractor.interactionManager.SelectEnter(directInteractor, interactable);
            }
        }
    }

    private void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            directInteractor.interactionManager.SelectExit(directInteractor, grabbedObject);
            grabbedObject = null;
        }
    }
}
