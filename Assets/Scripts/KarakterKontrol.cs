using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    // Karakterin hareket h�z�
    public float hareketHizi = 5f;

    // Karakterin d�nme h�z�
    public float donmeHizi = 5f;

    // Karakterin z�plama g�c�
    public float ziplamaGucu = 5f;

    // Karakterin yere d���p d��medi�ini kontrol eden flag
    public bool yerdeMi = true;

    // Karakterin Rigidbody bile�eni
    private Rigidbody rb;

    private void Start()
    {
        // Karakterin Rigidbody bile�enini al
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Yatay ve dikey hareket girdilerini al
        float yatayHareket = Input.GetAxis("Horizontal");
        float dikeyHareket = Input.GetAxis("Vertical");

        // Hareket vekt�r� hesapla ve zamanla �l�eklendir
        Vector3 hareket = new Vector3(yatayHareket, 0f, dikeyHareket) * hareketHizi * Time.deltaTime;

        // Hareketi uygula
        transform.Translate(hareket);

        // Fare yatay hareketini kullanarak karakteri d�nd�r
        float yatayFareHareket = Input.GetAxis("Mouse X") * donmeHizi;
        transform.Rotate(Vector3.up, yatayFareHareket);

        // Z�plama kontrol�
        if (Input.GetButtonDown("Jump") && yerdeMi)
        {
            // Z�plama kuvveti uygula ve yerdeMi flag'ini g�ncelle
            rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            yerdeMi = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �arp��ma kontrol�: E�er �arp���lan obje "Zemin" tag'�na sahipse, yerdeMi flag'ini g�ncelle
        if (collision.gameObject.CompareTag("Zemin"))
        {
            yerdeMi = true;
        }
    }
}
