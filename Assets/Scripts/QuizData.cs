using System.Collections.Generic;
using UnityEngine;

// --- Struktur Data Pertanyaan ---
[System.Serializable]
public class Question
{
    [TextArea(2, 5)]
    public string questionInfo;         // Teks Soal
    public QuestionType questionType;   // TEXT atau IMAGE
    public Sprite questionImage;        // Slot gambar (hanya dipakai jika type = IMAGE)
    public List<string> options;        // 4 Opsi Jawaban
    public string correctAns;           // String jawaban yang benar
}

public enum QuestionType { TEXT, IMAGE, AUDIO, VIDEO }
public enum GameStatus { PLAYING, NEXT }

// --- Database ScriptableObject ---
// Cara pakai di Unity: Klik Kanan di Folder -> Create -> Quiz -> QuestionsData
[CreateAssetMenu(fileName = "QuestionsData", menuName = "Quiz/QuestionsData", order = 1)]
public class QuizData : ScriptableObject
{
    public string categoryName;
    public List<Question> questions;
}

// --- Utility Class untuk Mengacak (Shuffle) Jawaban ---
public abstract class ShuffleList
{
    public static List<E> ShuffleListItems<E>(List<E> inputList)
    {
        List<E> originalList = new List<E>(inputList);
        List<E> randomList = new List<E>();

        System.Random r = new System.Random();
        while (originalList.Count > 0)
        {
            int randomIndex = r.Next(0, originalList.Count);
            randomList.Add(originalList[randomIndex]);
            originalList.RemoveAt(randomIndex);
        }

        return randomList;
    }
}