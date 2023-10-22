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

    public GameObject activeGameObject = null;

    public SliderController scaleSliderController;
    public SliderController rotateSliderController;

    public Transform spawnPoint;

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
            UpdateImage(t);
        }
    }

    void UpdateImage(ARTrackedImage t)
    {
        string name = t.referenceImage.name;
        GameObject obj = dict1[name];
        obj.transform.position = spawnPoint.position;
        obj.transform.rotation = spawnPoint.rotation;
        obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        if (t.trackingState == TrackingState.Tracking && !obj.activeSelf)
        {
            obj.SetActive(true);
            activeGameObject = obj;

            scaleSliderController.controlledObject = activeGameObject;
            rotateSliderController.controlledObject = activeGameObject;

            Mapping(obj);
        }

        if (activeGameObject != null)
        {
            manager.enabled = false;
        }
        // Following logic was to disable image when it's not under tracking state.

        //else if (t.trackingState != TrackingState.Tracking)
        //{
        //    obj.SetActive(false);
        //}

        //obj.SetActive(true);
        //activeGameObject = obj;

        //scaleSliderController.controlledObject = activeGameObject;
        //rotateSliderController.controlledObject = activeGameObject;

        //Mapping(obj);
    }

    public void Mapping(GameObject ActiveObj)
    {
        if(dict2.TryGetValue(ActiveObj, out Image image))
        {
            image.gameObject.SetActive(true); 
        }
    }
}
