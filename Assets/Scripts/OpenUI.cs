using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class OpenUI : MonoBehaviour
{
    public GameObject inventoryUI;

    public Track track;
    public Button deleteButton;
    public ARTrackedImageManager imageManager;
    public GameObject scaleSlider;
    public GameObject rotateSlider;

    [HideInInspector] public SliderController sliderController;

    void Start()
    {
        inventoryUI.SetActive(false);
        deleteButton.onClick.AddListener(DeleteActiveObject);

        sliderController = FindObjectOfType<SliderController>();
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
            track.activeGameObject.SetActive(false);
            track.activeGameObject = null;
        }

        imageManager.enabled = true;
        sliderController.DeactivateSliders();
    }
}
