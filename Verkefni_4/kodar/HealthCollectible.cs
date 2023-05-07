// �etta er k��inn sem s�r um a� h�kkja heilsufj�lda �egar hlutur er s�ttur � leiknum.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip; // Geymir hlj��skr� sem er spila� �egar hlutur er s�ttur.

    void OnTriggerEnter2D(Collider2D other) // Keyrir falli� �egar hlutur snertir colliderinn � hlutnum sem scripti� er �.
    {
        RubyController controller = other.GetComponent<RubyController>(); // N�lgast RubyController eininguna � hlutnum sem snertir colliderinn.

        if (controller != null) // Ef RubyController er ekki null, sem ���ir a� hluturinn er RubyController.
        {
            if (controller.health < controller.maxHealth) // Ef heilsufj�ldi RubyController hlutarins er minni en h�marksheilsufj�ldi�.
            {
                controller.ChangeHealth(1); // H�kka heilsufj�lda RubyController um 1.
                Destroy(gameObject); // Ey�a hlutnum sem inniheldur scripti�.

                controller.PlaySound(collectedClip); // Spila hlj��i� sem er skilgreint � collectedClip breytunni.
            }
        }
    }
