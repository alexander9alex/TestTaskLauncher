using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Runner.Game.UI
{
   internal class ResultMenuView : MonoBehaviour
   {
      [SerializeField] private TextMeshProUGUI _scoreText;
      [SerializeField] private TextMeshProUGUI _recordText;
      [SerializeField] private Button _restartButton;
      [SerializeField] private Button _endGameButton;
      public void Construct(ResultMenuModel resultMenuModel)
      {
         SetScore(resultMenuModel.Score);
         SetRecord(resultMenuModel.Record);
         
         _restartButton.onClick.AddListener(resultMenuModel.RestartGame);
         _endGameButton.onClick.AddListener(resultMenuModel.EndGame);
      }

      private void SetScore(string score) =>
         _scoreText.text = score;

      private void SetRecord(string record) =>
         _recordText.text = record;
   }
}