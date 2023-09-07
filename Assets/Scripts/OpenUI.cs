using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUI : MonoBehaviour
{
    public GameObject inventoryUI;
    

    void Start()
    {
        inventoryUI.SetActive(false);
    }

    public void OpenInventory()
    {    
       inventoryUI.SetActive(true);  
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
    }
}
