
VaultASaur is a simple, local password vault system designed for easy, single-user access and secure storage.

**Features**

Local Password Management: Simple, easy-to-use system for storing passwords locally.

Single-Instance Application: Prevents multiple instances of the application from running simultaneously.

Automatic Database Setup/Update: Initializes and updates the local database upon startup.

Clipboard Security: Clears the system clipboard upon application exit to prevent residual data exposure.

**Security & Technology**

**Encryption**

VaultASaur leverages the Bouncy Castle Crypto project for robust cryptographic operations.

The Bouncy Castle project offers open-source APIs for Java, C#, and Kotlin that support cryptography and cryptographic protocols. They cover many security areas, such as public key infrastructure, digital signatures, authentication, and secure communication.

Additionally, FIPS-certified versions are available for both Java and C#.

**Database**

VaultASaur utilizes a local SQLite database for persistent data storage.

**Programming Details**

Written in C# and uses Windows Forms (STAThread).

Implements a process-level Mutex (Constants.ProgramMutex) to ensure single-instance execution.

Includes Error Handling components for database update failures (tErrorResult).