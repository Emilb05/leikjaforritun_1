using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ber_collect : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) // Keyrir falli� �egar hlutur snertir colliderinn � hlutnum sem scripti� er �.
    {
        spilari controller = other.GetComponent<spilari>(); // N�lgast spilari eininguna � hlutnum sem snertir colliderinn.

        if (controller != null) // Ef spilari er ekki null, sem ���ir a� hluturinn er spilari.
        {
            if (controller.health < controller.maxHealth) // Ef heilsufj�ldi spilari hlutarins er minni en h�marksheilsufj�ldi�.
            {
                controller.ChangeHealth(1); // H�kka heilsufj�lda spilari um 1.
                Destroy(gameObject); // Ey�a hlutnum sem inniheldur scripti�.
            }
        }
    }
}