using UnityEngine;


public class MenuScript : MonoBehaviour
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
        "Nouvelle Partie"
      )
    )
    {
     
      Application.LoadLevel("Scene1");
    }
  }
}