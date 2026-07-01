using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 5f;
    public GameObject promptTextObject;
    public TMP_Text promptText;

    void Start()
    {
        promptTextObject.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                string message = interactable.GetPrompt();

                if (!string.IsNullOrEmpty(message))
                {
                    promptTextObject.SetActive(true);
                    promptText.text = message;

                    if (Input.GetKeyDown(interactable.GetInteractKey()))
                    {
                        interactable.Interact();
                        promptTextObject.SetActive(false);
                    }

                    return;
                }
            }
        }

        promptTextObject.SetActive(false);
    }
}