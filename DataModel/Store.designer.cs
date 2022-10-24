﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="OnlineShop")]
	public partial class StoreDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public StoreDataContext() : 
				base(global::DataModel.Properties.Settings.Default.OnlineShopConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public StoreDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StoreDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StoreDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StoreDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_GET_ORDER_BY_SHIPNAME")]
		public ISingleResult<SP_GET_ORDER_BY_SHIPNAMEResult> SP_GET_ORDER_BY_SHIPNAME([global::System.Data.Linq.Mapping.ParameterAttribute(Name="SHIP_NAME", DbType="NVarChar(100)")] string sHIP_NAME)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), sHIP_NAME);
			return ((ISingleResult<SP_GET_ORDER_BY_SHIPNAMEResult>)(result.ReturnValue));
		}
	}
	
	public partial class SP_GET_ORDER_BY_SHIPNAMEResult
	{
		
		private long _ID;
		
		private System.Nullable<System.DateTime> _CreatedDate;
		
		private string _ShipName;
		
		private string _ShipMobile;
		
		private string _ShipAddress;
		
		private string _ShipEmail;
		
		private long _ProductID;
		
		private System.Nullable<int> _Quantity;
		
		private System.Nullable<decimal> _Price;
		
		public SP_GET_ORDER_BY_SHIPNAMEResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="BigInt NOT NULL")]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this._CreatedDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShipName", DbType="NVarChar(50)")]
		public string ShipName
		{
			get
			{
				return this._ShipName;
			}
			set
			{
				if ((this._ShipName != value))
				{
					this._ShipName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShipMobile", DbType="VarChar(50)")]
		public string ShipMobile
		{
			get
			{
				return this._ShipMobile;
			}
			set
			{
				if ((this._ShipMobile != value))
				{
					this._ShipMobile = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShipAddress", DbType="NVarChar(50)")]
		public string ShipAddress
		{
			get
			{
				return this._ShipAddress;
			}
			set
			{
				if ((this._ShipAddress != value))
				{
					this._ShipAddress = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShipEmail", DbType="NVarChar(50)")]
		public string ShipEmail
		{
			get
			{
				return this._ShipEmail;
			}
			set
			{
				if ((this._ShipEmail != value))
				{
					this._ShipEmail = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductID", DbType="BigInt NOT NULL")]
		public long ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				if ((this._ProductID != value))
				{
					this._ProductID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int")]
		public System.Nullable<int> Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this._Quantity = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this._Price = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
