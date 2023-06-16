using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trashcan : MonoBehaviour, Interactable
{
    [SerializeField] private string _prompt;
    [SerializeField] private AudioClip _pickupSound;
    [SerializeField] private AudioClip _failSound;



    public string InteractionPrompt => _prompt;

    public bool Interact(Interacter interacter)
    {
        Inventory inventory = interacter.GetComponent<Inventory>();
        if (inventory != null && inventory.HasTrash())
        {
            AudioSource.PlayClipAtPoint(_pickupSound, transform.position);
            return true;
        }
        else
        {
            AudioSource.PlayClipAtPoint(_failSound, transform.position);

            return false;
        }
    }
}