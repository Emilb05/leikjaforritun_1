using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ber_collect : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) // Keyrir fallið þegar hlutur snertir colliderinn á hlutnum sem scriptið er á.
    {
        spilari controller = other.GetComponent<spilari>(); // Nálgast spilari eininguna á hlutnum sem snertir colliderinn.

        if (controller != null) // Ef spilari er ekki null, sem þýðir að hluturinn er spilari.
        {
            if (controller.health < controller.maxHealth) // Ef heilsufjöldi spilari hlutarins er minni en hámarksheilsufjöldið.
            {
                controller.ChangeHealth(1); // Hækka heilsufjölda spilari um 1.
                Destroy(gameObject); // Eyða hlutnum sem inniheldur scriptið.
            }
        }
    }
}