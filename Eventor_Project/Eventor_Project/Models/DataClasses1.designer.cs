﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eventor_Project.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Eventor_Project.Models.CurrentContext")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertPlaces(Places instance);
    partial void UpdatePlaces(Places instance);
    partial void DeletePlaces(Places instance);
    partial void InsertRoles(Roles instance);
    partial void UpdateRoles(Roles instance);
    partial void DeleteRoles(Roles instance);
    partial void InsertUserRoles(UserRoles instance);
    partial void UpdateUserRoles(UserRoles instance);
    partial void DeleteUserRoles(UserRoles instance);
    partial void InsertUsers(Users instance);
    partial void UpdateUsers(Users instance);
    partial void DeleteUsers(Users instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Eventor_Project_Models_CurrentContextConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Places> Places
		{
			get
			{
				return this.GetTable<Places>();
			}
		}
		
		public System.Data.Linq.Table<Roles> Roles
		{
			get
			{
				return this.GetTable<Roles>();
			}
		}
		
		public System.Data.Linq.Table<UserRoles> UserRoles
		{
			get
			{
				return this.GetTable<UserRoles>();
			}
		}
		
		public System.Data.Linq.Table<Users> Users
		{
			get
			{
				return this.GetTable<Users>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Places")]
	public partial class Places : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PlaceId;
		
		private string _PlaceInfo;
		
		private EntitySet<Users> _Users;
		
		private EntitySet<Users> _Users1;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPlaceIdChanging(int value);
    partial void OnPlaceIdChanged();
    partial void OnPlaceInfoChanging(string value);
    partial void OnPlaceInfoChanged();
    #endregion
		
		public Places()
		{
			this._Users = new EntitySet<Users>(new Action<Users>(this.attach_Users), new Action<Users>(this.detach_Users));
			this._Users1 = new EntitySet<Users>(new Action<Users>(this.attach_Users1), new Action<Users>(this.detach_Users1));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlaceId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PlaceId
		{
			get
			{
				return this._PlaceId;
			}
			set
			{
				if ((this._PlaceId != value))
				{
					this.OnPlaceIdChanging(value);
					this.SendPropertyChanging();
					this._PlaceId = value;
					this.SendPropertyChanged("PlaceId");
					this.OnPlaceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlaceInfo", DbType="NVarChar(MAX)")]
		public string PlaceInfo
		{
			get
			{
				return this._PlaceInfo;
			}
			set
			{
				if ((this._PlaceInfo != value))
				{
					this.OnPlaceInfoChanging(value);
					this.SendPropertyChanging();
					this._PlaceInfo = value;
					this.SendPropertyChanged("PlaceInfo");
					this.OnPlaceInfoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Places_Users", Storage="_Users", ThisKey="PlaceId", OtherKey="PlaceOfLiving_PlaceId")]
		public EntitySet<Users> Users
		{
			get
			{
				return this._Users;
			}
			set
			{
				this._Users.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Places_Users1", Storage="_Users1", ThisKey="PlaceId", OtherKey="PlaceOfStudy_PlaceId")]
		public EntitySet<Users> Users1
		{
			get
			{
				return this._Users1;
			}
			set
			{
				this._Users1.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Users(Users entity)
		{
			this.SendPropertyChanging();
			entity.Places = this;
		}
		
		private void detach_Users(Users entity)
		{
			this.SendPropertyChanging();
			entity.Places = null;
		}
		
		private void attach_Users1(Users entity)
		{
			this.SendPropertyChanging();
			entity.Places1 = this;
		}
		
		private void detach_Users1(Users entity)
		{
			this.SendPropertyChanging();
			entity.Places1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Roles")]
	public partial class Roles : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _RoleId;
		
		private string _Code;
		
		private string _Name;
		
		private EntitySet<UserRoles> _UserRoles;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRoleIdChanging(int value);
    partial void OnRoleIdChanged();
    partial void OnCodeChanging(string value);
    partial void OnCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Roles()
		{
			this._UserRoles = new EntitySet<UserRoles>(new Action<UserRoles>(this.attach_UserRoles), new Action<UserRoles>(this.detach_UserRoles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int RoleId
		{
			get
			{
				return this._RoleId;
			}
			set
			{
				if ((this._RoleId != value))
				{
					this.OnRoleIdChanging(value);
					this.SendPropertyChanging();
					this._RoleId = value;
					this.SendPropertyChanged("RoleId");
					this.OnRoleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", DbType="NVarChar(MAX)")]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Roles_UserRoles", Storage="_UserRoles", ThisKey="RoleId", OtherKey="RoleId")]
		public EntitySet<UserRoles> UserRoles
		{
			get
			{
				return this._UserRoles;
			}
			set
			{
				this._UserRoles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_UserRoles(UserRoles entity)
		{
			this.SendPropertyChanging();
			entity.Roles = this;
		}
		
		private void detach_UserRoles(UserRoles entity)
		{
			this.SendPropertyChanging();
			entity.Roles = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserRoles")]
	public partial class UserRoles : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserRoleId;
		
		private int _UserId;
		
		private int _RoleId;
		
		private EntityRef<Roles> _Roles;
		
		private EntityRef<Users> _Users;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserRoleIdChanging(int value);
    partial void OnUserRoleIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnRoleIdChanging(int value);
    partial void OnRoleIdChanged();
    #endregion
		
		public UserRoles()
		{
			this._Roles = default(EntityRef<Roles>);
			this._Users = default(EntityRef<Users>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserRoleId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserRoleId
		{
			get
			{
				return this._UserRoleId;
			}
			set
			{
				if ((this._UserRoleId != value))
				{
					this.OnUserRoleIdChanging(value);
					this.SendPropertyChanging();
					this._UserRoleId = value;
					this.SendPropertyChanged("UserRoleId");
					this.OnUserRoleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Users.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleId", DbType="Int NOT NULL")]
		public int RoleId
		{
			get
			{
				return this._RoleId;
			}
			set
			{
				if ((this._RoleId != value))
				{
					if (this._Roles.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRoleIdChanging(value);
					this.SendPropertyChanging();
					this._RoleId = value;
					this.SendPropertyChanged("RoleId");
					this.OnRoleIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Roles_UserRoles", Storage="_Roles", ThisKey="RoleId", OtherKey="RoleId", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Roles Roles
		{
			get
			{
				return this._Roles.Entity;
			}
			set
			{
				Roles previousValue = this._Roles.Entity;
				if (((previousValue != value) 
							|| (this._Roles.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Roles.Entity = null;
						previousValue.UserRoles.Remove(this);
					}
					this._Roles.Entity = value;
					if ((value != null))
					{
						value.UserRoles.Add(this);
						this._RoleId = value.RoleId;
					}
					else
					{
						this._RoleId = default(int);
					}
					this.SendPropertyChanged("Roles");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_UserRoles", Storage="_Users", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Users Users
		{
			get
			{
				return this._Users.Entity;
			}
			set
			{
				Users previousValue = this._Users.Entity;
				if (((previousValue != value) 
							|| (this._Users.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Users.Entity = null;
						previousValue.UserRoles.Remove(this);
					}
					this._Users.Entity = value;
					if ((value != null))
					{
						value.UserRoles.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("Users");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class Users : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _Email;
		
		private string _Nickname;
		
		private string _Name;
		
		private string _Surname;
		
		private string _Patronymic;
		
		private int _Sex;
		
		private System.Nullable<int> _PlaceOfStudy_PlaceId;
		
		private System.Nullable<int> _PlaceOfLiving_PlaceId;
		
		private string _ContactEmail;
		
		private string _PhoneNumber;
		
		private EntitySet<UserRoles> _UserRoles;
		
		private EntityRef<Places> _Places;
		
		private EntityRef<Places> _Places1;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnNicknameChanging(string value);
    partial void OnNicknameChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnSurnameChanging(string value);
    partial void OnSurnameChanged();
    partial void OnPatronymicChanging(string value);
    partial void OnPatronymicChanged();
    partial void OnSexChanging(int value);
    partial void OnSexChanged();
    partial void OnPlaceOfStudy_PlaceIdChanging(System.Nullable<int> value);
    partial void OnPlaceOfStudy_PlaceIdChanged();
    partial void OnPlaceOfLiving_PlaceIdChanging(System.Nullable<int> value);
    partial void OnPlaceOfLiving_PlaceIdChanged();
    partial void OnContactEmailChanging(string value);
    partial void OnContactEmailChanged();
    partial void OnPhoneNumberChanging(string value);
    partial void OnPhoneNumberChanged();
    #endregion
		
		public Users()
		{
			this._UserRoles = new EntitySet<UserRoles>(new Action<UserRoles>(this.attach_UserRoles), new Action<UserRoles>(this.detach_UserRoles));
			this._Places = default(EntityRef<Places>);
			this._Places1 = default(EntityRef<Places>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(MAX)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nickname", DbType="NVarChar(MAX)")]
		public string Nickname
		{
			get
			{
				return this._Nickname;
			}
			set
			{
				if ((this._Nickname != value))
				{
					this.OnNicknameChanging(value);
					this.SendPropertyChanging();
					this._Nickname = value;
					this.SendPropertyChanged("Nickname");
					this.OnNicknameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surname", DbType="NVarChar(MAX)")]
		public string Surname
		{
			get
			{
				return this._Surname;
			}
			set
			{
				if ((this._Surname != value))
				{
					this.OnSurnameChanging(value);
					this.SendPropertyChanging();
					this._Surname = value;
					this.SendPropertyChanged("Surname");
					this.OnSurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Patronymic", DbType="NVarChar(MAX)")]
		public string Patronymic
		{
			get
			{
				return this._Patronymic;
			}
			set
			{
				if ((this._Patronymic != value))
				{
					this.OnPatronymicChanging(value);
					this.SendPropertyChanging();
					this._Patronymic = value;
					this.SendPropertyChanged("Patronymic");
					this.OnPatronymicChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sex", DbType="Int NOT NULL")]
		public int Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				if ((this._Sex != value))
				{
					this.OnSexChanging(value);
					this.SendPropertyChanging();
					this._Sex = value;
					this.SendPropertyChanged("Sex");
					this.OnSexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlaceOfStudy_PlaceId", DbType="Int")]
		public System.Nullable<int> PlaceOfStudy_PlaceId
		{
			get
			{
				return this._PlaceOfStudy_PlaceId;
			}
			set
			{
				if ((this._PlaceOfStudy_PlaceId != value))
				{
					if (this._Places1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPlaceOfStudy_PlaceIdChanging(value);
					this.SendPropertyChanging();
					this._PlaceOfStudy_PlaceId = value;
					this.SendPropertyChanged("PlaceOfStudy_PlaceId");
					this.OnPlaceOfStudy_PlaceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlaceOfLiving_PlaceId", DbType="Int")]
		public System.Nullable<int> PlaceOfLiving_PlaceId
		{
			get
			{
				return this._PlaceOfLiving_PlaceId;
			}
			set
			{
				if ((this._PlaceOfLiving_PlaceId != value))
				{
					if (this._Places.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPlaceOfLiving_PlaceIdChanging(value);
					this.SendPropertyChanging();
					this._PlaceOfLiving_PlaceId = value;
					this.SendPropertyChanged("PlaceOfLiving_PlaceId");
					this.OnPlaceOfLiving_PlaceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContactEmail", DbType="NVarChar(MAX)")]
		public string ContactEmail
		{
			get
			{
				return this._ContactEmail;
			}
			set
			{
				if ((this._ContactEmail != value))
				{
					this.OnContactEmailChanging(value);
					this.SendPropertyChanging();
					this._ContactEmail = value;
					this.SendPropertyChanged("ContactEmail");
					this.OnContactEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhoneNumber", DbType="NVarChar(MAX)")]
		public string PhoneNumber
		{
			get
			{
				return this._PhoneNumber;
			}
			set
			{
				if ((this._PhoneNumber != value))
				{
					this.OnPhoneNumberChanging(value);
					this.SendPropertyChanging();
					this._PhoneNumber = value;
					this.SendPropertyChanged("PhoneNumber");
					this.OnPhoneNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_UserRoles", Storage="_UserRoles", ThisKey="UserId", OtherKey="UserId")]
		public EntitySet<UserRoles> UserRoles
		{
			get
			{
				return this._UserRoles;
			}
			set
			{
				this._UserRoles.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Places_Users", Storage="_Places", ThisKey="PlaceOfLiving_PlaceId", OtherKey="PlaceId", IsForeignKey=true)]
		public Places Places
		{
			get
			{
				return this._Places.Entity;
			}
			set
			{
				Places previousValue = this._Places.Entity;
				if (((previousValue != value) 
							|| (this._Places.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Places.Entity = null;
						previousValue.Users.Remove(this);
					}
					this._Places.Entity = value;
					if ((value != null))
					{
						value.Users.Add(this);
						this._PlaceOfLiving_PlaceId = value.PlaceId;
					}
					else
					{
						this._PlaceOfLiving_PlaceId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Places");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Places_Users1", Storage="_Places1", ThisKey="PlaceOfStudy_PlaceId", OtherKey="PlaceId", IsForeignKey=true)]
		public Places Places1
		{
			get
			{
				return this._Places1.Entity;
			}
			set
			{
				Places previousValue = this._Places1.Entity;
				if (((previousValue != value) 
							|| (this._Places1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Places1.Entity = null;
						previousValue.Users1.Remove(this);
					}
					this._Places1.Entity = value;
					if ((value != null))
					{
						value.Users1.Add(this);
						this._PlaceOfStudy_PlaceId = value.PlaceId;
					}
					else
					{
						this._PlaceOfStudy_PlaceId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Places1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_UserRoles(UserRoles entity)
		{
			this.SendPropertyChanging();
			entity.Users = this;
		}
		
		private void detach_UserRoles(UserRoles entity)
		{
			this.SendPropertyChanging();
			entity.Users = null;
		}
	}
}
#pragma warning restore 1591
