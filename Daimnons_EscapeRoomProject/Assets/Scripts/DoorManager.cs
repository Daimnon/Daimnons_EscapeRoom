using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField]
    private bool _isServersRoomLocked = true, _isTheaterLocked = true, _isBedRoomLocked = true, _isLibraryLocked = true;

    private void Update()
    {
        Debug.Log(UIManager.Instance.EquippedItemSlotImage.name);
        switch (UIManager.Instance.EquippedItemSlotImage.name.ToLower())
        {
            case "bluekey":
                _isServersRoomLocked = false;
                break;

            default:
                _isServersRoomLocked = true;
                break;
        }
    }
}
