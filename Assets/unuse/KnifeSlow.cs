using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeSlow : MonoBehaviour
{

    SpriteRenderer mesh;
    private Vector2 movement;
    Rigidbody2D rigidbody2d;
    int c;
    AudioSource audioSource;
    public AudioClip spawn;
    public AudioClip fly;
    public int rote;
    float rotation;


    public static Vector2 AngleToVector2(float angle)
    {
        var radian = angle * (Mathf.PI / 180);
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
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

        rotation = transform.localEulerAngles.z;

        movement = AngleToVector2(rotation);

        c = 1; //ここで飛んでいく挙動が開始されるようになっている。

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
            //Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rigidbody2d.AddForce(new Vector2(movement.x * 5, movement.y * 5)); //, ForceMode2D.Impulse
        }

    }
}