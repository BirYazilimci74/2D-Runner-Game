using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    
    private float highScore;
    private float score;

    void Start()
    {
        score = 0f;  // Oyun başında skoru sıfırla
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);  // Kaydedilen en yüksek skoru yükle

        // En yüksek skoru göster
        highScoreText.text = "High Score: " + Mathf.Round(highScore).ToString();
    }

    void Update()
    {
        if (!GameManager.Instance.canPlay)
        {
            return;
        }
        Score();
    }

    private void Score()
    {
        // Her saniye skor 5 artıyor olsun
        score += Time.deltaTime*5;
        scoreText.text = "Score: " + Mathf.Round(score).ToString();

        // En yüksek skoru kontrol et ve güncelle
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + Mathf.Round(highScore).ToString();

            // En yüksek skoru kaydet
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}