using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//2018-12-01 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为 受伤后的处理
//从而达到游戏结束的效果
//---------------------------------------------------------
public class ishurted : MonoBehaviour
{
    public Image loseImage;
    public  void OnCollisionEnter(Collision pOther)
    {
        if (pOther.gameObject.tag == "monster")
        {
            loseImage.gameObject.SetActive(true);
            StartCoroutine(WaitSeconds(0.5f));
        }   
            
    }
    IEnumerator WaitSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Final");
    }

}
