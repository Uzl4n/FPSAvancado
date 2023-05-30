using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public GameObject explosao;
    public Vector3 forward;
    [SerializeField]
    public float speed = 0.5f;
    // Start is called before the first frame update
   void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += forward * speed;
    }

    void OnCollisionEnter(Collision col)
    {
        //Destruir a bullet.
        GameObject obj = col.collider.gameObject;
        if(obj.tag == "Enemy"){
            obj.GetComponent<aiEnemy>().takeDamagEnemy();
       }else if(obj.tag == "Player"){
            obj.transform.Find("FirstPersonCharacter").GetComponent<movimento>().takeDamage();
        }
        Destroy(gameObject);
    }


    void OnDestroy(){
        GameObject obj = Instantiate(explosao,transform.position,Quaternion.identity);
        
        Destroy(obj,3f);
        //Debug.Log("Destruido");
    }
}
