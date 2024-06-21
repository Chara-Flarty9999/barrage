using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeDown : MonoBehaviour
{

    SpriteRenderer mesh;
    private Vector2 movement, cachedDirection;
    Rigidbody2D rigidbody2d;
    Transform knifetransform;
    int c;
    AudioSource audioSource;
    public AudioClip spawn;
    public AudioClip fly;


    // Start is called before the first frame update
    void Start()
    {
        //movement = new Vector2 ();
        audioSource = GetComponent<AudioSource>();
        mesh = GetComponent<SpriteRenderer>();
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        knifetransform = this.GetComponent<Transform>();
        StartCoroutine("Transparent");
        mesh.material.color -= new Color32(0,0,0,255);
        rigidbody2d.rotation -= 180;
        
    }

    IEnumerator Transparent()
    {
        
        audioSource.PlayOneShot(spawn);
        for (int i = 0; i < 30; i++)
        {
            mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 9);
            rigidbody2d.rotation += 6;
            yield return new WaitForSeconds(0.01f);
            
        }
        c = 1;
        audioSource.PlayOneShot(fly);
    }


    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (c == 1) 
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
            //rigidbody2d.MoveRotation(rigidbody2d.rotation);
            //rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y) + knifetransform.forward * Input.GetAxis("Vertical") * (-3.0f);
        }
        
    }

    //召喚時エフェクト
    public void Spawn()
    {

    }

}
