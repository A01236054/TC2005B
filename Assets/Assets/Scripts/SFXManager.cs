using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip menu;
    public AudioClip guerra;

    public void getMenu()
    {
        AudioSource.PlayClipAtPoint(menu, Camera.main.transform.position, 0.5f);
    }

    public void getGuerra()
    {
        AudioSource.PlayClipAtPoint(guerra, Camera.main.transform.position, 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
