using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public Text countText;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sword")
        {
            this.gameObject.SetActive(false);
        }
    }
    public virtual void OnCollisionEnter(Collision pOther)
    {
        if (pOther.gameObject.tag == "sword")
        {
            Instantblod(pOther);
            Back();
            count = count + 1;
            Onfile();
        }

    }
    public void Onfile()
    {
        PlayerPrefs.SetInt("count", count);
    }

    private void Update()
    {
        SetCountText();
    }

    private void SetCountText()
    {
        countText.text = "得分:" + count.ToString();
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
}
