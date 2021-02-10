using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    [SerializeField] private float dark;

    [SerializeField] private float initDark = 0.60f;
   
    

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1f, 1f, 1f, initDark);

        dark = initDark;
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1f, 1f, 1f, dark);
    }

    public void GetBright()
    {
        dark += -0.15f;
    }
}
