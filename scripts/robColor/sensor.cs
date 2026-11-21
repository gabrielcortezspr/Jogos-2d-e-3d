using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Chin.rampavel = true;
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Chin.rampavel = false;
        }
    }
}
