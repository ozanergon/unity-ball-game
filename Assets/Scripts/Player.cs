using UnityEngine;

public class Player : MonoBehaviour
{
    public string axisName = "Vertical"; // a ve d tuşlarını alıyoruz 
    public float moveSpeed = 10; 
    public Rigidbody2D bombPrefab;
    public Transform bombSpawn;
    public float bombSpeed = 10f; // Bombamızın hızı
    public int Score { get; set; } // Skor değişkenimiz 
    public int HScore { get; set; } // En yüksek skor değişkenimiz 
    
    private void Shoot() // Anlık olarak y eksenine top ile aynı büyüklükle bir bomba atıyor
    {
        var bomb = Instantiate(bombPrefab, bombSpawn.position, Quaternion.identity);  // Anlık olarak bir bomba oluşturuyor
        bomb.AddForce(transform.up * bombSpeed); // bombSpeed hızıyla // AddForce deyip y ekseninde fırlatıyoruz
    }

    void FixedUpdate() // Fizik ile alakalı işlemler yaptığımız için FixedUpdate'e yazıyoruz
    {
        float moveAxis = Input.GetAxis(axisName) * moveSpeed; // Klavyeden değer okuyup yerel bir değişkene atama yapıyoruz
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveAxis, 0); // Bir velocity uyguluyoruz
        
        if (Input.GetKeyDown(KeyCode.Space)) // Eğer space tuşuna basıldıysa içeri gir
            Shoot();
    }
   
}