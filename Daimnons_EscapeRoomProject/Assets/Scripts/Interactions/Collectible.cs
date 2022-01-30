using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    private Image _equippedSlotImage;

    [SerializeField]
    private int _itemId;

    [SerializeField]
    private bool _isItemAcquired = false;
    #endregion

    #region Fields
    private Vector3 _originalImagePos;
    private int _currentCycleIndex = 0;
    #endregion

    #region Unity Callbacks
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
    #endregion

    #region Methods
    public void Collect()
    {
        _currentCycleIndex = _itemId;
        _currentCycleIndex = Mathf.Clamp(_currentCycleIndex, 0, UIManager.Instance.AllCollectibles.Count - 1);

        Debug.Log(_currentCycleIndex);
        StartCoroutine(_uiManager.UpdateLog($"Collected: {gameObject.name}"));

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
    #endregion
}
