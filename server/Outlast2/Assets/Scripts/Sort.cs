using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using UnityEngine.SceneManagement;
using System.IO;


//2018-12-01 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为 排序并显示得分
//从而达到排行榜的效果
//---------------------------------------------------------

public class Sort : MonoBehaviour
{

    public GameObject L0;
    public GameObject[] newIndexs;

    public GameObject Panel;

    public Text indexText;

    int count;//用来把取的数赋值于此

   public static int[] save = new int[10];
    int Num;
    string saveIntStr;

    //插入排序

    // Use this for initialization
    void Start()
    {

        //获取上一场景存储的数据
        count = PlayerPrefs.GetInt("count");
        indexText.text = "Your score：" + count.ToString();
        var countlist = ReadFile();
        countlist.Sort();
        countlist.Reverse();
        //获取存储的排行榜中的数据
        for (int i = 0; i < 10; i++)
        {
            string saveIntStrS = saveIntStr + i.ToString();
            save[i] = (int)countlist[i];
        }

       
        //把当前数据存储
        for (int j = 0; j < 10; j++)
        {
            string saveIntStrI = saveIntStr + j.ToString();
            PlayerPrefs.SetInt(saveIntStrI, save[j]);
            //PlayerPrefs.SetInt(saveIntStrI, 0);
        }

        //将数据显示到场景UI中
        for (int i = 0; i < newIndexs.Length; i++)
        {
            string saveIntStrO = saveIntStr + i.ToString();
            newIndexs[i] = Instantiate(L0, transform.position, transform.rotation) as GameObject;
            newIndexs[i].transform.SetParent(Panel.transform);
            newIndexs[i].GetComponent<Text>().text = "\t \t \t \t \t" + PlayerPrefs.GetInt(saveIntStrO).ToString() + "\t \t ";
        }
    }

    //删除接口 (未被调用)
    public void DeleteFile()
    {
        PlayerPrefs.DeleteAll();
    }

    public void reStart()
    {
        SceneManager.LoadScene("MainGame");
    }
    public static ArrayList ReadFile()
    {
        ArrayList str = new ArrayList();

        StreamReader file = new StreamReader("../count.txt");
        string line;
        while ((line = file.ReadLine()) != null)
        {
            str.Add(Convert.ToInt32(line));
        }
        file.Close();
        
        return str;
    }

}
