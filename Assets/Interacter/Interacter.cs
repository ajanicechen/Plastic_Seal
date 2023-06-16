using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interacter : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUi _interactionPromptUi;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private Inventory _inventory;

    private Interactable _interactable;

    private void Start()
{
    _inventory = GetComponent<Inventory>();
}



    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if(_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<Interactable>();

            if(_interactable != null)
            {
                if (!_interactionPromptUi.IsDisplayed) _interactionPromptUi.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame) _interactable.Interact(this);
                
            }
        }

        else
        {
            if(_interactable != null) _interactable = null;
            if(_interactionPromptUi.IsDisplayed) _interactionPromptUi.Close();
        }
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
