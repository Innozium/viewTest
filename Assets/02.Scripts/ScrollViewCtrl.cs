using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewCtrl : MonoBehaviour {

    public ScrollRect scrollRect;

    private float value = 1.0f;
    #region is_touch 설명
    //is_touch는 Scroll View에 EventTrigger에 이벤트를 통해
    //ture로 변환된다. true일때는 보간을 하지 않는다.
    //false로 되는 순간은 스크롤상자를 물리적으로 제어하는 UP, Down 버튼을 눌렀을 때
    //true값으로 변한다.
    #endregion
    private bool is_touch = false;

    void Awake()
    {
        //위치를 상단으로 고정시킨다.
        scrollRect.verticalNormalizedPosition = 1.0f;

    }

    void FixedUpdate()
    {
        //print("스크롤" + scrollRect.verticalNormalizedPosition.ToString());
        //print("value" + value.ToString());

        //스크롤상자와 value값이 0 ~ 1 사이 값을 벗어나지 않도록 조정
        ValueNormalize();

        //버튼을 눌렀을 떄 보간을 통해 자연스럽게 이동시킨다.
        if (scrollRect.verticalNormalizedPosition != value && !is_touch)
        scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition, value, 5.0f * Time.deltaTime);

        
    }

    //스크롤상자와 value값이 0 ~ 1 사이 값을 벗어나지 않도록 조정
    public void ValueNormalize()
    {
        if (scrollRect.verticalNormalizedPosition > 1.0f) scrollRect.verticalNormalizedPosition = 1.0f;
        else if (scrollRect.verticalNormalizedPosition < 0.0f) scrollRect.verticalNormalizedPosition = 0.0f;

        if (value > 1.0f) value = 1.0f;
        else if (value < 0.0f) value = 0.0f;
    }

    #region 위, 아래 버튼 이벤트
    public void OnUpBoutton()
    {
        OnTouchRect();
        if (value < 1.0f) value += 0.1f;
        is_touch = false;
        //scrollRect.verticalNormalizedPosition = value;
    }

    public void OnDownButton()
    {
        OnTouchRect();
        if (value > 0.0f) value -= 0.1f;
        is_touch = false;
        //scrollRect.verticalNormalizedPosition = value;
    }
    #endregion

    
    public void OnTouchRect()
    {//버튼 이벤트시 값을 바꿔주기 전에 현재 위치를 얻는다.
        value = scrollRect.verticalNormalizedPosition;
    }

    //스크롤상자를 눌렀을 때 발생 시킬 이벤트
    public void OnTouchTrue()
    {
        is_touch = true;
    }

}
