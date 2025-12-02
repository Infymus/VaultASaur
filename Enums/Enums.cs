/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

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
