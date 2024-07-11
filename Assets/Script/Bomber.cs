using System.Collections;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField] GameObject _bomberBullet = default;
    SpriteRenderer mesh;
    Vector2 movement;
    Rigidbody2D rigidbody2d;
    AudioSource audioSource;
    Camera _cam;
    /// <summary>
    /// �������̉�
    /// </summary>
    [SerializeField] AudioClip spawn;
    /// <summary>
    /// �������̉�
    /// </summary>
    [SerializeField] AudioClip fly;
    /// <summary>
    /// �����e�����ł����p�x�B
    /// </summary>
    int _rote;
    /// <summary>
    /// "_rote + 360/bulletNumber"���p�x��ς��Ă����B
    /// </summary>
    public float bulletRote;
    float _rotation;
    /// <summary>
    /// �y���e�̌�
    /// </summary>
    float _bulletNumber;

    float _blastWaitTime;

    public static Vector2 AngleToVector2(float angle)
    {
        var radian = angle * (Mathf.PI / 180);
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;

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

    IEnumerator BomberCraster()�@//�����ŏ����̋����B�x�N�g�����擾���Ă���B
    {
        audioSource.PlayOneShot(spawn);
        for (int i = 0; i < 30; i++)
        {
            mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 9);
            yield return new WaitForSeconds(0.01f);

        }
        yield return new WaitForSeconds(0.8f);

        Vector3 pos = _cam.transform.position;
        bulletRote = transform.localEulerAngles.z;
        AudioSource.PlayClipAtPoint(fly, pos);
        yield return new WaitForSeconds(0.01f);

        for (int i = 0; i < _bulletNumber; i++)
        {
            Instantiate(_bomberBullet, this.transform.position, Quaternion.identity);
            bulletRote += 360 / _bulletNumber;
            /*rigidbody2d.AddForce(movement * new Vector2(_bulletNumber, _bulletNumber)); //ForceMode2D.Impulse*/
            yield return null;
        }
        for (int i = 0; i < 30; i++)
        {
            mesh.material.color -= new Color32(0, 0, 0, 10);
            transform.localScale += new Vector3(0.02f, 0.02f);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
