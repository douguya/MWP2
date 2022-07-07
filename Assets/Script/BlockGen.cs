using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BlockGen : MonoBehaviour
{
    // Start is called before the first frame update
  

    Vector3 RiriasePoint;
    Vector3 circle;

    public float timeOut;
    private float timeElapsed;
    public GameObject Block;


    [SerializeField] SoundManager SoundManager;
    [SerializeField] GameObject canvasu1;
    [SerializeField] Text Life ;
    [SerializeField] Text Score;
    [SerializeField] GameObject canvasu2;
    [SerializeField] Text Risult;

   
    double ScoreS=0;
    private int LifeS=5;

    public static bool GameNow=true;

    public void Start()
    {
        GameNow=true;
        StartCoroutine("DelayMethod");
        
        canvasu1.SetActive(true);
        canvasu2.SetActive(false);

        Life.text="Life:OOOOO";
        Score.text="Score:0";
      
        for (int loop = 0; loop<5;)
        {
            circle=Random.insideUnitCircle*30;
            if ((Mathf.Pow(circle.x, 2)+Mathf.Pow(circle.y, 2))>200)
            {

                loop++;
                Instantiate(Block, new Vector3(circle.x, circle.y, 0f), Quaternion.Euler(Random.Range(1, 300), Random.Range(1, 300), Random.Range(1, 300)));
            }
        }

    }


    public void Update()
    {
        if (GameNow==true) {

            timeElapsed += Time.deltaTime;
            Score.text="Score:"+ScoreS.ToString("f1");
            Life.text="Life:"+ LifeAnc();
            Risult.text="Score:"+ScoreS.ToString("f1");


            // for (int loop = 0; loop<10;)
            // {
            if (timeElapsed >= timeOut)
            {
                timeElapsed = 0.0f;
                for (int loop = 0; loop<5;) {
                    circle=Random.insideUnitCircle*30;
                    if ((Mathf.Pow(circle.x, 2)+Mathf.Pow(circle.y, 2))>200)
                    {

                        loop++;
                        Instantiate(Block, new Vector3(circle.x, circle.y, 0f), Quaternion.Euler(Random.Range(1, 300), Random.Range(1, 300), Random.Range(1, 300)));
                    }
                }
            }

            if (LifeS<=0)
            {
                GameRisult();

            }
        }
   



    }
    IEnumerator ChangeColor()
    {
        //赤色にする
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        //3秒停止
        yield return new WaitForSeconds(3);

        //青色にする
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }


    IEnumerator DelayMethod()
    {
        if (BlockGen.GameNow==true)
        {
            yield return new WaitForSeconds(0.1f);
            ScoreS+=0.1;
            StartCoroutine("DelayMethod");
        }
    }

    private string LifeAnc()
    {

        string ImiLife="";
   
        for (int loop = 0; loop<LifeS; loop++)
        {
            ImiLife=ImiLife+"O";

        }
        for (int loop = 0; loop<5-LifeS; loop++)
        {
            ImiLife=ImiLife+" -";
        }

        return ImiLife;
    }



    public void mainasuLife()
    {
        LifeS--;
    }

  public void GameRisult()
    {
        GameNow=false;
        canvasu1.SetActive(false);
        canvasu2.SetActive(true);
        SoundManager.resultSound();

    }


}


