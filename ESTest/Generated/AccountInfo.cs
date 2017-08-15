
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 6/8/2016 6:12:57 PM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'AccountInfo' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(AccountInfo))]	
	[XmlType("AccountInfo")]
	public partial class AccountInfo : esAccountInfo
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new AccountInfo();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid id)
		{
			var obj = new AccountInfo();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid id, esSqlAccessType sqlAccessType)
		{
			var obj = new AccountInfo();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("AccountInfoCollection")]
	public partial class AccountInfoCollection : esAccountInfoCollection, IEnumerable<AccountInfo>
	{
		public AccountInfo FindByPrimaryKey(System.Guid id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(AccountInfo))]
		public class AccountInfoCollectionWCFPacket : esCollectionWCFPacket<AccountInfoCollection>
		{
			public static implicit operator AccountInfoCollection(AccountInfoCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator AccountInfoCollectionWCFPacket(AccountInfoCollection collection)
			{
				return new AccountInfoCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class AccountInfoQuery : esAccountInfoQuery
	{
		public AccountInfoQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "AccountInfoQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(AccountInfoQuery query)
		{
			return AccountInfoQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator AccountInfoQuery(string query)
		{
			return (AccountInfoQuery)AccountInfoQuery.SerializeHelper.FromXml(query, typeof(AccountInfoQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esAccountInfo : esEntity
	{
		public esAccountInfo()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid id)
		{
			AccountInfoQuery query = new AccountInfoQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to AccountInfo.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(AccountInfoMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(AccountInfoMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(AccountInfoMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AccountInfo.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? Id
		{
			get
			{
				return base.GetSystemGuid(AccountInfoMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemGuid(AccountInfoMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(AccountInfoMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AccountInfo.Age
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int16? Age
		{
			get
			{
				return base.GetSystemInt16(AccountInfoMetadata.ColumnNames.Age);
			}
			
			set
			{
				if(base.SetSystemInt16(AccountInfoMetadata.ColumnNames.Age, value))
				{
					OnPropertyChanged(AccountInfoMetadata.PropertyNames.Age);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AccountInfo.Address
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Address
		{
			get
			{
				return base.GetSystemString(AccountInfoMetadata.ColumnNames.Address);
			}
			
			set
			{
				if(base.SetSystemString(AccountInfoMetadata.ColumnNames.Address, value))
				{
					OnPropertyChanged(AccountInfoMetadata.PropertyNames.Address);
				}
			}
		}		
		
		#endregion	

		#region .str() Properties
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}
		
		public override void SetProperty(string name, object value)
		{
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "Name": this.str().Name = (string)value; break;							
						case "Id": this.str().Id = (string)value; break;							
						case "Age": this.str().Age = (string)value; break;							
						case "Address": this.str().Address = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Guid)
								this.Id = (System.Guid?)value;
								OnPropertyChanged(AccountInfoMetadata.PropertyNames.Id);
							break;
						
						case "Age":
						
							if (value == null || value is System.Int16)
								this.Age = (System.Int16?)value;
								OnPropertyChanged(AccountInfoMetadata.PropertyNames.Age);
							break;
					

						default:
							break;
					}
				}
			}
            else if (this.ContainsColumn(name))
            {
                this.SetColumn(name, value);
            }
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}		

		public esStrings str()
		{
			if (esstrings == null)
			{
				esstrings = new esStrings(this);
			}
			return esstrings;
		}

		sealed public class esStrings
		{
			public esStrings(esAccountInfo entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Name
			{
				get
				{
					System.String data = entity.Name;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Name = null;
					else entity.Name = Convert.ToString(value);
				}
			}
				
			public System.String Id
			{
				get
				{
					System.Guid? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = new Guid(value);
				}
			}
				
			public System.String Age
			{
				get
				{
					System.Int16? data = entity.Age;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Age = null;
					else entity.Age = Convert.ToInt16(value);
				}
			}
				
			public System.String Address
			{
				get
				{
					System.String data = entity.Address;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Address = null;
					else entity.Address = Convert.ToString(value);
				}
			}
			

			private esAccountInfo entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return AccountInfoMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public AccountInfoQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AccountInfoQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AccountInfoQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(AccountInfoQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private AccountInfoQuery query;		
	}



	[Serializable]
	abstract public partial class esAccountInfoCollection : esEntityCollection<AccountInfo>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AccountInfoMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "AccountInfoCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public AccountInfoQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AccountInfoQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AccountInfoQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AccountInfoQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(AccountInfoQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((AccountInfoQuery)query);
		}

		#endregion
		
		private AccountInfoQuery query;
	}



	[Serializable]
	abstract public partial class esAccountInfoQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AccountInfoMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Name": return this.Name;
				case "Id": return this.Id;
				case "Age": return this.Age;
				case "Address": return this.Address;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Name
		{
			get { return new esQueryItem(this, AccountInfoMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Id
		{
			get { return new esQueryItem(this, AccountInfoMetadata.ColumnNames.Id, esSystemType.Guid); }
		} 
		
		public esQueryItem Age
		{
			get { return new esQueryItem(this, AccountInfoMetadata.ColumnNames.Age, esSystemType.Int16); }
		} 
		
		public esQueryItem Address
		{
			get { return new esQueryItem(this, AccountInfoMetadata.ColumnNames.Address, esSystemType.String); }
		} 
		
		#endregion
		
	}



	[Serializable]
	public partial class AccountInfoMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AccountInfoMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AccountInfoMetadata.ColumnNames.Name, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = AccountInfoMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AccountInfoMetadata.ColumnNames.Id, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = AccountInfoMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AccountInfoMetadata.ColumnNames.Age, 2, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = AccountInfoMetadata.PropertyNames.Age;
			c.NumericPrecision = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AccountInfoMetadata.ColumnNames.Address, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = AccountInfoMetadata.PropertyNames.Address;
			c.CharacterMaxLength = 256;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public AccountInfoMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string Name = "Name";
			 public const string Id = "Id";
			 public const string Age = "Age";
			 public const string Address = "Address";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Name = "Name";
			 public const string Id = "Id";
			 public const string Age = "Age";
			 public const string Address = "Address";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(AccountInfoMetadata))
			{
				if(AccountInfoMetadata.mapDelegates == null)
				{
					AccountInfoMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AccountInfoMetadata.meta == null)
				{
					AccountInfoMetadata.meta = new AccountInfoMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();			


				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Id", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Age", new esTypeMap("smallint", "System.Int16"));
				meta.AddTypeMap("Address", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "AccountInfo";
				meta.Destination = "AccountInfo";
				
				meta.spInsert = "proc_AccountInfoInsert";				
				meta.spUpdate = "proc_AccountInfoUpdate";		
				meta.spDelete = "proc_AccountInfoDelete";
				meta.spLoadAll = "proc_AccountInfoLoadAll";
				meta.spLoadByPrimaryKey = "proc_AccountInfoLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AccountInfoMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
