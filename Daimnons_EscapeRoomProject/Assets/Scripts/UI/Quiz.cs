using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [SerializeField]
    private GameObject _greenKey;

    public void DropKey()
    {
        _greenKey.SetActive(true);
    }
}
