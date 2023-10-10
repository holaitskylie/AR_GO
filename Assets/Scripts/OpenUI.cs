using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUI : MonoBehaviour
{
    public GameObject inventoryUI;

    public Track track;
    public Button deleteButton;

    void Start()
    {
        inventoryUI.SetActive(false);
        deleteButton.onClick.AddListener(DeleteActiveObject);
    }

    public void OpenInventory()
    {    
       inventoryUI.SetActive(true);  
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
    }

    public void DeleteActiveObject()
    {
        if (track.activeGameObject != null)
        {
            Destroy(track.activeGameObject);
            track.activeGameObject = null;
        }
    }
}
