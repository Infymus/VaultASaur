using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaultASaur.Enums
{
    public enum FormControls
    {
        FormPreferences,
        FormVault
    }

    public enum Regions
    {
        RegionUS = 0,
        RegionUK = 1,
        RegionCAN = 2
    }

    public enum ActiveStates
    {
        StateInactive = 0,
        StateActive = 1,
        StateAll = 3
    }

    public enum FormActions
    {
        ActionCancel,
        ActionSave,
        ActionConfirm,
        ActionOK
    }

    public enum CheckUpdateTypes
    {
        CheckUpdateNormal,
        CheckUpdateSilent,
        CheckUpdateFound,
        CheckUpdateError,
        CheckUpdateNone
    }

    public enum FeedStatusTypes
    {
        FeedReady = 0,
        FeedDownloaded = 1,
        FeedDuplicate = 2,
        FeedCorrupt = 3,
        FeedInactive = 4
    }

    public enum QueueStatusTypes
    {
        QueueOK = 0,
        QueueManual = 1,
        QueueFeed = 2,
        QueueDLError = 3
    }

    public enum GlobalRefreshTypes
    {
        FeedSites,
        TorrentFeeds,
        Categories,
        Filters,
        TimerStatus,
        History,
        Expressions,
        DownloadNow,
        Scrape
    }

    public enum IsActiveTypes
    {
        Inactive,
        Active
    }

    public enum ExpressionFilterTypes
    {
        None = 0,
        TVShow = 1,
        TVTalkShow = 2
    }

    public enum PercentTypes
    {
        On,
        Off
    }

    public enum TorrentSaveTypes
    {
        SaveToFile = 0,
        SaveToTorrent = 1
    }

    public enum FilterMatchDownloadOrQueueTypes
    {
        DownloadAutomatically = 0,
        DownloadToQueue = 1
    }

    public enum SiteDownloadOptionTypes
    {
        DLNow = 0,
        DLQueue = 1
    }

    public enum LogTypes
    {
        Normal,
        Deep
    }

    public enum EditFeedTypes
    {
        Feed = 1,
        Queue = 2
    }

    public enum URLFeedTypes
    {
        Magnet = 0,
        Torrent = 1
    }

    public enum HelpTopicTypes
    {
        HelpFeed = 1,
        HelpQueue = 2,
        HelpSite = 3,
        HelpFilter = 4,
        HelpHistory = 5,
        HelpPreferences = 6,
        HelpMain = 7,
        HelpStatus = 8,
        HelpExpressions = 9,
        HelpCategory = 10
    }

    public enum tPrefConstants
    {
        RegionCode,
        CheckForUpdates,
        SecondsToClose,
        EULA,
        FormWidth,
        FormHeight,
        FormLeft,
        FormTop,
        FormSize,
        Hint
    }

    public enum tTorrentType
    {
        Magnet = 0,
        Torrent = 1
    }


}
