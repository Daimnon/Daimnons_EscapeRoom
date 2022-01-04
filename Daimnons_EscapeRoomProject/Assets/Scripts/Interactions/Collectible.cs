using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    private Image _inventoryPanel;

    [SerializeField]
    private Image _equippedSlotImage;

    [SerializeField]
    private int _itemId;

    [SerializeField]
    private bool _isItemAcquired = false ,_isItemEquipped = false;

    private Vector3 _originalImagePos;
    private int _currentCycleIndex = 0;

    private void Awake()
    {
        _originalImagePos = _equippedSlotImage.transform.position;
    }

    private void OnMouseDown()
    {
        Debug.Log($"Trying to collect {gameObject.name}");
        _isItemAcquired = true;
        Collect();
    }

    public void Collect()
    {
        _currentCycleIndex = _itemId;
        _currentCycleIndex = Mathf.Clamp(_currentCycleIndex, 0, UIManager.Instance.AllCollectibles.Count - 1);

        Debug.Log(_currentCycleIndex);

        CollectGo();
        ShowImage();
    }

    private void CollectGo()
    {
        if (_isItemAcquired)
            UIManager.Instance.AllCollectibles[_currentCycleIndex].SetActive(true);
    }

    private void ShowImage()
    {
        if (_isItemAcquired)
            UIManager.Instance.AllImages[_currentCycleIndex].enabled = true;
    }

    public void Equip()
    {
        if (!_isItemEquipped)
        {
            Debug.Log("equip");
            _isItemEquipped = true;
            _equippedSlotImage.transform.parent = UIManager.Instance.EquippedItemSlotImage.transform;
            _equippedSlotImage.transform.position = UIManager.Instance.EquippedItemSlotImage.transform.position;
        }
        else
        {
            Debug.Log("unequip");
            _isItemEquipped = false;
            _equippedSlotImage.transform.parent = _inventoryPanel.gameObject.transform;
            _equippedSlotImage.transform.position = _originalImagePos;
        }
    }
}
