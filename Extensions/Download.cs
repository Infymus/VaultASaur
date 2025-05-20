using System;
using System.Diagnostics;
using VaultASaur.DataBase;
using VaultASaur.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VaultASaur.Extensions.tDialogBox;
using System.Xml.Linq;
using TaskDialogIcon = Ookii.Dialogs.WinForms.TaskDialogIcon;
using System;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml;
using VaultASaur.Enums;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using File = System.IO.File;
using String = System.String;
using VaultASaur.ToolsBox;
using System.Security.Policy;

namespace VaultASaur.Extensions
{
    public static class tDownload
    {

        /// <summary>
        /// I would use the XMlDocument, but XML tags coming in from torrents do NOT follow the rules.
        /// So I had to write my own. It's shit but it works.
        /// </summary>
        /// <param name="inXML"></param>
        /// <returns></returns>
        public static List<string> FindXMLItems(string inXML)
        {
            var result = new List<string>();
            string origXML = inXML; // original unmodified string
            string workXML = inXML.ToUpperInvariant(); // uppercase version for searching
            string codeToFind = "ITEM";
            bool globalDone = false;

            while (!globalDone)
            {
                string foundCode = string.Empty;
                int x = workXML.IndexOf("<" + codeToFind, StringComparison.Ordinal);

                if (x >= 0)
                {
                    // Trim everything before the current <ITEM>
                    if (x > 0)
                    {
                        workXML = workXML.Substring(x);
                        origXML = origXML.Substring(x);
                    }

                    int y = workXML.IndexOf("</" + codeToFind + ">", StringComparison.Ordinal);
                    if (y >= 0)
                    {
                        // Extract from original string using the original case
                        int lengthToExtract = y + codeToFind.Length + 3;
                        foundCode = origXML.Substring(0, lengthToExtract);

                        // Remove the found segment from both strings
                        workXML = workXML.Substring(lengthToExtract);
                        origXML = origXML.Substring(lengthToExtract);
                    }
                    else
                    {
                        // No matching end tag
                        globalDone = true;
                    }
                }
                else
                {
                    // No starting <ITEM> found
                    globalDone = true;
                }

                if (!string.IsNullOrEmpty(foundCode))
                {
                    result.Add(foundCode);
                }
            }

            return result;
        }

        public static string FindXMLTags(string inXML, string inCode, string subCode)
        {
            string result = string.Empty;
            string origXML = inXML;
            string workXML = inXML.ToUpperInvariant();
            string codeToFind = inCode.ToUpperInvariant();
            string subCodeToFind = subCode.ToUpperInvariant();

            int x = workXML.IndexOf("<" + codeToFind, StringComparison.Ordinal);
            if (x >= 0)
            {
                int tagStart = x;

                // Check for self-closing tag
                int closeTagCheck = workXML.IndexOf("/>", tagStart, StringComparison.Ordinal);
                int tagEnd = workXML.IndexOf(">", tagStart, StringComparison.Ordinal);

                if (tagEnd >= 0)
                {
                    // Handle self-closing
                    if (closeTagCheck != -1 && closeTagCheck < tagEnd)
                    {
                        // Extract full tag text
                        string fullTag = origXML.Substring(tagStart, closeTagCheck + 2 - tagStart);

                        // Now extract the attribute value
                        string attrKey = subCode + "=\""; // e.g., url="
                        int attrStart = fullTag.IndexOf(attrKey, StringComparison.OrdinalIgnoreCase);
                        if (attrStart >= 0)
                        {
                            attrStart += attrKey.Length;
                            int attrEnd = fullTag.IndexOf("\"", attrStart);
                            if (attrEnd > attrStart)
                            {
                                result = fullTag.Substring(attrStart, attrEnd - attrStart);
                            }
                        }

                        return result;
                    }

                    // Handle open/close pair tags
                    int offset = tagEnd + 1;
                    workXML = workXML.Substring(offset);
                    origXML = origXML.Substring(offset);

                    int y = workXML.IndexOf("</" + codeToFind + ">", StringComparison.Ordinal);
                    if (y >= 0)
                    {
                        result = origXML.Substring(0, y);
                    }
                }
            }

            return result;
        }

