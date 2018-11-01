SET IDENTITY_INSERT [dbo].[Subscriptions] ON
INSERT INTO [dbo].[Subscriptions] ([Id], [Amount], [CompPercentage], [VendorPercentage], [TaxPercentage], [DateCreated], [Status]) VALUES (1, CAST(10000.00 AS Decimal(18, 2)), 10, 90, 15, N'2012-12-12 00:00:00', N'A')
SET IDENTITY_INSERT [dbo].[Subscriptions] OFF
