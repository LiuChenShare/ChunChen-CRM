USE [ChunChen]
GO
INSERT [dbo].[Account] ([Id], [Account], [Password], [EmployeeId], [Deleted]) VALUES (N'5203dd5d-de6e-e811-8d24-00e0705eb4dc', N'123', N'123', N'c6835e4a-de6e-e811-8d24-00e0705eb4dc', 0)
GO
INSERT [dbo].[Account] ([Id], [Account], [Password], [EmployeeId], [Deleted]) VALUES (N'5ff9f2a2-f06a-e811-b245-00e0705eb4dc', N'13955775977', N'123', N'5d1b0f16-026a-e811-b245-00e0705eb4dc', 0)
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [CustomerNo], [Name], [Gender], [Mobile], [Address], [Birthday], [WaiterId], [WaiterName], [Spend], [CreateDate], [LastUpdatedOn], [Deleted]) VALUES (N'f2c28302-ba6f-e811-8d26-00e0705eb4dc', 1, N'一号', 0, N'111', N'地址', NULL, NULL, NULL, 0, CAST(N'2018-06-14T18:02:14.157' AS DateTime), CAST(N'2018-06-14T18:02:14.157' AS DateTime), 0)
GO
INSERT [dbo].[Customer] ([Id], [CustomerNo], [Name], [Gender], [Mobile], [Address], [Birthday], [WaiterId], [WaiterName], [Spend], [CreateDate], [LastUpdatedOn], [Deleted]) VALUES (N'fb21e008-ba6f-e811-8d26-00e0705eb4dc', 2, N'二号', 1, N'222', N'地址2', NULL, NULL, NULL, 0, CAST(N'2018-06-14T18:02:24.830' AS DateTime), CAST(N'2018-06-14T18:02:24.830' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([Id], [EmployeeNo], [Name], [Mobile], [Gender], [Birthday], [Authority], [Spend], [JoinDate], [Quit], [QuitDate], [CreateDate], [LastUpdatedOn], [Deleted]) VALUES (N'c6835e4a-de6e-e811-8d24-00e0705eb4dc', 1, N'admin', N'123', 1, NULL, 0, 0, CAST(N'2018-06-13T15:49:25.430' AS DateTime), 0, NULL, CAST(N'2018-06-13T15:49:25.430' AS DateTime), CAST(N'2018-06-13T15:49:25.430' AS DateTime), 0)
GO
INSERT [dbo].[Employee] ([Id], [EmployeeNo], [Name], [Mobile], [Gender], [Birthday], [Authority], [Spend], [JoinDate], [Quit], [QuitDate], [CreateDate], [LastUpdatedOn], [Deleted]) VALUES (N'5d1b0f16-026a-e811-b245-00e0705eb4dc', 1001, N'heheh', N'13955775977', 1, NULL, 0, 0, CAST(N'2018-06-12T15:59:19.907' AS DateTime), 0, NULL, CAST(N'2018-06-11T17:12:02.183' AS DateTime), CAST(N'2018-06-11T17:12:02.183' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
