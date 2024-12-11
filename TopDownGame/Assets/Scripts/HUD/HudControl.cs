using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudControl : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;

    [Header("Tools")]
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItens playerItens;
    private Player player;

    private void Awake()
    {
        playerItens = FindObjectOfType<PlayerItens>();
        player = playerItens.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItens.currentWater / playerItens.WaterLimit;
        woodUIBar.fillAmount = playerItens.totalWood / playerItens.WoodLimit;
        carrotUIBar.fillAmount = playerItens.totalCarrots / playerItens.CarrotLimit;

        // Ferramenta selecionada
        toolsUI[player.HandlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if (i == player.HandlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
