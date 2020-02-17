CREATE TABLE [dbo].[Sports]
(
	[SportId] INT NOT NULL IDENTITY(1,1),
	[SportName] NVARCHAR(100) NOT NULL,
	[Season] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_dbo.Sports] PRIMARY KEY CLUSTERED ([SportId] ASC)
);

CREATE TABLE [dbo].[Teams]
(
	[TeamId] INT NOT NULL IDENTITY(1,1),
	[TeamName] NVARCHAR(200) NOT NULL,
	[SportId] INT,
	[CoachId] INT,

	CONSTRAINT [FK_dbo.Teams_dbo.Sports_SportId] FOREIGN KEY ([SportId]) REFERENCES [dbo].[Sports] ([SportId]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Coaches_dbo.Coaches_CoachId] FOREIGN KEY ([CoachId]) REFERENCES [dbo].[Coaches] ([CoachId]) ON DELETE CASCADE,
	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([TeamId] ASC)
);

CREATE TABLE [dbo].[Athletes]
(
	[AthleteId] INT NOT NULL IDENTITY(1,1),
	[FirstName] NVARCHAR(100),
	[LastName] NVARCHAR(100),
    [PreferredName] NVARCHAR (100) NOT NULL,
	[ProfilePic] VARBINARY(max),
	[Sex] CHAR(1),
	[Gender] NVARCHAR(200),
	[Active] BIT NOT NULL,
	[DOB] DATE NOT NULL,
    [Height] FLOAT,
    [Weight] FLOAT,
	[UserId] NVARCHAR(max) NOT NULL,
	[TeamId] INT NOT NULL,
	
	CONSTRAINT [FK.dbo.Persons_dbo.Users_UserId] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Persons_dbo.Teams_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([TeamId]) ON DELETE CASCADE,
	CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([AthleteId] ASC)
);

CREATE TABLE [dbo].[Coaches]
(
	[CoachId] INT NOT NULL IDENTITY(1,1),
	[FirstName] NVARCHAR(100),
	[LastName] NVARCHAR(100),
    [PreferredName] NVARCHAR (100) NOT NULL,
	[ProfilePic] VARBINARY(max),
	[Sex] CHAR(1),
	[Gender] NVARCHAR(200),
	[Active] BIT NOT NULL,
	[DOB] DATE NOT NULL,
    [Height] FLOAT,
    [Weight] FLOAT,
	[UserId] NVARCHAR(max) NOT NULL
	
	CONSTRAINT [FK.dbo.Persons_dbo.Users_UserId] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([CoachId] ASC)
);