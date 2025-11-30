--
-- init.sql
-- This file contains the initial data and setup commands for the VaultASaur3 database.
-- It typically runs after the schema has been created.
--

-- Initial Setup:
-- The C# code checks if DBID < Start_DB_Version (100) and then sets it.
-- This INSERT simulates the start of the database version tracking.

-- Start the Database Version:
-- Assumes Start_DB_Version = 100. If the table is empty, this inserts the starting version.
INSERT INTO TABLE_MAIN (DBID) 
SELECT 100
WHERE NOT EXISTS (SELECT 1 FROM TABLE_MAIN);

-- UPDATE 101: Initial Preferences
-- This section inserts default values for the preferences introduced in version 101.
-- PNAME values (e.g., 'AutoClose', 'Hint') are inferred from the C# code.
-- NOTE: The actual PNAME strings (tPrefConstants) must match what your C# app uses.

-- Default: AutoClose = 300 (seconds)
INSERT INTO TABLE_PREFERENCE (PNAME, ASINT)
VALUES ('AutoClose', 300);

-- Default: Hint = "" (Empty string)
INSERT INTO TABLE_PREFERENCE (PNAME, ASSTR)
VALUES ('Hint', '');

-- Final Step: Update the DB Version to the 'Next' version (101) after running all initial updates.
UPDATE TABLE_MAIN
SET DBID = 101
WHERE DBID < 101;