using UnityEngine;


public class GameOver : MonoBehaviour
{
    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 40;


        if (
          GUI.Button(

            new Rect(
              (1 * Screen.width / 3) - (buttonWidth / 2),
              (3 * Screen.height / 4) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Recommencer"
          )
        )
        {

            Application.LoadLevel("Scene1");
        }

        if (
          GUI.Button(

            new Rect(
              (2 * Screen.width / 3) - (buttonWidth / 2),
              (3 * Screen.height / 4) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Menu"
          )
        )
        {

            Application.LoadLevel("MenuScene");
        }
    }
}