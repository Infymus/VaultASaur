/*
 * Author: Infymus
 * Description: VaultASaur
 * Copyright (c) 2025, Infymus. All rights reserved.
 * Website: https://github.com/Infymus/vaultasaur
*/

namespace VaultASaur3.Objects
{
   public class tVaultRec
   {
      public long ID { get; set; }
      public int IsActive { get; set; }
      public string SITENAME { get; set; }
      public string USERNAME { get; set; }
      public string PASSWORD { get; set; }
      public string EMAIL { get; set; }
      public string SITEURL { get; set; }
      public string SECQUEST1 { get; set; }
      public string SECQUEST2 { get; set; }
      public string SECQUEST3 { get; set; }
      public string SECQUEST4 { get; set; }
      public string PASSHINT { get; set; }

      public string SITEDESC { get; set; }

      public tVaultRec()
      {
         ID = 0;
         IsActive = 1;
         SITENAME = "";
         USERNAME = "";
         PASSWORD = "";
         EMAIL = "";
         SITEURL = "";
         SECQUEST1 = "";
         SECQUEST2 = "";
         SECQUEST3 = "";
         SECQUEST4 = "";
         PASSHINT = "";
         SITEDESC = "";
      }
   }


   public class tJsonVaultRec
   {
      [System.Text.Json.Serialization.JsonPropertyName("ID")]
      public string JsonID { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("SiteName")]
      public string SiteName { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("Username")]
      public string Username { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("Password")]
      public string Password { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("PasswordHint")]
      public string PasswordHint { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("Email")]
      public string Email { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("Question1")]
      public string Question1 { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("Question2")]
      public string Question2 { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("Question3")]
      public string Question3 { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("URL")]
      public string URL { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("Description")]
      public string Description { get; set; } = string.Empty;

      [System.Text.Json.Serialization.JsonPropertyName("Active")]
      public bool Active { get; set; }
   }

}
