using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class Track : MonoBehaviour
{
    //�̹����� Ʈ��ŷ�ϴ� �Ŵ���
    public ARTrackedImageManager manager;

    //Ʈ��ŷ�� �̹����� Ȱ��ȭ ��ų ���� ������Ʈ�� ������ ����Ʈ
    public List<GameObject> list1 = new List<GameObject>();

    //�̹����� �̸��� Ű�� ���� ������Ʈ�� �����ϴ� ��ųʸ�
    Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    void Start()
    {
        //list1�� ���� ������Ʈ���� dict1�� �߰��Ѵ�
        foreach (GameObject obj in list1)
        {
            //dict1�� �̹����� �̸��� ����Ͽ� �ش� �̹����� �����ϴ� ���� ������Ʈ�� ã�� ���ΰ��踦 ���´�
            dict1.Add(obj.name, obj);
        }

    }

    void OnEnable()
    {
        //trackedImagesChanged
        //�̹����� ī�޶� �󿡼� �������ų� �����̰ų� �ϴ� �� ��ȭ�� ����� �ڵ������� �Ҹ��� �̺�Ʈ �޼���
        manager.trackedImagesChanged += OnChanged;
    }

    void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;
    }

    //ARȯ�濡�� �̹����� �߰� �ǰų� ������Ʈ �� �� ȣ��Ǵ� �޼���
    //eventArgs : ���Ӱ� �߰� �� �̹����� ����
    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //�̹����� �߰� �Ǿ��� ��, �̹��� ������Ʈ
        foreach (ARTrackedImage t in eventArgs.added)
        {
            UpdateImage(t);
        }

    }

    void UpdateImage(ARTrackedImage t)
    {
        //������ �̹����� �̸��� �����´�
        string name = t.referenceImage.name;

        //dict1���� �ش� �̸��� �����ϴ� ���� ������Ʈ�� ã�´�
        GameObject obj = dict1[name];

        obj.transform.position = t.transform.position;
        obj.transform.rotation = t.transform.rotation;
        obj.SetActive(true);

    }

}
