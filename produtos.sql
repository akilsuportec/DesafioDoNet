USE [DBSistemaProdutos]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/09/2023 12:24:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 29/09/2023 12:24:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtos](
	[ProdutoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](255) NULL,
	[Preco] [decimal](18, 2) NOT NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[DataAtualizacao] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[ProdutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230928132901_InitialDB', N'6.0.0')
GO
SET IDENTITY_INSERT [dbo].[Produtos] ON 

INSERT [dbo].[Produtos] ([ProdutoId], [Nome], [Preco], [DataCadastro], [DataAtualizacao]) VALUES (4, N'PS5 Slim Desbloqueado', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-09-28T19:57:47.7790000' AS DateTime2), CAST(N'2023-09-28T19:57:47.7790000' AS DateTime2))
INSERT [dbo].[Produtos] ([ProdutoId], [Nome], [Preco], [DataCadastro], [DataAtualizacao]) VALUES (6, N'TV LG 50PL', CAST(5000.00 AS Decimal(18, 2)), CAST(N'2023-09-29T11:09:03.6566667' AS DateTime2), CAST(N'2023-09-29T11:09:03.6566667' AS DateTime2))
INSERT [dbo].[Produtos] ([ProdutoId], [Nome], [Preco], [DataCadastro], [DataAtualizacao]) VALUES (7, N'TV SANSUNG 60PL', CAST(6000.00 AS Decimal(18, 2)), CAST(N'2023-09-29T11:11:15.7400000' AS DateTime2), CAST(N'2023-09-29T11:11:15.7400000' AS DateTime2))
INSERT [dbo].[Produtos] ([ProdutoId], [Nome], [Preco], [DataCadastro], [DataAtualizacao]) VALUES (8, N'Aspirador de pó LG', CAST(500.00 AS Decimal(18, 2)), CAST(N'2023-09-29T12:09:29.7366667' AS DateTime2), CAST(N'2023-09-29T12:09:29.7366667' AS DateTime2))
INSERT [dbo].[Produtos] ([ProdutoId], [Nome], [Preco], [DataCadastro], [DataAtualizacao]) VALUES (9, N'Teste!', CAST(1899.00 AS Decimal(18, 2)), CAST(N'2023-09-29T13:39:44.2200000' AS DateTime2), CAST(N'2023-09-29T13:39:44.2200000' AS DateTime2))
INSERT [dbo].[Produtos] ([ProdutoId], [Nome], [Preco], [DataCadastro], [DataAtualizacao]) VALUES (10, N'string', CAST(100.00 AS Decimal(18, 2)), CAST(N'2023-09-29T14:45:46.8350000' AS DateTime2), CAST(N'2023-09-29T14:45:46.8350000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Produtos] OFF
GO
