using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageSequenceController : MonoBehaviour
{
    [Header("Image Sequence")]
    [SerializeField] private Image displayImage;
    [SerializeField] private List<Sprite> images = new List<Sprite>();

    [Header("Scene")]
    [SerializeField] private string nextSceneName = "Area 1";

    private int currentIndex = 0;

    private void Start()
    {
        if (images.Count > 0 && displayImage != null)
        {
            displayImage.sprite = images[0];
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextImage();
        }
    }

    private void ShowNextImage()
    {
        currentIndex++;

        if (currentIndex < images.Count)
        {
            displayImage.sprite = images[currentIndex];
        }
        else
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
