namespace VaultASaur
{
    public class actionObject
    {
        public int actionType;
        public string Caption = "TBD";
        public int imageIndex = 1;
        public string name = "";
    }

    public static class Actions
    {
        // Delegate Commands
        public const int tCheckForUpdatesEvent = 1;
        public const int tEvent_AddToQueue = 2;
        public const int tEvent_DownloadHistoryEvent = 3;
        public const int tEvent_DownloadQueueEvent = 4;
        public const int tEvent_DownloadFeedEvent = 5;
        public const int tEvent_EditFeedSite = 6;
        public const int tEvent_FilterMatch_DownloadFeedEvent = 7;
        public const int tEvent_NewFilterEvent = 8;
        public const int tEvent_PercentEvent = 9;
        public const int tEvent_PrefChange = 10;
        public const int tEvent_SiteTimerFeedEvent = 11;
        public const int tEvent_WelcomeEvent = 12;
        public const int tGlobal_Refresh_Event = 13;
        public const int tPrefChange = 14;
        public const int tQueue_DownloadFeedEvent = 15;
        public const int tEvent_LoggingEvent = 16;


        // Commands
        public const int CMD_CANCEL = 1;
        public const int CMD_CLEAR = 2;
        public const int CMD_CLOSE = 3;
        public const int CMD_CONFIG = 4;
        public const int CMD_CONTINUE = 5;
        public const int CMD_DELETE = 6;
        public const int CMD_EDIT = 7;
        public const int CMD_EMAIL = 8;
        public const int CMD_FILE = 9;
        public const int CMD_FIND_KEY = 10;
        public const int CMD_FIRST = 11;
        public const int CMD_GENERATE = 12;
        public const int CMD_HELP = 13;
        public const int CMD_HOME = 14;
        public const int CMD_LAST = 15;
        public const int CMD_LIST = 16;
        public const int CMD_LOAD = 17;
        public const int CMD_LOADFROMFILE = 18;
        public const int CMD_MAIN_BLOCKS = 19;
        public const int CMD_MAIN_BROWSE = 20;
        public const int CMD_MAIN_CHECKUPDATES = 21;
        public const int CMD_MAIN_CODES = 22;
        public const int CMD_MAIN_CONTACTUS = 23;
        public const int CMD_MAIN_DATABASE = 24;
        public const int CMD_MAIN_FORUMS = 25;
        public const int CMD_MAIN_FTP = 26;
        public const int CMD_MAIN_HELP = 27;
        public const int CMD_MAIN_NEWS = 28;
        public const int CMD_MAIN_PAGES = 29;
        public const int CMD_MAIN_PUBLISH = 30;
        public const int CMD_MAIN_REGISTER = 31;
        public const int CMD_NEW = 32;
        public const int CMD_NEXT = 33;
        public const int CMD_NO = 34;
        public const int CMD_OK = 35;
        public const int CMD_PREF = 36;
        public const int CMD_PREV = 37;
        public const int CMD_PRIMARY = 38;
        public const int CMD_PRINT = 39;
        public const int CMD_PRINT_LIST = 40;
        public const int CMD_PRINT_PREVIEW = 41;
        public const int CMD_PRINT_PRINT = 42;
        public const int CMD_PRINT_SETUP = 43;
        public const int CMD_REGISTER = 44;
        public const int CMD_REPORT = 45;
        public const int CMD_SAVE = 46;
        public const int CMD_SAVETOFILE = 47;
        public const int CMD_SEARCH = 48;
        public const int CMD_SEARCH_ALL = 49;
        public const int CMD_SECONDARY = 50;
        public const int CMD_SELECT = 51;
        public const int CMD_SELECT_CANCEL = 52;
        public const int CMD_SELECT_OK = 53;
        public const int CMD_VIEWUPDATES = 54;
        public const int CMD_WELCOME_FB = 55;
        public const int CMD_WRITE = 56;
        public const int CMD_YES = 57;
        public const int CMD_MAIN_FILES = 58;
        public const int CMD_MAIN_HOME = 59;
        public const int CMD_PUBLISH = 60;
        public const int CMD_BROWSE = 61;
        public const int CMD_RENAME = 62;
        public const int CMD_ISACTIVE = 63;
        public const int CMD_FTP = 64;
        public const int CMD_MAIN_LAYOUT = 65;
        public const int CMD_MAIN_BLOG = 66;
        public const int CMD_MOVE_UP = 67;
        public const int CMD_MOVE_DOWN = 68;
        public const int CMD_MOVE = 69;
        public const int CMD_FILTER = 70;
        public const int CMD_REPEAT = 71;
        public const int CMD_CLONE = 72;
        public const int CMD_FILTERS = 73;
        public const int CMD_SITES = 74;
        public const int CMD_FEEDS = 75;
        public const int CMD_HISTORY = 76;
        public const int CMD_SETTINGS = 77;
        public const int CMD_STATUS = 78;
        public const int CMD_VIEW = 79;
        public const int CMD_GET = 80;
        public const int CMD_FEED_RUNNOW = 81;
        public const int CMD_STOP_TIMER = 82;
        public const int CMD_START_TIMER = 83;
        public const int CMD_FEED_RUN_ALL = 84;
        public const int CMD_OPEN_IN_BROWSER = 85;
        public const int CMD_DOWNLOAD_NOW = 86;
        public const int CMD_CREATE_FILTER = 87;
        public const int CMD_QUEUE = 88;
        public const int CMD_LOAD_HISTORY = 89;
        public const int CMD_DOWNLOAD_QUEUE = 90;
        public const int CMD_RUN_MANUAL = 91;
        public const int CMD_TEST_EXPRESSION = 92;
        public const int CMD_TOOLBOX = 93;
        public const int CMD_DOWNLOAD_ALL_NOW = 94;
        public const int CMD_STOP = 95;
        public const int CMD_LOGGING = 96;
        public const int CMD_DELETE_ALL = 97;
        public const int CMD_SAVE_TO_FEED_ALL = 98;
        public const int CMD_TORRENT_WEBSITE_SCRAPE = 99;
        public const int CMD_SAVE_TO_FEED = 100;
        public const int CMD_RENAMER = 101;
        public const int CMD_CLIPBOARD_ENCLOSURE = 102;
        public const int CMD_CLIPBOARD_TITLE = 103;
        public const int CMD_PREF_SAVE = 104;
        public const int CMD_ACTIVITY = 105;
        public const int CMD_URL = 106;

