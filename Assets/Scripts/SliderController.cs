using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider scaleSlider;
    private Slider rotateSlider;
    public float scaleMinValue = 1f;
    public float scaleMaxValue = 3f;
    public float rotateMinValue = 0;
    public float rotateMaxValue = 360;

    public GameObject scaleSliderObject;
    public GameObject rotateSliderObject;

    public GameObject controlledObject;

    void Start()
    {
        scaleSlider = GameObject.Find("Scale Slider").GetComponent<Slider>();
        scaleSlider.minValue = scaleMinValue;
        scaleSlider.maxValue = scaleMaxValue;

        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        rotateSlider = GameObject.Find("Rotate Slider").GetComponent<Slider>();
        rotateSlider.minValue = rotateMinValue;
        rotateSlider.maxValue = rotateMaxValue;

        rotateSlider.onValueChanged.AddListener(RotateSliderUpdate);

        scaleSliderObject.SetActive(false);
        rotateSliderObject.SetActive(false);
    }

    void ScaleSliderUpdate(float value)
    {
        //transform.localScale = new Vector3(value, value, value);
        if (controlledObject != null)
        {
            controlledObject.transform.localScale = new Vector3(value, value, value);
        }
    }

    void RotateSliderUpdate(float value)
    {
        //transform.localEulerAngles = new Vector3(transform.rotation.x, value, transform.rotation.z);
        if (controlledObject != null)
        {
            controlledObject.transform.localEulerAngles = new Vector3(controlledObject.transform.rotation.x, value, controlledObject.transform.rotation.z);
        }
    }

    public void ActivateSliders()
    {
        scaleSliderObject.SetActive(true);
        rotateSliderObject.SetActive(true);
    }

    public void DeactivateSliders()
    {
        scaleSliderObject.SetActive(false);
        rotateSliderObject.SetActive(false);
    }
}