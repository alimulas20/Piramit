using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comparator : MonoBehaviour
{
    public Text[] ans;
    int result;
    public static int onayCount;
    public static bool pick;
    void Start()
    {
        result = TimerSlider.result[0];
        pick = false;
    }
    void Update()
    { 
        if(TimerSlider.type==1)
        result = TimerSlider.result[0];
    }
    public void onay()
    {

        
        if (NumberScroll.LearnEnd)
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
            else if (TimerSlider.type == 2)
            {


                bool lose = false;
                for (int i = 0; i < TimerSlider.result.Length; i++)
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
            }

            NumberScroll.select = -1;
        }else if (!TimerSlider.timeBraker)
        {
            NumberScroll.LearnEnd = true;
            pick = true;
            onay();
        }
    }
   
}
