using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenImage : MonoBehaviour
{
    //버튼 UI 리스트
    public List<Button> buttons = new List<Button>();

    //이미지 UI 리스트
    public List<Image> images = new List<Image>();

    Dictionary<Button, Image> imageDict = new Dictionary<Button, Image>();

    private Image currentImage;   


    // Start is called before the first frame update
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
