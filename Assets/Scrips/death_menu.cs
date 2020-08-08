using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class death_menu : MonoBehaviour
{
    public Text scoreText;
    public Image background;
    public bool isShow = false;
    public float transition = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        //không hiển thị
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShow)
        return;
        transition += Time.deltaTime;
        background.color = Color.Lerp(new Color(0,0,0,0),Color.black,transition);
    }
    public void toggleMenu(float score){
        gameObject.SetActive(true);
        scoreText.text  = ((int)score).ToString();
        isShow = true;
    }
    public void reStart(){
        //ScenceManager.LoadScene("SampleScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
