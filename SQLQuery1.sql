INSERT INTO Users Values(22,'DimaTestForConstraint2','1!k',1)
Insert INTO Users Values(1,'Dima','A123,',2);
Insert INTO Users Values(2,'Epson',Null,1);
Insert INTO Users Values(3,'Nastya','N!',1);
Select * FROM Users
CREATE TABLE [dbo].[Users] (
    [Ind]      INT          NOT NULL,
    [Login]    VARCHAR (40) NOT NULL,
    [Password] VARCHAR (40) NULL,
    [Status]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Ind] ASC),
    UNIQUE NONCLUSTERED ([Login] ASC), 
    CONSTRAINT [CK_Users_Pass] CHECK (Password like '([a-zA-Z]*:Po*)*')
);
Drop Table Users;


CREATE TABLE [dbo].[Users] (
    [Ind]      INT          NOT NULL,
    [Login]    VARCHAR (40) NOT NULL,
    [Password] VARCHAR (40) NULL,
    [Status]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Ind] ASC),
    UNIQUE NONCLUSTERED ([Login] ASC), 
    CONSTRAINT [CK_Users_Pass] CHECK (Password like '%[a-zA-Z+]%' AND Password like '%[.,?"!@#%&*\]%')
);