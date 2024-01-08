using UnityEngine;
using UnityEngine.UI;

public class TimerSetting : MonoBehaviour
{
    public Text Timer;
    public float Waktu;
    public bool GameAktif = true;
    public GameObject CanvasKalah;
    public GameObject gameObjekAktif; // Tambahkan GameObject yang ingin diaktifkan saat waktu habis

    void SetTimer()
    {
        int Menit = Mathf.FloorToInt(Waktu / 60); //01
        int Detik = Mathf.FloorToInt(Waktu % 60); //30
        Timer.text = Menit.ToString("00") + ":" + Detik.ToString("00");
    }

    float s;

    private void Update()
    {
        if (GameAktif)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                Waktu--;
                s = 0;
                SetTimer(); // Memanggil fungsi untuk mengupdate tampilan timer
            }
        }
        if (GameAktif && Waktu <= 0)
        {
            Debug.Log("Game Kalah");
            CanvasKalah.SetActive(true);
            GameAktif = false;

            // Mengaktifkan GameObject tertentu saat waktu habis
            if (gameObjekAktif != null)
            {
                gameObjekAktif.SetActive(true);
            }
        }
    }

    void Start()
    {
        SetTimer(); // Memanggil fungsi untuk mengatur timer awal saat permainan dimulai
    }
}
