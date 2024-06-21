using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
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
    /// Blasterが飛んでく角度
    /// </summary>
    private int rote;
    float rotation;

    float m_blastwait;


    // Start is called before the first frame update
    void Start()
    {
        GameObject spawner = GameObject.Find("SpawnArea");
        KnifeSpawn blaster = spawner.GetComponent<KnifeSpawn>();
        rote = blaster.rote;
        transform.rotation = Quaternion.Euler(0, 0, rote);
        audioSource = GetComponent<AudioSource>();
        mesh = GetComponent<SpriteRenderer>();
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        StartCoroutine("Transparent");
        mesh.material.color -= new Color32(0, 0, 0, 255);
        rigidbody2d.rotation -= 180;
    }
    IEnumerator Transparent()　//ここで召喚の挙動。ベクトルも取得している。
    {
            audioSource.PlayOneShot(spawn);
            for (int i = 0; i < 30; i++)
            {
                mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 9);
                rigidbody2d.rotation += 6;
                yield return new WaitForSeconds(0.01f);

            }
            yield return new WaitForSeconds(m_blastwait);

        rotation = transform.localEulerAngles.z;



        //c = 1; //ここで飛んでいく挙動が開始されるようになっている。

        audioSource.PlayOneShot(fly);

        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
