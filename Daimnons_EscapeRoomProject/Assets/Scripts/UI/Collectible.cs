using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Collectible : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler //, IPointerUpHandler
{
    #region SerializedFields
    [SerializeField]
    private UIManager _uIManager;

    [SerializeField]
    private Transform _equippedSlot, _playerTr, _mainCam;

    [SerializeField]
    private Image _itemImage;

    [SerializeField]
    private Renderer _render;
    #endregion

    #region Fields
    private Vector3 _originalPos;
    private bool _isMouseOver = false, _isItemEquipped = false;
    private const float maxRayDistance = 20f;
    #endregion

    public bool IsItemAquired = false;

    private void Awake()
    {
        _originalPos = transform.position;
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(_mainCam.position, _mainCam.forward, out hit, maxRayDistance) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hit");
            _uIManager.Collect();
            IsItemAquired = true;
            //if (_render.isVisible)
        }
    }

    //if player in sight: aquire item
    public void OnPointerDown(PointerEventData eventData)
    {
        //if (_render.isVisible)
        //    _isItemAquired = true;
    }

    //if player in sight: check if mouse is over the item
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_render.isVisible)
            _isMouseOver = true;
    }

    //if player in sight: check if mouse is not over the item
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_render.isVisible)
            _isMouseOver = false;
    }

    private void ShowItem()
    {
        if (_uIManager.AquiredItemImages.Contains(_itemImage) && IsItemAquired)
            _itemImage.enabled = true;
        else
            _itemImage.enabled = true;
    }

    //event
    public void Equip()
    {
        if (_itemImage.gameObject.name == _uIManager.CheckListeners())
        {
            _isItemEquipped = true;
            transform.position = _equippedSlot.position;
        }
        else
        {
            _isItemEquipped = false;
            transform.position = _originalPos;
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