        // Images
        public const int IMG_ADD = 0;
        public const int IMG_ADD_BUTTON = 1;
        public const int IMG_BACKORDER = 2;
        public const int IMG_BOLD = 3;
        public const int IMG_BROUCHURE3 = 4;
        public const int IMG_CAMPAIGN = 5;
        public const int IMG_CANCEL = 6;
        public const int IMG_CANCEL3 = 7;
        public const int IMG_CHECKMARKMARK = 8;
        public const int IMG_CLEAR_SEARCH = 9;
        public const int IMG_CLOSE2 = 10;
        public const int IMG_CLOSE4 = 11;
        public const int IMG_CLOSE5 = 12;
        public const int IMG_CLOSE6 = 13;
        public const int IMG_CLOSEBUTTON2 = 14;
        public const int IMG_CLOSEFORM = 15;
        public const int IMG_COMPANY = 16;
        public const int IMG_CONFIGURE = 17;
        public const int IMG_CONFIGURE2 = 18;
        public const int IMG_CUSTOMER = 19;
        public const int IMG_CUSTOMER2 = 20;
        public const int IMG_CUSTOMER5 = 21;
        public const int IMG_CUSTOMER6 = 22;
        public const int IMG_DELETE = 23;
        public const int IMG_DISABLE2 = 24;
        public const int IMG_DISABLED = 25;
        public const int IMG_DOWN_ARROW_BLUE = 26;
        public const int IMG_DOWN_ARROW_RED = 27;
        public const int IMG_DOWNLOAD_GREEN = 28;
        public const int IMG_EARNINGS = 29;
        public const int IMG_EDIT = 30;
        public const int IMG_EMAIL_LIST = 31;
        public const int IMG_EMAIL_SEND = 32;
        public const int IMG_EMAIL2 = 33;
        public const int IMG_EXIT3 = 34;
        public const int IMG_EXPENSES2 = 35;
        public const int IMG_FB = 36;
        public const int IMG_FEES = 37;
        public const int IMG_FILE_LOAD = 38;
        public const int IMG_FILE_LOAD2 = 39;
        public const int IMG_FILTER1 = 40;
        public const int IMG_FILTERIMAGE = 41;
        public const int IMG_FINALIZEORDER = 42;
        public const int IMG_FONT = 43;
        public const int IMG_FORUMS = 44;
        public const int IMG_FORUMS2 = 45;
        public const int IMG_FTP = 46;
        public const int IMG_GREEN_CHECK = 47;
        public const int IMG_HELP = 48;
        public const int IMG_HELP_WOMAN = 49;
        public const int IMG_HELP4 = 50;
        public const int IMG_HELP5 = 51;
        public const int IMG_HOME = 52;
        public const int IMG_HTML = 53;
        public const int IMG_INFO = 54;
        public const int IMG_INVOICE = 55;
        public const int IMG_ITALIC = 56;
        public const int IMG_LABELS = 57;
        public const int IMG_MONEY_COINS = 58;
        public const int IMG_MOVE_DOWN = 59;
        public const int IMG_MOVE_LEFT = 60;
        public const int IMG_MOVE_RIGHT = 61;
        public const int IMG_MOVE_UP = 62;
        public const int IMG_NAV_FIRST = 63;
        public const int IMG_NAV_LAST = 64;
        public const int IMG_NAV_NEXT = 65;
        public const int IMG_NAV_PRIOR = 66;
        public const int IMG_NEW_BUTTON = 67;
        public const int IMG_NEW_CUSTOMER2 = 68;
        public const int IMG_NO2 = 69;
        public const int IMG_OK2 = 70;
        public const int IMG_ORDER = 71;
        public const int IMG_PBORETURN = 72;
        public const int IMG_PRIMARY = 73;
        public const int IMG_PRINT = 74;
        public const int IMG_PRODUCT3 = 75;
        public const int IMG_RED_ARROW_LEFT = 76;
        public const int IMG_RED_ARROW_RIGHT = 77;
        public const int IMG_RED_DOTTED_ARROW_DOWN = 78;
        public const int IMG_REFRESH = 79;
        public const int IMG_REPORTS = 80;
        public const int IMG_REPORTS2 = 81;
        public const int IMG_REPORTS3 = 82;
        public const int IMG_RETURNS = 83;
        public const int IMG_RSS = 84;
        public const int IMG_RSSSMALL = 85;
        public const int IMG_SALE = 86;
        public const int IMG_SALE3 = 87;
        public const int IMG_SAVE = 88;
        public const int IMG_SAVE2 = 89;
        public const int IMG_SEARCH = 90;
        public const int IMG_SECONDARY = 91;
        public const int IMG_SETTINGS = 92;
        public const int IMG_SETTINGS2 = 93;
        public const int IMG_SHIPPING = 94;
        public const int IMG_SHOPPING = 95;
        public const int IMG_TAKEPAYMENT = 96;
        public const int IMG_TAXES = 97;
        public const int IMG_TIMER = 98;
        public const int IMG_TOOLS = 99;
        public const int IMG_TRANSMIT_FILE = 100;
        public const int IMG_TRASHCAN2 = 101;
        public const int IMG_UNDERLINE = 102;
        public const int IMG_UNLOCK2 = 103;
        public const int IMG_UPDATES = 104;
        public const int IMG_UPDATES2 = 105;
        public const int IMG_VOID = 106;
        public const int IMG_WIPE = 107;
        public const int IMG_WORLD = 108;
        public const int IMG_YES2 = 109;

