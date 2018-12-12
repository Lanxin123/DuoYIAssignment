using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IsArrived : MonoBehaviour {

    public Image winImage;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag=="B")
        {
           winImage.gameObject.SetActive(true);
            StartCoroutine(WaitSeconds(0.5f));
        }
        if (other.tag == "B")
        {
            Onfile();
        }
    }
    public void Onfile()
    {
        PlayerPrefs.SetInt("count", isattacked.TotalTime);
    }

    IEnumerator WaitSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Final");
    }
}
