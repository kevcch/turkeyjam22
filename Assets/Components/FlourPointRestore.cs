using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourPointRestore : MonoBehaviour
{
    private GameObject m_Player;
    private void Start()
    {
        m_Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (m_Player.GetComponent<PlayerMovement>().EnteredTrigger)
        {
            FlourPointTracker.numFlourPoints += 10;
            m_Player.GetComponent<PlayerMovement>().EnteredTrigger = false;
            Destroy(gameObject);
            
        }

    }
}
