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
        //게임이 시작될 때 인벤토리 창 비활성화
        inventoryUI.SetActive(false);
        //deleteButton에 On Click 이벤트 등록
        deleteButton.onClick.AddListener(DeleteActiveObject);
        //SliderController에 대한 참조를 가져온다
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
        //<Track.cs>에서 활성화 된 오브젝트가 있다면
        if (track.activeGameObject != null)
        {
            //활성화 시킨 오브젝트를 비활성화 한다
            track.activeGameObject.SetActive(false);
            track.activeGameObject = null;
        }

        //<Track.cs> - UpdateImage()에서 ARTrackedImageManger 비활성화한 것을 다시 활성화
        imageManager.enabled = true;
        //sliderController.DeactivateSliders();
    }
}
