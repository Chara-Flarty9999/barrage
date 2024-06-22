using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberbullet : MonoBehaviour
{
    SpriteRenderer mesh;
    Vector2 movement;
    Rigidbody2D rigidbody2d;
    AudioSource audioSource;
    /// <summary>
    /// 召喚時の音
    /// </summary>
    [SerializeField] AudioClip spawn;
    /// <summary>
    /// 飛んでく時の音
    /// </summary>
    [SerializeField] AudioClip fly;
    /// <summary>
    /// ナイフが飛んでく角度
    /// </summary>
    int _rote;
    float _rotation;
    /// <summary>
    /// ナイフの加速度
    /// </summary>
    float _magnification;
    float _waitTime;

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
        _rote = knife.rote;
        _magnification = knife.magnification;
        transform.rotation = Quaternion.Euler(0, 0, _rote);
        audioSource = GetComponent<AudioSource>();
        mesh = GetComponent<SpriteRenderer>();
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        StartCoroutine("Transparent");

        if (m_play == true)
        {
            mesh.material.color -= new Color32(0, 0, 0, 255);
            rigidbody2d.rotation -= 180;
        }


        Destroy(gameObject, 6);
        //Invoke("Destroy");
    }

    IEnumerator Transparent()　//ここで召喚の挙動。ベクトルも取得している。
    {
/*        if (m_play == true)
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
*/
        _rotation = transform.localEulerAngles.z;

        movement = AngleToVector2(_rotation);
        


        //c = 1; //ここで飛んでいく挙動が開始されるようになっている。

        audioSource.PlayOneShot(fly);
        rigidbody2d.AddForce(movement * new Vector2(_magnification, _magnification), ForceMode2D.Impulse);
        yield return null;
    }
}