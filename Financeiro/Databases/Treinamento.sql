/*------------------------------------------------------------*/
/*   Esquema para a criação do banco de dados da aplicação    */
/*                         Treinamento                        */
/*------------------------------------------------------------*/

/*------------------------------------------------------------*/
/*                     Exclusão de Triggers                   */
/*------------------------------------------------------------*/

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_GROUP_RULE') AND sysstat & 0xf = 11)
ALTER TABLE [TB_LOGIN_RULE]
DROP CONSTRAINT [TB_LOGIN_GROUP_RULE]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_GROUP_USER') AND sysstat & 0xf = 11)
ALTER TABLE [TB_LOGIN_USER]
DROP CONSTRAINT [TB_LOGIN_GROUP_USER]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_USER_TOKEN') AND sysstat & 0xf = 11)
ALTER TABLE [TB_LOGIN_TOKEN]
DROP CONSTRAINT [TB_LOGIN_USER_TOKEN]
GO

/*------------------------------------------------------------*/
/*                     Exclusão de Views                      */
/*------------------------------------------------------------*/

/*------------------------------------------------------------*/
/*                     Exclusão de tabelas                    */
/*------------------------------------------------------------*/

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('SYS~Sequencial') AND sysstat & 0xf = 3)
DROP TABLE [SYS~Sequencial]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_CARTEIRA') AND sysstat & 0xf = 3)
DROP TABLE [TB_CARTEIRA]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_CENTRO_DE_CUSTO') AND sysstat & 0xf = 3)
DROP TABLE [TB_CENTRO_DE_CUSTO]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_CONFIGURACOES') AND sysstat & 0xf = 3)
DROP TABLE [TB_CONFIGURACOES]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_CONTA') AND sysstat & 0xf = 3)
DROP TABLE [TB_CONTA]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_CORRENTISTA') AND sysstat & 0xf = 3)
DROP TABLE [TB_CORRENTISTA]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_GRUPO_CONTA') AND sysstat & 0xf = 3)
DROP TABLE [TB_GRUPO_CONTA]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_GROUP') AND sysstat & 0xf = 3)
DROP TABLE [TB_LOGIN_GROUP]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_RULE') AND sysstat & 0xf = 3)
DROP TABLE [TB_LOGIN_RULE]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_TOKEN') AND sysstat & 0xf = 3)
DROP TABLE [TB_LOGIN_TOKEN]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_USER') AND sysstat & 0xf = 3)
DROP TABLE [TB_LOGIN_USER]
GO

