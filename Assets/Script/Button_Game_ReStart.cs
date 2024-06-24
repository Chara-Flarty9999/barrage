using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //ÉVÅ[ÉìêÿÇËë÷Ç¶óp

public class Button_Game_ReStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(pushed);
    }

    void pushed()
    {
        SceneManager.LoadScene("Title 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
