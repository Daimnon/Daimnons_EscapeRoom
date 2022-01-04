using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("No UIManager Found");
    
            return _instance;
        }
    }
    #endregion

    #region Serialized Fields
    [SerializeField]
    private GameObject _inventoryPanel, _equippedItemSlotGO;
    #endregion

    #region Fields
    private bool _isInventoryOpen = false;
    #endregion

    #region Public Fields
    public List<GameObject> AllCollectibles;

    public List<Image> AllImages;
    
    public Image EquippedItemSlotImage;
    #endregion

    private void Awake()
    {
        _instance = this;

        foreach (Image image in AllImages)
            image.enabled = false;
    }

    #region Methods
    public void SetInventoryState()
    {
        if (!_isInventoryOpen)
        {
            _isInventoryOpen = true;
            _inventoryPanel.SetActive(true);
            _equippedItemSlotGO.SetActive(true);
        }
        else
        {
            _isInventoryOpen = false;
            _inventoryPanel.SetActive(false);
            _equippedItemSlotGO.SetActive(false);
        }
    }
    #endregion
}
