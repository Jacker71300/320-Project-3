using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    public InteractableScript currentInteractable;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed"); 
            if (currentInteractable != null)
            {
                currentInteractable.Trigger();
            }
        }

    }

    public void SetInteractable(InteractableScript interactable)
    {
        currentInteractable = interactable;
    }

    public void RemoveInteractable()
    {
        currentInteractable = null;
    }
}
