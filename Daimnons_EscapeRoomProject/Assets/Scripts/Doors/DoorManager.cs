using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public bool IsServersRoomLocked = true, IsTheaterLocked = true, IsLibraryKeyEquipped = false;

    private void Update()
    {
        //Debug.Log(UIManager.Instance.EquippedItemSlotImage.transform.GetChild(0).name.ToLower());

        if (UIManager.Instance.EquippedItemSlotImage.transform.GetChild(0) != null)
        {
            switch (UIManager.Instance.EquippedItemSlotImage.transform.GetChild(1).name.ToLower())
            {
                case "server room key":
                    IsServersRoomLocked = false;
                    break;

                case "theater room key":
                    IsTheaterLocked = false;
                    break;

                case "library room key":
                    IsLibraryKeyEquipped = true;
                    break;

                default:
                    IsServersRoomLocked = true;
                    IsTheaterLocked = true;
                    IsLibraryKeyEquipped = false;
                    break;
            }
        }
    }
}
