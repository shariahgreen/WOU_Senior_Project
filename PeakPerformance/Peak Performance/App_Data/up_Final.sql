CREATE TABLE [dbo].[Persons]
(
	[ID]				INT	IDENTITY (1,1)	NOT NULL,
	[FirstName]			NVARCHAR (100)		NOT NULL,
	[LastName]			NVARCHAR (100)		NOT NULL,
	[PreferredName] 	NVARCHAR (100),
	[Active] 			BIT, 				
	[ASPNetIdentityID]	NVARCHAR (128)		NOT NULL
	
	CONSTRAINT [PK_dbo.Persons]	PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Coaches]
(
	[ID] 			INT			 	NOT NULL,

	CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Coaches_dbo.Persons_ID] FOREIGN KEY ([ID]) REFERENCES [Persons] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[Sports]
( 
	[ID]			INT IDENTITY (1,1)	NOT NULL,
	[SportName]		NVARCHAR (100)		NOT NULL,
	[Season]		NVARCHAR (100)		NOT NULL
	
	CONSTRAINT [PK_dbo.Sports] PRIMARY KEY CLUSTERED ([ID] ASC)
)

CREATE TABLE [dbo].[Teams]
(
	[ID] 			INT IDENTITY (1,1)	NOT NULL,
	[TeamName] 		NVARCHAR (200) 		NOT NULL,
	[CoachID] 		INT					NOT NULL

	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([ID] ASC)
	CONSTRAINT [FK_dbo.Teams_dbo.Coaches_CoachID] FOREIGN KEY ([CoachID]) REFERENCES [dbo].[Coaches] ([ID]) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[Athletes]
(
	[ID] 			INT				NOT NULL,
	[Sex] 			CHAR (1),  
	[Gender] 		NVARCHAR (200),
	[DOB] 			DATE			NOT NULL,
    [Height] 		FLOAT,
    [Weight] 		FLOAT,
	[TeamID] 		INT 			NOT NULL
	
	CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Athletes_dbo.Persons_ID] FOREIGN KEY ([ID]) REFERENCES [Persons] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.Athletes_dbo.Teams_TeamID] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Teams] ([ID]) ON DELETE NO ACTION
);

