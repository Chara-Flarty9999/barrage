using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
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
    /// 爆発時の音
    /// </summary>
    [SerializeField] AudioClip fly;
    /// <summary>
    /// 初期弾が飛んでいく角度。
    /// </summary>
    int _rote;
    /// <summary>
    /// "_rote + 360/bulletNumber"ずつ角度を変えていく。
    /// </summary>
    public float bulletRote;
    float _rotation;
    /// <summary>
    /// ナイフの加速度
    /// </summary>
    float _bulletNumber;
    float _waitTime;

    public static Vector2 AngleToVector2(float angle)
    {
        var radian = angle * (Mathf.PI / 180);
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject spawner = GameObject.Find("SpawnArea");
        KnifeSpawn knife = spawner.GetComponent<KnifeSpawn>();
        _rote = knife.rote;
        _bulletNumber = knife.bulletNumber;
        transform.rotation = Quaternion.Euler(0, 0, _rote);
        audioSource = GetComponent<AudioSource>();
        mesh = GetComponent<SpriteRenderer>();
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        StartCoroutine("BomberCraster");
        mesh.material.color -= new Color32(0, 0, 0, 255);
    }

    IEnumerator BomberCraster()　//ここで召喚の挙動。ベクトルも取得している。
    {
        audioSource.PlayOneShot(spawn);
        for (int i = 0; i < 30; i++)
        {
            mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 9);
            yield return new WaitForSeconds(0.01f);

        }
        yield return new WaitForSeconds(0.1f);

        _rotation = transform.localEulerAngles.z;

        movement = AngleToVector2(_rotation);



        //c = 1; //ここで飛んでいく挙動が開始されるようになっている。

        audioSource.PlayOneShot(fly);

        for (int i = 1; i < _bulletNumber; i++)
        {
            /*rigidbody2d.AddForce(movement * new Vector2(_bulletNumber, _bulletNumber)); //ForceMode2D.Impulse*/
            yield return new WaitForEndOfFrame();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
