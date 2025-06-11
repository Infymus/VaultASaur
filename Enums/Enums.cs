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

}
