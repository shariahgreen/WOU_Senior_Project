CREATE TABLE [dbo].[MuscleGroups]
(
    [ID] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(200),
	CONSTRAINT [PK_dbo.MuscleList] PRIMARY KEY CLUSTERED ([ID] ASC)
)

CREATE TABLE [dbo].[Exercises]
(
    [ID] INT NOT NULL IDENTITY(1,1),
	[URL] NVARCHAR(MAX),
	CONSTRAINT [PK_dbo.Exercise] PRIMARY KEY CLUSTERED ([ID] ASC)
)

CREATE TABLE [dbo].[ExcerciseMuscleGroups]
(
    [ID] INT NOT NULL IDENTITY(1,1),
    [MuscleGroupID] INT NOT NULL,
	[ExerciseID] INT NOT NULL,
    
	CONSTRAINT [FK_dbo.ExerciseMuscleGroups_dbo.MuscleGroups_MuscleGroupsID] FOREIGN KEY ([MuscleGroupID]) REFERENCES [dbo].[MuscleGroups] ([ID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.ExerciseMuscleGroups_dbo.Exercises_ExerciseID] FOREIGN KEY ([ExerciseID]) REFERENCES [dbo].[Exercise] ([ID]) ON DELETE CASCADE,
	CONSTRAINT [PK_dbo.ExerciseMuscleGroups] PRIMARY KEY CLUSTERED ([ID] ASC)
)

CREATE TABLE [dbo].[Workouts]
(
    [ID] INT NOT NULL IDENTITY(1,1),
	[Date] DATE NOT NULL,
	[TeamID] INT NOT NULL,

	CONSTRAINT [FK_dbo.Workouts_dbo.Teams_TeamID] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Teams] ([ID]) ON DELETE CASCADE,
	CONSTRAINT [PK_dbo.Workouts] PRIMARY KEY CLUSTERED ([ID] ASC)
)

CREATE TABLE [dbo].[Complexes]
(
    [ID] INT NOT NULL IDENTITY(1,1),
	[WorkOutID] INT,

	CONSTRAINT [FK_dbo.Complex_dbo.WorkOuts_WorkOutID] FOREIGN KEY ([WorkOutID]) REFERENCES [dbo].[WorkOuts] ([ID]) ON DELETE CASCADE,
	CONSTRAINT [PK_dbo.Complex] PRIMARY KEY CLUSTERED ([ID] ASC)
)

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
    
	CONSTRAINT [FK_dbo.ComplexItems_dbo.Exercise_ExerciseID] FOREIGN KEY ([ExerciseID]) REFERENCES [dbo].[Exercise] ([ID]) ON DELETE CASCADE,
	CONSTRAINT [PK_dbo.ComplexItems] PRIMARY KEY CLUSTERED ([ID] ASC)
)