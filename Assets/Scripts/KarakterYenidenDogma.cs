using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterYenidenDogma : MonoBehaviour
{
    // Baþlangýç pozisyonu ve rotasyonu
    private Vector3 baslangicKonumu;
    private Quaternion baslangicRotasyonu;

    // Reset iþlemi için flag
    private bool resetIsteniyor = false;

    // Karakterin Rigidbody bileþeni
    private Rigidbody rb;

    private void Start()
    {
        // Baþlangýç pozisyonunu ve rotasyonunu kaydet
        baslangicKonumu = transform.position;
        baslangicRotasyonu = transform.rotation;

        // Karakterin Rigidbody bileþenini al
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // R tuþuna basýldýðýnda ve reset iþlemi aktif deðilse
        if (Input.GetKeyDown(KeyCode.R) && !resetIsteniyor)
        {
            resetIsteniyor = true;
            YenidenDog(); // YenidenDog fonksiyonunu burada çaðýrýyoruz
        }
    }

    private void FixedUpdate()
    {
        // Reset iþlemi isteniyorsa
        if (resetIsteniyor)
        {
            YenidenDog(); // Ve burada da çaðýrýyoruz
        }
    }

    private void YenidenDog()
    {
        // Karakterin hýzýný ve açýsal hýzýný sýfýrla
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Karakteri baþlangýç pozisyonuna ve rotasyonuna geri konumlandýr
        transform.position = baslangicKonumu;
        transform.rotation = baslangicRotasyonu;

        // Reset iþlemini tamamladýðýmýzý belirt
        resetIsteniyor = false;
    }
}
