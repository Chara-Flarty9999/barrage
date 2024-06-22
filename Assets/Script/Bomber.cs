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
    /// ナイフが飛んでく角度
    /// </summary>
    int _rote;
    float _rotation;
    /// <summary>
    /// ナイフの加速度
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
