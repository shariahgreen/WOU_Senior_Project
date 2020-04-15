ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_dbo.Teams_dbo.Sports_SportId];
ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_dbo.Teams_dbo.Coaches_CoachId];
ALTER TABLE [dbo].[Athletes] DROP CONSTRAINT [FK_dbo.Athletes_dbo.Coaches_CoachId];
ALTER TABLE [dbo].[Athletes] DROP CONSTRAINT [FK_dbo.Athletes_dbo.Teams_TeamId];

ALTER TABLE [dbo].[Coaches] DROP CONSTRAINT [PK_dbo.Coaches];
ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [PK_dbo.Teams];
ALTER TABLE [dbo].[Athletes] DROP CONSTRAINT [PK_dbo.Athletes];

DROP TABLE [dbo].[Coaches];
DROP TABLE [dbo].[Teams];
DROP TABLE [dbo].[Athletes];

ALTER TABLE [dbo].[Workouts] DROP CONSTRAINT [FK_dbo.Workouts_dbo.Teams_TeamID];