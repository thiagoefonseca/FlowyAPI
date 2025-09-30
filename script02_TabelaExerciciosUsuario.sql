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

ALTER TABLE [TB_PAGINAS] ADD [UsuarioId] int NULL;

CREATE TABLE [TB_USUARIOS] (
    [Id] int NOT NULL IDENTITY,
    [Username] varchar(200) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NOT NULL,
    [DataAcesso] datetime2 NULL,
    [Perfil] varchar(200) NULL DEFAULT 'Utilizador',
    [Email] varchar(200) NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Id])
);

UPDATE [TB_PAGINAS] SET [UsuarioId] = NULL, [dtCriacaoPagina] = '2025-08-25T19:48:25.2690311-03:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Id], [DataAcesso], [Email], [PasswordHash], [PasswordSalt], [Perfil], [Username])
VALUES (1, NULL, 'thiagoefonseca2007@gmail.com', 0x2C776B5F06890FBD34A53A24D6485CCEC587197179278A354E57AFECE682931400DCFE724D94A6A95844326D6DD6CC8065B770935000214BD94C3C04746602B1, 0x0D8E26102F0387839804A0F5949DD331FCCB35D2ADE056DEE16DCABDE81833FA52377203039B89978CC492FBAF16E16A7B1A5FF8BC8698791FA4AAE0B8D471433F24D6B9A1FC93B03A65806999120C5F35BF0671A8346E243EFCF7692531871139247F1A91704854985131D478D73FE9CB19FD117C3BE9675E47406BE2C439F2, 'Admin', 'UsuarioAdmin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;

CREATE INDEX [IX_TB_PAGINAS_UsuarioId] ON [TB_PAGINAS] ([UsuarioId]);

ALTER TABLE [TB_PAGINAS] ADD CONSTRAINT [FK_TB_PAGINAS_TB_USUARIOS_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIOS] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250825224827_UsuarioMigration', N'9.0.6');

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_USUARIOS]') AND [c].[name] = N'PasswordSalt');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [TB_USUARIOS] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [TB_USUARIOS] ALTER COLUMN [PasswordSalt] varbinary(max) NULL;

CREATE TABLE [TB_EXERCICIOS] (
    [Id] int NOT NULL IDENTITY,
    [atividade] varchar(200) NOT NULL,
    [descricao] varchar(200) NOT NULL,
    [dataTermino] datetime2 NOT NULL,
    [tempo] time NOT NULL,
    [quantidade] int NOT NULL,
    [relogio] float NOT NULL,
    [UsuarioId] int NOT NULL,
    CONSTRAINT [PK_TB_EXERCICIOS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_EXERCICIOS_TB_USUARIOS_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIOS] ([Id]) ON DELETE CASCADE
);

UPDATE [TB_PAGINAS] SET [UsuarioId] = 1, [dtCriacaoPagina] = '2025-09-08T20:34:27.8242011-03:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [TB_USUARIOS] SET [PasswordHash] = 0xD66DC7D4256B20E6CAF2473A79BCB1655CE7A045F69B7A74495110E75AFC510AEDFE4358DB399E22E29161E3EA8380E330A113F4575B321D6731A6C0FBE4E1B4, [PasswordSalt] = 0xB89C000D7400E2C36BA836D6C99431B6E902B6AEDF913E54B60A83FA2FB0654EE88D29C48BDAD0B5DB01B6CA8E614E11F98695D362B62C79A2241E8CA464DC576C3C49803E1371DC588A16FD816A750F126C76584964B693584D34BF0C83A81F2F97B17BEA2DDE00B22F6D53207ECE3F8DD258D9A894E2E5A6B6F282CB6B9505
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


CREATE INDEX [IX_TB_EXERCICIOS_UsuarioId] ON [TB_EXERCICIOS] ([UsuarioId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250908233431_ExercicioMigration', N'9.0.6');

ALTER TABLE [TB_EXERCICIOS] DROP CONSTRAINT [FK_TB_EXERCICIOS_TB_USUARIOS_UsuarioId];

ALTER TABLE [TB_PAGINAS] DROP CONSTRAINT [FK_TB_PAGINAS_TB_USUARIOS_UsuarioId];

ALTER TABLE [TB_USUARIOS] DROP CONSTRAINT [PK_TB_USUARIOS];

ALTER TABLE [TB_PAGINAS] DROP CONSTRAINT [PK_TB_PAGINAS];

ALTER TABLE [TB_EXERCICIOS] DROP CONSTRAINT [PK_TB_EXERCICIOS];

EXEC sp_rename N'[TB_USUARIOS]', N'tbl_usuario', 'OBJECT';

EXEC sp_rename N'[TB_PAGINAS]', N'tbl_pagina', 'OBJECT';

EXEC sp_rename N'[TB_EXERCICIOS]', N'tbl_exercicios', 'OBJECT';

EXEC sp_rename N'[tbl_pagina].[IX_TB_PAGINAS_UsuarioId]', N'IX_tbl_pagina_UsuarioId', 'INDEX';

EXEC sp_rename N'[tbl_exercicios].[IX_TB_EXERCICIOS_UsuarioId]', N'IX_tbl_exercicios_UsuarioId', 'INDEX';

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_usuario]') AND [c].[name] = N'Username');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [tbl_usuario] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [tbl_usuario] ALTER COLUMN [Username] varchar(1500) NOT NULL;

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_usuario]') AND [c].[name] = N'Perfil');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [tbl_usuario] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [tbl_usuario] ALTER COLUMN [Perfil] varchar(1500) NULL;
ALTER TABLE [tbl_usuario] ADD DEFAULT 'Utilizador' FOR [Perfil];

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_usuario]') AND [c].[name] = N'Email');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [tbl_usuario] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [tbl_usuario] ALTER COLUMN [Email] varchar(1500) NULL;

