using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimento : MonoBehaviour
{
    public float life = 10;

    public GameObject bullet;

    public AudioSource explosao;

    public Image lifeG;

    void Start()
    {
        explosao = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Fire1")){

            GameObject obj = Instantiate(bullet,transform.position + transform.forward* 5f, Quaternion.identity);
            obj.GetComponent<bulletMove>().forward = transform.forward;
            Destroy(obj,2f);

        }

        //Debug.Log(life);
        lifeG.GetComponent<RectTransform>().sizeDelta = new Vector2((life/10f)*200f,20f);
        
        if(life<=0 ){
            Application.LoadLevel(Application.loadedLevel);
        }
    }

     public void takeDamage(){
        explosao.Play();
        life--;

    }
}
