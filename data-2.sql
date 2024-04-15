USE [Supermarket]
GO
/****** Object:  Table [dbo].[company]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cname] [nvarchar](50) NOT NULL,
	[caddress] [nvarchar](50) NULL,
	[cvatno] [nvarchar](50) NULL,
	[clogo] [nvarchar](50) NULL,
	[branch] [nvarchar](50) NULL,
	[vatval] [numeric](18, 0) NULL,
	[store] [nvarchar](50) NULL,
	[lang] [nvarchar](50) NULL,
	[aname] [nvarchar](50) NULL,
	[regno] [nvarchar](50) NULL,
	[vatincluded] [int] NULL,
	[custdisplay] [int] NULL,
	[printqty] [numeric](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[duplicate_table]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[duplicate_table](
	[barcode] [nvarchar](50) NULL,
	[name] [nvarchar](250) NULL,
	[description] [nvarchar](250) NULL,
	[unit] [nvarchar](50) NULL,
	[lastprice] [numeric](18, 2) NULL,
	[costprice] [numeric](18, 2) NULL,
	[rate] [numeric](18, 2) NULL,
	[category] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[barcode] [text] NULL,
	[name] [text] NULL,
	[description] [text] NULL,
	[unit] [text] NULL,
	[lastprice] [numeric](18, 0) NULL,
	[costprice] [numeric](18, 0) NULL,
	[rate] [numeric](18, 0) NULL,
	[category] [text] NULL,
	[notax] [text] NULL,
	[discper] [numeric](18, 0) NULL,
	[b1] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productbackup]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productbackup](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[barcode] [nvarchar](50) NULL,
	[name] [nvarchar](250) NULL,
	[description] [nvarchar](250) NULL,
	[unit] [nvarchar](50) NULL,
	[lastprice] [numeric](18, 2) NULL,
	[costprice] [numeric](18, 2) NULL,
	[rate] [numeric](18, 2) NULL,
	[category] [nvarchar](50) NULL,
	[notax] [varchar](50) NULL,
	[discper] [numeric](18, 2) NULL,
	[qty] [numeric](18, 0) NULL,
	[pimage] [nvarchar](50) NULL,
	[total] [numeric](18, 2) NULL,
	[subcatid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_accts]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_accts](
	[acctid] [int] IDENTITY(1,1) NOT NULL,
	[acctcode] [nvarchar](50) NULL,
	[acctname] [nvarchar](200) NULL,
	[mainacct] [int] NULL,
	[crval] [numeric](18, 2) NULL,
	[dbval] [numeric](18, 2) NULL,
	[balance] [numeric](18, 2) NULL,
	[obalance] [numeric](18, 2) NULL,
	[vatno] [nvarchar](50) NULL,
	[cregno] [nvarchar](50) NULL,
	[telno] [nvarchar](50) NULL,
	[caddress] [nvarchar](250) NULL,
	[cemail] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_accts] PRIMARY KEY CLUSTERED 
(
	[acctid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_accttr]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_accttr](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trdate] [datetime] NULL,
	[trno] [nvarchar](50) NULL,
	[trtype] [nvarchar](50) NULL,
	[payacct] [nvarchar](50) NULL,
	[acctname] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[dbval] [numeric](18, 2) NULL,
	[crval] [numeric](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_categories]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[cimage] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_deacust]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_deacust](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[vatno] [nvarchar](50) NULL,
	[contact] [nvarchar](50) NULL,
	[address] [nvarchar](250) NULL,
	[added_by] [nvarchar](50) NULL,
	[added_date] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_dexpense]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_dexpense](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[edate] [datetime] NULL,
	[description] [nvarchar](250) NULL,
	[amount] [numeric](18, 2) NULL,
	[trtype] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_items]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [text] NULL,
	[qtyhand] [float] NULL,
	[price] [float] NULL,
	[unit] [text] NULL,
 CONSTRAINT [sqlite_autoindex_tbl_items_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_mainacct]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_mainacct](
	[mid] [int] IDENTITY(1,1) NOT NULL,
	[mainname] [nvarchar](250) NULL,
 CONSTRAINT [PK_tbl_mainacct] PRIMARY KEY CLUSTERED 
(
	[mid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_mexpense]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_mexpense](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[edate] [datetime] NULL,
	[electricity] [numeric](18, 2) NULL,
	[rent] [numeric](18, 2) NULL,
	[water] [numeric](18, 2) NULL,
	[others] [numeric](18, 2) NULL,
	[total] [numeric](18, 2) NULL,
	[trtype] [nvarchar](50) NULL,
	[salary] [numeric](18, 2) NULL,
	[month] [nchar](10) NULL,
	[year] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_products]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[barcode] [nvarchar](50) NOT NULL,
	[name] [nvarchar](250) NULL,
	[description] [nvarchar](250) NULL,
	[unit] [nvarchar](50) NULL,
	[lastprice] [numeric](18, 2) NULL,
	[costprice] [numeric](18, 2) NULL,
	[rate] [numeric](18, 2) NULL,
	[category] [nvarchar](50) NULL,
	[notax] [varchar](50) NULL,
	[discper] [numeric](18, 2) NULL,
	[qty] [numeric](18, 0) NULL,
	[pimage] [nvarchar](50) NULL,
	[total] [numeric](18, 2) NULL,
	[subcatid] [int] NULL,
	[canbesold] [int] NULL,
	[canbepurchased] [int] NULL,
 CONSTRAINT [PK_tbl_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_purchase]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_purchase](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trdate] [datetime] NULL,
	[dealer] [nvarchar](50) NULL,
	[invno] [nvarchar](50) NULL,
	[invdate] [datetime] NULL,
	[subtotal] [numeric](18, 2) NULL,
	[vat] [numeric](18, 2) NULL,
	[gtotal] [numeric](18, 2) NULL,
	[added_by] [nvarchar](50) NULL,
	[discount] [numeric](18, 2) NULL,
	[trtype] [nvarchar](50) NOT NULL,
	[description] [nvarchar](150) NULL,
	[paymethod] [nvarchar](50) NULL,
	[returnno] [nchar](10) NULL,
	[branch] [nchar](50) NULL,
	[store] [nchar](50) NULL,
	[wid] [int] NULL,
 CONSTRAINT [PK_tbl_purchase] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_purchaseitems]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_purchaseitems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trid] [int] NOT NULL,
	[itemid] [nvarchar](50) NULL,
	[itemname] [nvarchar](50) NULL,
	[barcode] [nvarchar](50) NULL,
	[itemqty] [numeric](18, 2) NULL,
	[itemprice] [numeric](18, 2) NULL,
	[itemtotal] [numeric](18, 2) NULL,
	[discount] [numeric](18, 2) NULL,
	[gtotal] [numeric](18, 2) NULL,
	[balance] [numeric](18, 0) NULL,
 CONSTRAINT [PK_tbl_purchaseitems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_rate]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_rate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[exdate] [date] NULL,
	[exrate] [numeric](18, 2) NULL,
	[from_currency] [nvarchar](50) NULL,
	[to_currency] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_rate] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sales]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trdate] [datetime] NULL,
	[subtotal] [numeric](18, 2) NULL,
	[vat] [numeric](18, 2) NULL,
	[discount] [numeric](18, 2) NULL,
	[grandtotal] [numeric](18, 2) NULL,
	[paymethod] [nvarchar](50) NULL,
	[added_by] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[branch] [nvarchar](50) NULL,
	[paid] [numeric](18, 0) NULL,
	[returned] [numeric](18, 2) NULL,
	[trtype] [nvarchar](50) NOT NULL,
	[customer] [nvarchar](50) NULL,
	[Returnno] [int] NULL,
	[paycard] [numeric](18, 2) NULL,
	[sessionid] [int] NULL,
	[paycredit] [numeric](18, 2) NULL,
	[paycash] [numeric](18, 2) NULL,
	[acctcode] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sdetail]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sdetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trid] [int] NOT NULL,
	[productid] [int] NOT NULL,
	[productname] [nvarchar](50) NULL,
	[rate] [numeric](18, 2) NULL,
	[qty] [numeric](18, 2) NULL,
	[total] [numeric](18, 2) NULL,
	[discount] [numeric](18, 2) NULL,
	[gtotal] [numeric](18, 2) NULL,
	[barcode] [nvarchar](50) NULL,
	[balance] [numeric](18, 0) NULL,
	[costprice] [numeric](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sessions]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sessions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sessionname] [nvarchar](50) NULL,
	[sessionuser] [nvarchar](50) NULL,
	[startdate] [datetime] NULL,
	[enddate] [datetime] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_tbl_sessions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_stock]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[itemid] [int] NULL,
	[wid] [int] NULL,
	[quantity] [numeric](18, 0) NULL,
 CONSTRAINT [PK_tbl_stock] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_subcat]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_subcat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[categid] [int] NULL,
	[name] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_trans]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_trans](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [text] NULL,
	[deacustid] [int] NULL,
	[subtotal] [float] NULL,
	[trdate] [text] NULL,
	[grandtotal] [float] NULL,
	[vat] [float] NULL,
	[discount] [float] NULL,
	[added_by] [int] NULL,
	[wid1] [int] NULL,
	[wid2] [int] NULL,
 CONSTRAINT [sqlite_autoindex_tbl_transactions_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_transdetails]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_transdetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trid] [int] NULL,
	[itemid] [int] NULL,
	[qty] [numeric](18, 0) NULL,
	[price] [numeric](18, 2) NULL,
	[total] [numeric](18, 2) NULL,
 CONSTRAINT [PK_tbl_transdetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_users]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[usertype] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_warehouse]    Script Date: 2/18/2024 8:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_warehouse](
	[wid] [int] IDENTITY(1,1) NOT NULL,
	[wname] [nvarchar](50) NULL,
	[wlocation] [nvarchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_items] ADD  DEFAULT ((0)) FOR [qtyhand]
GO
ALTER TABLE [dbo].[tbl_items] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[tbl_purchaseitems]  WITH CHECK ADD  CONSTRAINT [FK_tbl_purchaseitems_tbl_purchase] FOREIGN KEY([trid])
REFERENCES [dbo].[tbl_purchase] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_purchaseitems] CHECK CONSTRAINT [FK_tbl_purchaseitems_tbl_purchase]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_items', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_items', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_items', @level2type=N'COLUMN',@level2name=N'qtyhand'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_items', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_items', @level2type=N'COLUMN',@level2name=N'unit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_items'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_trans', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_trans', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_trans', @level2type=N'COLUMN',@level2name=N'deacustid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_trans', @level2type=N'COLUMN',@level2name=N'subtotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_trans', @level2type=N'COLUMN',@level2name=N'trdate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_trans', @level2type=N'COLUMN',@level2name=N'grandtotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_trans', @level2type=N'COLUMN',@level2name=N'vat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_trans', @level2type=N'COLUMN',@level2name=N'discount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_trans', @level2type=N'COLUMN',@level2name=N'added_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_trans'
GO
