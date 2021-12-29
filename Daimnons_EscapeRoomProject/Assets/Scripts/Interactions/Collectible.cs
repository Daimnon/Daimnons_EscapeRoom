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
    #endregion

    #region Fields
    private Vector3 _originalPos;

    [SerializeField]
    private int _delayCounter = 0, _targetDelay = 2;
    private const float _maxRayDistance = 20f;
    private bool _isMouseOver = false, _isItemEquipped = false;
    #endregion

    public bool IsItemAquired = false;

    private void Awake()
    {
        _originalPos = _itemImage.transform.position;
    }

    void Update()
    {
        RaycastHit hit;
        
        if (Input.GetMouseButtonDown(1) && Physics.Raycast(_mainCam.position, _mainCam.forward, out hit, _maxRayDistance) && transform.name == hit.transform.name)
        {
            _delayCounter++;

            //if (_delayCounter != _targetDelay)
            //    return;

            Debug.Log("Hit");
            IsItemAquired = true;
            _uIManager.Collect();
            //if (_render.isVisible)
        }
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
            Debug.Log("dudui");
            _isItemEquipped = true;
            _itemImage.transform.parent = _uIManager.EquippedItemSlot.transform;
            _itemImage.transform.position = _uIManager.EquippedItemSlot.transform.position;
        }
        else
        {
            Debug.Log("duduz");
            _isItemEquipped = false;
            _itemImage.transform.parent = null;
            _itemImage.transform.position = _originalPos;
        }
    }

    /* Check if GO is looking at player
     * void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) && hit.collider.gameObject.CompareTag("Player"))
        {

        }
    }*/

    /* On Pointer Events
    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }*/
}
