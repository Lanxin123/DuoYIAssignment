using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



//2018-12-07 宋柏慧
//---------------------------------------------------------
//添加巡逻判断控制
//---------------------------------------------------------

//2018-12-01 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为 自动寻路以及加速效果
//从而达到模拟敌人AI的效果
//---------------------------------------------------------

public class NavTest : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    private float distance;
    public Animator anim;
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
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (distance < 30)
        {
            anim.enabled=false;
        }
    }
}
