using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audies : MonoBehaviour
{
    // Список аудиоклипов
    public List<AudioClip> audies;
    // Компонент AudioSource для воспроизведения звука
    private AudioSource audioSource;
    // Масштаб по умолчанию
    private Vector3 defaultScale;

    // Свойство для получения масштаба по умолчанию
    public Vector3 DefaultScale => defaultScale;

    private void OnEnable()
    {
        // Сохраняем начальный масштаб объекта
        defaultScale = transform.localScale;
        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Метод для воспроизведения аудиоклипа по индексу
    public void PlayAudioByIndex(int index)
    {
        if (index >= 0 && index < audies.Count)
        {
            audioSource.clip = audies[index];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Индекс вне диапазона списка аудиоклипов.");
        }
    }

    // Метод для изменения масштаба объекта
    public void ChangeScale(float multiplier)
    {
        transform.localScale *= multiplier;
    }

    // Метод для сброса масштаба к начальному значению
    public void ResetScale()
    {
        transform.localScale = defaultScale;
    }
}
