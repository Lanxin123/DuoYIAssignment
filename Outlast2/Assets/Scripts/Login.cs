using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    //Toggle
    private Toggle fogPasswd;

    //注册信息
    public InputField inputName;
    public InputField inputPaswd;

    public void OnCLick()
    {
        if (inputName.text.Trim() == "root" && inputPaswd.text.Trim() == "123456")
        {
            Application.LoadLevel("MainGame");
        }
        else
        {
            Debug.Log("登录失败!");
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }

   public void regist()
    {
        //如果可以的或直接将数据写入数据库在这里我们仅仅模拟下功能就行了
        if (inputName.text != "" && inputPaswd.text != "")
        {
            Debug.Log("注册成功");
        }
        else
        {
            Debug.Log("请输入注册信息");
        }
    }
}