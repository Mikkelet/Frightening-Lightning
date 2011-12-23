////////////////////////////////////////////
///////////Freightening lightning///////////
/////////////GUI interface//////////////////
////////////////////////////////////////////
///////////////Scriptet by//////////////////
///////////Mikkel Munkholm Jensen///////////
////////////////////////////////////////////
using UnityEngine;
using System.Collections;

public class GUI_Interface : MonoBehaviour 
{
    //GUI buttons size and position
    int boxWidth = 270;
    int boxPosX = Screen.width / 2 - (Screen.width / 6 - 10);
    float boxPosY = Screen.height / 7F;
    int boxPosYAdd = 80; // Distance between each button
    int boxHeight = 70;

    //Public button texture variables
    public Texture newGame;
    public Texture howTo;
    public Texture credits;
    public Texture exit;
    public Texture toMenu;
    public Texture next;
    public Texture soundOn;
    public Texture soundOff;
    Texture currentSound;

    //Public How to texture variables
    public Texture control1;//Control the lightning
    public Texture control2;//Create a bridge with a tree or other
    public Texture control3;//Start the elevator
    public Texture control4;//Turn on the power suppy to a house
    public Texture control5;//Hit a wire to fill a gap with a big block of something
    Texture controlCurrent;

    //Control texture
    int clickedOn = 1;

    //Sound object
    public static bool soundPlay = true;

    void Start()
    {
        controlCurrent = control1;
        currentSound = soundOn;
    }

    void OnGUI()
    {
        #region Menu
        if (Application.loadedLevel == 0)
        {

            
            if (GUI.Button(new Rect(boxPosX, boxPosY, boxWidth, boxHeight), newGame, GUIStyle.none))
            {
                //Loads the game
                Application.LoadLevel(3);
            }

            if (GUI.Button(new Rect(boxPosX, boxPosY + boxPosYAdd, boxWidth, boxHeight), howTo, GUIStyle.none))
            {
                //Loads the how to menu
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(boxPosX, boxPosY + (boxPosYAdd * 2), boxWidth, boxHeight), credits, GUIStyle.none))
            {
                //Loads the credits
                Application.LoadLevel(2);
            }

            if (GUI.Button(new Rect(boxPosX, boxPosY + (boxPosYAdd * 3), boxWidth, boxHeight), exit, GUIStyle.none))
            {
                Application.Quit();
            }

            if(GUI.Button(new Rect(Screen.width - 65,15,50,50),currentSound,GUIStyle.none))
            {

                if (currentSound == soundOn)
                {
                    currentSound = soundOff;

                    AudioListener.pause = true;
                    soundPlay = false;
                }
                else
                {
                    currentSound = soundOn;
                    AudioListener.pause = false;
                    soundPlay = true;
                }
            }
        }
        #endregion

        #region How to
        if (Application.loadedLevel == 1)
        {
            guiTexture.texture = controlCurrent;

            if(GUI.Button(new Rect(50,Screen.height / 4 + Screen.height / 2 - boxHeight,boxWidth,boxHeight),toMenu,GUIStyle.none))
            {
                Application.LoadLevel(0);
            }
            if (GUI.Button(new Rect(50, Screen.height / 4 + Screen.height / 2, boxWidth, boxHeight), next,GUIStyle.none))
            {
                clickedOn++;
                switch (clickedOn)
                {
                    case 1:
                        controlCurrent = control1;
                        break;
                    case 2:
                        controlCurrent = control2;
                        break;
                    case 3:
                        controlCurrent = control3;
                        break;
                    case 4:
                        controlCurrent = control4;
                        break;
                    case 5:
                        controlCurrent = control5;
                        break;
                    case 6:
                        Application.LoadLevel(0);
                        break;
                }
                    
            }
        }
        #endregion

        #region Credits
        if (Application.loadedLevel == 2)
        {
            GUI.Box(new Rect(Screen.width / 2 - 75, 50, 200, 240), "Frightening Lightning  \n \n Created by \n Mikkel Thygesen \n Kristian Flejsborg \n Mikkel Munkholm \n\n\n A special thanks to \n\n GameIT College\n Teachers at GTS: \n\n© Freightening Games \n All rights reserved ");

            if (GUI.Button(new Rect(50, Screen.height / 4 + Screen.height / 2, boxWidth, boxHeight), toMenu, GUIStyle.none))
            {
                Application.LoadLevel(0);
            }
            
        }
        #endregion

        #region win

        if (Application.loadedLevel == 12)
        {
            GUI.Box(new Rect(Screen.width / 2 - 75, 50, 200, 300), "\nCongratulations! You won!\n\nFrightening Lightning  \n \n Created by \n Mikkel Thygesen \n Kristian Flejsborg \n Mikkel Munkholm \n\n\n A special thanks to \n\n GameIT College\n Teachers at GTS: \n\n© Frightening Games \n All rights reserved ");

            if (GUI.Button(new Rect(50, Screen.height / 4 + Screen.height / 2, boxWidth, boxHeight), toMenu, GUIStyle.none))
            {
                Application.LoadLevel(0);
            }
        }

        #endregion
    }
}
