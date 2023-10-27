using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class OpenUI : MonoBehaviour
{    
    public GameObject inventoryUI; //인벤토리창

    public Track track;
    public Button deleteButton; //오브젝트 비활성화 시키는 버튼
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
        //인벤토리 창 활성화
       inventoryUI.SetActive(true);  
    }

    public void CloseInventory()
    {
        //인벤토리 창 비활성화
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
        //sliderController.DeactivateSliders();
    }
}
