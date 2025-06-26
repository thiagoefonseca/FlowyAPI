IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TB_PAGINAS] (
    [Id] int NOT NULL IDENTITY,
    [codDiario] int NOT NULL,
    [Humor] int NOT NULL,
    [tituloPagina] varchar(200) NOT NULL,
    [temaPagina] varchar(200) NOT NULL,
    [qtdCaracteresPagina] int NOT NULL,
    [dtCriacaoPagina] datetime2 NOT NULL,
    [dtExclusaoPagina] datetime2 NOT NULL,
    [dtModificacaoPagina] datetime2 NOT NULL,
    [contPagina] varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_PAGINAS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Humor', N'codDiario', N'contPagina', N'dtCriacaoPagina', N'dtExclusaoPagina', N'dtModificacaoPagina', N'qtdCaracteresPagina', N'temaPagina', N'tituloPagina') AND [object_id] = OBJECT_ID(N'[TB_PAGINAS]'))
    SET IDENTITY_INSERT [TB_PAGINAS] ON;
INSERT INTO [TB_PAGINAS] ([Id], [Humor], [codDiario], [contPagina], [dtCriacaoPagina], [dtExclusaoPagina], [dtModificacaoPagina], [qtdCaracteresPagina], [temaPagina], [tituloPagina])
VALUES (1, 1, 1, 'teste 123 123 teste de novo', '2025-06-18T21:39:10.1098457-03:00', '0001-01-01T00:00:00.0000000', '0001-01-01T00:00:00.0000000', 123, 'teste', 'Pagina1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Humor', N'codDiario', N'contPagina', N'dtCriacaoPagina', N'dtExclusaoPagina', N'dtModificacaoPagina', N'qtdCaracteresPagina', N'temaPagina', N'tituloPagina') AND [object_id] = OBJECT_ID(N'[TB_PAGINAS]'))
    SET IDENTITY_INSERT [TB_PAGINAS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250619003911_InitialCreate', N'9.0.6');

UPDATE [TB_PAGINAS] SET [dtCriacaoPagina] = '2025-06-25T19:44:03.4492754-03:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250625224404_Migration2Legal', N'9.0.6');

COMMIT;
GO

