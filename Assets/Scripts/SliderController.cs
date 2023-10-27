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

    private float currentScale = 1.0f;
    private float currentRotation = 0.0f;

    void Start()
    {
        scaleSlider = GameObject.Find("Scale Slider").GetComponent<Slider>();
        scaleSlider.minValue = scaleMinValue;
        scaleSlider.maxValue = scaleMaxValue;

        //scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        rotateSlider = GameObject.Find("Rotate Slider").GetComponent<Slider>();
        rotateSlider.minValue = rotateMinValue;
        rotateSlider.maxValue = rotateMaxValue;

        //rotateSlider.onValueChanged.AddListener(RotateSliderUpdate);

        //scaleSliderObject.SetActive(false);
        //rotateSliderObject.SetActive(false);

        ActivateSliders();
    }

    private void Update()
    {
        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);
        rotateSlider.onValueChanged.AddListener(RotateSliderUpdate);

    }

    void ScaleSliderUpdate(float value)
    {
        // 슬라이더의 현재 값을 이용하여 스케일 업데이트
        currentScale = value;

        //transform.localScale = new Vector3(value, value, value);
        if (controlledObject != null)
        {
            //controlledObject.transform.localScale = new Vector3(value, value, value);
            controlledObject.transform.localScale = Vector3.one * currentScale;
        }
    }

    void RotateSliderUpdate(float value)
    {
        // 슬라이더의 현재 값을 이용하여 회전 업데이트
        currentRotation = value;

        //transform.localEulerAngles = new Vector3(transform.rotation.x, value, transform.rotation.z);
        if (controlledObject != null)
        {
            //controlledObject.transform.localEulerAngles = new Vector3(controlledObject.transform.rotation.x, value, controlledObject.transform.rotation.z);
            controlledObject.transform.localEulerAngles = new Vector3(controlledObject.transform.rotation.x, currentRotation, controlledObject.transform.rotation.z);
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