/*------------------------------------------------------------*/
/*                     Criação das tabelas                    */
/*------------------------------------------------------------*/

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*       SYS~Sequencial       */
/*------------------------------------------------------------*/

 CREATE TABLE [SYS~Sequencial](
	[PW~Projeto]                           varchar (10)         NOT NULL,
	[SYS~Tabela]                           varchar (30)         NOT NULL,
	[SYS~Campo]                            varchar (30)         NOT NULL,
	[SYS~Valor]                            varchar (50)         NOT NULL,
	[SYS~ValorAnterior]                    varchar (50)         NOT NULL,
	[SYS~Estacao]                          varchar (50)         NOT NULL,
	[SYS~Identificacao]                    varchar (30)         NOT NULL,
	[SYS~Pendentes]                        int                  DEFAULT 0 NOT NULL
		CONSTRAINT [Chave sequencial] PRIMARY KEY CLUSTERED
		(
			[SYS~Tabela],[SYS~Campo]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*     TB_CARTEIRA     */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_CARTEIRA](
	[CAR_ID]                               bigint               IDENTITY(1,1) NOT NULL,
	[CAR_NOME]                             nvarchar (100)       NOT NULL
		CONSTRAINT [PK_TB_CARTEIRA] PRIMARY KEY CLUSTERED
		(
			[CAR_ID]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*         TB_CENTRO_DE_CUSTO         */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_CENTRO_DE_CUSTO](
	[CC_ID]                                bigint               IDENTITY(1,1) NOT NULL,
	[CC_NOME]                              nvarchar (100)       NOT NULL
		CONSTRAINT [PK_TB_CENTRO_DE_CUSTO] PRIMARY KEY CLUSTERED
		(
			[CC_ID]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*        TB_CONFIGURACOES        */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_CONFIGURACOES](
	[CONFIG_ID]                            bigint               IDENTITY(1,1) NOT NULL,
	[CONFIG_CONTA_TRANSF_PADRAO]           bigint               NOT NULL,
	[CONFIG_CARTEIRA_PADRAO]               bigint               NULL
		CONSTRAINT [PK_TB_CONFIGURACOES] PRIMARY KEY NONCLUSTERED
		(
			[CONFIG_ID]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*    TB_CONTA    */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_CONTA](
	[CT_ID]                                varchar (10)         NOT NULL,
	[CT_NOME]                              nvarchar (100)       NOT NULL,
	[GC_ID]                                bigint               DEFAULT 0 NOT NULL
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*       TB_CORRENTISTA       */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_CORRENTISTA](
	[COR_ID]                               bigint               IDENTITY(1,1) NOT NULL,
	[COR_NOME]                             nvarchar (100)       NOT NULL,
	[COR_CPF]                              varchar (14)         NULL,
	[COR_FISICA]                           bit                  NOT NULL,
	[COR_CNPJ]                             varchar (18)         NULL,
	[COR_JURIDICA]                         bit                  NOT NULL,
	[COR_ENDERECO]                         varchar (100)        NULL,
	[COR_BAIRRO]                           varchar (100)        NULL,
	[COR_CIDADE]                           varchar (100)        NULL,
	[COR_EMAIL]                            varchar (100)        NULL
		CONSTRAINT [PK_TB_CORRENTISTA] PRIMARY KEY CLUSTERED
		(
			[COR_ID]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*       TB_GRUPO_CONTA       */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_GRUPO_CONTA](
	[GC_ID]                                bigint               IDENTITY(1,1) NOT NULL,
	[GC_NOME]                              nvarchar (100)       NOT NULL
		CONSTRAINT [PK_TB_GRUPO_CONTA] PRIMARY KEY CLUSTERED
		(
			[GC_ID]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*       TB_LOGIN_GROUP       */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_LOGIN_GROUP](
	[LOGIN_GROUP_NAME]                     varchar (60)         NOT NULL,
	[LOGIN_GROUP_IS_ADMIN]                 bit                  NOT NULL
		CONSTRAINT [LOGIN_GROUP_PK] PRIMARY KEY CLUSTERED
		(
			[LOGIN_GROUP_NAME]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*      TB_LOGIN_RULE      */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_LOGIN_RULE](
	[LOGIN_RULE_PROJECT]                   varchar (8)          NOT NULL,
	[LOGIN_GROUP_NAME]                     varchar (60)         NOT NULL,
	[LOGIN_RULE_OBJECT]                    varchar (100)        NOT NULL,
	[LOGIN_RULE_PERMISSIONS]               varchar (100)        NOT NULL
		CONSTRAINT [LOGIN_RULE_PK] PRIMARY KEY CLUSTERED
		(
			[LOGIN_RULE_PROJECT],[LOGIN_GROUP_NAME],[LOGIN_RULE_OBJECT]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*       TB_LOGIN_TOKEN       */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_LOGIN_TOKEN](
	[LOGIN_TOKEN_ID]                       varchar (36)         NOT NULL,
	[LOGIN_USER_LOGIN]                     varchar (40)         NOT NULL,
	[LOGIN_TOKEN_ACQUIRED]                 datetime             NOT NULL,
	[LOGIN_TOKEN_EXPIRATION]               datetime             NOT NULL
		CONSTRAINT [LOGIN_TOKEN_PK] PRIMARY KEY CLUSTERED
		(
			[LOGIN_TOKEN_ID]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*      TB_LOGIN_USER      */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_LOGIN_USER](
	[LOGIN_GROUP_NAME]                     varchar (60)         NOT NULL,
	[LOGIN_USER_LOGIN]                     varchar (40)         NOT NULL,
	[LOGIN_USER_PASSWORD]                  varchar (40)         NOT NULL,
	[LOGIN_USER_NAME]                      varchar (60)         NOT NULL,
	[LOGIN_USER_OBS]                       text                 NOT NULL
		CONSTRAINT [LOGIN_USER_PK] PRIMARY KEY CLUSTERED
		(
			[LOGIN_USER_LOGIN]
		) WITH FILLFACTOR = 90
)
GO

ALTER TABLE [TB_LOGIN_RULE] ADD CONSTRAINT [TB_LOGIN_GROUP_RULE]
	FOREIGN KEY
		([LOGIN_GROUP_NAME])
	REFERENCES [TB_LOGIN_GROUP]
		([LOGIN_GROUP_NAME])
	ON DELETE CASCADE
GO

ALTER TABLE [TB_LOGIN_USER] ADD CONSTRAINT [TB_LOGIN_GROUP_USER]
	FOREIGN KEY
		([LOGIN_GROUP_NAME])
	REFERENCES [TB_LOGIN_GROUP]
		([LOGIN_GROUP_NAME])
	ON DELETE CASCADE
GO

ALTER TABLE [TB_LOGIN_TOKEN] ADD CONSTRAINT [TB_LOGIN_USER_TOKEN]
	FOREIGN KEY
		([LOGIN_USER_LOGIN])
	REFERENCES [TB_LOGIN_USER]
		([LOGIN_USER_LOGIN])
	ON DELETE CASCADE
	ON UPDATE CASCADE
GO

