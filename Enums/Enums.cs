namespace VaultASaur3.Enums
{
   public enum dbTypes
   {
      Category,
      Expression,
      Feed,
      Filter,
      History,
      Preference,
      Queue,
      SiteStatus,
      Vault
   }

   public enum FormResult
   {
      Ok,
      Cancel
   }

   public enum FormControls
   {
      FormPreferences,
      FormVault
   }

   public enum tPrefConstants
   {
      RegionCode,
      dbGridColorGridLines,
      CheckForUpdates,
      EditorLoadSaveButtons,
      AutoClose,
      Hint,
      GuidPassword
   }

   public enum ActiveStates
   {
      StateInactive = 0,
      StateActive = 1,
      StateAll = 3
   }

}