ALTER TABLE [tbl_usuario] ADD [codDiarioUsuario] int NOT NULL DEFAULT 0;

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_pagina]') AND [c].[name] = N'tituloPagina');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [tbl_pagina] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [tbl_pagina] ALTER COLUMN [tituloPagina] varchar(1500) NOT NULL;

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_pagina]') AND [c].[name] = N'temaPagina');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [tbl_pagina] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [tbl_pagina] ALTER COLUMN [temaPagina] varchar(1500) NOT NULL;

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_pagina]') AND [c].[name] = N'contPagina');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [tbl_pagina] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [tbl_pagina] ALTER COLUMN [contPagina] varchar(1500) NOT NULL;

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_exercicios]') AND [c].[name] = N'descricao');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [tbl_exercicios] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [tbl_exercicios] ALTER COLUMN [descricao] varchar(1500) NOT NULL;

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tbl_exercicios]') AND [c].[name] = N'atividade');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [tbl_exercicios] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [tbl_exercicios] ALTER COLUMN [atividade] varchar(1500) NOT NULL;

ALTER TABLE [tbl_usuario] ADD CONSTRAINT [PK_tbl_usuario] PRIMARY KEY ([Id]);

ALTER TABLE [tbl_pagina] ADD CONSTRAINT [PK_tbl_pagina] PRIMARY KEY ([Id]);

ALTER TABLE [tbl_exercicios] ADD CONSTRAINT [PK_tbl_exercicios] PRIMARY KEY ([Id]);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'UsuarioId', N'atividade', N'dataTermino', N'descricao', N'quantidade', N'relogio', N'tempo') AND [object_id] = OBJECT_ID(N'[tbl_exercicios]'))
    SET IDENTITY_INSERT [tbl_exercicios] ON;
INSERT INTO [tbl_exercicios] ([Id], [UsuarioId], [atividade], [dataTermino], [descricao], [quantidade], [relogio], [tempo])
VALUES (1, 1, 'Respiração', '2025-09-29T22:09:49.5434472-03:00', 'Eu adoro respirar', 1, 5.0E0, '00:04:59.9999995');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'UsuarioId', N'atividade', N'dataTermino', N'descricao', N'quantidade', N'relogio', N'tempo') AND [object_id] = OBJECT_ID(N'[tbl_exercicios]'))
    SET IDENTITY_INSERT [tbl_exercicios] OFF;

UPDATE [tbl_pagina] SET [dtCriacaoPagina] = '2025-09-29T22:04:49.5407935-03:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


UPDATE [tbl_usuario] SET [PasswordHash] = 0x201393C43D3FB245B17EC5F72135A041E57D98D0E2A82E696CB949ECFF35359447B6E4202E8C0EBC2856A516A659144129E726AFDF8F008053AB5A34EA934C26, [PasswordSalt] = 0x3327047B7A5FC8C1AF3285DBFBFDCBAAD308B5394CE7880C1312A13ADBA7F7ABFDC757FC34999DF2ABE4C98994D5B3759F490F1539254144FC91C4D13832B8EADF9FFD29C6B0F496BBEAB48EF7A0243237A3C2072459CC5F05825B5455C4C8368C534A84136DAA33290FCAF95A710BED5D0821CD3EB765E3C7C6F3DBD3C4E35A, [codDiarioUsuario] = 0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


ALTER TABLE [tbl_exercicios] ADD CONSTRAINT [FK_tbl_exercicios_tbl_usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [tbl_usuario] ([Id]) ON DELETE CASCADE;

ALTER TABLE [tbl_pagina] ADD CONSTRAINT [FK_tbl_pagina_tbl_usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [tbl_usuario] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250930010452_PaginaExercicioMigration', N'9.0.6');

COMMIT;
GO

