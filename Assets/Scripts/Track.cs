using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using System.Reflection;

public class Track : MonoBehaviour
{
    //�̹����� Ʈ��ŷ�ϴ� �Ŵ���
    public ARTrackedImageManager manager;

    //Ʈ��ŷ�� �̹����� Ȱ��ȭ ��ų ���� ������Ʈ�� ������ ����Ʈ
    public List<GameObject> list1 = new List<GameObject>();      

    //�̹����� �̸��� Ű�� ���� ������Ʈ�� �����ϴ� ��ųʸ�
    Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    //���� ������Ʈ�� ���εǴ� ������ �̹��� ����Ʈ
    public List<Image> images = new List<Image>();

    //���� ������Ʈ�� �̹����� �����ϴ� ��ųʸ�
    Dictionary<GameObject, Image> dict2 = new Dictionary<GameObject, Image>();


    void Start()
    {
        //list1�� ���� ������Ʈ���� dict1�� �߰��Ѵ�
        foreach (GameObject obj in list1)
        {
            //dict1�� �̹����� �̸��� ����Ͽ� �ش� �̹����� �����ϴ� ���� ������Ʈ�� ã�� ���ΰ��踦 ���´�
            dict1.Add(obj.name, obj);
        }

        //images ����Ʈ�� �̹������� dict2�� �߰��Ѵ�
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

        Mapping(obj);

    }

    public void Mapping(GameObject ActiveObj)
    {
        //������Ʈ�� �ش��ϴ� �̹��� UI�� ã�ƿ´�
        //dict2�� ���� ������Ʈ�� Ű�� �Ͽ� �̹����� �����´�
        //TryGetValue() : ��ųʸ��� �ش� Ű�� ã�� ���, �̹����� ��ȯ�Ѵ�
        //�̹��� UI�� ã�� ���� ��� out �Ű� ������ ���� image�� null�� �Ҵ��Ѵ�
        if(dict2.TryGetValue(ActiveObj, out Image image))
        {
            //�̹��� UI�� �� �������� ǥ��
            image.gameObject.SetActive(true); 
        }

    }

}
