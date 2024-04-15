USE [Supermarket]
GO

/****** Object:  Table [dbo].[tbl_ptrans]    Script Date: 28-02-2024 12:47:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_ptrans](
	[pid] [int] IDENTITY(1,1) NOT NULL,
	[barcode] [nvarchar](50) NOT NULL,
	[trtype] [nvarchar](50) NULL,
	[invno] [int] NULL,
	[trdate] [datetime] NULL,
	[oldqty] [numeric](18, 2) NULL,
	[inqty] [numeric](18, 2) NULL,
	[outqty] [numeric](18, 2) NULL,
	[balance] [numeric](18, 2) NULL,
	[price] [numeric](18, 2) NULL,
	[costprice] [numeric](18, 2) NULL,
	[oqty] [numeric](18, 2) NULL,
	[stockid] [int] NULL,
	[catid] [int] NULL,
 CONSTRAINT [PK_tbl_ptrans] PRIMARY KEY CLUSTERED 
(
	[pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_ptrans] ADD  CONSTRAINT [DF_tbl_ptrans_oldqty]  DEFAULT ((0)) FOR [oldqty]
GO

ALTER TABLE [dbo].[tbl_ptrans] ADD  CONSTRAINT [DF_tbl_ptrans_invqty]  DEFAULT ((0)) FOR [inqty]
GO

ALTER TABLE [dbo].[tbl_ptrans] ADD  CONSTRAINT [DF_tbl_ptrans_balance]  DEFAULT ((0)) FOR [balance]
GO

ALTER TABLE [dbo].[tbl_ptrans] ADD  CONSTRAINT [DF_tbl_ptrans_price]  DEFAULT ((0)) FOR [price]
GO

ALTER TABLE [dbo].[tbl_ptrans] ADD  CONSTRAINT [DF_tbl_ptrans_costprice]  DEFAULT ((0)) FOR [costprice]
GO

ALTER TABLE [dbo].[tbl_ptrans] ADD  CONSTRAINT [DF_tbl_ptrans_oqty]  DEFAULT ((0)) FOR [oqty]
GO

