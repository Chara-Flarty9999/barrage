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
    /// �������̉�
    /// </summary>
    [SerializeField] AudioClip spawn;
    /// <summary>
    /// �������̉�
    /// </summary>
    [SerializeField] AudioClip fly;
    /// <summary>
    /// �i�C�t�����ł��p�x
    /// </summary>
    int _rote;
    float _rotation;
    /// <summary>
    /// �i�C�t�̉����x
    /// </summary>
    float _magnification;
    float _waitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
