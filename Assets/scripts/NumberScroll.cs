using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumberScroll : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public Text [] ques;
    private int positionLeft;
    private int positionRight;
    public static int select=-1;
    bool dragLeft = false;
    bool dragRight = false;

    // Start is called before the first frame update
    void Start()
    {
        positionLeft = (((int)left.localPosition.y+63)/100);
        positionRight = (((int)right.localPosition.y+63) / 100);
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (dragLeft||dragRight )
        {
            positionLeft = (((int)left.localPosition.y + 63) / 100) ;
            positionRight = (((int)right.localPosition.y + 63) / 100) ;
            if (positionLeft == 10)
            {
                positionLeft = 9;
            }
            if (positionRight == 10)
            {
                positionRight = 9;
            }
            if (select == -1)
            {
                if(positionLeft!=0)
                ques[TimerSlider.quesNum[Comparator.onayCount]].text = positionLeft + "" + positionRight;
                else
                    ques[TimerSlider.quesNum[Comparator.onayCount]].text ="" + positionRight;
            }
            
            else
            {
                if(positionLeft!=0)
                    ques[select].text= positionLeft + "" + positionRight;
                else
                    ques[select].text ="" + positionRight;
            }
        }
        if (!dragLeft)
        {
            lerpLeft(positionLeft * 100-25);
        }
        if (!dragRight)
        {
            lerpRight(positionRight * 100-25);
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
}
