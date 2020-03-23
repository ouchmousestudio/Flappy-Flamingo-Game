using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowCycle : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    [SerializeField] float cycleLength = 2f;
    [SerializeField] float cycleOffset;
    float cycleAmount;
    [SerializeField] float glowAmount;
    float alphaLevel;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cycleLength <= Mathf.Epsilon) { return; }
        float cycles = Time.time / cycleLength; //grows from 0
        const float tau = Mathf.PI * 2; //around 2.68
        float rawSine = Mathf.Sin(cycles * tau);

        cycleAmount = (rawSine + 1f) / 2;
        cycleAmount = (cycleAmount * glowAmount) + cycleOffset;

        //Position Movement
        alphaLevel = cycleAmount;
        spriteRenderer.color = new Color(1f, 1f, 1f, alphaLevel);
    }
}
