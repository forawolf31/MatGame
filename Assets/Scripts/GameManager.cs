using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI SoruText, aSolText, bSolText, cSolText, dSolText, aSagText, bSagText, cSagText, dSagText,GameEndText;

    [SerializeField]
    private GameObject FalseIcon, FalseIcon2,Cha1,Cha2;

    [SerializeField]
    private Button aSolBtn, bSolBtn, cSolBtn, dSolBtn, aSagBtn, bSagBtn, cSagBtn, dSagBtn;

    [SerializeField] private float _maxHealth = 10;

    [SerializeField] private GameObject GameEndPanel;

    private float _currentHealth;

    [SerializeField] private Healthbar _healthbar;
    [SerializeField] private Healthbar2 _healthbar2;

    static string[] Soru;

   
    public void Start()
    {

        _currentHealth = _maxHealth;

        _healthbar.UpdateHealthBar(_maxHealth,_currentHealth);
        _healthbar2.UpdateHealthBar(_maxHealth,_currentHealth);

        Soru = new string[49];
        

        Soru[0] = "7 x (12 + 5) - 4 i�leminin sonucu ka�t�r?";
        Soru[1] = "27 ? 4 x 3 � (8 + 4) i�leminin sonucu ka�t�r?";
        Soru[2] = "(40 ? 18) � 4 + 5 i�leminde, i�lem �nceli�i s�ras� a�a��dakilerden hangisidir?";
        Soru[3] = "(24 + 8) - 3 x 2 ��i�leminin sonucu ka�t�r?";
        Soru[4] = "18 - 2 x 0 + 5 x 7 verilen i�leminin sonucu ka�t�r ?";
        Soru[5] = "2,3,9,1,5 say� grubunun a��kl��� ile ortalamas�n�n toplam� ka�t�r ?";
        Soru[6] = "3^4 i�leminin sonucu ka�t�r?";
        Soru[7] = "7 x 7 x 7 x 7 x 7 x 7 i�leminin �sl� say� olarak yaz�l��� a�a��dakilerden hangisidir?";
        Soru[8] = "A�a��dakilerden hangisi do�rudur?";
        Soru[9] = "A�a��dakilerden hangisi bir do�al say�n�n karesi olarak ifade edilemez?";
        Soru[10] = "7^3, 9^2, 2^4, 4^3��sl� say�lar�n�n b�y�kten k����e s�ralan��� hangi se�enekte do�ru olarak verilmi�tir?";
        Soru[11] = "A�a��daki i�lemlerden hangisinin sonucu s�f�rd�r?";
        Soru[12] = "A�a��daki �arpma i�lemlerinden hangisinin sonucu en k���kt�r?		";
        Soru[13] = "24100 say�s�n�n birler b�l��� ile binler b�l���n�n �arp�m� ka�t�r?";
        Soru[14] = "A�a��daki �arpma i�lemlerinden hangisi yanl��t�r?";
        Soru[15] = "788 f�nd�k, 5 �ocu�a e�it say�da payla�t�r�l�rsa ka� f�nd�k artar?";
        Soru[16] = "A�a��dakilerden hangisi kalans�z bir b�lme i�lemidir?";
        Soru[17] = "A�a��da verilen b�lme i�lemlerinden hangisinin sonucu yanl��t�r?";
        Soru[18] = "Dik a��dan 42� k���k olan dar a�� a�a��dakilerden hangisidir?";
        Soru[19] = "Verilen say�lardan ka� tanesi asal say� de�ildir?  2, 7, 11, 57, 65, 46";
        Soru[20] = "A�a��dakilerden hangisi yanl��t�r?";
        Soru[21] = "A�a��dakilerden hangisi 72' nin �arpan� de�ildir?";
        Soru[22] = "Verilen say�lardan ka� tanesi asal say�d�r? 17, 26, 35, 94, 45, 57, 31";
        Soru[23] = "A�a��daki do�al say�lardan ka� tanesi asal say� de�ildir? 2, 54, 19, 23, 37, 39, 33";
        Soru[24] = "60 say�s�n�n asal �arpanlar� a�a��dakilerden hangisidir?";
        Soru[25] = "48 say�s�n�n asal �arpanlar�n�n �arp�m� �eklinde yaz�l��� a�a��dakilerden hangisidir?";
        Soru[26] = "A�a��daki say�lardan hangisi 3 ile tam b�l�n�r?";
        Soru[27] = "6958 do�al say�s�n�n 5�e b�l�m�nden kalan ka�t�r?";
        Soru[28] = "502116 say�s� a�a��dakilerden hangisine kalans�z b�l�nemez?";
        Soru[29] = "1250 TL Gelir� ifadesini g�steren tam say� hangisidir?";
        Soru[30] = "-4 ile +3 aras�ndaki say�lar hangi se�enekte do�ru g�sterilmi�tir?";
        Soru[31] = "+5 ile +9 aras�nda ka� tane tam say� vard�r?";
        Soru[32] = "0 say�s� hangi aral��a girmez?";
        Soru[33] = "-49 < ..... < -40 s�ralamas�nda yaz�labilecek en b�y�k tam say� ka�t�r?";
        Soru[34] = "(+1) + (+2) + (+3) toplama i�leminin sonucu nedir?";
        Soru[35] = "(-13) + (+4) i�leminin sonucu nedir?";
        Soru[36] = "(�9) � (+9) ��karma i�leminin sonucu nedir?";
        Soru[37] = "Bir say�n�n 2 kat�n�n 3 fazlas�, ifadesinin cebirsel olarak ifade edili�i a�a��daki se�eneklerin hangisinde verilmi�tir?";
        Soru[38] = "A�a��dakilerden hangisi bir cebirsel ifade de�ildir?";
        Soru[39] = "40 dakikal�k bir s�navda kalan s�re, t�mcesinin cebirsel olarak ifade edili�i a�a��dakilerden hangisidir?";
        Soru[40] = "A�a��daki cebirsel ifadelerden hangisi di�erlerinden farkl�d�r?";
        Soru[41] = "K�sa kenar� x, uzun kenar� y olan bir dikd�rtgenin alan�n�n cebirsel olarak ifade edili�i a�a��daki se�eneklerin hangisinde verilmi�tir?";
        Soru[42] = "4 b�l� 5 ,kesrinin ondal�k a��l�m� a�a��dakilerden hangisidir?		";
        Soru[43] = "5,04 ondal�k kesrinin okunu�u a�a��dakilerden hangisidir?";
        Soru[44] = "0,4365 ondal�k kesri onda birler basama��na g�re yuvarlat�l�rsa a�a��dakilerden hangisi bulunur?";
        Soru[45] = "2,3 x 4,5 �arp�m�n�n sonucu ka�t�r?";
        Soru[46] = "74,3a6 > 74,347 s�ralamas�n�n do�ru olabilmesi i�in a�a��da verilenlerden hangisi a yerine yaz�lamaz?";
        Soru[47] = "A�a��dakilerden hangisi bir k�me belirtmez?";
        Soru[48] = "A = {ATA, T�RK} k�mesinin eleman say�s� ka�t�r?";
    
        RandomSoru();

    }
 
    int index;
    public void RandomSoru()
    {
        index = Random.Range(0, Soru.Length);

        string Sorular = Soru[index];

        SoruText.text = Sorular.ToString();
        switch (index)
        {
            case 0:
                aSolText.text = "85".ToString();
                aSagText.text = "85".ToString();
                bSolText.text = "100".ToString();
                bSagText.text = "100".ToString();
                cSolText.text = "115".ToString();
                cSagText.text = "115".ToString();
                dSolText.text = "130".ToString();
                dSagText.text = "130".ToString();
                break;
            case 1:
                aSolText.text = "23".ToString();
                aSagText.text = "23".ToString();
                bSolText.text = "24".ToString();
                bSagText.text = "24".ToString();
                cSolText.text = "25".ToString();
                cSagText.text = "25".ToString();
                dSolText.text = "26".ToString();
                dSagText.text = "26".ToString();
                break;
            case 2:
                aSolText.text = "Parantez - Toplama - B�lme".ToString();
                aSagText.text = "Parantez - Toplama - B�lme".ToString();
                bSolText.text = "Parantez - B�lme - Toplama".ToString();
                bSagText.text = "Parantez - B�lme - Toplama".ToString();
                cSolText.text = "Toplama - Parantez - B�lme".ToString();
                cSagText.text = "Toplama - Parantez - B�lme".ToString();
                dSolText.text = "Toplama - ��karma - B�lme�".ToString();
                dSagText.text = "Toplama - ��karma - B�lme�".ToString();
                break;
            case 3:
                aSolText.text = "20".ToString();
                aSagText.text = "20".ToString();
                bSolText.text = "26".ToString();
                bSagText.text = "26".ToString();
                cSolText.text = "35".ToString();
                cSagText.text = "35".ToString();
                dSolText.text = "58".ToString();
                dSagText.text = "58".ToString();
                break;
            case 4:
                aSolText.text = "51".ToString();
                aSagText.text = "51".ToString();
                bSolText.text = "53".ToString();
                bSagText.text = "53".ToString();
                cSolText.text = "55".ToString();
                cSagText.text = "55".ToString();
                dSolText.text = "57".ToString();
                dSagText.text = "57".ToString();
                break;
            case 5:
                aSolText.text = "4".ToString();
                aSagText.text = "4".ToString();
                bSolText.text = "8".ToString();
                bSagText.text = "8".ToString();
                cSolText.text = "12".ToString();
                cSagText.text = "12".ToString();
                dSolText.text = "16".ToString();
                dSagText.text = "16".ToString();
                break;
            case 6:
                aSolText.text = "48".ToString();
                aSagText.text = "48".ToString();
                bSolText.text = "64".ToString();
                bSagText.text = "64".ToString();
                cSolText.text = "81".ToString();
                cSagText.text = "81".ToString();
                dSolText.text = "109".ToString();
                dSagText.text = "109".ToString();
                break;
            case 7:
                aSolText.text = "6^6".ToString();
                aSagText.text = "6^6".ToString();
                bSolText.text = "6^7".ToString();
                bSagText.text = "6^7".ToString();
                cSolText.text = "7^5".ToString();
                cSagText.text = "7^5".ToString();
                dSolText.text = "7^6".ToString();
                dSagText.text = "7^6".ToString();
                break;
            case 8:
                aSolText.text = "7 + 7 + 7 = 7^3".ToString();
                aSagText.text = "7 + 7 + 7 = 7^3".ToString();
                bSolText.text = "3^4�= 3 x 4".ToString();
                bSagText.text = "3^4�= 3 x 4".ToString();
                cSolText.text = "6^3�= 6 x 6 x 6".ToString();
                cSagText.text = "6^3�= 6 x 6 x 6".ToString();
                dSolText.text = "2 x 2 x 2 = 6�".ToString();
                dSagText.text = "2 x 2 x 2 = 6�".ToString();
                break;
            case 9:
                aSolText.text = "36".ToString();
                aSagText.text = "36".ToString();
                bSolText.text = "49".ToString();
                bSagText.text = "49".ToString();
                cSolText.text = "66".ToString();
                cSagText.text = "66".ToString();
                dSolText.text = "81".ToString();
                dSagText.text = "81".ToString();
                break;
            case 10:
                aSolText.text = "2^4�> 9^2�> 7^3�> 4^3".ToString();
                aSagText.text = "2^4�> 9^2�> 7^3�> 4^3".ToString();
                bSolText.text = "7^3�> 9^2�> 4^3�> 2^4".ToString();
                bSagText.text = "7^3�> 9^2�> 4^3�> 2^4".ToString();
                cSolText.text = "9^2�> 2^4�> 4^3�> 7^3".ToString();
                cSagText.text = "9^2�> 2^4�> 4^3�> 7^3s".ToString();
                dSolText.text = "4^3�> 9^2�> 7^3�> 2^4".ToString();
                dSagText.text = "4^3�> 9^2�> 7^3�> 2^4".ToString();
                break;
            case 11:
                aSolText.text = "1 x 148".ToString();
                aSagText.text = "1 x 148".ToString();
                bSolText.text = "4 x 100".ToString();
                bSagText.text = "4 x 100".ToString();
                cSolText.text = "10 x 25".ToString();
                cSagText.text = "10 x 25".ToString();
                dSolText.text = "0 x 45".ToString();
                dSagText.text = "0 x 45".ToString();
                break;
            case 12:
                aSolText.text = "40 x 50".ToString();
                aSagText.text = "40 x 50".ToString();
                bSolText.text = "25 x 55".ToString();
                bSagText.text = "25 x 55".ToString();
                cSolText.text = "98 x 10".ToString();
                cSagText.text = "98 x 10".ToString();
                dSolText.text = "45 x 30".ToString();
                dSagText.text = "45 x 30".ToString();
                break;
            case 13:
                aSolText.text = "2400".ToString();
                aSagText.text = "2400".ToString();
                bSolText.text = "12000".ToString();
                bSagText.text = "12000".ToString();
                cSolText.text = "24000".ToString();
                cSagText.text = "24000".ToString();
                dSolText.text = "25000".ToString();
                dSagText.text = "25000".ToString();
                break;

            case 14:
                aSolText.text = "46 x 10 = 460".ToString();
                aSagText.text = "46 x 10 = 460".ToString();
                bSolText.text = "248 x 100 = 24800".ToString();
                bSagText.text = "248 x 100 = 24800".ToString();
                cSolText.text = "7 x 1000 = 7000".ToString();
                cSagText.text = "7 x 1000 = 7000".ToString();
                dSolText.text = "76 x 100 = 76000".ToString();
                dSagText.text = "76 x 100 = 76000".ToString();
                break;
            case 15:
                aSolText.text = "1".ToString();
                aSagText.text = "1".ToString();
                bSolText.text = "2".ToString();
                bSagText.text = "2".ToString();
                cSolText.text = "3".ToString();
                cSagText.text = "3".ToString();
                dSolText.text = "4".ToString();
                dSagText.text = "4".ToString();
                break;
            case 16:
                aSolText.text = "305 � 3".ToString();
                aSagText.text = "305 � 3".ToString();
                bSolText.text = "212 � 5".ToString();
                bSagText.text = "212 � 5".ToString();
                cSolText.text = "906 � 6".ToString();
                cSagText.text = "906 � 6".ToString();
                dSolText.text = "608 � 3".ToString();
                dSagText.text = "608 � 3".ToString();
                break;
            case 17:
                aSolText.text = "3000 � 1000 = 3".ToString();
                aSagText.text = "3000 � 1000 = 3".ToString();
                bSolText.text = "5000 � 100 = 50".ToString();
                bSagText.text = "5000 � 100 = 50".ToString();
                cSolText.text = "5200 � 10 = 52".ToString();
                cSagText.text = "5200 � 10 = 52".ToString();
                dSolText.text = "4400 � 100 = 44".ToString();
                dSagText.text = "4400 � 100 = 44".ToString();
                break;
            case 18:
                aSolText.text = "38�".ToString();
                aSagText.text = "38�".ToString();
                bSolText.text = "48�".ToString();
                bSagText.text = "48�".ToString();
                cSolText.text = "128�".ToString();
                cSagText.text = "128�".ToString();
                dSolText.text = "138�".ToString();
                dSagText.text = "138�".ToString();
                break;
            case 19:
                aSolText.text = "1".ToString();
                aSagText.text = "1".ToString();
                bSolText.text = "2".ToString();
                bSagText.text = "2".ToString();
                cSolText.text = "3".ToString();
                cSagText.text = "3".ToString();
                dSolText.text = "4".ToString();
                dSagText.text = "4".ToString();
                break;
            case 20:
                aSolText.text = "En k���k asal say� 2' dir".ToString();
                aSagText.text = "En k���k asal say� 2' dir".ToString();
                bSolText.text = "1 asal say� de�ildir".ToString();
                bSagText.text = "1 asal say� de�ildir".ToString();
                cSolText.text = "2' den ba�ka �ift asal say� yoktur".ToString();
                cSagText.text = "2' den ba�ka �ift asal say� yoktur".ToString();
                dSolText.text = "�ki asal say�n�n toplam� daima asal say�d�r".ToString();
                dSagText.text = "�ki asal say�n�n toplam� daima asal say�d�r".ToString();
                break;
            case 21:
                aSolText.text = "2".ToString();
                aSagText.text = "2".ToString();
                bSolText.text = "6".ToString();
                bSagText.text = "6".ToString();
                cSolText.text = "36".ToString();
                cSagText.text = "36".ToString();
                dSolText.text = "48".ToString();
                dSagText.text = "48".ToString();
                break;
            case 22:
                aSolText.text = "2".ToString();
                aSagText.text = "2".ToString();
                bSolText.text = "3".ToString();
                bSagText.text = "3".ToString();
                cSolText.text = "4".ToString();
                cSagText.text = "4".ToString();
                dSolText.text = "5".ToString();
                dSagText.text = "5".ToString();
                break;
            case 23:
                aSolText.text = "2".ToString();
                aSagText.text = "2".ToString();
                bSolText.text = "3".ToString();
                bSagText.text = "3".ToString();
                cSolText.text = "4".ToString();
                cSagText.text = "4".ToString();
                dSolText.text = "5".ToString();
                dSagText.text = "5".ToString();
                break;
            case 24:
                aSolText.text = "2, 3, 4".ToString();
                aSagText.text = "2, 3, 4".ToString();
                bSolText.text = "2, 3, 5".ToString();
                bSagText.text = "2, 3, 5".ToString();
                cSolText.text = "2, 3, 6".ToString();
                cSagText.text = "2, 3, 6".ToString();
                dSolText.text = "3, 5, 6".ToString();
                dSagText.text = "3, 5, 6".ToString();
                break;
            case 25:
                aSolText.text = "2^3�. 3".ToString();
                aSagText.text = "2^3�. 3".ToString();
                bSolText.text = "2^3�. 3^2".ToString();
                bSagText.text = "2^3�. 3^2".ToString();
                cSolText.text = "2^4�. 3".ToString();
                cSagText.text = "2^4�. 3".ToString();
                dSolText.text = "2^4�. 3^2".ToString();
                dSagText.text = "2^4�. 3^2".ToString();
                break;
            case 26:
                aSolText.text = "866".ToString();
                aSagText.text = "866".ToString();
                bSolText.text = "409".ToString();
                bSagText.text = "409".ToString();
                cSolText.text = "753".ToString();
                cSagText.text = "753".ToString();
                dSolText.text = "575".ToString();
                dSagText.text = "575".ToString();
                break;
            case 27:
                aSolText.text = "1".ToString();
                aSagText.text = "1".ToString();
                bSolText.text = "3".ToString();
                bSagText.text = "3".ToString();
                cSolText.text = "5".ToString();
                cSagText.text = "5".ToString();
                dSolText.text = "8".ToString();
                dSagText.text = "8".ToString();
                break;
            case 28:
                aSolText.text = "2".ToString();
                aSagText.text = "2".ToString();
                bSolText.text = "4".ToString();
                bSagText.text = "4".ToString();
                cSolText.text = "6".ToString();
                cSagText.text = "6".ToString();
                dSolText.text = "9".ToString();
                dSagText.text = "9".ToString();
                break;
            case 29:
                aSolText.text = "(+1250)".ToString();
                aSagText.text = "(+1250)".ToString();
                bSolText.text = "(-1250)".ToString();
                bSagText.text = "(-1250)".ToString();
                cSolText.text = "(+250)".ToString();
                cSagText.text = "(+250)".ToString();
                dSolText.text = "(-250)".ToString();
                dSagText.text = "(-250)".ToString();
                break;
            case 30:
                aSolText.text = "-3, -2, -1, +1, +2, +3".ToString();
                aSagText.text = "-3, -2, -1, +1, +2, +3".ToString();
                bSolText.text = "-3, -2, -1, 0, +1, +2".ToString();
                bSagText.text = "-3, -2, -1, 0, +1, +2".ToString();
                cSolText.text = "4, -3, -2, -1, 0, +1, +2".ToString();
                cSagText.text = "4, -3, -2, -1, 0, +1, +2".ToString();
                dSolText.text = "-4, -3, -2, -1, 0, +1, +2, +3".ToString();
                dSagText.text = "-4, -3, -2, -1, 0, +1, +2, +3".ToString();
                break;
            case 31:
                aSolText.text = "5".ToString();
                aSagText.text = "5".ToString();
                bSolText.text = "4".ToString();
                bSagText.text = "4".ToString();
                cSolText.text = "3".ToString();
                cSagText.text = "3".ToString();
                dSolText.text = "2".ToString();
                dSagText.text = "2".ToString();
                break;
            case 32:
                aSolText.text = "-3 ile +1".ToString();
                aSagText.text = "-3 ile +1".ToString();
                bSolText.text = "-4 ile +5	".ToString();
                bSagText.text = "-4 ile +5	".ToString();
                cSolText.text = "-1 ile +1".ToString();
                cSagText.text = "-1 ile +1".ToString();
                dSolText.text = "+1 ile +10".ToString();
                dSagText.text = "+1 ile +10".ToString();
                break;
            case 33:
                aSolText.text = "-48".ToString();
                aSagText.text = "-48".ToString();
                bSolText.text = "-45".ToString();
                bSagText.text = "-45".ToString();
                cSolText.text = "-41".ToString();
                cSagText.text = "-41".ToString();
                dSolText.text = "-39".ToString();
                dSagText.text = "-39".ToString();
                break;
            case 34:
                aSolText.text = "(+5)".ToString();
                aSagText.text = "(+5)".ToString();
                bSolText.text = "(+6)".ToString();
                bSagText.text = "(+6)".ToString();
                cSolText.text = "(+7)".ToString();
                cSagText.text = "(+7)".ToString();
                dSolText.text = "(+8)".ToString();
                dSagText.text = "(+8)".ToString();
                break;
            case 35:
                aSolText.text = "(-9)".ToString();
                aSagText.text = "(-9)".ToString();
                bSolText.text = "(+9)".ToString();
                bSagText.text = "(+9)".ToString();
                cSolText.text = "(-17)".ToString();
                cSagText.text = "(-17)".ToString();
                dSolText.text = "(+17)".ToString();
                dSagText.text = "(+17)".ToString();
                break;
            case 36:
                aSolText.text = "0".ToString();
                aSagText.text = "0".ToString();
                bSolText.text = "(+18)".ToString();
                bSagText.text = "(+18)".ToString();
                cSolText.text = "(-18)".ToString();
                cSagText.text = "(-18)".ToString();
                dSolText.text = "(-6)".ToString();
                dSagText.text = "(-6)".ToString();
                break;
            case 37:
                aSolText.text = "2a".ToString();
                aSagText.text = "2a".ToString();
                bSolText.text = "3a".ToString();
                bSagText.text = "3a".ToString();
                cSolText.text = "3a + 2".ToString();
                cSagText.text = "3a + 2".ToString();
                dSolText.text = "2a + 3".ToString();
                dSagText.text = "2a + 3".ToString();
                break;
            case 38:
                aSolText.text = "2.a".ToString();
                aSagText.text = "2.a".ToString();
                bSolText.text = "a � 4".ToString();
                bSagText.text = "a � 4".ToString();
                cSolText.text = "2m + 4".ToString();
                cSagText.text = "2m + 4".ToString();
                dSolText.text = "42 � 16".ToString();
                dSagText.text = "42 � 16".ToString();
                break;
            case 39:
                aSolText.text = "40.x".ToString();
                aSagText.text = "40.x".ToString();
                bSolText.text = "40 � x".ToString();
                bSagText.text = "40 � x".ToString();
                cSolText.text = "x � 40".ToString();
                cSagText.text = "x � 40".ToString();
                dSolText.text = "40x � x".ToString();
                dSagText.text = "40x � x".ToString();
                break;
            case 40:
                aSolText.text = "x � 20".ToString();
                aSagText.text = "x � 20".ToString();
                bSolText.text = "20 � a".ToString();
                bSagText.text = "20 � a".ToString();
                cSolText.text = "20 � m".ToString();
                cSagText.text = "20 � m".ToString();
                dSolText.text = "20 � x�".ToString();
                dSagText.text = "20 � x�".ToString();
                break;
            case 41:
                aSolText.text = "x.y".ToString();
                aSagText.text = "x.y".ToString();
                bSolText.text = "2.x.y".ToString();
                bSagText.text = "2.x.y".ToString();
                cSolText.text = "x + y".ToString();
                cSagText.text = "x + y".ToString();
                dSolText.text = "2x + 2y".ToString();
                dSagText.text = "2x + 2y".ToString();
                break;
            case 42:
                aSolText.text = "0,8".ToString();
                aSagText.text = "0,8".ToString();
                bSolText.text = "6,2".ToString();
                bSagText.text = "6,2".ToString();
                cSolText.text = "4,5".ToString();
                cSagText.text = "4,5".ToString();
                dSolText.text = "5,4".ToString();
                dSagText.text = "5,4".ToString();
                break;
            case 43:
                aSolText.text = "Be� tam d�rt".ToString();
                aSagText.text = "Be� tam d�rt".ToString();
                bSolText.text = "Be� tam onda d�rt".ToString();
                bSagText.text = "Be� tam onda d�rt".ToString();
                cSolText.text = "Be� tam binde d�rt".ToString();
                cSagText.text = "Be� tam binde d�rt".ToString();
                dSolText.text = "Be� tam y�zde d�rt".ToString();
                dSagText.text = "Be� tam y�zde d�rt".ToString();
                break;
            case 44:
                aSolText.text = "0,44".ToString();
                aSagText.text = "0,44".ToString();
                bSolText.text = "0,43".ToString();
                bSagText.text = "0,43".ToString();
                cSolText.text = "0,4".ToString();
                cSagText.text = "0,4".ToString();
                dSolText.text = "0,3".ToString();
                dSagText.text = "0,3".ToString();
                break;
            case 45:
                aSolText.text = "1,035".ToString();
                aSagText.text = "1,035".ToString();
                bSolText.text = "10,35".ToString();
                bSagText.text = "10,35".ToString();
                cSolText.text = "10,45".ToString();
                cSagText.text = "10,45".ToString();
                dSolText.text = "103,5".ToString();
                dSagText.text = "103,5".ToString();
                break;
            case 46:
                aSolText.text = "7".ToString();
                aSagText.text = "7".ToString();
                bSolText.text = "6".ToString();
                bSagText.text = "6".ToString();
                cSolText.text = "5".ToString();
                cSagText.text = "5".ToString();
                dSolText.text = "4".ToString();
                dSagText.text = "4".ToString();
                break;
            case 47:
                aSolText.text = "Sonbahar mevsiminin aylar�".ToString();
                aSagText.text = "Sonbahar mevsiminin aylar�".ToString();
                bSolText.text = "Haftan�n g�nleri".ToString();
                bSagText.text = "Haftan�n g�nleri".ToString();
                cSolText.text = "Futbol tak�m�ndaki iyi oyuncular".ToString();
                cSagText.text = "Futbol tak�m�ndaki iyi oyuncular".ToString();
                dSolText.text = "�ift rakamlar".ToString();
                dSagText.text = "�ift rakamlar".ToString();
                break;
            case 48:
                aSolText.text = "2".ToString();
                aSagText.text = "2".ToString();
                bSolText.text = "3".ToString();
                bSagText.text = "3".ToString();
                cSolText.text = "5".ToString();
                cSagText.text = "5".ToString();
                dSolText.text = "7".ToString();
                dSagText.text = "7".ToString();
                break;
        }

    }
    
    public void aSolButton()
    {
        switch (index)
        {
            case 0:
                Wrong();
                break;
            case 1:
                Wrong();
                break;
            case 2:
                Wrong();

                break;
            case 3:
                Wrong();

                break;
            case 4:
                Wrong();

                break;
            case 5:
                Wrong();

                break;
            case 6:
                Wrong();

                break;
            case 7:
                Wrong();

                break;
            case 8:
                Wrong();

                break;
            case 9:
                Wrong();

                break;
            case 10:
                Wrong();

                break;
            case 11:
                Wrong();

                break;
            case 12:
                Wrong();

                break;
            case 13:
                Wrong();

                break;
            case 14:
                Wrong();

                break;
            case 15:
                Wrong();

                break;
            case 16:
                Wrong();

                break;
            case 17:
                Wrong();

                break;
            case 18:
                Wrong();

                break;
            case 19:
                Wrong();

                break;
            case 20:
                Wrong();

                break;
            case 21:
                Wrong();

                break;
            case 22:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 23:
                Wrong();

                break;
            case 24:
                Wrong();

                break;
            case 25:
                Wrong();

                break;
            case 26:
                Wrong();

                break;
            case 27:
                Wrong();

                break;
            case 28:
                Wrong();

                break;
            case 29:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 30:
                Wrong();

                break;
            case 31:
                Wrong();

                break;
            case 32:
                Wrong();

                break;
            case 33:
                Wrong();

                break;
            case 34:
                Wrong();

                break;
            case 35:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 36:
                Wrong();

                break;
            case 37:
                Wrong();

                break;
            case 38:
                Wrong();

                break;
            case 39:
                Wrong();

                break;
            case 40:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 41:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 42:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 43:
                Wrong();

                break;
            case 44:
                Wrong();

                break;
            case 45:
                Wrong();

                break;
            case 46:
                Wrong();

                break;
            case 47:
                Wrong();

                break;
            case 48:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
        }
    }
    public void aSagButton()
    {
        switch (index)
        {
            case 0:
                Wrong2();
                break;
            case 1:
                Wrong2();
                break;
            case 2:
                Wrong2();

                break;
            case 3:
                Wrong2();

                break;
            case 4:
                Wrong2();

                break;
            case 5:
                Wrong2();

                break;
            case 6:
                Wrong2();

                break;
            case 7:
                Wrong2();

                break;
            case 8:
                Wrong2();

                break;
            case 9:
                Wrong2();

                break;
            case 10:
                Wrong2();

                break;
            case 11:
                Wrong2();

                break;
            case 12:
                Wrong2();

                break;
            case 13:
                Wrong2();

                break;
            case 14:
                Wrong2();

                break;
            case 15:
                Wrong2();

                break;
            case 16:
                Wrong2();

                break;
            case 17:
                Wrong2();

                break;
            case 18:
                Wrong2();

                break;
            case 19:
                Wrong2();

                break;
            case 20:
                Wrong2();

                break;
            case 21:
                Wrong2();

                break;
            case 22:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 23:
                Wrong2();

                break;
            case 24:
                Wrong2();

                break;
            case 25:
                Wrong2();

                break;
            case 26:
                Wrong2();

                break;
            case 27:
                Wrong2();

                break;
            case 28:
                Wrong2();

                break;
            case 29:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 30:
                Wrong2();

                break;
            case 31:
                Wrong2();

                break;
            case 32:
                Wrong2();

                break;
            case 33:
                Wrong2();

                break;
            case 34:
                Wrong2();

                break;
            case 35:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 36:
                Wrong2();

                break;
            case 37:
                Wrong2();

                break;
            case 38:
                Wrong2();

                break;
            case 39:
                Wrong2();

                break;
            case 40:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 41:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 42:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 43:
                Wrong2();

                break;
            case 44:
                Wrong2();

                break;
            case 45:
                Wrong2();

                break;
            case 46:
                Wrong2();

                break;
            case 47:
                Wrong2();

                break;
            case 48:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
        }
    }
    public void bSolButton()
    {
        switch (index)
        {
            case 0:
                Wrong();
                break;
            case 1:
                Wrong();

                break;
            case 2:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 3:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 4:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 5:
                Wrong();

                break;
            case 6:
                Wrong();

                break;
            case 7:
                Wrong();

                break;
            case 8:
                Wrong();

                break;
            case 9:
                Wrong();

                break;
            case 10:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 11:
                Wrong();

                break;
            case 12:
                Wrong();

                break;
            case 13:
                Wrong();

                break;
            case 14:
                Wrong();

                break;
            case 15:
                Wrong();

                break;
            case 16:
                Wrong();

                break;
            case 17:
                Wrong();

                break;
            case 18:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 19:
                Wrong();

                break;
            case 20:
                Wrong();

                break;
            case 21:
                Wrong();

                break;
            case 22:
                Wrong();

                break;
            case 23:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 24:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 25:
                Wrong();

                break;
            case 26:
                Wrong();

                break;
            case 27:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 28:
                Wrong();

                break;
            case 29:
                Wrong();

                break;
            case 30:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 31:
                Wrong();

                break;
            case 32:
                Wrong();

                break;
            case 33:
                Wrong();

                break;
            case 34:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 35:
                Wrong();

                break;
            case 36:
                Wrong();

                break;
            case 37:
                Wrong();

                break;
            case 38:
                Wrong();

                break;
            case 39:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 40:
                Wrong();

                break;
            case 41:
                Wrong();

                break;
            case 42:
                Wrong();

                break;
            case 43:
                Wrong();

                break;
            case 44:
                Wrong();

                break;
            case 45:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 46:
                Wrong();

                break;
            case 47:
                Wrong();

                break;
            case 48:
                Wrong();

                break;
        }
    }
    public void bSagButton()
    {
        switch (index)
        {
            case 0:
                Wrong2();
                break;
            case 1:
                Wrong2();

                break;
            case 2:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 3:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 4:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 5:
                Wrong2();

                break;
            case 6:
                Wrong2();

                break;
            case 7:
                Wrong2();

                break;
            case 8:
                Wrong2();

                break;
            case 9:
                Wrong2();

                break;
            case 10:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 11:
                Wrong2();

                break;
            case 12:
                Wrong2();

                break;
            case 13:
                Wrong2();

                break;
            case 14:
                Wrong2();

                break;
            case 15:
                Wrong2();

                break;
            case 16:
                Wrong2();

                break;
            case 17:
                Wrong2();

                break;
            case 18:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 19:
                Wrong2();

                break;
            case 20:
                Wrong2();

                break;
            case 21:
                Wrong2();

                break;
            case 22:
                Wrong2();

                break;
            case 23:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 24:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 25:
                Wrong2();

                break;
            case 26:
                Wrong2();

                break;
            case 27:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 28:
                Wrong2();

                break;
            case 29:
                Wrong2();

                break;
            case 30:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 31:
                Wrong2();

                break;
            case 32:
                Wrong2();

                break;
            case 33:
                Wrong2();

                break;
            case 34:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 35:
                Wrong2();

                break;
            case 36:
                Wrong2();

                break;
            case 37:
                Wrong2();

                break;
            case 38:
                Wrong2();

                break;
            case 39:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 40:
                Wrong2();

                break;
            case 41:
                Wrong2();

                break;
            case 42:
                Wrong2();

                break;
            case 43:
                Wrong2();

                break;
            case 44:
                Wrong2();

                break;
            case 45:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 46:
                Wrong2();

                break;
            case 47:
                Wrong2();

                break;
            case 48:
                Wrong2();

                break;
        }
    }
    public void cSolButton()
    {
        switch (index)
        {
            case 0:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 1:
                Wrong();

                break;
            case 2:
                Wrong();

                break;
            case 3:
                Wrong();

                break;
            case 4:
                Wrong();

                break;
            case 5:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 6:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 7:
                Wrong();

                break;
            case 8:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 9:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 10:
                Wrong();

                break;
            case 11:
                Wrong();

                break;
            case 12:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 13:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 14:
                Wrong();

                break;
            case 15:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 16:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 17:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 18:
                Wrong();

                break;
            case 19:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 20:
                Wrong();

                break;
            case 21:
                Wrong();

                break;
            case 22:
                Wrong();

                break;
            case 23:
                Wrong();

                break;
            case 24:
                Wrong();

                break;
            case 25:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 26:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 27:
                Wrong();

                break;
            case 28:
                Wrong();

                break;
            case 29:
                Wrong();

                break;
            case 30:
                Wrong();

                break;
            case 31:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 32:
                Wrong();

                break;
            case 33:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 34:
                Wrong();

                break;
            case 35:
                Wrong();

                break;
            case 36:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 37:
                Wrong();

                break;
            case 38:
                Wrong();

                break;
            case 39:
                Wrong();

                break;
            case 40:
                Wrong();

                break;
            case 41:
                Wrong();

                break;
            case 42:
                Wrong();

                break;
            case 43:
                Wrong();

                break;
            case 44:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 45:
                Wrong();

                break;
            case 46:
                Wrong();

                break;
            case 47:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 48:
                Wrong();

                break;
        }
    }
    public void cSagButton()
    {
        switch (index)
        {
            case 0:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 1:
                Wrong2();

                break;
            case 2:
                Wrong2();

                break;
            case 3:
                Wrong2();

                break;
            case 4:
                Wrong2();

                break;
            case 5:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 6:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 7:
                Wrong2();

                break;
            case 8:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 9:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 10:
                Wrong2();

                break;
            case 11:
                Wrong2();

                break;
            case 12:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 13:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 14:
                Wrong2();

                break;
            case 15:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 16:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 17:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 18:
                Wrong2();

                break;
            case 19:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 20:
                Wrong2();

                break;
            case 21:
                Wrong2();

                break;
            case 22:
                Wrong2();

                break;
            case 23:
                Wrong2();

                break;
            case 24:
                Wrong2();

                break;
            case 25:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 26:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 27:
                Wrong2();

                break;
            case 28:
                Wrong2();

                break;
            case 29:
                Wrong2();

                break;
            case 30:
                Wrong2();

                break;
            case 31:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 32:
                Wrong2();

                break;
            case 33:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 34:
                Wrong2();

                break;
            case 35:
                Wrong2();

                break;
            case 36:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 37:
                Wrong2();

                break;
            case 38:
                Wrong2();

                break;
            case 39:
                Wrong2();

                break;
            case 40:
                Wrong2();

                break;
            case 41:
                Wrong2();

                break;
            case 42:
                Wrong2();

                break;
            case 43:
                Wrong2();

                break;
            case 44:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 45:
                Wrong2();

                break;
            case 46:
                Wrong2();

                break;
            case 47:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 48:
                Wrong2();

                break;
        }
    }
    public void dSolButton()
    {
        switch (index)
        {
            case 0:
                Wrong();

                break;
            case 1:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 2:
                Wrong();

                break;
            case 3:
                Wrong();

                break;
            case 4:
                Wrong();

                break;
            case 5:
                Wrong();

                break;
            case 6:
                Wrong();

                break;
            case 7:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 8:
                Wrong();

                break;
            case 9:
                Wrong();

                break;
            case 10:
                Wrong();

                break;
            case 11:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 12:
                Wrong();

                break;
            case 13:
                Wrong();

                break;
            case 14:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 15:
                Wrong();

                break;
            case 16:
                Wrong();

                break;
            case 17:
                Wrong();
                break;
            case 18:
                Wrong();

                break;
            case 19:
                Wrong();

                break;
            case 20:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 21:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 22:
                Wrong();

                break;
            case 23:
                Wrong();

                break;
            case 24:
                Wrong();

                break;
            case 25:
                Wrong();

                break;
            case 26:
                Wrong();

                break;
            case 27:
                Wrong();

                break;
            case 28:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 29:
                Wrong();

                break;
            case 30:
                Wrong();

                break;
            case 31:
                Wrong();

                break;
            case 32:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 33:
                Wrong();

                break;
            case 34:
                Wrong();

                break;
            case 35:
                Wrong();

                break;
            case 36:
                Wrong();

                break;
            case 37:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 38:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 39:
                Wrong();

                break;
            case 40:
                Wrong();

                break;
            case 41:
                Wrong();

                break;
            case 42:
                Wrong();

                break;
            case 43:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 44:
                Wrong();

                break;
            case 45:
                Wrong();

                break;
            case 46:
                Tokat1();
                RandomSoru();
                CanBar();
                break;
            case 47:
                Wrong();

                break;
            case 48:
                Wrong();

                break;
        }
    }
    public void dSagButton()
    {
        switch (index)
        {
            case 0:
                Wrong2();

                break;
            case 1:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 2:
                Wrong2();

                break;
            case 3:
                Wrong2();

                break;
            case 4:
                Wrong2();

                break;
            case 5:
                Wrong2();

                break;
            case 6:
                Wrong2();

                break;
            case 7:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 8:
                Wrong2();

                break;
            case 9:
                Wrong2();

                break;
            case 10:
                Wrong2();

                break;
            case 11:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 12:
                Wrong2();

                break;
            case 13:
                Wrong2();

                break;
            case 14:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 15:
                Wrong2();

                break;
            case 16:
                Wrong2();

                break;
            case 17:
                Wrong2();
                break;
            case 18:
                Wrong2();

                break;
            case 19:
                Wrong2();

                break;
            case 20:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 21:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 22:
                Wrong2();

                break;
            case 23:
                Wrong2();

                break;
            case 24:
                Wrong2();

                break;
            case 25:
                Wrong2();

                break;
            case 26:
                Wrong2();

                break;
            case 27:
                Wrong2();

                break;
            case 28:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 29:
                Wrong2();

                break;
            case 30:
                Wrong2();

                break;
            case 31:
                Wrong2();

                break;
            case 32:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 33:
                Wrong2();

                break;
            case 34:
                Wrong2();

                break;
            case 35:
                Wrong2();

                break;
            case 36:
                Wrong2();

                break;
            case 37:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 38:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 39:
                Wrong2();

                break;
            case 40:
                Wrong2();

                break;
            case 41:
                Wrong2();

                break;
            case 42:
                Wrong2();

                break;
            case 43:
                Tokat2();
                RandomSoru();
                CanBar2();
                break;
            case 44:
                Wrong2();

                break;
            case 45:
                Wrong2();

                break;
            case 46:
                Tokat2();
                RandomSoru();
                CanBar2();

                break;
            case 47:
                Wrong2();

                break;
            case 48:
                Wrong2();

                break;
        }
    }
    
    public void Tokat1()
    {
        Anims.instance.Tokat();
        
        print("tokat1");
        
    }

    public void Tokat2()
    {
        Anims2.instance.Tokat2();
        print("tokat2");
    }
    void CanBar2()
    {
        _currentHealth -= 1;
        _healthbar2.UpdateHealthBar(_maxHealth, _currentHealth);


        if (_currentHealth <= 0)
        {
            GameEndPanel.SetActive(true);
            Cha1.SetActive(false);
            Cha2.SetActive(false);

            GameEndText.text = "2. Oyuncu Kazand�".ToString();
        }
    }
    void CanBar()
    {
        _currentHealth -= 1;
        _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);


        if (_currentHealth <= 0)
        {
            GameEndPanel.SetActive(true);
            Cha1.SetActive(false);
            Cha2.SetActive(false);
            GameEndText.text = "1. Oyuncu Kazand�".ToString();
        }
    }
    public void Wrong()
    {
        StartCoroutine(Yanlis());
    }
    public void Wrong2()
    {
        StartCoroutine(Yanlis2());
    }
    IEnumerator Yanlis2()
    {
        FalseIcon2.GetComponent<RectTransform>().DOLocalMoveY(-210, 1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1);
        FalseIcon2.GetComponent<RectTransform>().DOLocalMoveY(-1210, 0.5f).SetEase(Ease.OutBack);
    }
    IEnumerator Yanlis()
    {
        FalseIcon.GetComponent<RectTransform>().DOLocalMoveY(-210, 1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1);
        FalseIcon.GetComponent<RectTransform>().DOLocalMoveY(-1210, 0.5f).SetEase(Ease.OutBack);
    }
}
