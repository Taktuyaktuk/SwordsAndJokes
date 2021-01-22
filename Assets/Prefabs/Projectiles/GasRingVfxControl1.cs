using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GasRingVfxControl1 : MonoBehaviour
{

    [SerializeField]
    private VisualEffect visualEffect;

    [SerializeField]
    private float size;

    // Start is called before the first frame update
    void Start()
    {
        size = 0.1f;
        visualEffect.SetFloat("size", size);
    }

    // Update is called once per frame
    void Update()
    {
        size = size + 0.3f;

        if (size >= 2.2f)
        {
            size = 2.2f;
        }
        visualEffect.SetFloat("size", size);
    }
}
