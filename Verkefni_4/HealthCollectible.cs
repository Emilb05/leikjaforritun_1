// Þetta er kóðinn sem sér um að hækkja heilsufjölda þegar hlutur er sóttur í leiknum.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip; // Geymir hljóðskrá sem er spilað þegar hlutur er sóttur.

    void OnTriggerEnter2D(Collider2D other) // Keyrir fallið þegar hlutur snertir colliderinn á hlutnum sem scriptið er á.
    {
        RubyController controller = other.GetComponent<RubyController>(); // Nálgast RubyController eininguna á hlutnum sem snertir colliderinn.

        if (controller != null) // Ef RubyController er ekki null, sem þýðir að hluturinn er RubyController.
        {
            if (controller.health < controller.maxHealth) // Ef heilsufjöldi RubyController hlutarins er minni en hámarksheilsufjöldið.
            {
                controller.ChangeHealth(1); // Hækka heilsufjölda RubyController um 1.
                Destroy(gameObject); // Eyða hlutnum sem inniheldur scriptið.

                controller.PlaySound(collectedClip); // Spila hljóðið sem er skilgreint í collectedClip breytunni.
            }
        }
    }
