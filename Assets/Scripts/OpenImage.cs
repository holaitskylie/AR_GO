using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//버튼이 활성화 된 후에 상세 이미지를 연결하는 스크립트
public class OpenImage : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();

    public List<Image> images = new List<Image>();

    //Dictionary<Button, Image> imageDict = new Dictionary<Button, Image>();

    private Image currentImage;   

    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i; // 필요한 인덱스 값을 보존하기 위해 인덱스를 새로운 변수에 할당
            buttons[index].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    void Update()
    {
       
    }

    void OnButtonClick(int buttonIndex)
    {
        if (currentImage != null)
        {
            currentImage.gameObject.SetActive(false);
        }

        if (buttonIndex >= 0 && buttonIndex < images.Count)
        {
            Image image = images[buttonIndex];
            if (image != null)
            {
                image.gameObject.SetActive(true);
                currentImage = image;
            }
        }
    }

    public void CloseImage()
    {
        currentImage.gameObject.SetActive(false);
    }   
}
