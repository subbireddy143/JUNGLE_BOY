using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatingFloor : MonoBehaviour
{
    public int Select_Floor, Select_type;
    public GameObject[] small,medium,large,bushes,bent,Coin_Set,Extras;
    public GameObject Gem,Freeze;
    Vector3 position;
    float Gem_Time,Freeze_Time;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Gem_pack", 0) == 1) {
            PlayerPrefs.SetFloat("Gem_Time", 15);
            PlayerPrefs.SetInt("Gem_pack",0);
        }
        Gem_Time = PlayerPrefs.GetFloat("Gem_Time",60);
        InvokeRepeating("instantiate_Gem", 1f, Gem_Time);
        PlayerPrefs.SetFloat("Gem_Time", 60);

        InvokeRepeating("instantiate_Coin",1f,4f);
        InvokeRepeating("instantiate", 1f, 1.8f);

        InvokeRepeating("instantiate_Extras", 1f, 10f);

        Freeze_Time = PlayerPrefs.GetFloat("Freeze_Time",43);
        InvokeRepeating("instantiate_Freeze",1f,Freeze_Time);

        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    void instantiate() {
        Select_type = Random.Range(1,5);
        switch (Select_type) {
            case 1:
                Select_Floor = Random.Range(0,small.Length);
                position.y = Random.Range(-1f, .5f);
                Instantiate(small[Select_Floor], position, transform.rotation);
                break;
            case 2:
                Select_Floor = Random.Range(0,medium.Length);
                position.y = Random.Range(-2f, 0f);
                Instantiate(medium[Select_Floor], position, transform.rotation);
                break;
            case 3:
                Select_Floor = Random.Range(0,large.Length);
                position.y = Random.Range(-2f, 0f);
                Instantiate(large[Select_Floor], position, transform.rotation);
                break;
            case 4:
                Select_Floor = Random.Range(0,bent.Length);
                position.y = Random.Range(-2f, 0f);
                Instantiate(bent[Select_Floor], position, transform.rotation);
                break;
            case 5:
                Select_Floor = Random.Range(0,bushes.Length);
                position.y = Random.Range(-2f, -1.5f);
                Instantiate(bushes[Select_Floor], position, transform.rotation);
                break;
        }
        position = transform.position;
        

    }
    void instantiate_Coin()
    {
        Select_Floor = Random.Range(0,Coin_Set.Length);
        position.y = position.y + 1.5f;
        position.x += 1f;
        Instantiate(Coin_Set[Select_Floor],position,transform.rotation);
        position = transform.position;
    }
    void instantiate_Extras() {
        Select_Floor = Random.Range(0,3);
        position.y = position.y + 2f;
        Instantiate(Extras[Select_Floor],position,transform.rotation);
        position = transform.position;
    }
    void instantiate_Gem() {
        position.y = position.y + 1.5f;
        Instantiate(Gem, position, transform.rotation);
        position = transform.position;
    }
    void instantiate_Freeze()
    {
        position.y = position.y + 1.5f;
        Instantiate(Freeze, position, transform.rotation);
        position = transform.position;
    }
}
