using VaultASaur.Enums;
using VaultASaur.ErrorHandling;
using VaultASaur.Objects;
using VaultASaur.ToolsBox;
using System.Data.SQLite;
using System.Text;
using VaultASaur.Enums;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace VaultASaur.DataBase
{
    public static class dbVault
    {
        public static tVaultRec InitializeRecord()
        {
            return new tVaultRec()
            {
                ID = "",
                SiteName = "",
                UserName = "",
                Password = "",
                PasswordHint = "",
                Email = "",
                Question1 = "",
                Question2 = "",
                Question3 = "",
                URL = "",
                Descript = ""
            };
        }

        public static tErrorResult Add(tVaultRec inVaultRec)
        {
            tErrorResult t;
            string sqlStr = $@"INSERT INTO {MasterData.GetTableName_Vault}
                (SITENAME, USERNAME, PASSWORD, PASSWORDHINT, EMAIL, QUESTION1, QUESTION2, QUESTION3, URL, DESCRIPT, EMAIL, ISACTIVE)
				VALUES
				(@SITENAME, @USERNAME, @PASSWORD, @PASSWORDHINT, @EMAIL, @QUESTION1, @QUESTION2, @QUESTION3, @URL, @DESCRIPT, @EMAIL, @ISACTIVE)";
            var parameters = new Dictionary<string, object>
            {
                { "@SITENAME", inVaultRec.SiteName },
                { "@USERNAME", inVaultRec.UserName },
                { "@PASSWORD", inVaultRec.Password },
                { "@PASSWORDHINT", inVaultRec.PasswordHint },
                { "@EMAIL", inVaultRec.Email },
                { "@QUESTION1", inVaultRec.Question1 },
                { "@QUESTION2", inVaultRec.Question2 },
                { "@QUESTION3", inVaultRec.Question3 },
                { "@URL", inVaultRec.URL },
                { "@DESCRIPT", inVaultRec.Descript },
                { "@EMAIL", inVaultRec.Email },
                { "@ISACTIVE", inVaultRec.IsActive }
            };
            t = MasterData.ExecuteSQL(sqlStr, parameters);
            return t;
        }

        public static tErrorResult Delete(string inID)
        {
            tErrorResult t;
            string sqlStr = $@"DELETE FROM {MasterData.GetTableName_Vault} WHERE ID = @ID";
            var parameters = new Dictionary<string, object>
            {
                { "@ID", inID }
            };
            using (SQLiteDataReader reader = MasterData.ExecuteQuery(sqlStr, parameters, out t)) ;
            return t;
        }

        public static tVaultRec Get(int inID)
        {
            tVaultRec t = InitializeRecord();
            tErrorResult e;
            string sqlStr = $@"SELECT * FROM {MasterData.GetTableName_Vault} WHERE ID = @ID";
            var parameters = new Dictionary<string, object>
                {
                    { "@ID", inID }
                };
            using (SQLiteDataReader reader = MasterData.ExecuteQuery(sqlStr, parameters, out e))
            {
                if (!e.errorResult)
                {
                    if (reader.Read())
                    {
                        t.ID = reader["ID"].ToString();
                        t.SiteName = reader["SITENAME"].ToString();
                        t.UserName = reader["USERNAME"].ToString();
                        t.Password = reader["PASSWORD"].ToString();
                        t.PasswordHint = reader["PASSWORDHINT"].ToString();
                        t.Email = reader["EMAIL"].ToString();
                        t.Question1 = reader["QUESTION1"].ToString();
                        t.Question2 = reader["QUESTION2"].ToString();
                        t.Question3 = reader["QUESTION3"].ToString();
                        t.URL = reader["URL"].ToString();
                        t.Descript = reader["DESCRIPT"].ToString();
                        t.Email = reader["EMAIL "].ToString();
                        t.IsActive = Convert.ToInt32(reader["ISACTIVE"]);
                    }
                }
            }
            return t;
        }

        public static tErrorResult Update(tVaultRec inVaultRec)
        {
            tErrorResult t;
            string sqlStr = $@"UPDATE {MasterData.GetTableName_Vault}
                SET ID = @ID,
				SITENAME = @SITENAME,
				USERNAME = @USERNAME,
				PASSWORD = @PASSWORD,
				PASSWORDHINT = @PASSWORDHINT,
				EMAIL = @EMAIL,
				QUESTION1 = @QUESTION1,
				QUESTION2 = @QUESTION2,
				QUESTION3 = @QUESTION3,
				URL = @URL,
				DESCRIPT = @DESCRIPT,
				EMAIL  = @EMAIL,
				ISACTIVE = @ISACTIVE,
                WHERE ID = @ID";
            var parameters = new Dictionary<string, object>
            {
                { "@SITENAME", inVaultRec.SiteName },
                { "@USERNAME", inVaultRec.UserName },
                { "@PASSWORD", inVaultRec.Password },
                { "@PASSWORDHINT", inVaultRec.PasswordHint },
                { "@EMAIL", inVaultRec.Email },
                { "@QUESTION1", inVaultRec.Question1 },
                { "@QUESTION2", inVaultRec.Question2 },
                { "@QUESTION3", inVaultRec.Question3 },
                { "@URL", inVaultRec.URL },
                { "@DESCRIPT", inVaultRec.Descript },
                { "@EMAIL", inVaultRec.Email },
                { "@ISACTIVE", inVaultRec.IsActive }
            };
            t = MasterData.ExecuteSQL(sqlStr, parameters);
            return t;
        }

        public static int Count()
        {
            string sqlStr = $@"SELECT COUNT(*) FROM {MasterData.GetTableName_Vault} WHERE ISACTIVE = 1";
            return MasterData.Count(sqlStr);
        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//
        // OTHER DATABASE ROUTINES SPECIFIC TO THIS CLASS
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

        public static DataTable GridLoadData()
        {
            string connectionString = MasterData.ConnectionString();
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            var cmd = new SQLiteCommand(@$"SELECT * FROM {MasterData.GetTableName_Vault}", conn);
            var adapter = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }


        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//




        /*
             unit ToolBox_PasswordToolBoxUnit;

interface uses
	constantsunit,
	toolboxunit,
	errorresultunit,
	masterdataunit,
	RecordStructureUnit,
	masterdata_BaseDataClassUnit,
	Toolbox_PreferenceToolBoxUnit,
	VaultObjectUnit,
	PercentFormUnit,
	EncryptUnit,
	//
	db,
	dbtables,
	bde,
	sysutils,
	classes,
	forms,
	dateutils,
	inifiles,
	stdctrls;

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

function ToolBox_Password_NewSite( inVaultObject : tVaultObject; inPassPhrase : String ) : string;
function ToolBox_Password_GetSite( inSiteID : string; inPassPhrase : string ) : tVaultObject;
function ToolBox_Password_UpdateSite( inVaultObject : tVaultObject; inPassPhrase : String ) : string;
function ToolBox_Password_DeleteSite( inSiteID : string ) : string;
function ToolBox_Password_UpdatePassword( inOldPassword, inNewPassword : string ) : string;
function ToolBox_Password_ActivateDeactivateSite( inSiteID : string; inActivityType : tActiveStates; inPassPhrase : string ) : string;
//
procedure ToolBox_Password_ExportVaulteSiteDatabaser(inPassPhrase : String; inFileName : string );

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

implementation

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

function ToolBox_Password_NewSite( inVaultObject : tVaultObject; inPassPhrase : String ) : string;
var
	fQuery : tQuery;
begin
	result := '';
	fQuery := masterData.GetQuery();
	try
		fQuery.SQL.Text := 'SELECT * FROM ' + masterData.Gettable_Password;
		fQuery.Open();
		//
		fQuery.Append();
		//
		fQuery.FieldByName('ID').AsString := inVaultObject.ID;
		fQuery.FieldByName('FNAME').AsString := inVaultObject.SiteName;
		fQuery.FieldByName('FPASSWORD').AsString := EncryptObj.EncriptSite( inVaultObject, inPassPhrase );
		fQuery.FieldByName('ISACTIVE').AsBoolean := inVaultObject.ACTIVE;
		//
		fQuery.Post();
		//
		fQuery.Close();
	finally
		FreeAndNil(fQuery);
	end;
	result := inVaultObject.ID;
end;

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

function ToolBox_Password_GetSite( inSiteID : string; inPassPhrase : string ) : tVaultObject;
var
	fQuery : tQuery;
	siteStr : string;
begin
	result := tVaultObject.Create();
	fQuery := masterData.GetQuery();
	try
		fQuery.SQL.Text := 'SELECT * FROM ' + masterData.Gettable_Password + ' WHERE ID = ' + masterData.WrapDBID( inSiteID );
		fQuery.Open();
		//
		if ( fQuery.RecordCount <> 0 ) then
		begin
			siteStr := fQuery.FieldByName('FPASSWORD').AsString;
			EncryptObj.DecryptSite( siteStr, result, inPassPhrase );
         result.ACTIVE := fQuery.FieldByName('ISACTIVE').AsBoolean;
		end else
			result.ID := 'ERROR';
		//
		fQuery.Close();
	finally
		FreeAndNil(fQuery);
	end;
end;

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

function ToolBox_Password_UpdateSite( inVaultObject : tVaultObject; inPassPhrase : String ) : string;
var
	fQuery : tQuery;
begin
	fQuery := masterData.GetQuery();
	try
		fQuery.SQL.Text := 'SELECT * FROM ' + masterData.Gettable_Password + ' WHERE ID = ' + masterData.WrapDBID( inVaultObject.ID );
		fQuery.Open();
		//
		fQuery.Edit();
		//
		fQuery.FieldByName('ID').AsString := inVaultObject.ID;
		fQuery.FieldByName('FNAME').AsString := inVaultObject.SiteName;
		fQuery.FieldByName('FPASSWORD').AsString := EncryptObj.EncriptSite( inVaultObject, inPassPhrase );
		fQuery.FieldByName('ISACTIVE').AsBoolean := inVaultObject.ACTIVE;
		//
		fQuery.Post();
		//
		fQuery.Close();
	finally
		FreeAndNil(fQuery);
	end;
end;

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

function ToolBox_Password_DeleteSite( inSiteID : string ) : string;
var
	fQuery : tQuery;
begin
	fQuery := masterData.GetQuery();
	try
		fQuery.SQL.Text := 'DELETE FROM ' + masterData.Gettable_Password + ' WHERE ID = ' + masterData.WrapDBID( inSiteID );
		fQuery.ExecSQL();
		fQuery.Close();
	finally
		FreeAndNil(fQuery);
	end;
end;

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

function ToolBox_Password_UpdatePassword( inOldPassword, inNewPassword : string ) : string;
var
	fQuery : tQuery;
	VaultObject : tVaultObject;
	siteStr : string;
begin
	VaultObject := tVaultObject.Create();
	fQuery := masterData.GetQuery();
	try
		fQuery.SQL.Text := 'SELECT * FROM ' + masterData.Gettable_Password;
		fQuery.Open();
		//
		if ( fQuery.RecordCount <> 0 ) then
		begin
			repeat
				// Pull the old Site by the OLD password
				siteStr := fQuery.FieldByName('FPASSWORD').AsString;
				EncryptObj.DecryptSite( siteStr, VaultObject, inOldPassword );
				//
				fQuery.Edit();
				fQuery.FieldByName('FPASSWORD').AsString := EncryptObj.EncriptSite( VaultObject, inNewPassword );
				fQuery.Post();
				//
				fQuery.Next();
				PercentForm_Update();
			until fQuery.Eof;
		end else
			result := 'ERROR';
		//
		fQuery.Close();
	finally
		FreeAndNil(fQuery);
		FreeAndNil(VaultObject);
	end;
end;

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

function ToolBox_Password_ActivateDeactivateSite( inSiteID : string; inActivityType : tActiveStates; inPassPhrase : string ) : string;
var
	fQuery : tQuery;
	VaultObject : tVaultObject;
	siteStr : string;
	fActive : boolean;
begin
	case inActivityType of
		tActiveStates.stateActive: fActive := true;
		tActiveStates.stateInactive: fActive := false;
	end;
	//
	VaultObject := tVaultObject.Create();
	fQuery := masterData.GetQuery();
	//
	try
		fQuery.SQL.Text := 'SELECT * FROM ' + masterData.Gettable_Password + ' WHERE ID = ' + masterData.WrapDBID( inSiteID );
		fQuery.Open();
		//
		if ( fQuery.RecordCount <> 0 ) then
		begin
			// pull old site
			siteStr := fQuery.FieldByName('FPASSWORD').AsString;
			EncryptObj.DecryptSite( siteStr, VaultObject, inPassPhrase );
			//
			VaultObject.ACTIVE := fActive;
			//
			fQuery.Edit();
			fQuery.FieldByName('FPASSWORD').AsString := EncryptObj.EncriptSite( VaultObject, inPassPhrase );
			fQuery.FieldByName('ISACTIVE').AsBoolean := fActive;
			fQuery.Post();
				//
		end else
			result := 'ERROR';
		//
		fQuery.Close();
	finally
		FreeAndNil(fQuery);
		FreeAndNil(VaultObject);
	end;
end;

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

procedure ToolBox_Password_ExportVaulteSiteDatabaser(inPassPhrase : String; inFileName : string );
var
	fQuery : tQuery;
	VaultObject : tVaultObject;
	siteStr : string;
	tFile : TextFile;
begin
	VaultObject := tVaultObject.Create();
	fQuery := masterData.GetQuery();
	try
		fQuery.SQL.Text := 'SELECT * FROM ' + MasterData.Gettable_Password + ' ORDER BY FNAME DESC';
		fQuery.Open();
		//
		if ( fQuery.RecordCount <> 0 ) then
		begin
			system.Assign(tFile, inFileName);
			Rewrite(tfile);
			repeat
				// Pull the old Site by the OLD password
				siteStr := fQuery.FieldByName('FPASSWORD').AsString;
				EncryptObj.DecryptSite( siteStr, VaultObject, inPassPhrase );
				writeln(tFile, vaultObject.AsText);
				//
				fQuery.Next();
				PercentForm_Update();
			until fQuery.Eof;
			close(tfile);
		end;
		//
		fQuery.Close();
	finally
		FreeAndNil(fQuery);
		FreeAndNil(VaultObject);
	end;
end;

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%//

end.




                */


    }
}

