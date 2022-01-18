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
    private EventSystem eventSystem;
    
    [SerializeField]
    private GameObject _inventoryPanel, _equippedItemSlotGO;
    #endregion

    #region Fields
    private List<Vector3> _originalImagesPosition;
    private GameObject? lastSelectedGameObject;
    private GameObject currentSelectedGameObject_Recent;
    private bool _isInventoryOpen = false, _isItemEquipped = false;
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
            //image.enabled = false;

        for (int i = 0; i < AllImages.Count; i++)
            _originalImagesPosition[i] = AllImages[i].transform.position;

        lastSelectedGameObject = currentSelectedGameObject_Recent;
    }

    #region Methods
    // Try to get last listener
    private void GetLastGameObjectSelected()
    {
        if (eventSystem.currentSelectedGameObject != currentSelectedGameObject_Recent)
        {
            lastSelectedGameObject = currentSelectedGameObject_Recent;
            currentSelectedGameObject_Recent = eventSystem.currentSelectedGameObject;
        }
    }

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

    public void Equip()
    {
        GetLastGameObjectSelected(); //Try to get last listener

        /* Trying to make sure that when pressing another item the equipped slot gets cleared before equipping a new one
        if (lastSelectedGameObject != null && EquippedItemSlotImage.name.ToLower() != "equippeditemslot")
        {
            lastSelectedGameObject.transform.parent = _inventoryPanel.gameObject.transform;
            lastSelectedGameObject.transform.position = _originalImagesPosition[_originalImagesPosition.Count];
        }
        */

        // currently sometimes need to press twice on item which is not the first equipped

        if (!_isItemEquipped)
        {
            Debug.Log("equip");
            _isItemEquipped = true;
            currentSelectedGameObject_Recent.transform.parent = EquippedItemSlotImage.transform;
            currentSelectedGameObject_Recent.transform.position = EquippedItemSlotImage.transform.position;
        }
        else
        {
            Image currentImage = AllImages.Find(image => image.name == currentSelectedGameObject_Recent.name);
            Debug.Log("unequip");
            _isItemEquipped = false;
            currentSelectedGameObject_Recent.transform.parent = _inventoryPanel.gameObject.transform;

            for (int i = 0; i < AllImages.Count; i++)
            {
                if (AllImages[i].name == currentImage.name)
                    currentSelectedGameObject_Recent.transform.position = _originalImagesPosition[i];
            }
        }
    }
    #endregion
}
