using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knife : MonoBehaviour
{

    SpriteRenderer mesh;
    public Vector2 movement;
    Rigidbody2D rigidbody2d;
    AudioSource audioSource;
    /// <summary>
    /// 召喚時の音
    /// </summary>
    public AudioClip spawn;
    /// <summary>
    /// 飛んでく時の音
    /// </summary>
    public AudioClip fly;
    /// <summary>
    /// ナイフが飛んでく角度
    /// </summary>
    private int rote;
    float rotation;
    /// <summary>
    /// ナイフの加速度
    /// </summary>
    float magnification;
    float m_waitTime;

    public bool m_play = true;
    

    /// <summary>
    /// ベクトルから角度を取得する。
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static Vector2 AngleToVector2(float angle)
    {
        var radian = angle * (Mathf.PI / 180);
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        //スポーン時の情報を取得する
        GameObject spawner = GameObject.Find("SpawnArea");
        KnifeSpawn knife = spawner.GetComponent<KnifeSpawn>();
        rote = knife.rote;
        magnification = knife.magnification;
        transform.rotation = Quaternion.Euler(0, 0, rote);
        audioSource = GetComponent<AudioSource>();
        mesh = GetComponent<SpriteRenderer>();
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        StartCoroutine("Transparent");

        if (m_play == true)
        {
            mesh.material.color -= new Color32(0, 0, 0, 255);
            rigidbody2d.rotation -= 180;
        }
        
        
        Invoke("Destroy", 6);
    }

    IEnumerator Transparent()　//ここで召喚の挙動。ベクトルも取得している。
    {
        if(m_play == true)
        {
            audioSource.PlayOneShot(spawn);
            for (int i = 0; i < 30; i++)
            {
                mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 9);
                rigidbody2d.rotation += 6;
                yield return new WaitForSeconds(0.01f);

            }
            yield return new WaitForSeconds(0.1f);
        }
        
        rotation = transform.localEulerAngles.z;

        movement = AngleToVector2(rotation);
        
        

        //c = 1; //ここで飛んでいく挙動が開始されるようになっている。

        audioSource.PlayOneShot(fly);

        for (int i = 0; i < 50; i++)
        {
            rigidbody2d.AddForce(movement * new Vector2(magnification, magnification)); //ForceMode2D.Impulse
            yield return new WaitForSeconds(0.01f);
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}