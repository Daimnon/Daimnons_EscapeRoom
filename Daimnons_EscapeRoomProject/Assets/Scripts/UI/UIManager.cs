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

    [SerializeField]
    private Image _equippedItemSlot;
    #endregion

    #region Fields
    private Image _equippedItem;
    private Vector3 _uIMousePos { get => _mainCam.WorldToScreenPoint(Input.mousePosition); }
    private bool _isInventoryOpen = false;
    #endregion

    private void Awake()
    {
        //singleton
        /*_instance = this;*/
    }

    private void Update()
    {
        CheckListeners();
    }

    #region Methods
    private void SetInventoryState(bool onOff)
    {
        if (onOff)
            _inventoryPanel.SetActive(true);

        else
            _inventoryPanel.SetActive(false);
    }

    public string CheckListeners()
    {
        string itemName;

        for (int i = 0; i < AquiredItemImages.Count; i++)
        {
            Button btn = AquiredItemImages[i].GetComponent<Button>();
            
            btn.onClick.AddListener(delegate { Callback(btn); });

            if (btn.IsInvoking())
                return itemName = Callback(btn);
            else
                return "btn.Invoking() Not Working Properly";
        }

        return null;
    }

    private string Callback(Button btnPressed)
    {
        Debug.Log(btnPressed.gameObject.name + " pressed!");
        return btnPressed.gameObject.name;
    }

    public void Collect()
    {
        Debug.Log("Collect phase 1");
        foreach (GameObject item in Collectibles)
        {
            Debug.Log("Collect phase 2");
            if (item.GetComponent<Collectible>().IsItemAquired)
            {
                Debug.Log("Collect phase 3");
                foreach (Image itemImage in AquiredItemImages)
                {
                    Debug.Log("Collect phase 4");
                    itemImage.gameObject.SetActive(true);
                    Debug.Log($"{itemImage.name} is aquired");
                }
            }

            Debug.Log("Collect phase 5");
            gameObject.SetActive(false);
        }
    }

    #endregion
}
