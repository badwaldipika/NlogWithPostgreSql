# NlogWithPostgreSql
NLog  implemented using .NET 7 and PostgreSQL 

# Create table in pgadmin
CREATE TABLE logs
( 
    Id serial primary key,
    Application character varying(100) NULL,
    Logged text,
    Level character varying(100) NULL,
    Message character varying(8000) NULL,
    Logger character varying(8000) NULL, 
    Callsite character varying(8000) NULL, 
    Exception character varying(8000) NULL
)

# Required packages need to be added
NLog.Web.AspNetCore and Npgsql

# Create middleware for handing exception/Error
 GlobalExceptionHandler class 
