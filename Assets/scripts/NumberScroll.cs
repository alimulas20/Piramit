using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class NumberScroll : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public Text [] ques;
    public AudioSource scroll;
    public Image [] Click;
    
    private int positionLeft;
    private int positionRight;
    public static int select=-1;
    bool dragLeft = false;
    bool dragRight = false;
    
    
    bool TruePick;
    public static bool LearnEnd;
    bool pickTime;//doðru seçim zamanlamasý için

    // Start is called before the first frame update
    void Start()
    {
        positionLeft = (((int)left.localPosition.y+63)/100);
        positionRight = (((int)right.localPosition.y+63) / 100);
        LearnEnd = true;
        pickTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerSlider.timeBraker&&LearnEnd)
        {
            LearnEnd = false;
            StartCoroutine(HowtoPlay());
        }
        if (dragLeft || dragRight)
        {
            scroll.UnPause();
            positionLeft = (((int)left.localPosition.y + 63) / 100);
            positionRight = (((int)right.localPosition.y + 63) / 100);
            if (positionLeft == 10)
            {
                positionLeft = 9;
            }
            if (positionRight == 10)
            {
                positionRight = 9;
            }
           
            else
            {
                write();
            }
            
        }
        else
            scroll.Pause();
        if (!dragLeft)
        {
            lerpLeft(positionLeft * 100);
        }
        if (!dragRight)
        {
            lerpRight(positionRight * 100);
        }
    }
    void write()
    {
        if (select == -1)
        {
            if (positionLeft != 0)
                ques[TimerSlider.quesNum[Comparator.onayCount]].text = positionLeft + "" + positionRight;
            else
                ques[TimerSlider.quesNum[Comparator.onayCount]].text = "" + positionRight;
        }

        else
        {
            if (positionLeft != 0)
                ques[select].text = positionLeft + "" + positionRight;
            else
                ques[select].text = "" + positionRight;
        }
    }
    public void StartDragLeft()
    {
        dragLeft = true;
    }
    public void EndDragLeft()
    {
        dragLeft = false;
    }
    public void StartDragRight()
    {
        dragRight = true;
    }
    public void EndDragRight()
    {
        dragRight = false;
    }
    public void select1()
    {
        select = 0;
    }
    void lerpLeft(int position)
    {
        float newY = Mathf.Lerp(left.localPosition.y, position, Time.deltaTime * 30f);
        Vector2 newPos = new Vector2(left.localPosition.x,newY);
        left.localPosition = newPos;
    }
    void lerpRight(int position)
    {
        float newY = Mathf.Lerp(right.localPosition.y, position, Time.deltaTime * 30f);
        Vector2 newPos = new Vector2(right.localPosition.x, newY);
        right.localPosition = newPos;
    }
    public void select2()
    {
        select = 1;
    }
    public void select3()
    {
        select = 2;
    }
    public void select4()
    {
        select = 3;
    }
    public void select5()
    {
        select = 4;
    }
    public void select6()
    {
        select = 5;
    }
     IEnumerator HowtoPlay()
    {

        for(int i = 0; i < 3; i++)
        {
            StartCoroutine(Fade(TimerSlider.quesNum[i],i));
            yield return new WaitWhile(() => !TruePick);
            TruePick = false;
        }
        StartCoroutine(OnayFade());
        yield return new WaitWhile(() => !TruePick);
       


    }
    IEnumerator Fade(int k,int result)
    {
        StartCoroutine(pickTimer());
        int counter = 0;
        while(select!=k&&pickTime)
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                if (select==k)
                {
                    Click[k].color = new Color(1, 1, 1, 0);
                    break;
                }
                Click[k].color = new Color(1, 1, 1, i);
                yield return null;
            }
            
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                if (select == k)
                {
                    Click[k].color = new Color(1, 1, 1, 0);
                    break;
                }
                Click[k].color = new Color(1, 1, 1, i);
                yield return null;
            }
         
            counter++;
        }
        if (!pickTime)
        {
            select = k;
            pickTime = true;
        }
        ques[k].fontSize = 65;
        if (k == 0)
        {
            ques[0].text = ques[1].text+ "+"+ ques[2].text;
        }
        else if(k==1)
        {
            if (TimerSlider.quesType == 0)
            {
                ques[1].text = ques[3].text +"+"+ ques[4].text;
            }
            else
            {
                ques[1].text = ques[0].text + "-" + ques[2].text;
            }
        }else if (k == 2)
        {
            if (TimerSlider.quesType == 0)
            {
                ques[2].text = ques[4].text + "+" + ques[5].text;
            }
            else
            {
                ques[2].text = ques[0].text + "-" + ques[1].text;
            }
        }
        else if (k == 3)
        {
            ques[3].text = ques[1].text + "-" + ques[4].text;
        }else if (k == 4)
        {
            if (TimerSlider.quesType == 1)
            {
                ques[4].text = ques[2].text + "-" + ques[5].text;
            }
            else
            {
                ques[4].text = ques[1].text + "-" + ques[3].text;
            }
        }
        else
        {
            ques[5].text = ques[2].text + "-" + ques[4].text;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ScrollFade(k,result));
        
       
    }
    IEnumerator ScrollFade(int k,int result)
    {
        StartCoroutine(pickTimer());
        while (!(dragRight||dragLeft|| !pickTime))
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                if(dragRight || dragLeft)
                {
                    Click[6].color = new Color(1, 1, 1, 0);
                    break;
                }
                Click[6].color = new Color(1, 1, 1, i);
                yield return null;
            }

            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                if (dragRight || dragLeft)
                {
                    Click[6].color = new Color(1, 1, 1, 0);
                    break;
                }
                // set color with i as alpha
                Click[6].color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        
        yield return new WaitWhile(() =>  pickTime&&int.Parse(ques[k].text) != TimerSlider.result[result]);
        if (!pickTime)
        {
            autoPick(TimerSlider.result[result]);
            yield return new WaitWhile(() => !pickTime);
        }
        TruePick = true;
    }
    IEnumerator OnayFade()
    {
        
        TimerSlider.timerStart();
        while (!Comparator.pick)
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                if (Comparator.pick)
                {
                    Click[7].color = new Color(1, 1, 1, 0);
                    break;
                }
                Click[7].color = new Color(1, 1, 1, i);
                yield return null;
            }

            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                if (Comparator.pick)
                {
                    Click[7].color = new Color(1, 1, 1, 0);
                    break;
                }
                // set color with i as alpha
                Click[7].color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        Comparator.pick = false;
        TruePick = true;
        
    }
    IEnumerator pickTimer()
    {
        float StartTime = Time.time;
        while (Time.time - StartTime < 3)
            yield return null;
        pickTime = false;
    }
    void autoPick(int result)
    {
        positionLeft = result/10;
        positionRight = result%10;
        write();
        ques[select].fontSize = 100;
        pickTime = true;
    }
}
