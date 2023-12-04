using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    // Karakterin hareket hýzý
    public float hareketHizi = 5f;

    // Karakterin dönme hýzý
    public float donmeHizi = 5f;

    // Karakterin zýplama gücü
    public float ziplamaGucu = 5f;

    // Karakterin yere düþüp düþmediðini kontrol eden flag
    public bool yerdeMi = true;

    // Karakterin Rigidbody bileþeni
    private Rigidbody rb;

    private void Start()
    {
        // Karakterin Rigidbody bileþenini al
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Yatay ve dikey hareket girdilerini al
        float yatayHareket = Input.GetAxis("Horizontal");
        float dikeyHareket = Input.GetAxis("Vertical");

        // Hareket vektörü hesapla ve zamanla ölçeklendir
        Vector3 hareket = new Vector3(yatayHareket, 0f, dikeyHareket) * hareketHizi * Time.deltaTime;

        // Hareketi uygula
        transform.Translate(hareket);

        // Fare yatay hareketini kullanarak karakteri döndür
        float yatayFareHareket = Input.GetAxis("Mouse X") * donmeHizi;
        transform.Rotate(Vector3.up, yatayFareHareket);

        // Zýplama kontrolü
        if (Input.GetButtonDown("Jump") && yerdeMi)
        {
            // Zýplama kuvveti uygula ve yerdeMi flag'ini güncelle
            rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            yerdeMi = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpýþma kontrolü: Eðer çarpýþýlan obje "Zemin" tag'ýna sahipse, yerdeMi flag'ini güncelle
        if (collision.gameObject.CompareTag("Zemin"))
        {
            yerdeMi = true;
        }
    }
}
