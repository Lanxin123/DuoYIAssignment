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

//2018-12-13 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为 发送分数到服务器
//---------------------------------------------------------

public class Net : MonoBehaviour
{
    public byte[] GetBytes(string data)
    {
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        int dataLength = dataBytes.Length + 4;
        byte[] lengthBytes = BitConverter.GetBytes(dataLength);
        byte[] newBytes = lengthBytes.Concat(dataBytes).ToArray();
        return newBytes;
    }
    // Use this for initialization
    void Start()
    {
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5566));
        byte[] data = new byte[1024];
        //"{\"ID\"" + ":\"" + isattacked.TotalTime.ToString() + "\"}"
        var userlist = GetBytes(isattacked.TotalTime.ToString());
        clientSocket.Send(userlist);

        clientSocket.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
