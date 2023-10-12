using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider scaleSlider;
    private Slider rotateSlider;
    public float scaleMinValue;
    public float scaleMaxValue;
    public float rotateMinValue;
    public float rotateMaxValue;

    public GameObject controlledObject;

    void Start()
    {
        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();
        scaleSlider.minValue = scaleMinValue;
        scaleSlider.maxValue = scaleMaxValue;

        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        rotateSlider = GameObject.Find("RotateSlider").GetComponent<Slider>();
        rotateSlider.minValue = rotateMinValue;
        rotateSlider.maxValue = rotateMaxValue;

        rotateSlider.onValueChanged.AddListener(RotateSliderUpdate);
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
}