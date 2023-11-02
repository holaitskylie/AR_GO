using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


public class Track : MonoBehaviour
{
    public ARTrackedImageManager manager;

    //트랙킹한 이미지에 활성화 시킬 게임 오브젝트 저장할 리스트
    public List<GameObject> list1 = new List<GameObject>();
    //이미지 이름을 key로 게임 오브젝트 연결할 딕셔너리
    Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    //게임 오브젝트와 연결되는 인벤토리 버튼 이미지 리스트
    public List<Image> images = new List<Image>();
    //게임 오브젝트를 key로 이미지와 연결하는 딕셔너리
    Dictionary<GameObject, Image> dict2 = new Dictionary<GameObject, Image>();

    public GameObject activeGameObject = null;

    public SliderController scaleSliderController;
    public SliderController rotateSliderController;
    [HideInInspector] public SliderController sliderManager;

    //public GameObject scaleSlider;
    //public GameObject rotateSlider;

    //AR Camera 자식 오브젝트 : 오브젝트 스폰 위치 지정
    public Transform spawnPoint;

    void Start()
    {
        foreach (GameObject obj in list1)
        {
            dict1.Add(obj.name, obj);
        }

        int index = 0;
        foreach (GameObject obj2 in list1)
        {
            Image image = images[index];
            dict2.Add(obj2, image);
            image.gameObject.SetActive(false);
            index++;
        }

        sliderManager = FindObjectOfType<SliderController>();

        // 이미지 리스트를 반복하며 초기 활성화 상태를 복원
        for (int index_Img = 0; index_Img < images.Count; index_Img++)
        {
            string key = "ImageState_" + index_Img.ToString();
            int isActive = PlayerPrefs.GetInt(key, 0); // 기본값 0은 비활성화 상태를 나타낸다

            // 이미지의 활성화 상태를 복원
            if (isActive == 1)
            {
                images[index_Img].gameObject.SetActive(true);
            }
            else
            {
                images[index_Img].gameObject.SetActive(false);
            }
        }
    }

    void OnEnable()
    {
        manager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {        
        foreach (ARTrackedImage t in eventArgs.added)
        {
            UpdateImage(t);
        }

        foreach (ARTrackedImage t in eventArgs.updated)
        {
            UpdateImage(t);
        }
    }

    void UpdateImage(ARTrackedImage t)
    {
        string name = t.referenceImage.name;
        GameObject obj = dict1[name];
        obj.transform.position = spawnPoint.position;
        obj.transform.rotation = spawnPoint.rotation;
        //obj.transform.localScale = new Vector3(1f, 1f, 1f);

        if (t.trackingState == TrackingState.Tracking && !obj.activeSelf)
        {
            obj.SetActive(true);
            activeGameObject = obj;

            scaleSliderController.controlledObject = activeGameObject;
            scaleSliderController.scaleMinValue = activeGameObject.transform.localScale.x;
            scaleSliderController.scaleMaxValue = activeGameObject.transform.localScale.x * 2.5f;

            rotateSliderController.controlledObject = activeGameObject;

            sliderManager.ActivateSliders();

            Mapping(obj);
        }

        //중복 트래킹 방지하여 오브젝트를 1개만 활성화되도록
        //Double Tracking 안됨
        if (activeGameObject != null)
        {
            manager.enabled = false;
        }

        // Following logic was to disable image when it's not under tracking state.

        //else if (t.trackingState != TrackingState.Tracking)
        //{
        //    obj.SetActive(false);
        //}
    }

    //오브젝트에 해당하는 이미지 UI를 가져온다
    public void Mapping(GameObject ActiveObj)
    {
        if(dict2.TryGetValue(ActiveObj, out Image image))
        {
            image.gameObject.SetActive(true);

            // 이미지의 리스트 인덱스를 문자열로 변환하여 PlayerPrefs에 저장
            int index = images.IndexOf(image);
            string key = "ImageState_" + index.ToString();
            PlayerPrefs.SetInt(key, 1); // 1은 활성화 상태를 나타냅니다
            PlayerPrefs.Save(); // 변경사항 저장
        }
    }
}
