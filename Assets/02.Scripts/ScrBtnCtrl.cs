using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrBtnCtrl : MonoBehaviour {

    private Button button;
    private Sprite baseSprite;
    private Image viewSprite;

    void Awake()
    {
        //TEST 나중에 지웁시다
        Debug.Log("2017-04-05-18:01");
        //버튼 컴포넌트를 넣어두자!
        button = GetComponent<Button>();
        //버튼 이벤트 동적 할당
        button.GetComponent<Button>().onClick.AddListener(delegate { OnScrButton(); });
    }

    //버튼에 표시될 이미지와 클릭시 저장될 Image의 정보를 저장!
    public void ScrBtnSetup(Sprite baseSprite, Image viewSprite)
    {
        this.baseSprite = baseSprite;
        this.viewSprite = viewSprite;
        GetComponent<Image>().sprite = baseSprite;
    }

    //버튼이 눌렸을 때 실행될 함수
    public void OnScrButton()
    {
        if(baseSprite != null)
            viewSprite.sprite = baseSprite;
    }
}
