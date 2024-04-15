USE [Supermarket]
GO

/****** Object:  Table [dbo].[tbl_accttr]    Script Date: 18-02-2024 1:19:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[sprod](
	
	[prd_id] [nvarchar](50) NULL, 
	[upc_code][nvarchar](50) NULL, 
	[prd_desc][nvarchar](250) NULL, 
	[cost_p] [numeric](18, 4) NULL, 
	[unit_m_name] [nvarchar](50) NULL,  
	[dep_id][nvarchar](150) NULL,  
	[dep][nvarchar](250) NULL, 
	[unit_m][numeric](18, 0) NULL, 
	[p_qty][numeric](18, 4) NULL,
	[sale_p][numeric](18, 4) NULL,
	[upd][nvarchar](250) NULL,  
	[ids][numeric](18, 0) NULL,
	[vend_id] [nvarchar](50) NULL,
	[vend][nvarchar](50) NULL,  
	[createddate] [datetime] NULL, 
	[deleteStatus][int], 
	[taxPercentage][numeric](18, 2) NULL, 
	[prod_img][nvarchar](50) NULL, 
	[active_status][int], 
	[prod_type][int],
	[price_edit][int],
	[ids_shelf][int], 
	[weighing_status][int], 
	[hsn_code][nvarchar](50) NULL, 
	[weighing_no][int], 
	[mrp][numeric](18, 4) NULL, 
	[pos_prefix][nvarchar](50) NULL, 
	[add_serialno][int],
	[show_stock][int], 
	[guid][nvarchar](250) NULL, 
	[prd_details][int], 
	[exempt_def_tax][nvarchar](50) NULL, 
	[lg_as2][int], 
	[exempt_reason][nvarchar](50) NULL, 
	[zero_tax] [nvarchar](50) NULL,
	[zero_tax_reason] [nvarchar](50) NULL,
	[dep_guid][nvarchar](250) NULL, 
	[vend_guid][nvarchar](250) NULL, 
	[unit_guid][nvarchar](250) NULL,
	[triger_status][int], 
	[exp_prod][int],
	[avg_cost][numeric](18, 4) NULL) 
	
	
	 ON [PRIMARY]
GO

