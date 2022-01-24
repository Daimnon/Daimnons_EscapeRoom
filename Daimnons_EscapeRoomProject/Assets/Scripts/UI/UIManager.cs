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
    private GameObject CurrentSelectedGameObject;
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
            image.enabled = false; // turn off to test, current working subject is blue key, current test subject is red key

        for (int i = 0; i < AllImages.Count; i++)
            _originalImagesPosition[i] = AllImages[i].transform.position;

        lastSelectedGameObject = CurrentSelectedGameObject;
    }

    #region Methods
    // Try to get last listener
    private void GetLastGameObjectSelected()
    {
        if (eventSystem.currentSelectedGameObject != CurrentSelectedGameObject)
        {
            lastSelectedGameObject = CurrentSelectedGameObject;
            CurrentSelectedGameObject = eventSystem.currentSelectedGameObject;
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
        GetLastGameObjectSelected(); // Try to get last listener

        //Trying to make sure that when pressing another item the equipped slot gets cleared before equipping a new one
        //if (lastSelectedGameObject != null && EquippedItemSlotImage.name.ToLower() != "equippeditemslot")
        //{
        //    lastSelectedGameObject.transform.SetParent(_inventoryPanel.gameObject.transform);
        //    lastSelectedGameObject.transform.position = _originalImagesPosition[_originalImagesPosition.Count];
        //}


        // currently sometimes need to press twice on item which is not the first equipped

        if (!_isItemEquipped)
        {
            Debug.Log("equip");
            _isItemEquipped = true;

            CurrentSelectedGameObject.transform.SetParent(EquippedItemSlotImage.transform);
            CurrentSelectedGameObject.transform.position = EquippedItemSlotImage.transform.position;
        }
        else
        {
            Image currentImage = AllImages.Find(image => image.name == CurrentSelectedGameObject.name);
            Debug.Log("unequip");
            _isItemEquipped = false;
            //currentSelectedGameObject_Recent.transform.parent = _inventoryPanel.gameObject.transform;
            CurrentSelectedGameObject.transform.SetParent(_inventoryPanel.gameObject.transform); // Changed to "Set Partent" becasue the Console yelled at me #2

            for (int i = 0; i < AllImages.Count; i++)
            {
                if (AllImages[i].name == currentImage.name)
                    CurrentSelectedGameObject.transform.position = _originalImagesPosition[i];
            }
        }
    }
    #endregion
}
