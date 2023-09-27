using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenImage : MonoBehaviour
{
    [SerializeField]
    private List<Button> buttons = new List<Button>();

    [SerializeField]
    private List<Image> objImages = new List<Image>();

    Dictionary<Button, Image> imageDict = new Dictionary<Button, Image>();

    private Image currentImage;   


    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        foreach(Button button in buttons)
        {
            Image image = objImages[index];
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
            Image image = this.objImages[index];
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
