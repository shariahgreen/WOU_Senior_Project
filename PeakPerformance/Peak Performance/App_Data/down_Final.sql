ALTER TABLE [dbo].[Coaches] DROP CONSTRAINT [FK_dbo.Coaches_dbo.Persons_ID]
ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_dbo.Teams_dbo.Coaches_CoachID]
ALTER TABLE [dbo].[Athletes] DROP CONSTRAINT [FK_dbo.Athletes_dbo.Persons_ID]
ALTER TABLE [dbo].[Athletes] DROP CONSTRAINT [FK_dbo.Athletes_dbo.Teams_TeamID]

DROP TABLE [dbo].[Persons];

DROP TABLE [dbo].[Coaches];

DROP TABLE [dbo].[Sports];

DROP TABLE [dbo].[Teams];

DROP TABLE [dbo].[Athletes];