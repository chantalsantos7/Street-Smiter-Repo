using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DollyCamera : MonoBehaviour
{
    public UnityEvent endIntro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndIntroSequence()
    {
        endIntro.Invoke();
    }
}
