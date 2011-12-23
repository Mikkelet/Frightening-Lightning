using System.Collections;
using UnityEngine;

public class Pause : MonoBehaviour 
{
    public Texture PauseBTN;
    public Texture PlayBTN;
    Texture btnToShow;
    public Texture soundOn;
    public Texture soundOff;
    Texture currentSound;

    float pauseBtnPosX = (Screen.width) - 60;
    float pauseBtnPosY = 10;

    public bool showPause = false;
    bool showTutorial = false;

    float boxWidth = 200;
    float boxHeight = 250;
    float btnWidth = 180;
    float btnHeight = 35;

    int clicks = 0;


    void Start()
    {

        btnToShow = PauseBTN;
        if (GUI_Interface.soundPlay == true)
        {
            currentSound = soundOn;
        }
        else
        {
            currentSound = soundOff;
        }

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(pauseBtnPosX, pauseBtnPosY, 50, 50), btnToShow, GUIStyle.none))
        {
            if(!showPause)
            {
                showPause = true;
                Time.timeScale = Time.timeScale == 1 ? 0 : 1;
                clicks++;
                btnToShow = PlayBTN;
            }
            else
            {
                showPause = false;
                clicks = 0;
                Time.timeScale = Time.timeScale == 1 ? 1 : 1;
                btnToShow = PauseBTN;
            }


        }
        if (showPause == true)//Martin was here!
        {
            if(GUI.Button(new Rect(pauseBtnPosX - 50,pauseBtnPosY,50,50),currentSound,GUIStyle.none))
            {
                if (currentSound == soundOn)
                {
                    currentSound = soundOff;//hihihihi
                    audio.Pause();
                    GUI_Interface.soundPlay = false;
                }//hihihihihihihi
                else
                {
                    currentSound = soundOn;
                    audio.Play();
                    GUI_Interface.soundPlay = true;
                }
            }
        }

        if (showPause == true & showTutorial == false)
        {
            float boxPosX = Screen.width / 2 -(boxWidth / 2);
            float boxPosY = 40;
            float btnPosX = Screen.width / 2 - (boxWidth / 2) + 10;
            float btnPosY = boxPosY + btnHeight -10;
            float btnPosYAdd = btnHeight + 5;
            //Pause box
            GUI.Box(new Rect(boxPosX,boxPosY, boxWidth, boxHeight), "Game Paused");

            //Resume Button
            if (GUI.Button(new Rect(btnPosX,btnPosY,btnWidth,btnHeight * 2), "Resume"))
            {
                showPause = false;
                showTutorial = false;

                Time.timeScale = Time.timeScale == 1 ? 1 : 1;
            }

            //Quick tutorial
            if (GUI.Button(new Rect(btnPosX, btnPosY + (btnPosYAdd* 2) , btnWidth, btnHeight), "Quick tutorial"))
            {
                //showTutorial = true;
                //showOptions = false
            }
            //Quit to menu
            if (GUI.Button(new Rect(btnPosX, btnPosY + (btnPosYAdd * 3), btnWidth, btnHeight), "Quit to menu"))
            {
                Application.LoadLevel(0); 
                Time.timeScale = Time.timeScale == 1 ? 1 : 1;

            }
            //Quit Game
            if (GUI.Button(new Rect(btnPosX, btnPosY + (btnPosYAdd * 4), btnWidth, btnHeight), "Exit the game"))
            {
                Application.Quit();
                Time.timeScale = Time.timeScale == 1 ? 1 : 1;
            }
        }
    }
}
