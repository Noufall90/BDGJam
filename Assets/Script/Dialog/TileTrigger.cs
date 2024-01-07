using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour
{
  public GameObject dialogToShow; // Tambahkan dialog yang sesuai di Inspector
  public float dialogDuration = 7f; // Atur durasi tampilan dialog

  private bool dialogActive = false;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !dialogActive)
    {
      // Nonaktifkan GameObject dialog yang lain (jika ada)
      DisableAllDialogs();
      // Aktifkan dialog yang sesuai
      dialogToShow.SetActive(true);
      dialogActive = true;
      // Panggil fungsi untuk menonaktifkan dialog setelah dialogDuration detik
      Invoke("HideDialog", dialogDuration);
    }
  }

  private void DisableAllDialogs()
  {
    // Nonaktifkan semua dialog dalam hierarki
    GameObject[] dialogs = GameObject.FindGameObjectsWithTag("Dialog");
    foreach (GameObject dialog in dialogs)
    {
      dialog.SetActive(false);
    }
  }

  private void HideDialog()
  {
    // Nonaktifkan dialog setelah sejumlah waktu tertentu
    dialogToShow.SetActive(false);
  }
}

