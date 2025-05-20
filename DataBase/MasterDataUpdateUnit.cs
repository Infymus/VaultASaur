using VaultASaur.Enums;
using VaultASaur.ErrorHandling;
using VaultASaur.Objects;
using VaultASaur.ToolsBox;

namespace VaultASaur.DataBase
{
    public static class MasterDataUpdateUnit
    {
        private static int File_Struct_Count = 1;
        private static int Start_DB_Version = 100;
        private static int Next_DB_Version = 101;
        private static string sqlStr = "";

        //
        public static tErrorResult UpdateTables()
        {
            tErrorResult t;

            #region Table Creation

            // ===========================================================================================
            // create the initial table_main - It contains the DBID or Database Version id.
            sqlStr = $@"CREATE TABLE IF NOT EXISTS {MasterData.GetTableName_Main} 
                (DBID INTEGER PRIMARY KEY);";
            t = MasterData.ExecuteSQL(sqlStr, null);
            int dbVersion = MasterData.GetDataBaseVersion();
            if (dbVersion < Start_DB_Version)
            {
                MasterData.StartDBVersion();
                MasterData.SetDBVersion(Start_DB_Version);
            }
            if (t.errorResult)
                return t;

            // ===========================================================================================
            // FILTER
            sqlStr = $@"CREATE TABLE IF NOT EXISTS {MasterData.GetTableName_Vault}  
                (ID INTEGER PRIMARY KEY AUTOINCREMENT,
                 SITENAME TEXT,
                 USERNAME TEXT,
                 PASSWORD TEXT,
                 PASSWORDHINT TEXT,
                 EMAIL TEXT,
                 QUESTION1 TEXT,
                 QUESTION2 TEXT,
                 QUESTION3 TEXT,
                 URL TEXT,
                 DESCRIPT TEXT,
                 EMAIL TEXT,
                 ISACTIVE INT);";
            t = MasterData.ExecuteSQL(sqlStr, null);
            if (t.errorResult)
                return t;

            // ===========================================================================================
            // PREFERENCES
            sqlStr = $@"CREATE TABLE IF NOT EXISTS {MasterData.GetTableName_Preference}
                (ID INTEGER PRIMARY KEY AUTOINCREMENT,
                PNAME TEXT,      
                ASSTR TEXT,      
                ASBOOL INT,  
                ASGUID TEXT,     
                ASMEMO BLOB,     
                ASINT INT,   
                ASCURR REAL);";
            t = MasterData.ExecuteSQL(sqlStr, null);
            if (t.errorResult)
                return t;
            #endregion

            // %%%%%%%%%%%%%%% UPDATES FROM HERE ON ONLY %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

            #region Updates to Tables Here On Only

            // UPDATE 101
            if (MasterData.CompareVersion(101))
            {
                // Add the default preferences


                //                public enum tPrefConstants
                //{
                //    // General Preferences
                //    RegionCode,
                //    dbGridColorGridLines,
                //    CheckForUpdates,
                //    EditorLoadSaveButtons,
                //    // Topics
                //    topicSortView,
                //    topicIsActive,
                //    DBTopicGridWidth,
                //    //
                //    TorrentApp,
                //    TorrentParam,
                //    PromptDownload,
                //    TorrentFilterAdd,
                //    FeedDBNavPanelVisible,
                //    KeepDay,
                //    TorrentSaveDirectory,
                //    TorrentSaveType,
                //    AskToQuit,
                //    LogFile,
                //    AllowDuplicateFeedTitles,
                //    FilterMatchDownloadOrQueue,
                //    StartMinimized,
                //    DeepLogging,
                //    StopOnRSSGetFailure,
                //    ReProcessRSSFeeds,
                //    RSSOptionTorrentOrMagnet,
                //    DownloadFeedQueueDelay,
                //    StripTorrentEnclosures
                //}

                // Preferences
                dbPreference.SetInt(tPrefConstants.KeepDay, 365);
                dbPreference.SetString(tPrefConstants.TorrentApp, "C:\\Program Files\\qBittorrent\\qbittorrent.exe");
                dbPreference.SetString(tPrefConstants.TorrentParam, "%T");
                dbPreference.SetString(tPrefConstants.TorrentSaveDirectory, "");

                //tTorrentRec tAddTor = dbTorrent.InitializeRecord();

                //tAddTor.Title = "Hell's Kitchen S12E10 1080P X265-Elite";
                //tAddTor.Enclosure = @$"magnet:<![CDATA[magnet:?xt=urn:btih:A5F763EB1A32BF1F37037B27497761EBFEAF9E0E&dn=Chicago+PD+S12E10+1080p+x265-ELiTE%5BEZTVx to%5D mkv&tr=udp%3A%2F%2Fglotorrents pw%3A6969%2Fannounce&tr=udp%3A%2F%2Ftracker coppersurfer tk%3A6969&tr=udp%3A%2F%2Ftracker opent";
                //tAddTor.IsActive = 1;
                //tAddTor.DLType = ToolBox.ConvertEnumToInt(tTorrentType.Magnet);
                //tAddTor.Link = @"YEEEEE";
                //tAddTor.EnclosureHash = @"TBD";
                //tAddTor.CID = tRet.AsLong;
                //tAddTor.FID = tFed.AsLong;
                ////tAddTor.FeedDate = 
                //dbTorrent.Add(tAddTor);
                //tAddTor.Title = "Hell's Kitchen S12E11 1080P X265-[eztv]";
                //tAddTor.Enclosure = @$"magnet:<![CDATA[magnet:?xt=urn:btih:A5F763EB1A32BF1F37037B27497761EBFEAF9E0E&dn=Chicago+PD+S12E10+1080p+x265-ELiTE%5BEZTVx to%5D mkv&tr=udp%3A%2F%2Fglotorrents pw%3A6969%2Fannounce&tr=udp%3A%2F%2Ftracker coppersurfer tk%3A6969&tr=udp%3A%2F%2Ftracker opent";
                //tAddTor.IsActive = 1;
                //tAddTor.DLType = ToolBox.ConvertEnumToInt(tTorrentType.Magnet);
                //tAddTor.Link = @"YEEEEE";
                //tAddTor.EnclosureHash = @"TBD";
                //tAddTor.CID = tRet.AsLong;
                //tAddTor.FID = tFed.AsLong;
                ////tAddTor.FeedDate = 
                //dbTorrent.Add(tAddTor);

            }




            #endregion

            // %%%%%%%%%%%%%%% NO MORE UPDATES AFTER THIS %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

            MasterData.SetDBVersion(Next_DB_Version);

            return new tErrorResult();
        }


    }
}






