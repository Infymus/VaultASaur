using System;
using System.Text;
using VaultASaur.Config;
using System.Globalization;
using System.Reflection;

namespace VaultASaur.ToolsBox
{
    public static class ToolBox
    {

        public static string ProperCase(string input, bool trim = true)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            if (trim)
                input = input.Trim();

            input = input.ToLower();

            var result = new StringBuilder(input.Length);
            bool cap = true;
            char[] trigChars = { '"', '\'', '.', ',', '-', '_', '\\', '/', ' ', '(', ':',
                             '1','2','3','4','5','6','7','8','9','0' };

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (cap && char.IsLetter(c))
                    c = char.ToUpper(c);

                result.Append(c);

                // Look ahead for 's pattern (like it's or John's)
                if (c == '\'' && i < input.Length - 1 && input[i + 1] == 's')
                {
                    cap = false;
                }
                else
                {
                    cap = Array.IndexOf(trigChars, c) >= 0;
                }
            }

            return result.ToString();
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                System.ComponentModel.DescriptionAttribute[] attributes =
                    (System.ComponentModel.DescriptionAttribute[])field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }

            return value.ToString();  // Return the enum name if no description is found
        }

        public static bool ConvertEnumToBool<T>(T enumValue) where T : Enum
        {
            // Check if the enum value represents True or False
            if (Enum.IsDefined(typeof(T), enumValue))
            {
                // Return true if the value is True, false otherwise
                return enumValue.ToString() == "True";
            }
            else return false;
        }

        public static int ConvertEnumToInt<T>(T enumValue) where T : Enum
        {
            if (Enum.IsDefined(typeof(T), enumValue))
            {
                return Convert.ToInt32(enumValue);
            }
            else
            {
                throw new ArgumentException("Invalid enum value.");
            }
        }

        public static string GetEnumName(Enum value)
        {
            return value.ToString();
        }

        public static string convertDateSQLite(DateTime inDate)
        {
            return inDate.ToString("yyy-MMM-dd", CultureInfo.InvariantCulture).ToUpper();
        }

        public static string DoDeleteEnclosure(string inStr, string inVal, int inStart, int inLen)
        {
            string result = inStr;
            int x;

            while ((x = result.IndexOf(inVal, StringComparison.Ordinal)) >= 0)
            {
                if (inStart > 0)
                {
                    result = result.Remove(x + inStart, inLen);
                }
                else
                {
                    result = result.Remove(x, inLen);
                }
            }

            return result;
        }

        public static string GetBuildInfoAsString()
        {
            // Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Get version information
            Version version = assembly.GetName().Version;

            // Extract major and minor version only
            string majorMinorVersion = $"{version.Major}.{version.Minor}";

            return majorMinorVersion;
        }

        public static void WindowSizePosition(Form inForm, string inSetting, int inDefaultWidth, int inDefaultHeight)
        {
            inForm.Width = AppConfig.ReadInt("FormWidth", inDefaultWidth);
            inForm.Height = AppConfig.ReadInt("FormHeight", inDefaultHeight);
            inForm.Left = AppConfig.ReadInt("FormLeft", 0);
            inForm.Top = AppConfig.ReadInt("FormTop", 0);
        }

        public static string DelDoubleSpaces(string input)
        {
            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }

            return input;
        }

        /*
       



// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

{ Written to take the hassle out of the Mask Edit Shit }
Function Return_MaskEdit_Str( InCash : String ) : String;
Var
  _Cash : Currency;
  _CashStr : String;
begin
  _CashStr := Trim(InCash);
  if Copy(_CashStr, 1, 1) = '$' then
    Delete(_CashStr, 1, 1);
  While Pos(#32, _CashStr) >= 1 do
    Delete(_CashStr, Pos(#32, _CashStr), 1);
  if (_CashStr = '') or (_CashStr = '.') then
    _CashStr := '0';
  Result := _CashStr;
end;

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

Function Return_MaskEdit_Int( InCash : String ) : Integer;
Var
  _Cash : Currency;
  _CashStr : String;
begin
   _CashStr := Trim(InCash);
   if Copy(_CashStr, 1, 1) = '$' then
      Delete(_CashStr, 1, 1);
   While Pos(#32, _CashStr) >= 1 do
      Delete(_CashStr, Pos(#32, _CashStr), 1);
   if (_CashStr = '') or (_CashStr = '.') then
      _CashStr := '0';
   Result := StrToInt(_CashStr);
end;

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

Function Return_MaskEdit_Curr( InCash : String ) : Currency;
Var
  _Cash : Currency;
  _CashStr : String;
begin
  _CashStr := Trim(InCash);
  if Copy(_CashStr, 1, 1) = '$' then
    Delete(_CashStr, 1, 1);
  While Pos(#32, _CashStr) >= 1 do
    Delete(_CashStr, Pos(#32, _CashStr), 1);
  if (_CashStr = '') or (_CashStr = '.') then
    _CashStr := '0';
  Result := StrToCurr(_CashStr);
end;

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

// this function is only to pull out anything in an
function Return_MaskEdit_ProductNumber( inStr : string ) : string;
var
   workStr : string;
begin
   workStr := Trim( inStr );
   // remove spaces
   while pos(#32, workStr) >= 1 do
      delete( workStr, pos(#32, workStr), 1);
   // remove dashes
   while pos('-', workStr) >= 1 do
      delete( workStr, pos('-', workStr), 1);
   //
   result := workStr;
end;


// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

{ This replaces ONE string with ANOTHER string and sends the result back }
Function RepIntStr( SearchCode, SearchStr, RepStr : String) : String;
var
  GlobVar : Integer;
begin
  Repeat
    GlobVar := Pos( SearchCode, SearchStr );
    if GlobVar <> 0 then
    begin
      Delete( SearchStr, GlobVar, Length( SearchCode ));
      Insert( RepStr, SearchStr, GlobVar );
    end;
  until Pos( SearchCode, SearchStr ) = 0;
  Result := SearchStr;
end;

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

Function ToolBox_CheckFileName( InFileName : String ) : String;
begin
  Result := '';
  If Copy(InFileName,Length(InFileName),1) = '\' then
    Result := InFileName
  else
    Result := InFileName + '\';
end;

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

{ This routine breaks down the full name into First, Last, Middle and Title }
function ParseName(const AFullName: string): String;
var
  sl: TStringList;
begin
  Result := '';
  sl := TStringList.Create();
  try
    sl.Delimiter := ' ';
    sl.QuoteChar := '''';
    sl.DelimitedText := aFullName;
    if sl.Count = 4 then
    begin
      Result := sl[0] + ' ' + sl[1] + ' ' + sl[2] + ' ' + sl[3];
    end else
      if sl.Count = 3 then
      begin
        Result := sl[0] + ' ' + sl[1] + ' ' + sl[2];
      end else
        if sl.Count = 2 then
        begin
          Result := sl[0] + ' ' + sl[1];
        end else
          if Sl.Count >= 1 then
            Result := sl[0];
  finally
    sl.Free();
  end;
end;

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% //

{ Notes by Hoenie:
  ----------------
  Personally I don't think this statement will ever really work properly. A change request came about
  because this original procedure was converting "Macey" to "MacEy", which is incorrect. The modifications
  I did remedy this situation, but do not take into account "MacErnest" or "MacFookable", etc. In all
  reality, the routine actually needs to check the name, and if said "C" character is found in
  the string in position #2 or #3, it should really ASK the user to decide between the two names
  and then do so. Unfortunatly the code is set up so that it would probably ask the same stupid question
  dozens of times as it ran through processes, AND, it is not scriptable so it'd ask the question
  in places it should not. I digress, this routine is only worth the characters it's typed up to be. }

{ Proper Case Statement }
function ProperCase(const AValue: string; ATrim: Boolean = True): string;
var
  i: Integer;
  cap: Boolean;
const
  TrigChars: array[1..21] of Char = ('"','''','.',',','-','_','\','/',' ','(',':','1','2','3','4','5','6','7','8','9','0');
begin
  Result := LowerCase(AValue);
  if ATrim then
    Result := Trim(Result);
  cap := True;
  for i := 1 to Length(Result) do
  begin
    if cap then
      Result[i] := UpCase(Result[i]);
    // Handle the McMillan, MacMillan and 's cases. If none of those, check for trigger char
      if (Result[i] = '''') and (i < Length(Result)) and (Result[i+1] = 's') then
        cap := False
      else
        cap := (Pos(Result[i],TrigChars) > 0);
  end;
end;

(* ************************************************************************************************************* *)

Function ProtectCCNum( InCC : String ) : String;
begin
  result := InCC;
end;

(* ************************************************************************************************************* *)

Function UnProtectCCNum( InCC : String ) : String;
begin
  result := InCC;
end;

(* ************************************************************************************************************* *)

Function Return_MaskEdit_Float( InFloat : String ) : Double;
Var
  _Cash : Double;
  _CashStr : String;
begin
  _CashStr := Trim(InFloat);
  While Pos(#32, _CashStr) >= 1 do
    Delete(_CashStr, Pos(#32, _CashStr), 1);
  if (_CashStr = '') or (_CashStr = '.') then
    _CashStr := '0';
  Result := StrToFloat(_CashStr);
end;

(* ************************************************************************************************************* *)

Function SetSize( inSize : Integer; InStr : String ) : String;
begin
  While length(InStr) < InSize do
    InStr := Instr + #32;
  Result := InStr;
end;

(* ************************************************************************************************************* *)

Function SpaceToDot( Instr : String ) : String;
Var
  X : Integer;
begin
  for X := 1 to Length(Instr) do
    if Instr[X] = #32 then
      Instr[X] := '.';
  Result := Instr;
end;

(* ************************************************************************************************************* *)

Procedure TrimCurr( VAR InStr : String );
begin
  while (POS(#32,InStr)<>0) do
    Delete(InStr,POS(#32,InStr),1);
end;


// ******************************************************************************************** //

{ this stupid ass goddamn function exists because delphi can't fucking change a goddamn fucking stupid ass
	fucking word into an integer, so we have to convert it to a goddamn string and then fucking convwert
   it back into an integer. delphi is a bitch sometimes... mh 6/11/2011 }

function ToolBox_Date_GetDateRecord( inDate : tDateTime ) : tDateRecord;
var
   y, m, d, h, min, sec, mil : word;
   convStr : string;
begin
	DecodeDateTime(inDate,y,m,d,h,min,sec,mil);
   //
   result.fDate := inDate;
   //
   convStr := IntToStr(y);
   result.fYear := StrToInt(convStr);
   //
   convStr := IntToStr(m);
   result.fMonth := StrToInt(convStr);
   //
   convStr := IntToStr(d);
   result.fDay := StrToInt(convStr);
   //
   convStr := IntToStr(h);
   result.fHour := StrToInt(convStr);
   //
   convStr := IntToStr(min);
   result.fMin := StrToInt(convStr);
   //
   convStr := IntToStr(sec);
   result.fSec := StrToInt(convStr);
   //
   convStr := IntToStr(mil);
   result.fMilli := StrToInt(convStr);
end;

// ******************************************************************************************** //

function ToolBox_FormatCurrency( inCurrency : currency ) : string;
begin
   if inCurrency > 0 then
      result := FormatFloat('#####.00', inCurrency)
   else
      result := '    0.00';
end;

// ******************************************************************************************** //

function ToolBox_DateTime_TrimSpaces( inDateStr : string ) : tDateTime;
begin
	result := NOW;
	while POS(#32, inDateStr ) >= 1 do
   	Delete(inDateStr, POS(#32, inDateStr), 1);
   result := StrToDate( inDateStr );
end;

// ******************************************************************************************** //

function Toolbox_NewDBGuid: String;
var
   Guid : tGuid;
   tempStr : string;
begin
   CreateGuid( Guid );
   tempStr := GUIDToString( Guid );
   System.Delete(tempStr, 1, 1);
   System.Delete(tempStr, Length(TempStr), 1);
   result := tempStr;
end;

// ******************************************************************************************** //

{$REGION 'Passwords'}

function ToolboxValidatePassword( Password1, Password2 : string ) : string;
var
   cnt : integer;
   Valid_Upper : boolean;
   Valid_Number : boolean;
begin
   result := '';
   Valid_Upper := false;
   Valid_Number := true;
   //
   if ( Password1 <> Password2 ) then
      result := Result + '* Passwords do NOT match - check validation\n';

   if ( Length(Password1) < 8 ) then
      result := result + '* Password must be 8 characters or greater\n';

   for cnt := 1 to length( Password1 ) do
   begin
      if (Password1[cnt] in ['A'..'Z']) then
         valid_Upper := true;
      if (Password1[cnt] in ['0'..'9']) then
         valid_Number := true;
   end;

   if ( NOT Valid_Upper ) then
      result := result + '* Must contain at least 1 UPPERcase letter (A-Z)';
   if ( NOT Valid_Number ) then
      result := result + '* Must contain at least 1 numeric character (0-9)';
end;

// Password Generation Stuff

// ` ! " ? $ ? % ^ & * ( ) _ - + = { [ } ] : ; @ ' ~ # | \ < , > . ? /
// 1 uppercase

// ******************************************************************************************** //

function ToolBox_GeneratePassword( usePunct : boolean; pwLen : integer ) : String;
var
	PW : string;
   cnt : integer;
   roll : integer;
   str : string;
   rnd : integer;
begin
	PW := '';
   roll := 0;
   Randomize();
   //
   for cnt := 1 to pwLen do
   begin
		inc(roll);
      if ( roll > 3 ) then
      	roll := 1;
      //
      Str := '';
      //
      case roll of
      	1: // alpha lower
         begin
				rnd := Random( 26 ) + 1;
            Str := Chr( rnd + 97 );
         end;
         2: // numeric
         begin
				rnd := Random( 9 ) + 1;
            Str := Chr( rnd + 48 );
         end;
         3: // alpha upper
         begin
				rnd := Random( 26 ) + 1;
            Str := Chr( rnd + 65 );
			end;
      end;
      //
      PW := PW + Str;
      // punctuation
      if ( usePUnct ) then
      begin
			//* Has symbols, such as ` ! " ? $ ? % ^ & * ( ) _ - + = { [ } ] : ; @ ' ~ # | \ < , > . ? /
      	rnd := Random( 25 + 1 );
         case ( rnd ) of
         	1 : Str := '!';
         	2 : Str := '"';
         	3 : Str := '#';
         	4 : Str := '$';
         	5 : Str := '%';
         	6 : Str := '&';
         	7 : Str := '''';
         	8 : Str := '(';
         	9 : Str := ')';
         	10 : Str := '*';
         	11 : Str := '+';
         	12 : Str := '`';
         	13 : Str := '~';
         	14 : Str := '-';
         	15 : Str := '.';
         	16 : Str := '/';
         	17 : Str := '\';
         	18 : Str := '|';
         	19 : Str := '[';
         	20 : Str := ']';
         	21 : Str := '{';
         	22 : Str := '}';
         	23 : Str := '=';
         	24 : Str := '@';
         	25 : Str := '^';
         end;
         PW := PW + Str;
      end;
   end;
   //
   result := Copy( PW, 1, pwLen );
end;

{$ENDREGION}

// ******************************************************************************************** //

function Toolbox_LoadFileToStr(const FileName: TFileName): String;
var LStrings: TStringList;


   function fixit( inStr : string ) : string;
   var
      cnt : integer;
   begin
      result := '';
      for cnt :=1 to length( instr ) do
      begin
         if ( ord(instr[cnt]) > 31 ) AND ( ord(instr[cnt]) < 128 ) then
            result := result + instr[cnt];
      end;

   end;

begin
    LStrings := TStringList.Create;
    try
      LStrings.Loadfromfile(FileName);
      Result := fixit(LStrings.text);
    finally
      FreeAndNil(LStrings);
    end;
end;

// ******************************************************************************************** //

procedure GetBuildInfo(var V1, V2, V3, V4: word);
var
  VerInfoSize, VerValueSize, Dummy: DWORD;
  VerInfo: Pointer;
  VerValue: PVSFixedFileInfo;
begin
  VerInfoSize := GetFileVersionInfoSize(PChar(ParamStr(0)), Dummy);
  if VerInfoSize > 0 then
  begin
      GetMem(VerInfo, VerInfoSize);
      try
        if GetFileVersionInfo(PChar(ParamStr(0)), 0, VerInfoSize, VerInfo) then
        begin
          VerQueryValue(VerInfo, '\', Pointer(VerValue), VerValueSize);
          with VerValue^ do
          begin
            V1 := dwFileVersionMS shr 16;
            V2 := dwFileVersionMS and $FFFF;
            V3 := dwFileVersionLS shr 16;
            V4 := dwFileVersionLS and $FFFF;
          end;
        end;
      finally
        FreeMem(VerInfo, VerInfoSize);
      end;
  end;
end;

// ******************************************************************************************** //



// ******************************************************************************************** //

// This cleans it so a filename can be written out
function ToolBox_CleanTorrentFileName( inFile : string ) : string;
var
   cnt : integer;
   canUse : boolean;
begin
   result := '';
   for cnt := 1 to length( inFile ) do
   begin
      canUse := true;
      //
      // Bad Characters
      case inFile[ cnt ] of
         '/','\',':','*','?','"','|','#','%','+' : canUse := false;
      end;
      // Higher than lower case z
      if ( ORD( inFile[cnt] ) > 122 ) then
         canUse := False;
      // less than a space
      if ( ORD( inFile[cnt] ) < 32 ) then
         canUse := False;
      //
      if ( canUse) then
         result := result + inFile[cnt];
   end;
end;


// ******************************************************************************************** //

function RandomString( inCount : integer ) : string;
var
	PW : string;
   cnt : integer;
   str : string;
   rnd : integer;
begin
	PW := '';
   Randomize();
   //
   for cnt := 1 to inCount do
   begin
      Str := '';
      rnd := Random( 26 );
      Str := Chr( rnd + 65 );
      PW := PW + Str;
   end;
   //
   result := pw;
end;

// ******************************************************************************************** //

function RunExternalApplication(const FileName, Params, DefaultDir: string; ShowCmd: Integer): integer;
begin
   result := ShellExecute( Application.Handle, 'open', PChar(FileName), nil, nil, SW_SHOWNORMAL) ;
end;

function ExecuteFile(const FileName, Params, DefaultDir: string; ShowCmd: Integer): THandle;
begin
  Result := ShellExecute(Application.MainForm.Handle, 'OPEN', PChar(FileName), PChar(Params), PChar(DefaultDir), SW_SHOWNORMAL);
end;


// ******************************************************************************************** //

// This comes from FeedsListFormUnit - FeedRunInternal() - To Validate if it should attempt to download a feed strings[] item
Function ValidateFEEDURL( inURL : string ) : boolean;
var
   workStr : string;
begin
   result := true;
   //
   workStr := TRIM( inURL );
   workStr := UpperCase( workStr );
   //
   // Validate
   //
   if Length( workStr ) <= 0 then
      result := false;
   if ( pos('#', workStr) = 1 ) then
      result := FALSE;
   if ( pos('/', workStr) = 1 ) then
      result := FALSE;
end;

// ******************************************************************************************** //

Function URLErrorToMessage( inError : LongInt ) : String;
var
  ErrMsg : string;
begin
  case inError of
    -2146697213 : ErrMsg :='NO SESSION';
    -2146697212 : ErrMsg :='CANNOT CONNECT';
    -2146697211 : ErrMsg :='RESOURCE NOT FOUND';
    -2146697210 : ErrMsg :='PAGE NOT FOUND';
    -2146697209 : ErrMsg :='DATA NOT AVAILABLE';
    -2146697208 : ErrMsg :='DOWNLOAD FAILURE';
    -2146697207 : ErrMsg :='AUTHENTICATION REQUIRED';
    -2146697206 : ErrMsg :='NO VALID MEDIA';
    -2146697205 : ErrMsg :='CONNECTION TIMEOUT';
    -2146697204 : ErrMsg :='INVALID REQUEST';
    -2146697203 : ErrMsg :='UNKNOWN PROTOCOL';
    -2146697202 : ErrMsg :='SECURITY PROBLEM';
    -2146697201 : ErrMsg :='CANNOT LOAD DATA';
    -2146697200 : ErrMsg :='CANNOT INSTANTIATE OBJECT';
    -2146697196 : ErrMsg :='REDIRECT FAILED';
    -2146697195 : ErrMsg :='REDIRECT TO DIR';
    -2146697194 : ErrMsg :='CANNOT LOCK REQUEST';
    -2146697193 : ErrMsg :='USE EXTEND BINDING';
    -2146697192 : ErrMsg :='TERMINATED BIND';
    -2146697191 : ErrMsg :='INVALID CERTIFICATE';
    -2146696960 : ErrMsg :='CODE DOWNLOAD DECLINED';
    -2146696704 : ErrMsg :='RESULT DISPATCHED';
    -2146696448 : ErrMsg :='CANNOT REPLACE SFP FILE';
    -2146695936 : ErrMsg :='CODE INSTALL BLOCKED BY HASH POLICY';
    -2146696192 : ErrMsg :='CODE INSTALL SUPPRESSED';
    else ErrMsg := 'SHITS FUCKED';
  end;
  //
  result := ErrMsg;
end;

// ******************************************************************************************** //

Function ValidateEnclosureType( inString : string ) : tURLFeedTypes;
begin
	result := tURLFeedTypes.Blank;
   //
   inString := UpperCase ( InString );
   //
	if POS('HTTP', inString ) >= 1 then
		result := tURLFeedTypes.Torrent;
	if POS('MAGNET', inString ) >= 1 then
		result := tURLFeedTypes.Magnet;

end;

// ******************************************************************************************** //

{ This method brings in an HTML page and strips out all of the tabs and bad characters.

   1. Strip out all bad characters (tabs, high end ascii, etc)
   2. Break page down into individual <CODE> codes.
}

Procedure ToolBox_FormatHTMLToProperTags( inHTML : string; VAR inStringList : tStringList );
var
   htmlString : string;
   cnt : integer;
   Out_String : String;
   GlobalDone : Boolean;
   Code : string;
   X : Integer;
begin
   //
   htmlString := inHTML;
   inStringList.Clear;
   GlobalDone := False;
   Out_String := '';
	Repeat

      if Length(htmlString) >= 1 then
      begin

         if htmlString[1] <> '<' then
			begin
            Out_String := Out_String + htmlString[1];
            Delete(htmlString,1,1);
         end else
            begin
					if ( out_string <> '' ) then
                  inStringList.add( ToolBox_CleanTorrentFileName(out_string) );
               out_string := '';

               X := POS('>', htmlString);

               if X <> 0 then
               begin
                  Code := Copy(htmlString, 1, X);
                  if ( code <> '' ) then
                     inStringList.add(code);
                  Delete(htmlString, 1, x);
              end else
                begin
                  Out_String := Out_String + htmlString[1];
                  Delete(htmlString,1,1);
                end;

            end;

    end;

    if Length(htmlString) <= 0 then
      GlobalDone := True;

   Until (GlobalDone);

	//if ( Out_String <> '' ) then Result.Add( Out_String );
end;

// ******************************************************************************************** //

// Validate that the .Torrent file is actually a goddamn TORRENT...
Function ToolBox_CheckIfValidTorrent( inFileDirPlusName : string) : boolean;
var
	Torrent : tStringList;
	workStr : string;
	x : integer;

begin
	result := false;
	//
	Torrent := tStringList.Create();
	//
	Torrent.LoadFromFile( inFileDirPlusName );
	try
		for x := Torrent.Count-1 Downto 0 do
		begin
			workStr := UpperCase(Torrent.Strings[x]);
			if POS('ANNOUNCE', workStr) >= 1 then
				result := true;
		end;
		// Done.
	finally
	end;
	//
	FreeAndNil(Torrent);
end;

// ******************************************************************************************** //

function DelDoubleSpaces(OldText:String):string;
var
	i:integer;
	s:string;
begin
	if length(OldText)>0 then
		s:=OldText[1]
	else
		s:='';
	for i:=1 to length(OldText) do
	begin
		if OldText[i]=' ' then
		begin
			if not (OldText[i-1]=' ') then
				s:=s+' ';
		end else
			begin
				s:=s+OldText[i];
			end;
	end;
	DelDoubleSpaces:= copy( s, 2, length(s));
end;

// ******************************************************************************************** //

procedure DeleteFiles(sMask, sPath: string);
var
  SearchRec: TSearchRec;
  Found: Integer;
begin
  sPath := IncludeTrailingPathDelimiter(sPath);
  Found := SysUtils.FindFirst(sPath + sMask, faAnyFile, SearchRec);
  try
    while (Found = 0) do
    begin
      if not (SearchRec.Attr and faDirectory > 0) then
        SysUtils.DeleteFile(sPath + SearchRec.Name);
      Found := SysUtils.FindNext(SearchRec);
    end;
  finally
    SysUtils.FindClose(SearchRec);
  end;
end;

        */






    }
}
