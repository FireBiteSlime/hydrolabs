using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class DataTransfer : MonoBehaviour
{
    public TMP_InputField height, length, lengthL1, lengthL2, diameter, diameterD1, diameterD2, volume, fofK, lsgG, haglZ, angleA;
    public GameObject dialogWindow, blurWindow, anglGameObject, diameterD2GameObject;
    
    public TextMeshProUGUI errorsText;
    private float hDialog, wDialog;

    void Start()
    {
        hDialog = dialogWindow.GetComponent<RectTransform>().rect.height;
        wDialog = dialogWindow.GetComponent<RectTransform>().rect.width;
    }
    public void HideDialog()
    {
        errorsText.text = "";
        dialogWindow.GetComponent<RectTransform>().sizeDelta = new Vector2(wDialog, hDialog);
        dialogWindow.SetActive(false);
        blurWindow.SetActive(false);
    }
    public void AcceptH(){
        if(height.text != ""){
            height.image.color = Color.white;
        }else{
            height.image.color = Color.red;
        }
    }
    public void AcceptL1(){
        if(lengthL1.text != ""){
            lengthL1.image.color = Color.white;
        }else{
            lengthL1.image.color = Color.red;
        }
    }
    public void AcceptL2(){
        if(lengthL2.text != ""){
            lengthL2.image.color = Color.white;
        }else{
            lengthL2.image.color = Color.red;
        }
    }
    public void AcceptL(){
        if(length.text != ""){
            length.image.color = Color.white;
        }else{
            length.image.color = Color.red;
        }
    }
    public void AcceptD(){
        if(diameter.text != ""){
            diameter.image.color = Color.white;
        }else{
            diameter.image.color = Color.red;
        }
    }
    public void AcceptD1(){
        if(diameterD1.text != ""){
            diameterD1.image.color = Color.white;
        }else{
            diameterD1.image.color = Color.red;
        }
    }
    public void AcceptD2(){
        if(diameterD2.text != ""){
            diameterD2.image.color = Color.white;
        }else{
            diameterD2.image.color = Color.red;
        }
    }
    public void AcceptW(){
        if(volume.text != ""){
            volume.image.color = Color.white;
        }else{
            volume.image.color = Color.red;
        }
    }
    public void AcceptK(){
        if(fofK.text != ""){
            fofK.image.color = Color.white;
        }else{
            fofK.image.color = Color.red;
        }
    }
    public void AcceptG(){
        if(lsgG.text != ""){
            lsgG.image.color = Color.white;
        }else{
            lsgG.image.color = Color.red;
        }
    }
    public void AcceptZ(){
        if(haglZ.text != ""){
            haglZ.image.color = Color.white;
        }else{
            haglZ.image.color = Color.red;
        }
    }
    public void AcceptA(){
        if(angleA.text != ""){
            angleA.image.color = Color.white;
        }else{
            angleA.image.color = Color.red;
        }
    }
    public bool CheckVolume(){
        if(volume.text == "" || float.Parse(volume.text) > 0.5f || float.Parse(volume.text) < 0.003f){
            errorsText.text += "W введён некорректно, должен находиться в пределах от 0,003 (м³) до 0,5 (м³) \n";
            return CancelValue(volume);
        }
        return true;
    }
    public bool CheckFofK(){
        if (fofK.text == "" || float.Parse(fofK.text) <= 0 || float.Parse(fofK.text) > 1){
             errorsText.text += "K введён некорректно, должен находиться в пределах от 0 до 1 \n";
            return CancelValue(fofK);
        }
        shared_data.K = float.Parse(fofK.text);
        return true;
    }
    public bool ChecklsgG(){
        if(lsgG.text == "" || float.Parse(lsgG.text) < 0.8f || float.Parse(lsgG.text) > 1.3f){
            errorsText.text += "G введён некорректно, должен находиться в пределах от 0,8 (г/см³) до 1,3 (г/см³) \n";
            return CancelValue(lsgG);
        }
        return true;
    }
    public bool CheckHeight(){
        if(height.text == "" || float.Parse(height.text) < 0.6f || float.Parse(height.text) > 100){
            errorsText.text += "H введён некорректно, должен находиться в пределах от 0,6 (м) до 100 (м) \n";
            return CancelValue(height);
        }
        return true;
    }
    public bool CancelValue(TMP_InputField input){
        input.image.color = Color.red;
        input.text = "";
        var h = dialogWindow.GetComponent<RectTransform>().rect.height;
        var w = dialogWindow.GetComponent<RectTransform>().rect.width;
        dialogWindow.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h + 30);
        return false;
    }
}
