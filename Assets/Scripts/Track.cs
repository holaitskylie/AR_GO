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

    public List<GameObject> list1 = new List<GameObject>();      
    Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    public List<Image> images = new List<Image>();
    Dictionary<GameObject, Image> dict2 = new Dictionary<GameObject, Image>();  
    

    void Start()
    {
        foreach (GameObject obj in list1)
        {
            dict1.Add(obj.name, obj);
        }

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
            if (t.trackingState == TrackingState.Limited || t.trackingState == TrackingState.None)
            {
                DisableImage(t);
            }
            else
            {
                UpdateImage(t);
            }
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
             
        Mapping(obj);
    }

    void DisableImage(ARTrackedImage t)
    {
        string name = t.referenceImage.name;

        if(dict1.TryGetValue(name, out GameObject obj))
        {
            obj.SetActive(false);

            if(dict2.TryGetValue(obj, out Image image))
            {
                image.gameObject.SetActive(false);
            }
        }
    }

    void AddLeanComponents(GameObject obj)
    {
        if (!obj.GetComponent<Lean.Touch.LeanDragTranslate>())
        {
            obj.AddComponent<Lean.Touch.LeanDragTranslate>();
        }
        if (!obj.GetComponent<Lean.Touch.LeanPinchScale>())
        {
            obj.AddComponent<Lean.Touch.LeanPinchScale>();
        }
        if (!obj.GetComponent<Lean.Touch.LeanTwistRotateAxis>())
        {
            obj.AddComponent<Lean.Touch.LeanTwistRotateAxis>();
        }
    }

    public void Mapping(GameObject ActiveObj)
    {
        if(dict2.TryGetValue(ActiveObj, out Image image))
        {
            image.gameObject.SetActive(true); 
        }
    }
}
