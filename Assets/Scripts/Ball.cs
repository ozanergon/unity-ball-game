using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject player;
    public GameObject ball;
    Rigidbody2D rb;
    Vector3 originalPos;
    public Player play;
    public float moveSpeed = 10;

    public Text scoreTxt, hScoreTxt;
    public int Score { get; private set; }
    public int HScore { get; private set; }

    void Start()
    {
        play = FindObjectOfType<Player>();
        Invoke("BallMove", 2); // Topu oyun başladıktan 2 saniye sonra hareket ettir

        if (SaveLoadManager.decisior == 1) // Eğer Load Last Game'e tıklandıysa 
        {
            GameData gd = SaveLoadManager.Load(Application.persistentDataPath + "gaming" + ".gamedata"); // Dosyaya atama yap
            Score = gd.Skor; // Skoru ata
            HScore = gd.HiScore; // En yüksek skoru ata
            play.transform.position = new Vector3(0, gd.yKonum, 0); // En son olan y konumunu yükle
            scoreTxt.text = Score.ToString(); // Text'e atama yap
            hScoreTxt.text = HScore.ToString(); // Text'e atama yap
        }
        else if (SaveLoadManager.decisior == 0) // New Game'e tıklandıysa 
        {
            GameData gd = SaveLoadManager.Load(Application.persistentDataPath + "gaming" + ".gamedata"); // Dosyaya atama yap
            HScore = gd.HiScore; // En yüksek skoru ata
            hScoreTxt.text = HScore.ToString(); // Text'e atama yap
        }

    }

    private void BallMove() // Topu Hareket Ettirme Metodu
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 0) * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) // Bomba topa değdiyse
    {
        GetComponent<AudioSource>().Play(); // Top çarpma sesini çal
        if (collision.gameObject.name == "top1(Clone)") // Eğer bizim nesnemizin çarptığı topumuzun klonuysa
        {
            MakeScore(); // Skor yapma metoduna git
            rb.velocity = new Vector2(1, 0) * moveSpeed; //topumuzun hızını eski haline getir 
            Destroy(collision.gameObject, 0f); // Klon olan topu hemen yok et
        }

    }
    public void MakeScore() // Skor yapma metodumuz 
    {
        Score++; // Skor bir artırılır 
        scoreTxt.text = Score.ToString(); // Text değişkenine atama yapılır
        
        if (Score % 5 == 0) // Eğer 5 ile bölümünden kalan sıfır ise içeri igir
        {
            player.transform.position += new Vector3(0, 1, 0); // player'ımızı y ekseninde bir birim yukarı kaydırıyoruz
        }

        float mesafe = Mathf.Abs(ball.transform.position.y - player.transform.position.y); // Top ile oyuncumuzun mesafesini ölçüyoruz 
        originalPos = new Vector3(player.transform.position.x, player.transform.position.y - 6f, player.transform.position.z); // Oyunucumuzun orjinal pozisyonu 

        if (mesafe < 3) // Oyuncu topa çok yaklaştıysa içeri gir (2 birim yakınsa)
        {
            player.transform.position = originalPos; // Oyuncunun pozisyonunu eski haline getir
        }
        if (Score > HScore) // Skorumuzen yüksek skordan büyük ise içeri gir
        {
            HScore = Score; // En yüksek skor ataması yap
            hScoreTxt.text = HScore.ToString(); // En yüksek skor atasını yazdır
            SaveLoadManager.Save(Application.persistentDataPath + "gaming" + ".gamedata", new GameData(Score, HScore, player.transform.position.y)); // Dosyaya yazma işlemi yapıyoruz
        }
        SaveLoadManager.Save(Application.persistentDataPath + "gaming" + ".gamedata", new GameData(Score, HScore, player.transform.position.y)); // Dosyaya yazma işlemi yapıyoruz
    }

}
