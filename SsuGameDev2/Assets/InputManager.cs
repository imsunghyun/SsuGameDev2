using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sign
{
    None,       //�ʱ����, ���Է�
    Pa,         //����
    Block,      //����
    Charge,     //�������
    EnergyPa    //Ǯ������������
}

public class InputManager : MonoBehaviour
{
    private Sign player1Choice = Sign.None;
    private Sign player2Choice = Sign.None;

    public int player1Energy = 0;
    public int player2Energy = 0;

    public int a = 0;

    void Start()
    {
        
    }

    /*
    void Player1Choose(Sign choice)
    {
        player1Choice = choice;
        Player2Choose();
        DetermineWinner();
    }

    void Player2Choose()
    {
        // ���Ƿ� Player2�� ������ ���ϴ� �ڵ带 ������ �� �ֽ��ϴ�.
        // ���� ���, Random.Range()�� ����Ͽ� �������� �����ϰų�,
        // �����δ� ��Ʈ��ũ ��� ���� ���� ������ ������ ���� �� �ֽ��ϴ�.
        player2Choice = (Sign)Random.Range(1, 4);
    }
    */

    void DetermineWinner()
    {
        //�÷��̾�1�� ����
        if (player1Choice == Sign.Pa)
        {
            player1Energy = 0;
            if (player2Choice == Sign.Charge)
            {
                player2Energy = 0;
                Debug.Log("Player 1�� ���� ����!");
            }
            else if(player2Choice == Sign.Block)
            {
                Debug.Log("Blocking");
            }
            else if(player2Choice == Sign.Pa)
            {
                player2Energy = 0;
                if (player1Energy > player2Energy)
                    Debug.Log("Player 1�� ���� ����!");
                else if (player2Energy > player1Energy)
                    Debug.Log("Player 2�� ���� ����!");
                else
                    Debug.Log("���� ����");
            }
            else if(player2Choice == Sign.EnergyPa)
            {
                player2Energy = 0;
                Debug.Log("Player 2�� ���� ����!");
            }
        }

        //�÷��̾�1�� ����
        if (player1Choice == Sign.Block)
        {
            if (player2Choice == Sign.Charge)
            {
                player2Energy++;
                Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Block)
            {
                Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Pa)
            {
                player2Energy = 0;
                Debug.Log("Blocking");
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                player2Energy = 0;
                Debug.Log("Player 2�� ���� ����!");
            }
        }

        //�÷��̾�1�� �������
        if (player1Choice == Sign.Charge)
        {
            player1Energy++;
            if (player2Choice == Sign.Charge)
            {
                player2Energy++;
                Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Block)
            {
                Debug.Log("Nothing Happen");
            }
            else if (player2Choice == Sign.Pa)
            {
                player2Energy = 0; player1Energy = 0;
                Debug.Log("Player 2�� ���� ����!");
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                player2Energy = 0; player1Energy = 0;
                Debug.Log("Player 2�� ���� ����!");
            }
        }

        //�÷��̾�1�� ��������
        if (player1Choice == Sign.EnergyPa)
        {
            player1Energy = 0;
            if (player2Choice == Sign.Charge)
            {
                player2Energy = 0;
                Debug.Log("Player 1�� ���� ����!");
            }
            else if (player2Choice == Sign.Block)
            {
                player2Energy = 0;
                Debug.Log("Player 1�� ���� ����!");
            }
            else if (player2Choice == Sign.Pa)
            {
                player2Energy = 0;
                Debug.Log("Player 1�� ���� ����!");
            }
            else if (player2Choice == Sign.EnergyPa)
            {
                player2Energy = 0;
                Debug.Log("���� ����");
            }
        }

        a++;
        ResetChoices();
    }

    void ResetChoices()
    {
        player1Choice = Sign.None;
        player2Choice = Sign.None;
    }

    private void Update()
    {
        //=============Player01 Ű�Է�===============
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(player1Energy >= 3)
                player1Choice = Sign.EnergyPa;
            else
                player1Choice = Sign.Pa;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            player1Choice = Sign.Block;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            player1Choice = Sign.Charge;
        }

        //=============Player02 Ű�Է�==============
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            if (player2Energy >= 3)
                player2Choice = Sign.EnergyPa;
            else
                player2Choice = Sign.Pa;
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            player2Choice = Sign.Block;
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            player2Choice = Sign.Charge;
        }



        if(Input.GetKeyUp(KeyCode.Space))
        {
            //�ϴ��� �����̽��ٷ� ��������ֱ�� ������ ����, ����ý��� ������ �� ��� �Űܰ� ����
            DetermineWinner();
        }
    }
}
