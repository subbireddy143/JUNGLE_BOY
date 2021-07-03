using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_Tut : MonoBehaviour
{
    public GameObject floors,Get,Set,Go,small_d,large_d,burnt_d,down_d,ready_d;
    Vector3 Initialpos,floors_pos,Get_Pos; 
    // Start is called before the first frame update
    void Start()
    {
        Initialpos = transform.position;
        floors_pos = floors.GetComponent<Transform>().position;

        Get.SetActive(false);
        Set.SetActive(false);
        Go.SetActive(false);
        Get_Pos = Get.GetComponent<Transform>().position;
        

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tut_Floor" && !(floors.GetComponent<Transform>().position.x < -85f)) {
            StartCoroutine(reverse());
        }
        if (collision.gameObject.tag == "floor") {
            if (floors.GetComponent<Transform>().position.x < 5f) {
                floors_pos.x = 5f;
                large_d.SetActive(true);
                small_d.SetActive(false);
                burnt_d.SetActive(false);
                down_d.SetActive(false);
                ready_d.SetActive(false);
            }
            if (floors.GetComponent<Transform>().position.x < -9f)
            {
                floors_pos.x = -9f;
                large_d.SetActive(false);
                small_d.SetActive(false);
                burnt_d.SetActive(false);
                down_d.SetActive(true);
                ready_d.SetActive(false);
            }
            if (floors.GetComponent<Transform>().position.x < -60f)
            {
                floors_pos.x = -40f;
                large_d.SetActive(false);
                small_d.SetActive(false);
                burnt_d.SetActive(true);
                down_d.SetActive(false);
                ready_d.SetActive(false);
            }
            if (floors.GetComponent<Transform>().position.x < -80f)
            {
                floors_pos.x = -80f;
                large_d.SetActive(false);
                small_d.SetActive(false);
                burnt_d.SetActive(false);
                down_d.SetActive(false);
                ready_d.SetActive(true);
            }
        }
    }
    public IEnumerator reverse() {
        yield return new WaitForSeconds(.5f);
        transform.position = Initialpos;
        floors.GetComponent<Transform>().position = floors_pos;
        Debug.Log(floors_pos);
        Debug.Log(floors.GetComponent<Transform>().position);
        Time.timeScale = 0.1f;
        Get.SetActive(true);
        Get.GetComponent<Transform>().position=Get_Pos;
        yield return new WaitForSeconds(.1f);
        Get.SetActive(false);
        Set.SetActive(true);
        Set.GetComponent<Transform>().position = Get_Pos;
        yield return new WaitForSeconds(.1f);
        Set.SetActive(false);
        Go.SetActive(true);
        Go.GetComponent<Transform>().position = Get_Pos;
        Time.timeScale = 1f;
        
    }

    public void home()
    {
        //move to home
        SceneManager.LoadScene("Official_Home");
    }

}
