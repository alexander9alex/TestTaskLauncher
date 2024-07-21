using CodeBase.Clicker.StaticData;
using CodeBase.Clicker.UI;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Clicker.Infrastructure
{
   class ClickerUiFactory : IClickerUiFactory
   {
      private MenuData _menuData;
      public ClickerUiFactory(IStaticData staticData)
      {
         _menuData = staticData.GetClickerMenuData();
      }

      public void CreateClickerMenu()
      {
         ClickerMenuView clickerMenuView = Object.Instantiate(_menuData.ClickerMenu).GetComponent<ClickerMenuView>();
         
         ClickerMenuModel clickerMenuModel = new ClickerMenuModel();
         clickerMenuView.Construct(clickerMenuModel);
      }
   }
}