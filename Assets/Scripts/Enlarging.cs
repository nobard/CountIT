using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enlarging : MonoBehaviour 
{
    
    public Text enlargeArea;

    private float doubleClickTimeLimit = 0.35f;

    bool clickedOnce = false;

    float count = 0f;

    void OnMouseDown()
    {
        startClick();
    }

    public void startClick()
    {
        StartCoroutine (ClickEvent ());
    }

    public IEnumerator ClickEvent()
    {
        if(!clickedOnce && count < doubleClickTimeLimit)
        {
            clickedOnce = true;
        } 
        else 
        {
            clickedOnce = false;
            yield break;  //If the button is pressed twice, don't allow the second function call to fully execute.
        }
        yield return new WaitForEndOfFrame();

        while(count < doubleClickTimeLimit)
        {
            if(!clickedOnce)
            {
                DoubleClick();
                count = 0f;
                clickedOnce = false;
                yield break;
            }
            count += Time.deltaTime;// increment counter by change in time between frames
            yield return null; // wait for the next frame
        }
        SingleClick();
        count = 0f;
        clickedOnce = false;
    }
         
    private void SingleClick()
    {
        CheckPossibility("double"); 
    }

    private void DoubleClick()
    {
        CheckPossibility("triple");
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CheckPossibility("divide");
        }
    }
    void Update()
    {
        enlargeArea.text = (this.GetComponent<ObjectsArea>().Area).ToString();
    }

    void CheckPossibility(string enlarge)
    {
        var pole = GameObject.Find("Pole");
        var doubleLimit = pole.GetComponent<Pole>().tempArea + this.GetComponent<ObjectsArea>().Area / 100;
        var tripleLimit = doubleLimit + this.GetComponent<ObjectsArea>().Area / 100;
        var divideLimit = this.GetComponent<ObjectsArea>().Area;
        if(enlarge == "triple" && tripleLimit <= 3)
        {
            CountArea(pole, 3);
        }
        else if(enlarge == "double" && doubleLimit <= 3)
        {
            CountArea(pole, 2);
        }
        else if(enlarge == "divide" && divideLimit % 2 == 0)
        {
            CountArea(pole, 1);
        }
    }

    void CountArea(GameObject pole, int enlarge)
    {
        var excessArea = this.GetComponent<ObjectsArea>().Area;
        if(enlarge == 3)
        {
            this.GetComponent<ObjectsArea>().Area *= 3;
        }
        else if(enlarge == 2)
        {   
            this.GetComponent<ObjectsArea>().Area *= 2;
        }
        else if(enlarge == 1)
        {
            this.GetComponent<ObjectsArea>().Area /= 2;
        }
        var addArea = this.GetComponent<ObjectsArea>().Area;
        pole.GetComponent<Pole>().CountEnlargeArea(excessArea, addArea);
    }
}