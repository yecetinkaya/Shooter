using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterYenidenDogma : MonoBehaviour
{
    // Ba�lang�� pozisyonu ve rotasyonu
    private Vector3 baslangicKonumu;
    private Quaternion baslangicRotasyonu;

    // Reset i�lemi i�in flag
    private bool resetIsteniyor = false;

    // Karakterin Rigidbody bile�eni
    private Rigidbody rb;

    private void Start()
    {
        // Ba�lang�� pozisyonunu ve rotasyonunu kaydet
        baslangicKonumu = transform.position;
        baslangicRotasyonu = transform.rotation;

        // Karakterin Rigidbody bile�enini al
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // R tu�una bas�ld���nda ve reset i�lemi aktif de�ilse
        if (Input.GetKeyDown(KeyCode.R) && !resetIsteniyor)
        {
            resetIsteniyor = true;
            YenidenDog(); // YenidenDog fonksiyonunu burada �a��r�yoruz
        }
    }

    private void FixedUpdate()
    {
        // Reset i�lemi isteniyorsa
        if (resetIsteniyor)
        {
            YenidenDog(); // Ve burada da �a��r�yoruz
        }
    }

    private void YenidenDog()
    {
        // Karakterin h�z�n� ve a��sal h�z�n� s�f�rla
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Karakteri ba�lang�� pozisyonuna ve rotasyonuna geri konumland�r
        transform.position = baslangicKonumu;
        transform.rotation = baslangicRotasyonu;

        // Reset i�lemini tamamlad���m�z� belirt
        resetIsteniyor = false;
    }
}
