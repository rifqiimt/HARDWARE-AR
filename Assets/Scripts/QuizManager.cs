using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private QuizGameUI quizGameUI;
    [SerializeField] private List<QuizData> quizDataList;
    
    [Header("Game Settings")]
    [SerializeField] private float timePerQuestion = 20f;
    [SerializeField] private int scorePerCorrectAnswer = 10; // Diubah dari xp menjadi skor (misal 10 per soal)
    [SerializeField] private float delayBetweenQuestions = 0.5f; // Tambahan: Durasi jeda antar soal

    private int correctAnswerCount = 0;
    private int totalQuestions = 0;
    private int currentQuestionIndex = 0;
    private List<Question> questions;
    private Question selectedQuestion;
    private float currentTime;
    private GameStatus gameStatus = GameStatus.NEXT;

    public GameStatus GameStatus { get { return gameStatus; } }

    public void StartGame(int categoryIndex = 0)
    {
        correctAnswerCount = 0;
        currentQuestionIndex = 0;
        currentTime = timePerQuestion;

        if(quizDataList.Count == 0 || quizDataList[categoryIndex] == null) {
            Debug.LogError("Quiz Data List kosong! Masukkan ScriptableObject ke Inspector.");
            return;
        }

        questions = new List<Question>();
        questions.AddRange(quizDataList[categoryIndex].questions);
        totalQuestions = questions.Count;

        SelectQuestion();
        gameStatus = GameStatus.PLAYING;
    }

    private void SelectQuestion()
    {
        if (questions.Count == 0)
        {
            GameEnd();
            return;
        }

        int val = UnityEngine.Random.Range(0, questions.Count);
        selectedQuestion = questions[val];
        
        currentQuestionIndex++;
        currentTime = timePerQuestion; 
        
        quizGameUI.SetQuestion(selectedQuestion, currentQuestionIndex, totalQuestions);
        questions.RemoveAt(val);

        // [PERBAIKAN PENTING] 
        // Mengembalikan status ke PLAYING agar timer jalan & tombol bisa diklik di soal berikutnya
        gameStatus = GameStatus.PLAYING; 
    }

    private void Update()
    {
        if (gameStatus == GameStatus.PLAYING)
        {
            currentTime -= Time.deltaTime;
            
            // Kirim 2 data: persentase (untuk bar) dan waktu asli (untuk teks)
            quizGameUI.UpdateTimer(currentTime / timePerQuestion, currentTime);

            if (currentTime <= 0)
            {
                // WAKTU HABIS
                gameStatus = GameStatus.NEXT;
                quizGameUI.ShowTimeout();
                
                // Jika waktu habis, langsung panggil panel Game Over setelah jeda 1 detik
                Invoke("GameEnd", 1.0f);
            }
        }
    }

    public bool Answer(string selectedOption)
    {
        bool isCorrect = false;
        gameStatus = GameStatus.NEXT; // Hentikan timer sejenak

        if (selectedQuestion.correctAns == selectedOption)
        {
            correctAnswerCount++;
            isCorrect = true;
        }

        // Pindah ke soal berikutnya setelah jeda yang diatur (default: 0.5 detik)
        Invoke("SelectQuestion", delayBetweenQuestions); 
        return isCorrect;
    }

    private void GameEnd()
    {
        gameStatus = GameStatus.NEXT;
        int totalScore = correctAnswerCount * scorePerCorrectAnswer;
        
        // --- LOGIKA PRE-TEST & POST-TEST ---
        // Jika pemain belum pernah main sama sekali, simpan skor ini sebagai PRE-TEST
        if (!PlayerPrefs.HasKey("PreTestScore"))
        {
            PlayerPrefs.SetInt("PreTestScore", totalScore);
            // Jadikan skor pre-test sebagai post-test sementara agar tidak kosong
            PlayerPrefs.SetInt("PostTestScore", totalScore);
        }
        else
        {
            // Jika sudah pernah main, selalu update skor ini sebagai POST-TEST
            PlayerPrefs.SetInt("PostTestScore", totalScore);
        }

        quizGameUI.ShowGameOver(correctAnswerCount, totalQuestions, totalScore);
    }
}