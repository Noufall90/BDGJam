using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
  [SerializeField] public GameObject dialog; // Tambahkan dialog yang ingin ditampilkan di Inspector
  public float displayDuration = 5f; // Atur durasi tampilan dialog

  private float displayTimer = 0f;
  private bool isDialogActive = false;

  private void Update()
  {
    if (isDialogActive)
    {
      displayTimer += Time.deltaTime;

      if (displayTimer >= displayDuration)
      {
        CloseDialog();
      }
    }
  }

  public void ShowDialog()
  {
    dialog.SetActive(true);
    isDialogActive = true;
    displayTimer = 0f;
  }

  public void CloseDialog()
  {
    dialog.SetActive(false);
    isDialogActive = false;
  }
}

