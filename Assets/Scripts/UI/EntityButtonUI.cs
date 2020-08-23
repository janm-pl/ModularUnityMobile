using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using S = UnityEngine.SerializeField;

public class EntityButtonUI : MonoBehaviour
{
    [S] Image image;
    [S] Button button;

    public Image Image => image;
    public Button Button => button;
}
