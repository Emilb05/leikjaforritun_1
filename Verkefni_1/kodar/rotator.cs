using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	// keyrir á undan hverjum 'frame'
	void Update ()
	{
		// leikhluturinn snýst sem þetta handrit er tengt við um 15 á X-ásnum,
		// 30 á Y-ásnum og 45 á Z-ásnum, síðan margfaldað með 'deltaTime' til að láta þetta gerast á hverri sekúndu
		// frekar en á hverjum 'frame'.
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}	
