[System.Serializable]
public class GameData
{
    public int Skor { get; set; } // Dosyaya kaydedilen skor değişkenimiz 
    public float yKonum { get; set; } // Dosyaya kaydedilen konum değişkenimiz 
    public int HiScore { get; set; } // Dosyaya kaydedilen en yüksek skro değişkenimiz  
    public GameData(Player player)
    {
        Skor = player.HScore;
        yKonum = player.transform.position.y;
    }

    public GameData(int Skor,int HiScore, float yKonum)
    {
        this.Skor = Skor;
        this.yKonum = yKonum;
        this.HiScore = HiScore;
    }
}