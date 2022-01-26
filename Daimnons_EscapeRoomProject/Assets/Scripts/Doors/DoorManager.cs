using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public bool IsServersRoomLocked = true, IsTheaterLocked = true, IsBedRoomLocked = true, IsLibraryLocked = true;

    private void Update()
    {
        Debug.Log(UIManager.Instance.EquippedItemSlotImage.transform.GetChild(0).name.ToLower());

        if (UIManager.Instance.EquippedItemSlotImage.transform.GetChild(0) != null)
        {
            switch (UIManager.Instance.EquippedItemSlotImage.transform.GetChild(0).name.ToLower())
            {
                case "bluekey":
                    IsServersRoomLocked = false;
                    break;

                default:
                    IsServersRoomLocked = true;
                    break;
            }
        }
    }
}