        public static actionObject AddNewAction(int inActionType)
        {
            actionObject a = new actionObject();
            a.actionType = inActionType;
            switch (inActionType)
            {
                case CMD_ACTIVITY:
                    a.Caption = "Activity";
                    a.imageIndex = IMG_CHECKMARKMARK;
                    a.name = "actActivity";
                    break;
                case CMD_URL:
                    a.Caption = "URL";
                    a.imageIndex = IMG_BACKORDER;
                    a.name = "actUrl";
                    break;
                case CMD_HELP:
                    a.Caption = "Help";
                    a.imageIndex = IMG_HELP5;
                    a.name = "actHelp";
                    break;
                case CMD_TOOLBOX:
                    a.Caption = "Toolbox";
                    a.imageIndex = IMG_TOOLS;
                    a.name = "actToolBox";
                    break;
                case CMD_RUN_MANUAL:
                    a.Caption = "Manual RSS";
                    a.imageIndex = IMG_RSSSMALL;
                    a.name = "actRunManual";
                    break;
                case CMD_OPEN_IN_BROWSER:
                    a.Caption = "Open Web";
                    a.imageIndex = IMG_WORLD;
                    a.name = "actOpenWeb";
                    break;
                case CMD_VIEW:
                    a.Caption = "View";
                    a.imageIndex = IMG_CLEAR_SEARCH;
                    a.name = "actView";
                    break;
                case CMD_CREATE_FILTER:
                    a.Caption = "Filter";
                    a.imageIndex = IMG_FILTERIMAGE;
                    a.name = "actFilter";
                    break;
                case CMD_DOWNLOAD_QUEUE:
                    a.Caption = "DL Queue";
                    a.imageIndex = IMG_DOWN_ARROW_BLUE;
                    a.name = "actDownloadQueue";
                    break;
                case CMD_DOWNLOAD_NOW:
                    a.Caption = "DL Now";
                    a.imageIndex = IMG_DOWN_ARROW_RED;
                    a.name = "actDownloadNow";
                    break;
                case CMD_FEED_RUN_ALL:
                    a.Caption = "Run All";
                    a.imageIndex = IMG_UPDATES2;
                    a.name = "actFeedRunAll";
                    break;
                case CMD_SAVE:
                    a.Caption = "Save";
                    a.imageIndex = IMG_SAVE;
                    a.name = "actSave";
                    break;
                case CMD_CANCEL:
                    a.Caption = "Cancel";
                    a.imageIndex = IMG_CANCEL;
                    a.name = "actCancel";
                    break;
                case CMD_DELETE:
                    a.Caption = "Delete";
                    a.imageIndex = IMG_TRASHCAN2;
                    a.name = "actDelete";
                    break;
                case CMD_DELETE_ALL:
                    a.Caption = "Delete All";
                    a.imageIndex = IMG_TRASHCAN2;
                    a.name = "actDeleteAll";
                    break;
                case CMD_NEW:
                    a.Caption = "New";
                    a.imageIndex = IMG_NEW_BUTTON;
                    a.name = "actNew";
                    break;
                case CMD_LIST:
                    a.Caption = "List";
                    a.imageIndex = IMG_INFO;
                    a.name = "actList";
                    break;
                case CMD_SEARCH:
                    a.Caption = "Search";
                    a.imageIndex = IMG_INFO;
                    a.name = "actSearch";
                    break;
                case CMD_SEARCH_ALL:
                    a.Caption = "Search All";
                    a.imageIndex = IMG_INFO;
                    a.name = "actSearchAll";
                    break;
                case CMD_OK:
                    a.Caption = "";
                    a.imageIndex = IMG_OK2;
                    a.name = "actOk";
                    break;
                case CMD_EDIT:
                    a.Caption = "Edit";
                    a.imageIndex = IMG_EDIT;
                    a.name = "actEdit";
                    break;
                case CMD_LOAD:
                    a.Caption = "Load";
                    a.imageIndex = IMG_EDIT;
                    a.name = "actLoad";
                    break;
                case CMD_FIRST:
                    a.Caption = "First";
                    a.imageIndex = IMG_INFO;
                    a.name = "actFirst";
                    break;
                case CMD_PREV:
                    a.Caption = "Prev";
                    a.imageIndex = IMG_INFO;
                    a.name = "actPrev";
                    break;
                case CMD_NEXT:
                    a.Caption = "Next";
                    a.imageIndex = IMG_NAV_NEXT;
                    a.name = "actNext";
                    break;
                case CMD_LAST:
                    a.Caption = "Last";
                    a.imageIndex = IMG_INFO;
                    a.name = "actLast";
                    break;
                case CMD_LOADFROMFILE:
                    a.Caption = "Load From File";
                    a.imageIndex = IMG_INFO;
                    a.name = "actLoadFromFile";
                    break;
                case CMD_WRITE:
                    a.Caption = "Write";
                    a.imageIndex = IMG_INFO;
                    a.name = "actWrite";
                    break;
                case CMD_CLOSE:
                    a.Caption = "Close";
                    a.imageIndex = IMG_CLOSEFORM;
                    a.name = "actClose";
                    break;
                case CMD_SAVETOFILE:
                    a.Caption = "Save To File";
                    a.imageIndex = IMG_INFO;
                    a.name = "actSaveToFile";
                    break;
                case CMD_FILE:
                    a.Caption = "File";
                    a.imageIndex = IMG_INFO;
                    a.name = "actFile";
                    break;
                case CMD_PRIMARY:
                    a.Caption = "Primary";
                    a.imageIndex = IMG_INFO;
                    a.name = "actPrimary";
                    break;
                case CMD_SECONDARY:
                    a.Caption = "Secondary";
                    a.imageIndex = IMG_INFO;
                    a.name = "actSecondary";
                    break;
                case CMD_CONFIG:
                    a.Caption = "Config";
                    a.imageIndex = IMG_INFO;
                    a.name = "actConfig";
                    break;
                case CMD_SELECT_OK:
                    a.Caption = "Select";
                    a.imageIndex = IMG_CHECKMARKMARK;
                    a.name = "actSelectOK";
                    break;
                case CMD_SELECT_CANCEL:
                    a.Caption = "Cancel";
                    a.imageIndex = IMG_CANCEL;
                    a.name = "actSelectCancel";
                    break;
                case CMD_SELECT:
                    a.Caption = "Select";
                    a.imageIndex = IMG_INFO;
                    a.name = "actSelect";
                    break;
                case CMD_EMAIL:
                    a.Caption = "Email";
                    a.imageIndex = IMG_EMAIL2;
                    a.name = "actEmail";
                    break;
                case CMD_REPORT:
                    a.Caption = "Report";
                    a.imageIndex = IMG_INFO;
                    a.name = "actReport";
                    break;
                case CMD_GENERATE:
                    a.Caption = "Generate";
                    a.imageIndex = IMG_INFO;
                    a.name = "actGenerate";
                    break;
                case CMD_PRINT:
                    a.Caption = "Print";
                    a.imageIndex = IMG_PRINT;
                    a.name = "actPrint";
                    break;
                case CMD_YES:
                    a.Caption = "";
                    a.imageIndex = IMG_YES2;
                    a.name = "actYes";
                    break;
                case CMD_NO:
                    a.Caption = "";
                    a.imageIndex = IMG_NO2;
                    a.name = "actNo";
                    break;
                case CMD_CLEAR:
                    a.Caption = "Clear";
                    a.imageIndex = IMG_INFO;
                    a.name = "actClear";
                    break;
                case CMD_PRINT_SETUP:
                    a.Caption = "Setup Printer";
                    a.imageIndex = IMG_TOOLS;
                    a.name = "actPrintSetup";
                    break;
                case CMD_PRINT_PREVIEW:
                    a.Caption = "Preview Report";
                    a.imageIndex = IMG_SEARCH;
                    a.name = "actPrintPreview";
                    break;
                case CMD_PRINT_PRINT:
                    a.Caption = "Print Report";
                    a.imageIndex = IMG_PRINT;
                    a.name = "actPrintPrint";
                    break;
                case CMD_PRINT_LIST:
                    a.Caption = "Print List";
                    a.imageIndex = IMG_PRINT;
                    a.name = "actPrintList";
                    break;
                case CMD_FIND_KEY:
                    a.Caption = "Find Key";
                    a.imageIndex = IMG_UNLOCK2;
                    a.name = "actFindKey";
                    break;
                case CMD_REGISTER:
                    a.Caption = "Register";
                    a.imageIndex = IMG_INFO;
                    a.name = "actRegister";
                    break;
                case CMD_CONTINUE:
                    a.Caption = "Continue";
                    a.imageIndex = IMG_NAV_LAST;
                    a.name = "actContinue";
                    break;
                case CMD_PUBLISH:
                    a.Caption = "Publish";
                    a.imageIndex = IMG_PRINT;
                    a.name = "actPublish";
                    break;
                case CMD_BROWSE:
                    a.Caption = "Browse";
                    a.imageIndex = IMG_WORLD;
                    a.name = "actBrowse";
                    break;
                case CMD_RENAME:
                    a.Caption = "Rename";
                    a.imageIndex = IMG_REFRESH;
                    a.name = "actRename";
                    break;
                case CMD_ISACTIVE:
                    a.Caption = "IsActive";
                    a.imageIndex = IMG_CHECKMARKMARK;
                    a.name = "actIsActive";
                    break;
                case CMD_FTP:
                    a.Caption = "FTP";
                    a.imageIndex = IMG_FTP;
                    a.name = "actFTP";
                    break;
                case CMD_MOVE_UP:
                    a.Caption = "Move Up";
                    a.imageIndex = IMG_INFO;
                    a.name = "actMoveUp";
                    break;
                case CMD_MOVE_DOWN:
                    a.Caption = "Move Down";
                    a.imageIndex = IMG_INFO;
                    a.name = "actMoveDown";
                    break;
                case CMD_MOVE:
                    a.Caption = "Move";
                    a.imageIndex = IMG_INFO;
                    a.name = "actMove";
                    break;
                case CMD_FILTER:
                    a.Caption = "Filter";
                    a.imageIndex = IMG_INFO;
                    a.name = "actFilter";
                    break;
                case CMD_REPEAT:
                    a.Caption = "Repeat";
                    a.imageIndex = IMG_INFO;
                    a.name = "actRepeat";
                    break;
                case CMD_CLONE:
                    a.Caption = "Clone";
                    a.imageIndex = IMG_INFO;
                    a.name = "actClone";
                    break;
                case CMD_GET:
                    a.Caption = "Get";
                    a.imageIndex = IMG_INFO;
                    a.name = "actGet";
                    break;
                case CMD_FEED_RUNNOW:
                    a.Caption = "Run";
                    a.imageIndex = IMG_NAV_NEXT;
                    a.name = "actRunNow";
                    break;
                case CMD_STOP_TIMER:
                    a.Caption = "Stop";
                    a.imageIndex = IMG_CANCEL;
                    a.name = "actStopTimer";
                    break;
                case CMD_START_TIMER:
                    a.Caption = "Start";
                    a.imageIndex = IMG_CHECKMARKMARK;
                    a.name = "actStartTimer";
                    break;
                case CMD_DOWNLOAD_ALL_NOW:
                    a.Caption = "DL All";
                    a.imageIndex = IMG_DOWN_ARROW_RED;
                    a.name = "ActDownloadAllNow";
                    break;
                case CMD_LOAD_HISTORY:
                    a.Caption = "Add Hist";
                    a.imageIndex = IMG_COMPANY;
                    a.name = "actLoadHistory";
                    break;
                case CMD_TEST_EXPRESSION:
                    a.Caption = "Test";
                    a.imageIndex = IMG_CHECKMARKMARK;
                    a.name = "actTestExp";
                    break;
                case CMD_STOP:
                    a.Caption = "Stop";
                    a.imageIndex = IMG_CANCEL;
                    a.name = "actStop";
                    break;
                case CMD_TORRENT_WEBSITE_SCRAPE:
                    a.Caption = "Web Scraper";
                    a.imageIndex = IMG_FONT;
                    a.name = "ActScraper";
                    break;
                case CMD_SAVE_TO_FEED_ALL:
                    a.Caption = "Save ALL";
                    a.imageIndex = IMG_DOWN_ARROW_BLUE;
                    a.name = "actSaveToFeedAll";
                    break;
                case CMD_SAVE_TO_FEED:
                    a.Caption = "Save";
                    a.imageIndex = IMG_DOWN_ARROW_BLUE;
                    a.name = "actSaveToFeed";
                    break;
                case CMD_CLIPBOARD_ENCLOSURE:
                    a.Caption = "Clipboard - Enclosure";
                    a.imageIndex = IMG_CONFIGURE;
                    a.name = "actClipboardEnclosure";
                    break;
                case CMD_CLIPBOARD_TITLE:
                    a.Caption = "Clipboard - Title";
                    a.imageIndex = IMG_CONFIGURE;
                    a.name = "actClipboardTitle";
                    break;
                case CMD_PREF_SAVE:
                    a.Caption = "Save";
                    a.imageIndex = IMG_SAVE;
                    a.name = "actPrefSave";
                    break;
            }
            return a;
        }
    }
}
