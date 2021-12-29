using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Collectible : MonoBehaviour //IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler //, IPointerUpHandler
{
    #region SerializedFields
    [SerializeField]
    private UIManager _uIManager;

    [SerializeField]
    private Transform _playerTr, _mainCam;

    [SerializeField]
    private Image _itemImage; //_equippedSlot

    [SerializeField]
    private Renderer _render;

    [SerializeField]
    private bool _isItemAquired = false, _isItemInRange = false;
    #endregion

    #region Fields
    private Vector3 _originalPos;
    private Ray _rayDirection;
    private RaycastHit hit;

    private int _delayCounter = 0, _targetDelay = 2;
    private const float _maxRayDistance = 20f;
    private bool _isMouseOver = false, _isItemEquipped = false;
    #endregion

    #region Properties
    public bool IsItemAquired { get => _isItemAquired; }

    public bool IsItemInRange { get => _isItemInRange; }
    #endregion

    public int _itemId;

    private void Update()
    {
        //if (Physics.Raycast(gameObject.transform.position, Camera.main.transform.position, out hit))
        //    _isItemInRange = true;
        //else
        //    _isItemInRange = false;

    }

    private void Awake()
    {
        _originalPos = _itemImage.transform.position;
    }

    private void OnMouseDown()
    {
        Debug.Log("Hit");
        _uIManager.Collect();
        _isItemAquired = true;

        //if (IsItemInRange)
        //{
        //    Debug.Log("Hit");
        //    _uIManager.Collect();
        //    _isItemAquired = true;
        //}
    }

    //if player in sight: aquire item
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    //if (_render.isVisible)
    //    //    _isItemAquired = true;
    //}
    //
    ////if player in sight: check if mouse is over the item
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    if (_render.isVisible)
    //        _isMouseOver = true;
    //}
    //
    ////if player in sight: check if mouse is not over the item
    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    if (_render.isVisible)
    //        _isMouseOver = false;
    //}

    private void ShowItem()
    {
        if (_uIManager.AquiredItemImages.Contains(_itemImage) && IsItemAquired)
            _itemImage.enabled = true;
        else
            _itemImage.enabled = false;
    }

    //event
    public void Equip()
    {
        //if (_itemImage.gameObject.name == _uIManager.CheckListeners())
        //{
        //   
        //}

        if (!_isItemEquipped)
        {
            Debug.Log("equip");
            _isItemEquipped = true;
            _itemImage.transform.parent = _uIManager.EquippedItemSlot.transform;
            _itemImage.transform.position = _uIManager.EquippedItemSlot.transform.position;
        }
        else
        {
            Debug.Log("unequip");
            _isItemEquipped = false;
            _itemImage.transform.parent = null;
            _itemImage.transform.position = _originalPos;
        }
    }
}
