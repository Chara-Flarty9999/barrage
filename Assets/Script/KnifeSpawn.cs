using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class KnifeSpawn : MonoBehaviour
{
    public int damage;
    float y;
    float x;
    /// <summary>
    /// ���i����i�C�t�B
    /// </summary>
    [SerializeField] GameObject m_spawnPrefab = default;
    /// <summary>
    /// �i�s�������w��ł���i�C�t�B(�㉺���E)
    /// </summary>
    [SerializeField] GameObject m_spawn2Prefab = default;
    public int rote;
    public float wait;
    public float magnification;
    GameObject _player;
    public string movedirection = "left";
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Square");
        StartCoroutine("Hard");
    }


    IEnumerator Hard()
    {
        magnification = 20f;

        
        for (int i = 0; i < 45; i++)
        {

            //transform.position = Vector3.zero;
            rote = UnityEngine.Random.Range(150, 210);
            wait = 0.2f;
            float x = UnityEngine.Random.Range(10.0f, 15.0f);
            y = UnityEngine.Random.Range(-6.0f, 6.0f);
            Vector3 spawn = new Vector3(x, y);
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);

            yield return new WaitForSeconds(0.2f);

        }

        yield return new WaitForSeconds(0.4f);
        y = 6;
        for (int i = 0; i < 10; i++)
        {
            rote = 180;
            x = 12;
            Vector3 spawn = new Vector3(x, y);
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);


            yield return new WaitForSeconds(0.1f);
            y -= 1;
        }
        y = -6;
        yield return new WaitForSeconds(0.4f);

        for (int i = 0; i < 10; i++)
        {
            rote = 180;
            x = 12;
            Vector3 spawn = new Vector3(x, y);
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);


            yield return new WaitForSeconds(0.1f);
            y += 1;
        }

        yield return new WaitForSeconds(0.6f);

        for (int i = 0; i < 10; i++)
        {
            x = 10;
            y = UnityEngine.Random.Range(-6.0f, 6.0f);
            rote = 200;
            for (int j = 0; j < 10; j++)
            {
                Vector3 spawn = new Vector3(x, y);
                Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
                yield return new WaitForEndOfFrame();
                rote -= 5;
            }
            yield return new WaitForSeconds(0.7f);
        }
        x = 12;
        for (int i = 0; i < 5; i++)
        {
            magnification = 8;
            for (int j = 0; j < 2; j++)
            {
                y = 0;
                rote = 90;
                movedirection = "left";
                Vector3 spawn = new Vector3(x, y);
                Instantiate(m_spawn2Prefab, spawn, Quaternion.identity);
                yield return new WaitForSeconds(0.4f);
                y = 6;
                rote = 90;
                movedirection = "left";
                spawn = new Vector3(x, y);
                Instantiate(m_spawn2Prefab, spawn, Quaternion.identity);
                yield return new WaitForEndOfFrame();
                y = -6;
                rote = 90;
                movedirection = "left";
                spawn = new Vector3(x, y);
                Instantiate(m_spawn2Prefab, spawn, Quaternion.identity);
                yield return new WaitForSeconds(0.4f);
            }
            y = 4;
            magnification = 20;
            for (int m = 0; m < 6; m++)
            {
                rote = 180;
                Vector3 spawn = new Vector3(x, y);
                Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
                yield return new WaitForEndOfFrame();
                y -= 0.5f;
            }
            y = -4.5f;
            magnification = 20;
            for (int m = 0; m < 6; m++)
            {
                rote = 180;
                Vector3 spawn = new Vector3(x, y);
                Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
                yield return new WaitForEndOfFrame();
                y += 0.5f;
            }
        }
        yield return new WaitForSeconds(0.6f);
        rote = 180;
        for (int m = 0; m < 50; m++)
        {
            x = -12;
            y = 5;
            Vector3 spawn = new Vector3(x, y);
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
            yield return new WaitForEndOfFrame();
            y = -5;
            spawn = new Vector3(x, y);
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
            yield return new WaitForEndOfFrame();
            x = 12;
            y = 5;
            spawn = new Vector3(x, y);
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
            yield return new WaitForEndOfFrame();
            y = -5;
            spawn = new Vector3(x, y);
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            rote -= 35;
        }
        yield return new WaitForSeconds(0.5f);

        for (int m = 0; m <= 25; m++)
        {
            y = Random.Range(-6.0f, 6.0f);
            x = Random.Range(-13.0f, 13.0f);
            Vector2 spawn = new Vector2(x, y);
            //Vector2 dir = _player.transform.position - spawn;
            transform.position = spawn;
            this.transform.LookAt(_player.transform);
            Quaternion dir = this.transform.rotation;
            rote = (int)(Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg);
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
        for (int m = 0;m <= 50; m++)
        {
            x = 13;
            y = Random.Range(-6.0f, 6.0f);
            Vector2 spawn = new Vector2(x, y);
            rote = 180;
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
            yield return new WaitForEndOfFrame();
            x = -13;
            y = Random.Range(-6.0f, 6.0f);
            spawn = new Vector2(x, y);
            rote = 0;
            Instantiate(m_spawnPrefab, spawn, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}