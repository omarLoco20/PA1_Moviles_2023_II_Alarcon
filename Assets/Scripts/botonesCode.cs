using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class botonesCode : MonoBehaviour
{
    public codeBilletera cbilletera;

    //public GameObject panelOpciones;
    public ScriptableSelector p1;
    public ScriptableSelector p2;
    public ScriptableSelector p3;
    public ScriptableSelector pActual;
    //public GameObject pausePanel;
    //public GameObject listaScore;
    [SerializeField] string newScene;

    public Button btnPl2;
    public Button btnPl3;

    public Button buyPl2;
    public Button buyPl3;

    public GameObject pnlBlock2;
    public GameObject pnlBlock3;

    //string menu= "menu";
    //string game = "SampleScene";
    //string seleccionar = "seleccionPlayer";
    int precioPl2 = 3000;
    int precioPl3 = 1000;

    private void Start()
    {
        //SceneManager.LoadScene("splash", LoadSceneMode.Additive);

        if (SceneManager.GetActiveScene().name == "seleccionPlayer")
        {
            if (p2.comprado)
            {
                pnlBlock2.SetActive(false);
                buyPl2.interactable = false;
                btnPl2.interactable = true;
            }
            if (p3.comprado)
            {
                pnlBlock3.SetActive(false);
                buyPl3.interactable = false;
                btnPl3.interactable = true;
            }
        }
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject panel) 
    { 
        panel.SetActive(false);
    }
    public void Pause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void SelectPlayer(ScriptableSelector player) //bool bought)
    {
        pActual.life = player.life;
        pActual.force = player.force;
        pActual.character = player.character;
        pActual.cambiarFlip = player.cambiarFlip;
        //player.comprado = true;
        //pActual.comprado = bought;
    }
    //public void Bought(ScriptableSelector player)
    //{
    //    player.comprado = true;
    //}
    public void buyPlayer2()
    {
        if (pActual.coins >= precioPl2)
        {
            pnlBlock2.SetActive(false);
            pActual.coins = pActual.coins - precioPl2;
            cbilletera.actualizarMonedero();
            btnPl2.interactable = true;
            p2.comprado = true;
        }
    }

    public void buyPlayer3()
    {
        if (pActual.coins >= precioPl3)
        {
            pnlBlock3.SetActive(false);
            pActual.coins = pActual.coins - precioPl3;
            cbilletera.actualizarMonedero();
            btnPl3.interactable = true;
            p3.comprado = true;

        }
    }
    public void exit()
    {
        Application.Quit();
    }

    // Antes del refactory xd

    //public void abrirListaScore()
    //{
    //    listaScore.SetActive(true);
    //}
    //public void cerrarListaScore()
    //{
    //    listaScore.SetActive(false);

    //}
    //public void pauseGame()
    //{
    //    pausePanel.SetActive(true);
    //    Time.timeScale = 0;

    //}

    //public void closePause()
    //{
    //    pausePanel.SetActive(false);
    //    Time.timeScale = 1;
    //}

    

    //public void menuIr()
    //{
    //    SceneManager.LoadScene(menu);
    //}
    //public void GoPLay()
    //{
    //    SceneManager.LoadScene(game);
    //}

    //public void selectorCharacter()
    //{
    //    SceneManager.LoadScene(seleccionar);

    //}
   

    //public void options()
    //{
    //    panelOpciones.SetActive(true);
    //}
    //public void closeOptions()
    //{
    //    panelOpciones.SetActive(false);

    //}


    
    //public void selectP1()
    //{
    //    pActual.life = p1.life;
    //    pActual.force = p1.force;
    //    pActual.character = p1.character;
    //    // pActual.rotacion = p1.rotacion;
    //    pActual.cambiarFlip = p1.cambiarFlip;
    //}
    //public void selectP2()
    //{
    //    pActual.life = p2.life;
    //    pActual.force = p2.force;
    //    pActual.character = p2.character;
    //    //  pActual.rotacion = p2.rotacion;
    //    pActual.cambiarFlip = p2.cambiarFlip;
    //    p2.comprado = true;
    //}

    //public void selectP3()
    //{
    //    pActual.life = p3.life;
    //    pActual.force = p3.force;
    //    pActual.character = p3.character;
    //    // pActual.rotacion = p3.rotacion;
    //    pActual.cambiarFlip = p3.cambiarFlip;
    //    p3.comprado = true;
    //}

    // COMPRAR FUNCTIONS

   
}
