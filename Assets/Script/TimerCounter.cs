using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounter : MonoBehaviour
{
    AudioSource m_AudioSource;
    GameObject m_timeText = default;
    float _nowtime;
    float _maxtime = 120f;
    float _time;
    GameObject m_lifeText;
    GameObject m_gameover;
    GameObject m_bgm;
    GameObject m_spawn;
    public GameObject ButtonUIObj;
    AudioSource m_BGM;
    GameObject player;
    [SerializeField] AudioClip m_Clear;

    // Start is called before the first frame update
    void Start()
    {
        _nowtime = 0;
        m_AudioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        m_lifeText = GameObject.Find("HP Text");
        m_gameover = GameObject.Find("Gameover");
        m_bgm = GameObject.Find("BGM");
        m_BGM = m_bgm.GetComponent<AudioSource>();
        m_spawn = GameObject.Find("SpawnArea");
        m_timeText = GameObject.Find("TimeText");
    }

    // Update is called once per frame
    void Update()
    {
        _nowtime += Time.deltaTime;
        _time = _maxtime - _nowtime;
        m_timeText.GetComponent<Text>().text = _time.ToString("F2");
        if (_time < 0)
        {
            Destroy(player); Destroy(m_spawn);
            m_AudioSource.PlayOneShot(m_Clear);
            Text gameoverText = m_gameover.GetComponent<Text>();
            gameoverText.text = "Congratulations!";
            ButtonUIObj.SetActive(true);
            Text lifeText = m_lifeText.GetComponent<Text>();
            lifeText.text = " ";
            Destroy(gameObject, 2f);
            m_BGM.mute = true;
        }
    }
}
