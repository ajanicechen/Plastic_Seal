using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, Interactable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InteractionPromptUi _interactionPromptUi;
    [SerializeField] private AudioClip _pickupSound;


    public string InteractionPrompt => _prompt;

    public bool Interact(Interacter interacter)
    {
        Inventory inventory = interacter.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.SetHasTrash(true);
        }

        AudioSource.PlayClipAtPoint(_pickupSound, transform.position);

        // Destroy the trash object
        Destroy(gameObject);

        return true;
    }
}