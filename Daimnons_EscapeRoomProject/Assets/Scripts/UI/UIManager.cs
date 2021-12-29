using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //#region Singleton
    //private static UIManager _instance;
    //public static UIManager Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //            Debug.Log("No UIManager Found");
    //
    //        return _instance;
    //    }
    //}
    //#endregion

    #region Serialized Fields
    //[SerializeField]
    public List<GameObject> Collectibles;

    //[SerializeField]
    public List<Image> AquiredItemImages;

    [SerializeField]
    private Camera _mainCam;

    [SerializeField]
    private GameObject _inventoryPanel;
    #endregion

    #region Fields
    private Image _equippedItem;
    private Vector3 _uIMousePos { get => _mainCam.WorldToScreenPoint(Input.mousePosition); }
    private bool _isInventoryOpen = false;
    #endregion

    #region Public Fields
    public Image EquippedItemSlot;
    #endregion

    private void Awake()
    {
        //singleton
        /*_instance = this;*/
    }

    private void Update()
    {
        //CheckListeners();
    }

    #region Methods
    public void SetInventoryState()
    {
        if (!_isInventoryOpen)
        {
            _inventoryPanel.SetActive(true);
            _isInventoryOpen = true;
        }
        else
        {
            _inventoryPanel.SetActive(false);
            _isInventoryOpen = false;
        }
    }

    public void Collect()
    {
        Debug.Log("Collect phase -1");
        for (int i = 0; i < Collectibles.Count; i++)
        {
            Debug.Log("Collect phase -2");

            if (Collectibles[i].GetComponent<Collectible>().IsItemAquired)
                return;

            else
            {
                Debug.Log("Collect phase -3");
                foreach (Image itemImage in AquiredItemImages)
                {
                    Debug.Log("Collect phase -4");
                    itemImage.gameObject.SetActive(true);
                    Debug.Log($"{itemImage.name} is aquired");
                }
            }
        }

        //Debug.Log("Collect phase 1");
        //foreach (GameObject item in Collectibles)
        //{
        //    Debug.Log("Collect phase 2");
        //    if (item.GetComponent<Collectible>().IsItemAquired)
        //    {
        //        Debug.Log("Collect phase 3");
        //        foreach (Image itemImage in AquiredItemImages)
        //        {
        //            Debug.Log("Collect phase 4");
        //            itemImage.gameObject.SetActive(true);
        //            Debug.Log($"{itemImage.name} is aquired");
        //        }
        //    }
        //
        //    //Debug.Log("Collect phase 5");
        //    //gameObject.SetActive(false);
        //}
    }
    #endregion
}
