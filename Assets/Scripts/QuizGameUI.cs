using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Wajib ditambahkan untuk memuat scene

public class QuizGameUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;

    [Header("PRIMO Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject quizPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Quiz Elements")]
    [SerializeField] private TMP_Text moduleProgressText; 
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private Image questionImage; 
    [SerializeField] private GameObject imageHolder; 
    [SerializeField] private Image timerBarFill; 
    [SerializeField] private TMP_Text timerText;     
    [SerializeField] private List<Button> optionButtons;

    [Header("Game Over Elements")]
    [SerializeField] private TMP_Text evaluationText; 
    [SerializeField] private TMP_Text expGainedText; // Akan kita gunakan untuk teks SKOR
    [SerializeField] private TMP_Text homeTotalExpText; // Akan kita gunakan untuk teks PRE/POST Test

    [Header("PRIMO Colors")]
    [SerializeField] private Color glassPanelColor = new Color(0.08f, 0.12f, 0.24f, 0.8f); 
    [SerializeField] private Color primoCyan = new Color(0.21f, 0.76f, 0.94f, 1f); 
    [SerializeField] private Color primoRed = new Color(1f, 0.26f, 0.26f, 1f); 

    private bool isAnswered = false;
    
    // Variabel static ini tidak akan terhapus saat Anda pindah antar scene
    private static bool isFirstTimeLoaded = true;

    private void Start()
    {
        // Mengecek apakah ini adalah pertama kalinya scene dimuat sejak APK dibuka
        if (isFirstTimeLoaded)
        {
            ResetScoreData();
            isFirstTimeLoaded = false; // Tandai bahwa aplikasi sudah pernah dibuka
        }
        else
        {
            // Jika bukan pertama kali (misal: kembali dari scene home), cukup update UI teksnya saja
            UpdateHomeScoreUI();
        }

        for (int i = 0; i < optionButtons.Count; i++)
        {
            Button localBtn = optionButtons[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    // Fungsi untuk kembali ke scene home utama aplikasi
    public void exit()
    {
        SceneManager.LoadScene("home");
    }

    public void Btn_StartQuiz()
    {
        if(mainMenuPanel) mainMenuPanel.SetActive(false);
        if(quizPanel) quizPanel.SetActive(true);
        if(gameOverPanel) gameOverPanel.SetActive(false);
        quizManager.StartGame(0); 
    }

    public void SetQuestion(Question question, int currentIndex, int totalQuestions)
    {
        if (moduleProgressText != null) {
            moduleProgressText.text = $"MODULE {currentIndex}/{totalQuestions}";
        }

        if (questionText != null) questionText.text = question.questionInfo;

        if (imageHolder != null) {
            if (question.questionType == QuestionType.IMAGE && question.questionImage != null)
            {
                imageHolder.SetActive(true);
                if(questionImage != null) questionImage.sprite = question.questionImage;
            }
            else
            {
                imageHolder.SetActive(false);
            }
        }

        List<string> ansOptions = ShuffleList.ShuffleListItems<string>(question.options);

        for (int i = 0; i < optionButtons.Count; i++)
        {
            if (optionButtons[i] != null) {
                TMP_Text btnText = optionButtons[i].GetComponentInChildren<TMP_Text>();
                
                if (btnText != null) btnText.text = ansOptions[i];
                
                optionButtons[i].name = ansOptions[i]; 
                optionButtons[i].GetComponent<Image>().color = glassPanelColor;
                optionButtons[i].interactable = true;
            }
        }

        isAnswered = false;
    }

    public void UpdateTimer(float fillPercentage, float currentTime)
    {
        if (timerBarFill != null) {
            timerBarFill.fillAmount = fillPercentage;
            if (fillPercentage <= 0.25f) timerBarFill.color = primoRed;
            else timerBarFill.color = primoCyan;
        }

        if (timerText != null) {
            float displayTime = currentTime < 0 ? 0 : currentTime;
            TimeSpan time = TimeSpan.FromSeconds(displayTime);
            timerText.text = time.ToString("mm':'ss");
            
            if (fillPercentage <= 0.25f) timerText.color = primoRed;
            else timerText.color = Color.white;
        }
    }

    public void ShowTimeout()
    {
        isAnswered = true;
        foreach (var btn in optionButtons) {
            if(btn != null) btn.interactable = false;
        }
    }

    private void OnClick(Button clickedBtn)
    {
        if (quizManager.GameStatus == GameStatus.PLAYING && !isAnswered)
        {
            isAnswered = true;
            bool isCorrect = quizManager.Answer(clickedBtn.name);

            foreach (var btn in optionButtons) {
                if(btn != null) btn.interactable = false;
            }

            if (isCorrect) clickedBtn.GetComponent<Image>().color = primoCyan;
            else clickedBtn.GetComponent<Image>().color = primoRed;
        }
    }

    public void ShowGameOver(int correctAnswers, int totalQuestions, int finalScore)
    {
        if(quizPanel) quizPanel.SetActive(false);
        if(gameOverPanel) gameOverPanel.SetActive(true);
        
        if(evaluationText != null) evaluationText.text = $"Anda berhasil menjawab {correctAnswers} dari {totalQuestions} soal dengan benar.";
        
        // Ubah Teks dari XP menjadi Skor
        if(expGainedText != null) expGainedText.text = $"SKOR : {finalScore}";
        
        UpdateHomeScoreUI();
    }

    public void Btn_ReturnToMenu()
    {
        if(gameOverPanel) gameOverPanel.SetActive(false);
        if(quizPanel) quizPanel.SetActive(false);
        if(mainMenuPanel) mainMenuPanel.SetActive(true);
    }

    // --- TAMBAHAN: FUNGSI UNTUK MERESET SKOR DI HP ---
    public void ResetScoreData()
    {
        // Menghapus kunci penyimpanan dari memori HP
        PlayerPrefs.DeleteKey("PreTestScore");
        PlayerPrefs.DeleteKey("PostTestScore");
        PlayerPrefs.Save(); // Simpan perubahan secara paksa

        // Perbarui teks di layar agar langsung kembali menjadi "SKOR: 0"
        UpdateHomeScoreUI(); 
        
        Debug.Log("Data Skor Berhasil Direset!");
    }

    private void UpdateHomeScoreUI()
    {
        if(homeTotalExpText != null)
        {
            // Tampilkan Skor Pre-Test dan Post-Test
            if (PlayerPrefs.HasKey("PreTestScore"))
            {
                int preTest = PlayerPrefs.GetInt("PreTestScore", 0);
                int postTest = PlayerPrefs.GetInt("PostTestScore", 0);
                homeTotalExpText.text = $"PRE: {preTest} | POST: {postTest}";
            }
            else
            {
                homeTotalExpText.text = "SKOR: 0";
            }
        }
    }
}