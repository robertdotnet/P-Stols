using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
    public float lifeSpan;
    // Start is called before the first frame update
    void Start()
    {
        lifeSpan = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0)
        {
            Destroy(this);
        }
    }
}
