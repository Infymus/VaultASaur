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
}
