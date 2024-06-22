using UnityEngine;
using UnityEngine.UI;

public class PlayerHitbox : MonoBehaviour
{
    float invTime = 1.5f;
    AudioSource m_AudioSource;
    int life = 20;
    public static bool inv = false;
    GameObject m_lifeText;
    SpriteRenderer m_player;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        m_player = player.GetComponent<SpriteRenderer>();
        m_AudioSource = GetComponent<AudioSource>();
        m_lifeText = GameObject.Find("HP Text");
        Text lifeText = m_lifeText.GetComponent<Text>();
        lifeText.text = " HP :" + life.ToString() + " / 20";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" && inv == false)
        {
            m_player.material.color = new Color32(255, 0, 0, 150);
            inv = true;
            life -= 1;
            m_AudioSource.Play();
            Text lifeText = m_lifeText.GetComponent<Text>();
            lifeText.text = " HP :" + life.ToString() + " / 20  ";

            Invoke("Invisible", invTime);

        }
    }

    void Invisible()
    {
        m_player.material.color = new Color32(255, 0, 0, 255);
        inv = false;
    }
}
