using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine.SceneManagement;

//2018-12-12 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为 登录和注册的写入和判断
//---------------------------------------------------------

public class Login : MonoBehaviour
{

    //注册信息
    public InputField inputName;
    public InputField inputPaswd;

    public Dictionary<string, string> allAccount = new Dictionary<string, string>();


    private void Start()
    {
        ReadJson();
    }

    public void LoginButton()
    {
        string username = inputName.text;
        string password = inputPaswd.text;

        if (username == "" || password == "")
        {
            print("用户名或密码为空,请重新输入");
            return;//如果用户名或密码为空,进入这里
        }
        else if (allAccount.ContainsKey(username))
        {
            if (password == allAccount[username])
            {
               
                SceneManager.LoadScene("MainGame");
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void SignUpButton()
    {
        string username = inputName.text;
        string password = inputPaswd.text;

        if (username == "" || password == "")
        {
            return;
        }
        else {

            allAccount.Add(username, password);


            string path = "../login.txt";
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                Debug.LogError("找不到储存文件!!!!!");
            }
            StreamWriter writer = new StreamWriter(path);
            JsonData jd = JsonMapper.ToJson(allAccount);
            writer.Write(jd);
            writer.Close();
            file.Refresh();

            print("注册成功!!");
            return;
        }
    }
    public void ReadJson()
    {
        string path = "../login.txt";
        FileInfo file = new FileInfo(path);
        if (!file.Exists)
        {
            Debug.LogError("找不到储存文件!!!!!");
        }
        string all = File.ReadAllText(path);
        allAccount = JsonMapper.ToObject<Dictionary<string, string>>(all);
    }
}