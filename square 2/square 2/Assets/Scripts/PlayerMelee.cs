using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private float nextTimeToAttack;
    public float swingSpeed;

    // Update is called once per frame
    void Update()
    {
        if (nextTimeToAttack <= 0)
        {
            nextTimeToAttack = swingSpeed;
        }
;
    }
}
