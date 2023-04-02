using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.10f;
    public float sideways = 0.10f;
    public float jump = 0.30f;
    //private Rigidbody leikmadur;
    public static int count;
    public Text countText;

    void Start()
    {
        Debug.Log("byrja");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //sný player
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))//hoppa
        {
            transform.position += transform.up * jump ;
        }
        if (transform.position.y <= -1)
        {
            Endurræsa();
        }
        if (Input.GetKey(KeyCode.DownArrow))// til baka
        {
            transform.position += transform.forward * speed ;
        }
        if (Input.GetKey(KeyCode.UpArrow))//áfram
        {
            transform.position += -transform.forward * speed;

        }
        if (Input.GetKey(KeyCode.LeftArrow))//hægri
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.RightArrow))//vinstri
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á RightArrow
            transform.position += -transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("búmm");
            //Vector3 movement = new Vector3(0, 10, 0);
            transform.position +=transform.up *jump;
        }
        if (transform.position.y<=-1)
        {
            Endurræsa();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        // ef player keyrir á object sem heitir hlutur
        if (other.gameObject.CompareTag("hlutur"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            // Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (other.gameObject.CompareTag("pikk"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (other.gameObject.CompareTag("hindrun"))
        {
            other.gameObject.SetActive(false);
            count = count - 3;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (other.gameObject.CompareTag("hreyfir"))
        {
            count = count - 3;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
    }
   
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();
       
        if (count < 0)
        {
            this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
            countText.text = "Svo dauðððððððððððððððður " + count.ToString()+" stigum";

            StartCoroutine(Bida());
            
        }
        
    }
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(1);
        Endurræsa();
    }
   
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    public void Endurræsa()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
        SceneManager.LoadScene(0);
    }
    void OnTriggerEnter(Collider other)
    {
        // ef hluturinn sem þú snertir hefur 'tag'ið 'Pick Up' þá gerist það sem er fyrir neðan
        if (other.gameObject.CompareTag("null"))
        {
            count = count + 0;
            SetCountText();
        }
        if (other.gameObject.CompareTag("byrja"))
        {
            count = 0;
            SetCountText();
        }
    }

}
