

create schema dxsecurity authorization dbo
go


create table dxsecurity.account (
	ID int not null identity(1,1) constraint pk_security_account_id primary key
	,UID uniqueidentifier not null
	,displayName nchar(50) not null
	, createDT datetimeoffset not null constraint def_security_account_createdt default getutcdate()
	, enabled tinyint not null constraint def_security_account_enabled default 1
	,rv rowversion
)

create table dxsecurity.credential (
	ID int not null identity(1,1) constraint pk_security_credential_id primary key
	, accountID int not null constraint fk_security_credential_account
		foreign key references dxsecurity.account ( ID )
	, token nvarchar(255) null
	, credential nvarchar(1000) null
	, salt nvarchar(255) null
	, provider nchar(100) not null
	, createDT datetimeoffset not null constraint def_security_credential_createdt default getutcdate()
	, expireDT datetimeoffset null
	, renewDT datetimeoffset null
	, attempts int not null constraint def_security_credential_attempts default 0
	, enabled tinyint not null constraint def_security_credential_enabled default 1
	,rv rowversion
)
alter table dxsecurity.credential add constraint uq_security_credential_token unique (token)



delcare @id int; 
insert into dxsecurity.account (uid, displayName, createDT, enabled) values (NEWID(), 'Frosty', GETUTCDATE(), 1);
set @id = SCOPE_IDENTITY();
insert into dxsecurity.credential (accountid, token, credential, provider) values (@id, 'MagicHat', 'ImNotAFairyTale', 'stackfoodemo')

select * from dxsecurity.account;
select * from dxsecurity.credential;