        public static string CleanTorrentTitle(string inTitle)
        {
            if (string.IsNullOrWhiteSpace(inTitle))
                return string.Empty;

            // Define disallowed characters
            var disallowedChars = new HashSet<char> { '/', '\\', ':', '*', '?', '"', '|', '#', '%', '+' };

            // Filter characters based on rules
            var filtered = inTitle
                .Where(c => !disallowedChars.Contains(c) && c >= 32 && c <= 122)
                .ToArray();

            // Join, trim, and collapse multiple spaces
            var cleaned = new string(filtered);
            cleaned = Regex.Replace(cleaned.Trim(), @"\s{2,}", " ");

            return cleaned;
        }

        public static void DownloadLocalFile(string inFileName, long inFeedID)
        {
            bool didError = false;
            long tFID = inFeedID;
            string fXml;
            long tCID = dbFeed.GetFeedCategoryIDByFeedID(tFID);
            string rawXml = File.ReadAllText(inFileName);

            fXml = Regex.Replace(rawXml, @"&(?!amp;)", "&amp;");
            fXml = fXml.Replace("<![CDATA[", "").Replace("]]>", ">");

            List<string> xmlList = FindXMLItems(fXml);
            if (xmlList.Count == 0)
            {
                Dialog_Box("Error", "RSS Parse Error", "No ITEM tags found.", new[] { DialogButton.OK }, TaskDialogIcon.Error);
                return;
            }

            foreach (var node in xmlList)
            {
                tVaultRec t = dbVault.InitializeRecord();

                // Get the Title
                t.Title = FindXMLTags(node, "title", "");
                if (t.Title == "")
                    t.Title = FindXMLTags(node, "torrent:title", "");
                t.Title = ToolBox.ProperCase(t.Title, true);
                t.Title = CleanTorrentTitle(t.Title);
                // Get the Enclosure

                t.Enclosure = FindXMLTags(node, "torrent:magnetURI", "url=?");
                if (t.Enclosure == "")
                    t.Enclosure = FindXMLTags(node, "enclosure", "url=?");
                if (t.Enclosure == "")
                    t.Enclosure = FindXMLTags(node, "torrent:enclosure", "");
                if (t.Enclosure == "")
                    t.Enclosure = FindXMLTags(node, "torrent:enclosure", "url=");
                if (t.Enclosure == "")
                    t.Enclosure = FindXMLTags(node, "torrent:enclosure", "url=?");
                if (t.Enclosure == "")
                    t.Enclosure = FindXMLTags(node, "enclosure url", "");
                if (t.Enclosure == "")
                    t.Enclosure = FindXMLTags(node, "guid", "");
                if (t.Enclosure == "")
                    t.Enclosure = FindXMLTags(node, "guid", "url=");
                if (t.Enclosure == "")
                    t.Enclosure = FindXMLTags(node, "torrent:guid", "");
                if (t.Enclosure == "")
                    t.Enclosure = FindXMLTags(node, "torrent:guid", "url=");

                // Set Torrent or Magnet
                if (t.Enclosure.ToUpper().Contains("MAGNET"))
                    t.DLType = (int)URLFeedTypes.Magnet;
                else
                    t.DLType = (int)URLFeedTypes.Torrent;

                // Link
                t.Link = FindXMLTags(node, "link", "");
                if (t.Link == "")
                    t.Link = FindXMLTags(node, "torrent:link", "");

                // Validate
                string validateStr = "";
                if (t.Title == "")
                    validateStr = $"RSS Missing TITLE Tag | {t.Title}";
                if (t.Enclosure == "")
                    validateStr = $"RSS Missing proper ENCLOSURE/GUID Tag | {t.Title}";
                if (validateStr == "")
                {
                    // Final Params and Add()
                    t.FID = tFID;
                    t.CID = tCID;
                    dbVault.Add(t);
                }
            }
        }

