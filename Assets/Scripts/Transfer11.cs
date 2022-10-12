using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transfer11 : DataTransfer
{
    public TMP_Dropdown dropDown;
    public GameObject firstIm, secondIm, therdIm;
    private bool CheckAllValues()
    {
        return CheckDiameterD1() & CheckDiameterD2() & CheckVolume() & CheckFofK() & ChecklsgG() & CheckHaglZ() & CheckHeight() & Checklength();   
    }

    private bool CheckAllValuesForAngle()
    {
        return CheckDiameterD1() & CheckAngleA() & CheckVolume() & CheckFofK() & ChecklsgG() & CheckHaglZ() & CheckHeight() & Checklength();   
    }
    public void ChangeAngleVisibility(){
        if(dropDown.value == 2){
            // diameterD1.placeholder.canvas = "d";
            // placeholderD1.text = "Введите диаметр D (м)";
            secondIm.SetActive(false);
            therdIm.SetActive(true);
            firstIm.SetActive(false);
            diameterD2GameObject.SetActive(false);
            anglGameObject.SetActive(true);
        }else if(dropDown.value == 0){
            secondIm.SetActive(false);
            therdIm.SetActive(false);
            firstIm.SetActive(true);
            diameterD2GameObject.SetActive(true);
            anglGameObject.SetActive(false);
        }else if(dropDown.value == 1){
            secondIm.SetActive(true);
            therdIm.SetActive(false);
            firstIm.SetActive(false);
            diameterD2GameObject.SetActive(true);
            anglGameObject.SetActive(false);
        }
    }
    public void SubmitButton()
    {

        if(dropDown.value == 0){
            if(CheckAllValues()){
                shared_data.speed = 0.8f;
                SceneManager.LoadScene("lab11-1");
            }else{
                blurWindow.SetActive(true);
                dialogWindow.SetActive(true);
            }
        }else if(dropDown.value == 1){
            if(CheckAllValues()){
                shared_data.speed = 0.8f;
                SceneManager.LoadScene("lab11-2");
            }else{
                blurWindow.SetActive(true);
                dialogWindow.SetActive(true);
            }
        }else if(dropDown.value == 2){
            if(CheckAllValuesForAngle()){
                shared_data.speed = 0.8f;
                SceneManager.LoadScene("lab11-3");
            }else{
                blurWindow.SetActive(true);
                dialogWindow.SetActive(true);
            }
        }
    }

    private bool CheckDiameterD1(){
        if(diameterD1.text == "" || float.Parse(diameterD1.text) > 0.06f || float.Parse(diameterD1.text) < 0.01f){
            errorsText.text += "D введён некорректно, должен находиться в пределах от 0,01 (м) до 0,06 (м) \n";
            return CancelValue(diameterD1);
        }
        return true;
    }
    private bool CheckDiameterD2(){
        if (diameterD2.text == "" && diameterD1.text == ""){
            errorsText.text += "d введён некорректно\n";
            return CancelValue(diameterD2);
        }else if(diameterD2.text == "" && diameterD1.text != ""){
            errorsText.text += $"d введён некорректно, должен находиться в пределах от {float.Parse(diameterD1.text) + 0.01} (м) до {float.Parse(diameterD1.text) + 0.1} (м) \n";
            return CancelValue(diameterD2);
        }else if(diameterD1.text != "" && (float.Parse(diameterD2.text) <= float.Parse(diameterD1.text) || float.Parse(diameterD2.text) > (float.Parse(diameterD1.text) + 0.1))){
            errorsText.text += $"d введён некорректно, должен находиться в пределах от {float.Parse(diameterD1.text) + 0.01} (м) до {float.Parse(diameterD1.text) + 0.1} (м) \n";
            return CancelValue(diameterD2);
        }
        return true;
    }
    private bool CheckAngleA(){
        if(angleA.text == "" || float.Parse(angleA.text) > 90 || float.Parse(angleA.text) < 0){
            errorsText.text += "a введён некорректно, должен находиться в пределах от 0 до 90 градусов\n";
            return CancelValue(angleA);
        }
        return true;
    }
    private bool Checklength(){
        if (length.text == ""){
            errorsText.text += "L введён некорректно, должен быть не менее 70*D (м) \n";
            return CancelValue(length);
        }else if(diameterD1.text != "" && (float.Parse(length.text) < 70*float.Parse(diameterD1.text) || float.Parse(length.text) > 10)){
            errorsText.text += $"L введён некорректно, должен быть в переделах от {70*float.Parse(diameterD1.text)} (м) до 10 (м)\n";
            return CancelValue(length);
        }
        return true;
    }

    private bool CheckHaglZ(){
        if (haglZ.text == ""){
            errorsText.text += "Z введён некорректно, должен находиться в пределах от 0,6*D (м) до 2 (м) \n";
            return CancelValue(haglZ);
        }else if(diameterD1.text != "" && (float.Parse(haglZ.text) < 0.6f*float.Parse(diameterD1.text) || float.Parse(haglZ.text) > 2)){
            errorsText.text += "Z введён некорректно, должен находиться в пределах от 0,6*D (м) до 2 (м) \n";
            return CancelValue(haglZ);
        }
        return true;
    }
    
}
