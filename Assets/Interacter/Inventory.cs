using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    private bool hasTrash = false;

    public bool HasTrash()
    {
        return hasTrash;
    }

    public void SetHasTrash(bool value)
    {
        hasTrash = value;
    }
}