using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public float displayDuration = 3f;

    private bool isDisplayingDialog;

    public void StartDialog(string message)
    {
        if (isDisplayingDialog)
            return;

        isDisplayingDialog = true;
        dialogText.text = message;
        gameObject.SetActive(true);

        Invoke("EndDialog", displayDuration);
    }

    private void EndDialog()
    {
        isDisplayingDialog = false;
        gameObject.SetActive(false);
    }
}