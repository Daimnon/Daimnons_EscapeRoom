using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Collectible : MonoBehaviour
{
    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    private Image _equippedSlotImage;

    [SerializeField]
    private int _itemId;

    [SerializeField]
    private bool _isItemAcquired = false;

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
}
