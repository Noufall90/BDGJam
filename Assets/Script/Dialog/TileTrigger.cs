using System.Collections;
using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    public GameObject dialogToShow; // Tambahkan dialog yang sesuai di Inspector
    public float dialogDuration = 7f; // Atur durasi tampilan dialog

    private bool isPlayerInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            StartCoroutine(ShowDialog());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            HideDialog();
        }
    }

    private IEnumerator ShowDialog()
    {
        if (isPlayerInside)
        {
            dialogToShow.SetActive(true);
            yield return new WaitForSeconds(dialogDuration);
            HideDialog();
        }
    }

    private void HideDialog()
    {
        dialogToShow.SetActive(false);
    }
}
