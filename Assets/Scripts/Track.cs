using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using System.Reflection;

public class Track : MonoBehaviour
{
    //이미지를 트랙킹하는 매니저
    public ARTrackedImageManager manager;

    //트랙킹한 이미지에 활성화 시킬 게임 오브젝트를 저장할 리스트
    public List<GameObject> list1 = new List<GameObject>();      

    //이미지의 이름을 키로 게임 오브젝트를 연결하는 딕셔너리
    Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    //게임 오브젝트와 매핑되는 아이콘 이미지 리스트
    public List<Image> images = new List<Image>();

    //게임 오브젝트와 이미지를 연결하는 딕셔너리
    Dictionary<GameObject, Image> dict2 = new Dictionary<GameObject, Image>();


    void Start()
    {
        //list1의 게임 오브젝트들을 dict1에 추가한다
        foreach (GameObject obj in list1)
        {
            //dict1은 이미지의 이름을 사용하여 해당 이미지에 대응하는 게임 오브젝트를 찾는 매핑관계를 갖는다
            dict1.Add(obj.name, obj);
        }

        //images 리스트의 이미지들을 dict2에 추가한다
        int index = 0;
        foreach(GameObject obj2 in list1)
        {
            Image image = images[index];
            dict2.Add(obj2, image);
            image.gameObject.SetActive(false);
            index++;
        }

    }

    void OnEnable()
    {
        //trackedImagesChanged
        //이미지가 카메라 상에서 없어지거나 움직이거나 하는 등 변화가 생기면 자동적으로 불리는 이벤트 메서드
        manager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;
    }

    //AR환경에서 이미지가 추가 되거나 업데이트 될 때 호출되는 메서드
    //eventArgs : 새롭게 추가 된 이미지의 정보
    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //이미지가 추가 되었을 때, 이미지 업데이트
        foreach (ARTrackedImage t in eventArgs.added)
        {
            UpdateImage(t);
        }

    }

    void UpdateImage(ARTrackedImage t)
    {
        //추적된 이미지의 이름을 가져온다
        string name = t.referenceImage.name;

        //dict1에서 해당 이름에 대응하는 게임 오브젝트를 찾는다
        GameObject obj = dict1[name];

        obj.transform.position = t.transform.position;
        obj.transform.rotation = t.transform.rotation;
        obj.SetActive(true);

        Mapping(obj);

    }

    public void Mapping(GameObject ActiveObj)
    {
        //오브젝트에 해당하는 이미지 UI를 찾아온다
        //dict2는 게임 오브젝트를 키로 하여 이미지를 가져온다
        //TryGetValue() : 딕셔너리에 해당 키를 찾은 경우, 이미지를 반환한다
        //이미지 UI를 찾지 못한 경우 out 매개 변수를 통해 image에 null을 할당한다
        if(dict2.TryGetValue(ActiveObj, out Image image))
        {
            //이미지 UI를 상세 페이지에 표시
            image.gameObject.SetActive(true); 
        }

    }

}
