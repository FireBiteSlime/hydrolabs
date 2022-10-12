using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer9 : DataTransfer
{
    
    private bool CheckAllValues()
    {
        return Checkdiameter() & CheckVolume() & CheckFofK() & ChecklsgG() & CheckHaglZ() & CheckHeight() & CheckL1() & CheckL2();   
    }
    public void SubmitButton()
    {
      
        if(CheckAllValues()){
            shared_data.speed = 0.8f;
            SceneManager.LoadScene("lab9");
        }else{
            blurWindow.SetActive(true);
            dialogWindow.SetActive(true);
        }
    }

    private bool Checkdiameter(){
        if(diameter.text == "" || float.Parse(diameter.text) > 0.06f || float.Parse(diameter.text) < 0.01f){
            errorsText.text += "D введён некорректно, должен находиться в пределах от 0,01 (м) до 0,06 (м) \n";
            return CancelValue(diameter);
        }
        return true;
    }
    private bool CheckL1(){
        if (lengthL1.text == ""){
            errorsText.text += "L1 введён некорректно, должен быть не менее 70*D (м) \n";
            return CancelValue(lengthL1);
        }else if(diameter.text != "" && (float.Parse(lengthL1.text) < 70*float.Parse(diameter.text) || float.Parse(lengthL1.text) > 10)){
            errorsText.text += "L1 введён некорректно, должен быть не менее 70*D (м) \n";
            return CancelValue(lengthL1);
        }
        return true;
    }
    private bool CheckL2(){
        if(lengthL2.text == "" || float.Parse(lengthL2.text) < 1 || float.Parse(lengthL2.text) > 10){
            errorsText.text += "L2 введён некорректно, должен находиться в пределах от 1 (м) до 10 (м) \n";
            return CancelValue(lengthL2);
        }
        return true;
    }
    private bool CheckHaglZ(){
        if (haglZ.text == ""){
            errorsText.text += "Z введён некорректно, должен находиться в пределах от 0,6*D (м) до 2 (м) \n";
            return CancelValue(haglZ);
        }else if(diameter.text != "" && (float.Parse(haglZ.text) < 0.6f*float.Parse(diameter.text) || float.Parse(haglZ.text) > 2)){
            errorsText.text += "Z введён некорректно, должен находиться в пределах от 0,6*D (м) до 2 (м) \n";
            return CancelValue(haglZ);
        }
        return true;
    }
}
