using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        //không hiển thị
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toggleMenu(float score){
        gameObject.SetActive(true);
    }
}
