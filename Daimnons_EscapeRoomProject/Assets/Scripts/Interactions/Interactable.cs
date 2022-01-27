using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Interactable : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _interactables;

    [SerializeField]
    private int _itemId;

    [SerializeField]
    private bool _isItemTouched = false;

    private Vector3 _originalImagePos;
    private int _currentCycleIndex = 0;

    private void OnMouseDown()
    {
        Debug.Log($"Trying to collect {gameObject.name}");
        _isItemTouched = true;
        Interact();
    }

    public void Interact()
    {
        _currentCycleIndex = _itemId;
        _currentCycleIndex = Mathf.Clamp(_currentCycleIndex, 0, _interactables.Count - 1);

        Debug.Log(_currentCycleIndex);

        OpenLibraryDoor();
    }

    private void OpenLibraryDoor()
    {
        if (_isItemTouched)
            UIManager.Instance.IsLibraryLocked = true;
    }
}
