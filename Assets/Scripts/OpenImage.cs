using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//도감창의 버튼이 활성화 된 후에 습지생물 상세 이미지를 연결하는 스크립트
public class OpenImage : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();

    public List<Image> images = new List<Image>();

    //Dictionary<Button, Image> imageDict = new Dictionary<Button, Image>();

    private Image currentImage; //현재 화면에 표시 중인 이미지   

    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i; // 필요한 인덱스 값을 보존하기 위해 인덱스를 새로운 변수에 할당
            //index에 해당하는 버튼에 On Click 이벤트 등록
            buttons[index].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    void Update()
    {
       
    }

    //버튼이 클릭될 때마다 호출되는 메서드
    //매개변수 값으로는 클릭된 버튼의 인덱스 값이 들어온다
    void OnButtonClick(int buttonIndex)
    {
        //상세 이미지가 활성화된 상태이면, 이전 이미지를 숨기기 위해 해당 이미지는 비활성화
        if (currentImage != null)
        {
            currentImage.gameObject.SetActive(false);
        }

        //버튼의 인덱스가 images 리스트의 유효한 인덱스 범위 내에 있는지 확인
        if (buttonIndex >= 0 && buttonIndex < images.Count)
        {
            //버튼 인덱스와 같은 인덱스의 이미지를 가져온다
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
