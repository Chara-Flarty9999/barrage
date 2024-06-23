using System.Collections;
using UnityEngine;

public class Bomberbullet : MonoBehaviour
{
    SpriteRenderer mesh;
    Vector2 movement;
    Rigidbody2D rigidbody2d;
    AudioSource audioSource;

    /// <summary>
    /// ���ł����̉�
    /// </summary>
    //[SerializeField] AudioClip fly;
    /// <summary>
    /// �i�C�t�����ł��p�x
    /// </summary>
    float _rote;
    float _rotation;
    /// <summary>
    /// �i�C�t�̉����x
    /// </summary>
    float _magnification;
    float _waitTime;


    /// <summary>
    /// �x�N�g������p�x���擾����B
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
        //�X�|�[�����̏����擾����
        GameObject spawner = GameObject.Find("Bomber(Clone)");
        Bomber knife = spawner.GetComponent<Bomber>();
        _rote = knife.bulletRote;
        _magnification = 10;
        transform.rotation = Quaternion.Euler(0, 0, _rote);
        audioSource = GetComponent<AudioSource>();
        mesh = GetComponent<SpriteRenderer>();
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        StartCoroutine("Bulletshoot");
/*
        if (m_play == true)
        {
            mesh.material.color -= new Color32(0, 0, 0, 255);
            rigidbody2d.rotation -= 180;
        }*/


        Destroy(gameObject, 6);
        //Invoke("Destroy");
    }

    IEnumerator Bulletshoot()�@//�����ŏ����̋����B�x�N�g�����擾���Ă���B
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



        //c = 1; //�����Ŕ��ł����������J�n�����悤�ɂȂ��Ă���B

        //audioSource.PlayOneShot(fly);
        rigidbody2d.AddForce(movement * new Vector2(_magnification, _magnification), ForceMode2D.Impulse);
        transform.rotation = Quaternion.Euler(0, 0, _rote - 90);
        yield return null;
    }
}