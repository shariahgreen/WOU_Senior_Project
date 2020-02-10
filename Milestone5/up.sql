CREATE TABLE [dbo].[Sports]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[SportName] NVARCHAR(100),
	[Season] NVARCHAR(100),
	PRIMARY KEY (ID)
);

CREATE TABLE [dbo].[Teams]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[TeamName] NVARCHAR(200),
	[SportID] INT,
	FOREIGN KEY (SportID) REFERENCES [dbo].[Sports](ID),
	PRIMARY KEY (ID)
);



CREATE TABLE [dbo].[Roles]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[RoleName] NVARCHAR(100),
	PRIMARY KEY (ID)
);

CREATE TABLE [dbo].[Persons]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[Email] NVARCHAR(320),
	[FirstName] NVARCHAR(100),
	[M.I.] CHAR(1),
	[LastName] NVARCHAR(100),
	[PreferredName] NVARCHAR(200),
	[ProfilePic] VARBINARY(max),
	[Sex] CHAR(1),
	[Gender] NVARCHAR(200),
	[Active] BIT,
	[DOB] DATE,
	[DateAdded] DATE,
	[RoleID] INT,
	[TeamID] INT,
	FOREIGN KEY (RoleID) REFERENCES [dbo].[Roles](ID),
	FOREIGN KEY (TeamID) REFERENCES [dbo].[Teams](ID),
	PRIMARY KEY (ID)
);

CREATE TABLE [dbo].[WorkOuts]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[Date] DATE,
	[PersonID] INT,
	FOREIGN KEY (PersonID) REFERENCES [dbo].[Persons](ID),
	PRIMARY KEY (ID)
);

CREATE TABLE [dbo].[MuscleList]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(200),
	PRIMARY KEY (ID)
);

CREATE TABLE [dbo].[MovementList]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(200),
	PRIMARY KEY (ID)
);

CREATE TABLE [dbo].[Exercise]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[URL] NVARCHAR(MAX),
	PRIMARY KEY (ID)
);

CREATE TABLE [dbo].[ExerciseMovements]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[MovementListID] INT NOT NULL,
	[MuscleListID] INT NOT NULL,
	[ExerciseID] INT NOT NULL,
	FOREIGN KEY (MuscleListID) REFERENCES [dbo].[MuscleList](ID),
	FOREIGN KEY (MovementListID) REFERENCES [dbo].[MovementList](ID),
	FOREIGN KEY (ExerciseID) REFERENCES [dbo].[Exercise](ID),
	PRIMARY KEY (ID)
);

CREATE TABLE [dbo].[ComplexItems]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[Reps] INT,
	[Sets] INT,
	[Weight] FLOAT,
	[Speed] FLOAT,
	[Time] TIME,
	[Distance] FLOAT,
	[ExerciseID] INT,
	FOREIGN KEY (ExerciseID) REFERENCES [dbo].[Exercise](ID),
	PRIMARY KEY (ID)
);

CREATE TABLE [dbo].[Complex]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[ComplexItemsID] INT,
	[WorkoutID] INT,
	FOREIGN KEY (ComplexItemsID) REFERENCES [dbo].[ComplexItems](ID),
	FOREIGN KEY (WorkoutID) REFERENCES [dbo].[Workouts](ID),
	PRIMARY KEY (ID)
);

CREATE TABLE [dbo].[Records]
(
	[ID] INT NOT NULL IDENTITY(1,1),
	[Weight] FLOAT,
	[Time] TIME,
	[PersonID] INT,
	[ExerciseID] INT,
	FOREIGN KEY (PersonID) REFERENCES [dbo].[Persons](ID),
	FOREIGN KEY (ExerciseID) REFERENCES [dbo].[Exercise](ID),
	PRIMARY KEY (ID)
);
