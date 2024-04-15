USE [Supermarket]
GO

/****** Object:  Table [dbo].[tbl_accttr]    Script Date: 18-02-2024 1:19:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[sdepartments](
	[dep_id] [nvarchar](50) NULL,
	[dep] [nvarchar](50) NULL,
	[upd] [nvarchar](50) NULL,
	[branch_ids] [nvarchar](50) NULL,
	[createddate] [datetime] NULL,
	[ids_dep] [int],
	[sort_order] [int],
	[item_button_height] [int],
	[item_button_color] [nvarchar](150) NULL,
	[item_button_fontsize] [int],
	[prd_item_button_height] [int],
	[prd_item_button_color] [nvarchar](150) NULL,
	[prd_item_button_fontsize] [int],
	[deleteStatus] [int],
	[dept_img] [nvarchar](150) NULL,
	[active_status] [int],
	[parrent_dep_id] [nvarchar](150) NULL,
	[pos_prefix] [nvarchar](150) NULL,
	[item_forecolor] [nvarchar](150) NULL,
	[prd_forecolor] [nvarchar](150) NULL,
	[guid] [nvarchar](550) NULL,
	[p_guid] [nvarchar](150) NULL,
	[triger_status] [int]) 
	
	 ON [PRIMARY]
GO

