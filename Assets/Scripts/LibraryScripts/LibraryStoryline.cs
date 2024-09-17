using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class LibraryStoryline : MonoBehaviour
{
    public bool startImmediately;
    public bool firstBookAttached = false;
    public bool secondBookAttached = false;
    public bool thirdBookAttached = false;
    public bool fourthBookAttached = false;
    public bool fifthBookAttached = false;
    public bool isTableAttached = false;

   

    public TextMeshProUGUI pcText;

    public TextMeshProUGUI Q1;
    public TextMeshProUGUI Q2;
    public TextMeshProUGUI Q3;

    public TabletAttachment tablet;
    private HintManager hintManager;

    public ScannableBook book;
    public BookScanner scanner;

    public Light scannerLight;



    //public XRPushButton keyboardEnter;

    public Transform xrOrigin, initialPosition;

    public bool enterPressed = false;

    private Coroutine current;

    void Start()
    {
        if (hintManager == null)
            hintManager = FindObjectOfType<HintManager>();

        /*
        keyboardEnter.onPress.AddListener(
            new UnityEngine.Events.UnityAction(
                () => enterPressed = true
            )
        );
        */

        if (startImmediately)
            Begin();
    }

    public void Begin(Action callback=null)
    {
        xrOrigin.SetPositionAndRotation(initialPosition.position, initialPosition.rotation);
        current = StartCoroutine(RunStory(callback));
    }

    public void ResetStory()
    {
        if (current != null)
            StopCoroutine(current);

        pcText.text = "";
        hintManager.SetHint("");
    }

    public void FirstAttach()
    {
        firstBookAttached = true;
    }

    public void SecondAttach()
    {
        secondBookAttached = true;
    }

    public void ThirdAttach()
    {
        thirdBookAttached = true;
    }

    public void FourthAttach()
    {
        fourthBookAttached = true;
    }


    private IEnumerator RunStory(Action callback)
    {
        hintManager.SetHint("123123123");
        pcText.text = "������:\n    ��������...";
        scannerLight.enabled = false;
        isTableAttached = false;
        

        yield return new WaitForSeconds(2f);
        AudioManager.instance.Play("LibrarySpawn");


        Debug.Log("Step 1: sound");
        yield return new WaitUntil(() => tablet.currentAttachment != null);

        Q1.text = "<s>1. ����� �������</s>";
        AudioManager.instance.Stop("LibrarySpawn");
        isTableAttached = true;
        Debug.Log("Step 2: Disable  sound and show hint 1");
        hintManager.SetHint("���� ����� ������������� ���� �����. ��� ��������� � ����������� ���� � ������ �������. � ���� ����� ������� �������");
        yield return new WaitUntil(() => book.IsGrabbed);


        Debug.Log("Step 3: Show hint 2");
        hintManager.SetHint(
            "�������, ������ ������� ��� ����� �� ���� � ������ � �� ������ ������"
        );
        yield return new WaitUntil(() => scanner.HaveBook);


        Debug.Log("Step 4: Show hint 3");
        enterPressed = true;
        hintManager.SetHint(
            "������ ����� Enter �� ���������� ���������� ����� ��������� ������"
        );
        yield return new WaitUntil(() => enterPressed);


        Debug.Log("Step 5: Wait...");
        pcText.text = "������:\n    ������������...";
        scannerLight.enabled = true;
        AudioManager.instance.Play("ScanSound");
        hintManager.SetHint("�������� ������� ���������");
        yield return new WaitForSeconds(4f);

        Debug.Log("Step 5: Weeee");
        scannerLight.enabled = false;
        pcText.text = "������:\n    ������������ ���������\n    ����������� ���������!";
        hintManager.SetHint("������ ���������!");
        yield return new WaitForSeconds(5f);

        Q2.text = "<s>2. ������������� �����</s>";
        hintManager.SetHint("������ ���� ���������� ���������� ����� ����� �� �� �����!����� ������ ��� ������ ������ �����-������������ �� ������. ����� ��� ������ ���� ���� �������� ������ ������������ �� ������ ����������.");
        yield return new WaitUntil(() => (firstBookAttached == true && secondBookAttached==true ) );


        hintManager.SetHint("�������! ���������  ����� ���������� ��������� �� ����� � ������� �����������.");
        yield return new WaitUntil(() => (thirdBookAttached == true));

        hintManager.SetHint("�������! ���������  ����� ���������� ��������� �� ����� � ������� �����������.");
        yield return new WaitUntil(() => (fourthBookAttached == true));

        Q3.text = "<s>3. ���������� �����</s>";
        hintManager.SetHint("������� ��� ������ ���������!");
        AudioManager.instance.Play("QuestFinished");
        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene(0);


        callback?.Invoke();
    }
}
