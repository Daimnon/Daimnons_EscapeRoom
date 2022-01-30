using UnityEngine;

public class DoorManager : MonoBehaviour
{
    #region Public Fields
    public bool IsServersRoomLocked = true, IsTheaterLocked = true, IsLibraryKeyEquipped = false;
    #endregion

    #region Unity Callbacks
    private void Update()
    {
        //check if inventory's equipped item slot has any children.
        if (UIManager.Instance.EquippedItemSlotImage.transform.GetChild(0) != null)
        {
            //if a child is found, which is a key, unlock the relevant door.
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
    #endregion
}
