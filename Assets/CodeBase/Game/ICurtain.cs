using System;

namespace CodeBase.Game
{
   public interface ICurtain
   {
      void Show(Action onEnded = null);
      void Hide(Action onHided = null);
   }
}