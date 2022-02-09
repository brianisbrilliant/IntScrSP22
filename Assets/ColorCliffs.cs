using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCliffs : MonoBehaviour
{
    [SerializeField]
    Vector2 valueMinMax = new Vector2(0.2f, 0.9f);

    // Start is called before the first frame update
    void Start()
    {
        // loop through each child
        for(int i = 0; i < this.transform.childCount; i++) {
            this.transform.GetChild(i).GetComponent<Renderer>().material.color = Random.ColorHSV(0, 0, 0, 0, valueMinMax.x, valueMinMax.y);
        }
        // give the child a random color.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
