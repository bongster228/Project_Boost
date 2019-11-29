using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    [SerializeField] float period = 2f;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0,1)] float movementFactor;
    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //  error check for when period == 0
        if (period <= Mathf.Epsilon) return;
        
        //  cycle gradually increases from 0
        float cycle = Time.time / period;

        //  oscillate between 0 and 1
        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(tau * cycle);
        movementFactor = (rawSineWave / 2) + .5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos+ offset;
    }
}
