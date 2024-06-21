using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test用 : MonoBehaviour
{
    SpriteRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<SpriteRenderer>();
        mesh.material.color = new Color32(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 1);
    }
}
