using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Collectible : MonoBehaviour
{
    //[SerializeField]
    //private Renderer _itemRend;
    //
    //[SerializeField]
    //private Collider _itemCol;

    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    private Image _inventoryPanel, _equippedSlotImage;

    [SerializeField]
    private int _itemId;

    [SerializeField]
    private bool _isItemAcquired = false, _isItemEquipped = false;

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
        Destroy(gameObject);
        Collect();
    }

    public void Collect()
    {
        _currentCycleIndex = _itemId;
        _currentCycleIndex = Mathf.Clamp(_currentCycleIndex, 0, UIManager.Instance.AllCollectibles.Count - 1);

        Debug.Log(_currentCycleIndex);
        StartCoroutine(_uiManager.DisplayLogText($"Collected: {gameObject.name}"));

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

    /* Equip
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
    */
}
