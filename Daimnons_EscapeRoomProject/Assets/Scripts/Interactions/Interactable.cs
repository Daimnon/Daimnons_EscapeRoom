using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
    private List<GameObject> _interactables;

    [SerializeField]
    private int _itemId;

    [SerializeField]
    private bool _isItemTouched = false;
    #endregion

    #region Fields
    private Vector3 _originalImagePos;
    private int _currentCycleIndex = 0;
    #endregion

    #region Unity Callbacks
    private void OnMouseDown()
    {
        Debug.Log($"Trying to collect {gameObject.name}");
        _isItemTouched = true;
        Interact();
    }
    #endregion

    #region Methods
    private void OpenLibraryDoor()
    {
        if (_isItemTouched)
            UIManager.Instance.IsLibraryLocked = false;
    }
    #endregion

    #region Events
    public void Interact()
    {
        _currentCycleIndex = _itemId;
        _currentCycleIndex = Mathf.Clamp(_currentCycleIndex, 0, _interactables.Count - 1);

        Debug.Log(_currentCycleIndex);

        OpenLibraryDoor();
    }
    #endregion
}
