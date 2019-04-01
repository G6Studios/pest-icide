using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayImage : MonoBehaviour
{

    // Character images
    public Sprite rat;
    public Sprite wombat;
    public Sprite snake;
    public Sprite bird;
    public Sprite displayedImage;

    // Start is called before the first frame update
    void Start()
    {
        displayedImage = gameObject.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
