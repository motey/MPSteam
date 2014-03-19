namespace MPsteam.Configuration
{
   public interface IConfigurationAccessor
   {
      ConfigurationModel Model { get; }
      void Load();
      void Save(ConfigurationModel model);
   }
}
