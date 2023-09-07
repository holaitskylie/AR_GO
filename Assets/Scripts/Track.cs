using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class Track : MonoBehaviour
{
    //이미지를 트랙킹하는 매니저
    public ARTrackedImageManager manager;

    //트랙킹한 이미지에 활성화 시킬 게임 오브젝트를 저장할 리스트
    public List<GameObject> list1 = new List<GameObject>();

    //이미지의 이름을 키로 게임 오브젝트를 연결하는 딕셔너리
    Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    void Start()
    {
        //list1의 게임 오브젝트들을 dict1에 추가한다
        foreach (GameObject obj in list1)
        {
            //dict1은 이미지으 이름을 사용하여 해당 이미지에 대응하는 게임 오브젝트를 찾는 매핑관계를 갖는다
            dict1.Add(obj.name, obj);
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

    }

}
