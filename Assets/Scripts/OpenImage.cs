using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//버튼이 활성화 된 후에 상세 이미지를 연결하는 스크립트
public class OpenImage : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();

    public List<Image> images = new List<Image>();

    Dictionary<Button, Image> imageDict = new Dictionary<Button, Image>();

    private Image currentImage;   

    void Start()
    {
        int index = 0;
        foreach(Button button in buttons)
        {
            Image image = images[index];
            imageDict.Add(button, image);
            button.onClick.AddListener(() => OnButtonClick(button));
            index++;
        }        
    }

    void Update()
    {
        int index = 0;
        foreach (Button button in buttons)
        {
            Image image = images[index];
            imageDict.Add(button, image);
            button.onClick.AddListener(() => OnButtonClick(button));
            index++;
        }
    }

    void OnButtonClick(Button button)
    {          
        if (currentImage != null)
        {
            currentImage.gameObject.SetActive(false);
        }

        if (imageDict.TryGetValue(button, out Image image))
        {
            image.gameObject.SetActive(true);

            currentImage = image;
        }
    }

    public void CloseImage()
    {
        currentImage.gameObject.SetActive(false);
    }   
}
