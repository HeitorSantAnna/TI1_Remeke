using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    public TMP_Text timeText;

    [SerializeField] GameObject enemy, newenemy;

    [SerializeField] TextMeshProUGUI textMesh;

    public static int coletados = 0;

    public void Ene()
    {
        enemy = GameObject.Find("Enemy");
    }

    void Update()
    {
        if(enemy == null)
        {
            SaveGame(1);

            LoadGame(1);

            Instantiate(newenemy, transform.position, transform.rotation);
        }

        textMesh.text = $"Coletados: {coletados}";
    }

    public void SaveGame(int saveNumber)
    {
        SaveController.SaveGame(saveNumber);
    }

    public void LoadGame(int saveNumber)
    {
        DateTime time = SaveController.LoadGame(saveNumber);
        if (time == DateTime.MinValue) return;
        timeText.text = time.ToString();
    }

    public void DeleteGame(int saveNumber)
    {
        SaveController.DeleteGame(saveNumber);
    }

}
