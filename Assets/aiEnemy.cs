using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aiEnemy : MonoBehaviour
{
    public GameObject bullet;
    public Animator anim;
    public Image vidaEnemy;
    
    public float timer = 0;
    private float speed= 0.03f;
    public int life = 5000;

    private bool startAttack = false;
    private float startAttackTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
  
    }

    private void shoot(){
       
        timer+=Time.deltaTime;
        if(timer >= 2.0f){
            timer = 0;
            GameObject obj = Instantiate(bullet,transform.position + new Vector3(0,0.09f,0) + transform.forward* 3f, Quaternion.identity);
            obj.GetComponent<bulletMove>().forward = transform.forward;
            Destroy(obj,2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

        float distancePlayer = Vector3.Distance(transform.position,player.transform.position);

        if(distancePlayer > 15.0f){
                if(startAttack){
                    anim.Play("assault_combat_run");
                    transform.position+=transform.forward*speed;
                }else{
                    startAttackTimer+=Time.deltaTime;
                    if(startAttackTimer >= 1.0f){
                        startAttack = true;
                        startAttackTimer = 0;
                    }
                }
        }else{
            //Debug.DrawRay(transform.position,transform.forward*10f,Color.red);
            startAttack = false;
            this.shoot();
            anim.Play("assault_combat_idle");
        }
        
        atualizarUI();

        if(life <= 0){
            Destroy(gameObject);
        }
    }

    

    private void atualizarUI(){
        Debug.Log(life);
        vidaEnemy.GetComponent<RectTransform>().sizeDelta = new Vector2((life/10f)*14.44f,1.99f);
    }

    public void takeDamagEnemy(){
        
        life--;

    }
}
