using MPsteam.Configuration;
namespace MPsteam.Steam
{
   public class SteamFacade
   {
      public SteamFacade(ConfigurationVM configurationVM)
      {
         _steamStarter = new SteamStarter(configurationVM);
      }

      /// <summary>
      /// Starts steam
      /// </summary>
      public void Start()
      {
         _steamStarter.Start();
      }

      /// <summary>
      /// Sets window focus to steam
      /// </summary>
      public void SetFocus()
      {
         _steamStarter.SetFocus();
      }

      private readonly ISteamStarter _steamStarter;
   }
}

