using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Text NbLife;

    public void setMaxLife(int maxLife)
    {
        NbLife.text = maxLife.ToString();
    }
    public void setLife(int Life)
    {
        NbLife.text = Life.ToString();
    }
}
