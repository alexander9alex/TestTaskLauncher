using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Clicker.UI
{
   public class ClickerMenuView : MonoBehaviour
   {
      [SerializeField] private TextMeshProUGUI _score;
      
      [SerializeField] private Button _addScore;
      [SerializeField] private Button _closeGame;

      public void Construct(ClickerMenuModel clickerMenuModel)
      {
         clickerMenuModel.ScoreChanged += ScoreChanged;
         _addScore.onClick.AddListener(clickerMenuModel.AddScore);
         _closeGame.onClick.AddListener(clickerMenuModel.CloseGame);
      }

      private void ScoreChanged(int score) =>
         _score.text = score.ToString();
   }
}