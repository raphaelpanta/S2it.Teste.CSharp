CREATE LOGIN teste WITH PASSWORD = 'Test1234';
CREATE USER teste FOR LOGIN teste;
EXECUTE sys.sp_addsrvrolemember @loginame = N'teste', @rolename = N'dbcreator';
USE master;
GRANT CREATE ANY DATABASE TO teste;
CREATE DATABASE EMPRESTIMO;