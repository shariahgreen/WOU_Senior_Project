DROP TABLE [dbo].[AllData];

ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_dbo.Teams_dbo.Coaches_CoachID];
ALTER TABLE [dbo].[Athletes] DROP CONSTRAINT [FK_dbo.Athletes_dbo.Teams_TeamID];
ALTER TABLE [dbo].[RaceEvents] DROP CONSTRAINT [FK_dbo.RaceEvents_dbo.Distances_DistanceID];
ALTER TABLE [dbo].[RaceEvents] DROP CONSTRAINT [FK_dbo.RaceEvents_dbo.Athletes_AthleteID];
ALTER TABLE [dbo].[RaceEvents] DROP CONSTRAINT [FK_dbo.RaceEvents_dbo.Locations_LocationID];

DROP TABLE [dbo].[Coaches];

DROP TABLE [dbo].[Teams];

DROP TABLE [dbo].[Athletes];

DROP TABLE [dbo].[Locations];

DROP TABLE [dbo].[Distances];

DROP TABLE [dbo].[RaceEvents];