using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Calculate : MonoBehaviour
{

    // energy produced by 1 panel in kwh
    const int ENERGYPERPANEL = 42;
    const float COSTPERPANEL = 584.51f;
    const float COSTPERKWH = 11.85f;

    [SerializeField] GameObject panelsUI;
    [SerializeField] GameObject cost;

    [SerializeField] GameObject button;
    [SerializeField] GameObject inputfieldSqft;
    [SerializeField] GameObject inputfieldResidents;
    private Button calcButton;
    private Text inputsqft;
    private Text inputResidents;
    private Text outputPanels;
    private Text outputCost;

    [SerializeField] GameObject[] panelArr;

    // Start is called before the first frame update
    void Start()
    {
        calcButton = button.GetComponent<Button>();
        inputsqft = inputfieldSqft.GetComponent<Text>();
        inputResidents = inputfieldResidents.GetComponent<Text>();
        outputCost = cost.GetComponent<Text>();
        outputPanels = panelsUI.GetComponent<Text>();
        calcButton.onClick.AddListener(CalculatePanels);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float calculateMonthlyEnergy(int sqFt, int residents)
    {
        float result = (float) ((93*residents) + 190 + (255 * Math.Exp(0.0006f * sqFt)));
        return result;
    }

    float calculateCost(float monthlyEnergyConsumed)
    {
        float panelsNeeded = monthlyEnergyConsumed/ENERGYPERPANEL;
        return (float) (panelsNeeded * COSTPERPANEL);
    }

    void CalculatePanels()
    {
        float totalCost = calculateCost(calculateMonthlyEnergy(Int32.Parse(inputsqft.text), Int32.Parse(inputResidents.text)));
        outputCost.text = totalCost.ToString();
        int panelAmount = (int)(totalCost/COSTPERPANEL);
        outputPanels.text = panelAmount.ToString();
        ShowPanels(panelAmount);
    }

    void ShowPanels(int panelAmount)
    {
        ResetPanels();

        for (int i = 0; i < Math.Min(panelAmount, panelArr.Length); i++){
            panelArr[i].SetActive(true);
        }
    }

    void ResetPanels()
    {
        for (int i = 0; i < panelArr.Length; i++){
            panelArr[i].SetActive(false);
        }
    }




}
