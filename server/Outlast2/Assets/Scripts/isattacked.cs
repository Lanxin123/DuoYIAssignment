using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//2018-12-01 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为 被攻击后的反应
//从而达到怪物后退 在被砍点生成粒子的效果
//---------------------------------------------------------

public class isattacked : MonoBehaviour
{

    public GameObject blod;
    private int count = 0;
   // public Text countText;
    public static int TotalTime = 120;//总时间

    public Text TimeText;//在UI里显示时间
    public string LoadsceneName;
    public Image loseImage;
    public AudioSource damage;

    private int mumite;//分

    private int second;//秒

    void Start()
    {

        StartCoroutine(startTime());   //运行一开始就进行协程

    }

    public IEnumerator startTime()
    {

        while (TotalTime >= 0)
        {

            //Debug.Log(TotalTime);//打印出每一秒剩余的时间

            yield return new WaitForSeconds(1);//由于开始倒计时，需要经过一秒才开始减去1秒，
                                               //所以要先用yield return new WaitForSeconds(1);然后再进行TotalTime--;运算

            TotalTime--;

            TimeText.text = "Time:" + TotalTime;

            if (TotalTime <= 0)
            {                //如果倒计时剩余总时间为0时，就跳转场景

                loseImage.gameObject.SetActive(true);
                StartCoroutine(WaitSeconds(0.5f));

            }

            mumite = TotalTime / 60; //输出显示分

            second = TotalTime % 60; //输出显示秒

            string length = mumite.ToString();
            if (second >= 10)
            {

                TimeText.text ="倒计时: "+ "0" + mumite + ":" + second;
            }     //如果秒大于10的时候，就输出格式为 00：00

            else
                TimeText.text = "倒计时: "+"0" + mumite + ":0" + second;      //如果秒小于10的时候，就输出格式为 00：00

        }


    }

    public virtual void OnCollisionEnter(Collision pOther)
    {
        if (pOther.gameObject.tag == "sword")
        {
            Instantblod(pOther);
            damage.Play();
            Back();

        }
        

    }
   
    private void Update()
    {
        
    }
    private void Instantblod(Collision pOther)
    {
        ContactPoint contact = pOther.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;    //这个就是碰撞点
        blod = Instantiate(blod, pos, rot);  //在碰撞点产生爆炸火焰
        blod.transform.parent = this.transform;
    }

    //若Rigbody不FreezePosition会产生后退 但效果不明显 会偏移  原因可能为采用的模型问题
    //所以用此方法模拟后退
    private void Back()
    {
        this.gameObject.transform.Translate(new Vector3(-1, 0, -1));
    }

    IEnumerator WaitSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Final");
    }
}
