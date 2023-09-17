using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using Lean.Touch;

public class Track : MonoBehaviour
{
    public ARTrackedImageManager manager;

    public List<GameObject> list1 = new List<GameObject>();
    Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    public List<Image> images = new List<Image>();
    Dictionary<GameObject, Image> dict2 = new Dictionary<GameObject, Image>();

    public GameObject deleteButton;

    //Added Stack
    private Stack<GameObject> instantiatedPrefabs = new Stack<GameObject>();

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

        deleteButton.GetComponent<Button>().onClick.AddListener(DeletePrefab);
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

        obj.transform.position = t.transform.position;
        obj.transform.rotation = t.transform.rotation;
        obj.SetActive(true);

        AddLeanComponents(obj);
        //Add instantiated objects to Stack memory
        instantiatedPrefabs.Push(obj);

        Mapping(obj);
    }

    void AddLeanComponents(GameObject obj)
    {
        if (!obj.GetComponent<LeanDragTranslate>())
        {
            obj.AddComponent<LeanDragTranslate>();
        }
        if (!obj.GetComponent<LeanPinchScale>())
        {
            obj.AddComponent<LeanPinchScale>();
        }
        if (!obj.GetComponent<LeanTwistRotate>())
        {
            obj.AddComponent<LeanTwistRotate>();
        }
    }

    public void Mapping(GameObject ActiveObj)
    {
        if (dict2.TryGetValue(ActiveObj, out Image image))
        {
            image.gameObject.SetActive(true);
        }
    }

    public void DeletePrefab()
    {
        // Delete objects in the order in which they are stored in the stack
        if (instantiatedPrefabs.Count > 0)
        {
            GameObject objToDelete = instantiatedPrefabs.Pop();
            objToDelete.SetActive(false);
        }
    }
}