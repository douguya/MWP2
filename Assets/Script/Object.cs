using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Object : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    Rigidbody thisObject;
    Vector3 MoveVec;
    Vector3 MouseVec;
    Vector3 speedVec;
    Vector3 Volo;
    bool StartMagic=false;

   public GameObject sound;

    public int HP = 200;
    public float ColorH=260;
    public float Color1 = 0.57f;
    public float Color2 = 1;

    private bool ReceiveMagic =false;
    public GameObject GameManager;
    void Start()
    {
        sound=GameObject.Find("Sound_Manager");
        thisObject= this.GetComponent<Rigidbody>();
        GameManager= GameObject.Find("GameManager");
    }
    // ドラッグ中に実行されるメソッド
    public void Update()
    {
        if (BlockGen.GameNow==true)
        {
            // Mouse.text="Mouse:"+Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    obje.text = "Obje :"+this.transform.position;
            //   Add.text  = "Add  :"+((new Vector3(Input.mousePosition.x-(Screen.width/2f), Input.mousePosition.y-(Screen.height/2f), 0f)*0.1f)-this.transform.position);
            if (HP<=0)
            {
                Destroy(this.gameObject);
                GameManager.SendMessage("mainasuLife");
                sound.GetComponent<SoundManager>().deleteSound();

            }
            if (Vector3.Distance(this.transform.position, new Vector3(0f, 0f, 0f))>34)
            {
                Destroy(this.gameObject);

            }


            gameObject.GetComponent<Renderer>().material.color =  Color.HSVToRGB(ColorH= Map(HP, 0, 200, 0, 0.3f), Color1, Color2);

            ColorH= Map(HP, 0, 200, 0, 1.16f);
            Debug.Log(ColorH);

            if (StartMagic==true)
            {
                // AddReal.text  = "Doragu:"+a++;
                MouseVec=new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y-5f, this.transform.position.z);
                MoveVec=(MouseVec)-this.transform.position;

                this.transform.position=Vector3.SmoothDamp(this.transform.position, MouseVec, ref speedVec, 0.1f);
                ReceiveMagic=true;
            }
            else if (ReceiveMagic==false)
            {

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, 0f), Time.deltaTime*5);

            }
        }
    }

    public float Map(int value ,int V_min, int V_max,float R_min,float R_max)
    {


        Debug.Log("ナマコの心臓"+((R_max-R_min)/(V_max-V_min)));
        return  value*((R_max-R_min)/(V_max-V_min));

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        StartMagic=true;
        thisObject.velocity=new Vector3(0, 0, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
        StartMagic=false;
        MouseVec=new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y-5f, this.transform.position.z);
        MoveVec=(MouseVec)-this.transform.position;
        thisObject.velocity=MoveVec*2f;
        

    }


    public void OnDrag(PointerEventData eventData)
    {
        /*
        MouseVec=new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y-2.6f, this.transform.position.z);
        MoveVec=(MouseVec)-this.transform.position;


        this.transform.position=Vector3.SmoothDamp(this.transform.position, MouseVec, ref speedVec, 0.2f);
        */
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="Filde")
        {
            HP--;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("asasda");
        if (other.gameObject.tag=="OutFilde")
        {
            Destroy(this.gameObject);
        }
    }
}