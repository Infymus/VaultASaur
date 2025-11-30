--
-- schema.sql
-- This file defines the structure of the VaultASaur3 SQLite database.
--

-- Table_Main: Stores metadata, primarily the database version ID (DBID).
CREATE TABLE IF NOT EXISTS TABLE_MAIN (
    DBID INTEGER PRIMARY KEY
);

-- Table_Vault: Stores encrypted user credentials and site information.
CREATE TABLE IF NOT EXISTS TABLE_VAULT (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    SITENAME TEXT,
    USERNAME TEXT,
    PASSWORD TEXT,
    SITEDESC TEXT,
    EMAIL TEXT,
    SITEURL TEXT,
    SECQUEST1 TEXT,
    SECQUEST2 TEXT,
    SECQUEST3 TEXT,
    SECQUEST4 TEXT,
    PASSHINT TEXT,
    ISACTIVE INT
);

-- Table_Preference: Stores application settings/preferences in a key-value style.
CREATE TABLE IF NOT EXISTS TABLE_PREFERENCE (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    PNAME TEXT,
    ASSTR TEXT,
    ASBOOL INT,
    ASGUID TEXT,
    ASMEMO BLOB,
    ASINT INT,
    ASCURR REAL
);