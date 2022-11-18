using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraThrows : MonoBehaviour
{

    [SerializeField] public int extraThrows;

    ThrowingKnives kniveScript;

    // Start is called before the first frame update
    void Start()
    {
        kniveScript = GetComponent<ThrowingKnives>();
        extraThrows = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
