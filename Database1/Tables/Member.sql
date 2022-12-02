CREATE TABLE [dbo].[Member]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Prenom] VARCHAR(50) NOT NULL, 
    [Nom] VARCHAR(50) NOT NULL, 
    [Pseudo] VARCHAR(50) NOT NULL, 
    [Birthday] DATE NOT NULL, 
    [email] VARCHAR(250) NOT NULL, 
    [password] VARCHAR(14) NOT NULL, 
    [Pwd_Hash] CHAR(97) NOT NULL
)
