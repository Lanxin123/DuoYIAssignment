using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2018-12-01 宋柏慧
//---------------------------------------------------------
//这个脚本的功能为 状态机的信号量改变
//从而达到动画切换的效果
//---------------------------------------------------------
public class AnimationController : MonoBehaviour
{
    Animator warriorAnimator;
    public GameObject sword;
    bool isChanged;
    new Rigidbody rigidbody;
    // Use this for initialization
    void Start()
    {
        warriorAnimator = GameObject.FindGameObjectWithTag("player").GetComponent<Animator>();

        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            warriorAnimator.SetBool("Idling", false);
        }
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            warriorAnimator.SetBool("Idling", true);
        }
        StartCoroutine(test());

    }
    IEnumerator test()
    {
        if (Input.GetMouseButtonDown(0))
        {
            warriorAnimator.SetBool("Attack", true);
            sword.gameObject.tag = "sword";
            yield return new WaitForSeconds(0.4f);
            warriorAnimator.SetBool("Attack", false);
            sword.gameObject.tag = "player";
        }

    }

}
