SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [UnitInStock], [Created], [CategoryId]) VALUES (2, N'Watch1', N'nice watch', CAST(3.00 AS Decimal(18, 2)), 123, N'2012-12-12 00:00:00', 1)
INSERT INTO [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [UnitInStock], [Created], [CategoryId]) VALUES (3, N'Watch2222', N'nice watch for women', CAST(2222.00 AS Decimal(18, 2)), 44, N'2012-12-12 00:00:00', 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
