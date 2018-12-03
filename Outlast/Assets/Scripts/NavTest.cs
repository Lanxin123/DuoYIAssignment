using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//2018-12-01 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为 自动寻路以及加速效果
//从而达到模拟敌人AI的效果
//---------------------------------------------------------
public class NavTest : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        agent.speed += 0.01f;
    }
}
