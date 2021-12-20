using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject CurrentGO;
    public string GOName;
    public bool IsInteracting = false;

    private void Awake()
    {
        GOName = CurrentGO.name;
    }

    private void OnMouseDown()
    {
        IsInteracting = true;
    }

    private void OnMouseUp()
    {
        IsInteracting = false;
    }

    public virtual void Interact() { }
}