        public static void DownloadTorrent<T>(T data)
        {
            string downloadEnclosure = "";
            int DLType = 0;
            if (data is tVaultRec torrentRec)
            {
                downloadEnclosure = torrentRec.Enclosure;
                DLType = torrentRec.DLType;
            }
            if (data is tQueueRec queueRec)
            {
                downloadEnclosure = queueRec.Enclosure;
                DLType = queueRec.DLType;
            }

            if (dbPreference.GetString(tPrefConstants.TorrentApp) == "")
            {
                Dialog_Box("Warning", "Torrent App Not Defined", "Torrent Application needs to be set in preferences.", new[] { DialogButton.OK }, TaskDialogIcon.Information);
                return;
            }
            if (dbPreference.GetString(tPrefConstants.TorrentParam) == "")
            {
                Dialog_Box("Warning", "Torrent Param Not Defined", "Torrent Application parameter needs to be set in preferences.", new[] { DialogButton.OK }, TaskDialogIcon.Information);
                return;
            }
            if (DLType == (int)URLFeedTypes.Torrent)
            {
                // Save to File
                //// Save to File
                //  if ( Pref_GetInteger( tPrefConstants.TorrentSaveType, Integer(tTorrentSaveTypes.SaveToFile)) = Integer(tTorrentSaveTypes.SaveToFile) ) then
                //  begin
                //    saveDir := Pref_GetString( tPrefConstants.TorrentSaveDirectory, '*ERR*');
                //    if ( saveDir <> '*ERR*') then
                //    begin
                //      if ( saveDir[ Length(SaveDir) ] <> '' ) then
                //        saveDir := saveDir + '\';
                //      if NOT DirectoryExists( saveDir ) then
                //        errMsg := 'Directory "' + saveDir + '" not found.';
                //    end else
                //      errMsg := 'No Directory Setup - Please Configure in Preferences';
                //  end;
                //if ( Pref_GetInteger( tPrefConstants.TorrentSaveType, Integer(tTorrentSaveTypes.SaveToFile) ) = Integer(tTorrentSaveTypes.SaveToFile)) then
                //      begin
                //        saveFile := ToolBox_CleanTorrentFileName( feedRec.TITLE + '.torrent');
                //        try
                //          Logging_WriteLog('HTTP REQUEST: ' + feedRec.ENCLOSURE, tLogTypes.Normal );
                //          DLOK := URLDownloadToFile(NIL, PChar(feedRec.Enclosure), PChar(saveDir + saveFile), 0, NIL);
                //          if ( DLOK <> S_OK ) then
                //          begin
                //            result.errorResult := true;
                //            result.errorMessage := 'FAILED (' + URLErrorToMessage( DLOK ) + ')';
                //          end else
                //            Logging_WriteLog('HTTP COMPLETED NO ERRORS', tLogTypes.Normal );
                //        except on E:Exception do
                //        begin
                //          result.errorResult := true;
                //          result.errorMessage := e.Message;
                //        end;
                //      end;
                //      if NOT ( FileExists( saveDir + saveFile ) ) then
                //      begin
                //        result.errorResult := true;
                //        if ( result.errorMessage = '' ) then
                //          result.errorMessage := '.Torrent FAILED TO DOWNLOAD';
                //      end else
                //        if NOT ( ToolBox_CheckIfValidTorrent( saveDir + saveFile ) ) then
                //        begin
                //          result.errorResult := true;
                //          if ( result.errorMessage = '' ) then
                //            result.errorMessage := 'Torrent SCAN: .Torrent file is INVALID - does not contain .Torrent Data'
                //        end else
                //          Logging_WriteLog('Torrent SCAN: .Torrent is valid: ', tLogTypes.Normal );

            }
            if (DLType == (int)URLFeedTypes.Magnet)
            {
                string directory = dbPreference.GetString(tPrefConstants.TorrentSaveDirectory);
                string torAppParams = $"{dbPreference.GetString(tPrefConstants.TorrentApp)}   {dbPreference.GetString(tPrefConstants.TorrentParam)}";
                torAppParams = torAppParams.Replace("%T", downloadEnclosure).Replace("%t", downloadEnclosure);
                torAppParams = torAppParams.Replace("%SD", downloadEnclosure).Replace("%SD", downloadEnclosure);
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = dbPreference.GetString(tPrefConstants.TorrentApp),
                        Arguments = torAppParams,
                        UseShellExecute = true,
                        WindowStyle = ProcessWindowStyle.Normal
                    };

                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    Dialog_Box("Error", "Torrent Error", ex.Message, new[] { DialogButton.OK }, TaskDialogIcon.Error);
                }
            }

        }
    }
}

