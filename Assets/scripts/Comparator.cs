using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comparator : MonoBehaviour
{
    public Text[] ans;
    int result;
    public static int onayCount;
    void Start()
    {
        result = TimerSlider.result[0];
    }
    void Update()
    {
        if(TimerSlider.type==1)
        result = TimerSlider.result[0];
    }
    public void onay()
    {
        if (TimerSlider.type == 1)
        {   
            int ansNum;
            int.TryParse(ans[TimerSlider.quesNum[0]].text, out ansNum);
            if (ansNum == result)
            {
                TimerSlider.win();
            }
            else
            {
                TimerSlider.lose();
            }
        }
        else if(TimerSlider.type==2)
        {
            
            
            bool lose = false;
            for(int i = 0; i < TimerSlider.result.Length; i++)
            {
                int ansNum;
                int.TryParse(ans[TimerSlider.quesNum[i]].text, out ansNum);
                if (TimerSlider.result[i] != ansNum)
                {
                    lose = true;
                    break;
                }
            }
            if (lose)
            {
                TimerSlider.lose();
            }
            else
            {
                TimerSlider.win();
            }
            /*if (ansNum == TimerSlider.result[onayCount]) //seçim yaptýrmadan yazma
            {
                onayCount++;
                if (onayCount == 3)
                {
                    TimerSlider.win();
                    onayCount = 0;
                }else
                ans[TimerSlider.quesNum[onayCount]].text = "?";
            }    
            else
            {
                TimerSlider.lose();
                onayCount = 0;
            }*/
            
            
            
        }
        NumberScroll.select = -1;
        
    }
   
}
