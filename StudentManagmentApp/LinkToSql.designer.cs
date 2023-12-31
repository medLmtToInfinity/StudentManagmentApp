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

namespace StudentManagmentApp
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SMA_db")]
	public partial class LinkToSqlDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertEtudiant(Etudiant instance);
    partial void UpdateEtudiant(Etudiant instance);
    partial void DeleteEtudiant(Etudiant instance);
    partial void InsertFiliere(Filiere instance);
    partial void UpdateFiliere(Filiere instance);
    partial void DeleteFiliere(Filiere instance);
    partial void InsertLevel(Level instance);
    partial void UpdateLevel(Level instance);
    partial void DeleteLevel(Level instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public LinkToSqlDataContext() : 
				base(global::StudentManagmentApp.Properties.Settings.Default.SMA_dbConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LinkToSqlDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinkToSqlDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinkToSqlDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinkToSqlDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Etudiant> Etudiants
		{
			get
			{
				return this.GetTable<Etudiant>();
			}
		}
		
		public System.Data.Linq.Table<Filiere> Filieres
		{
			get
			{
				return this.GetTable<Filiere>();
			}
		}
		
		public System.Data.Linq.Table<Level> Levels
		{
			get
			{
				return this.GetTable<Level>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Etudiants")]
	public partial class Etudiant : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.Nullable<int> _cne;
		
		private string _nom;
		
		private string _prenom;
		
		private char _sexe;
		
		private System.Nullable<System.DateTime> _date_naiss;
		
		private string _adress;
		
		private string _email;
		
		private string _telephone;
		
		private System.Nullable<int> _id_filiere;
		
		private System.Nullable<int> _id_level;
		
		private EntityRef<Filiere> _Filiere;
		
		private EntityRef<Level> _Level;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OncneChanging(System.Nullable<int> value);
    partial void OncneChanged();
    partial void OnnomChanging(string value);
    partial void OnnomChanged();
    partial void OnprenomChanging(string value);
    partial void OnprenomChanged();
    partial void OnsexeChanging(char value);
    partial void OnsexeChanged();
    partial void Ondate_naissChanging(System.Nullable<System.DateTime> value);
    partial void Ondate_naissChanged();
    partial void OnadressChanging(string value);
    partial void OnadressChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OntelephoneChanging(string value);
    partial void OntelephoneChanged();
    partial void Onid_filiereChanging(System.Nullable<int> value);
    partial void Onid_filiereChanged();
    partial void Onid_levelChanging(System.Nullable<int> value);
    partial void Onid_levelChanged();
    #endregion
		
		public Etudiant()
		{
			this._Filiere = default(EntityRef<Filiere>);
			this._Level = default(EntityRef<Level>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cne", DbType="Int")]
		public System.Nullable<int> cne
		{
			get
			{
				return this._cne;
			}
			set
			{
				if ((this._cne != value))
				{
					this.OncneChanging(value);
					this.SendPropertyChanging();
					this._cne = value;
					this.SendPropertyChanged("cne");
					this.OncneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nom", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string nom
		{
			get
			{
				return this._nom;
			}
			set
			{
				if ((this._nom != value))
				{
					this.OnnomChanging(value);
					this.SendPropertyChanging();
					this._nom = value;
					this.SendPropertyChanged("nom");
					this.OnnomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_prenom", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string prenom
		{
			get
			{
				return this._prenom;
			}
			set
			{
				if ((this._prenom != value))
				{
					this.OnprenomChanging(value);
					this.SendPropertyChanging();
					this._prenom = value;
					this.SendPropertyChanged("prenom");
					this.OnprenomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sexe", DbType="Char(1) NOT NULL")]
		public char sexe
		{
			get
			{
				return this._sexe;
			}
			set
			{
				if ((this._sexe != value))
				{
					this.OnsexeChanging(value);
					this.SendPropertyChanging();
					this._sexe = value;
					this.SendPropertyChanged("sexe");
					this.OnsexeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_naiss", DbType="Date")]
		public System.Nullable<System.DateTime> date_naiss
		{
			get
			{
				return this._date_naiss;
			}
			set
			{
				if ((this._date_naiss != value))
				{
					this.Ondate_naissChanging(value);
					this.SendPropertyChanging();
					this._date_naiss = value;
					this.SendPropertyChanged("date_naiss");
					this.Ondate_naissChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_adress", DbType="VarChar(255)")]
		public string adress
		{
			get
			{
				return this._adress;
			}
			set
			{
				if ((this._adress != value))
				{
					this.OnadressChanging(value);
					this.SendPropertyChanging();
					this._adress = value;
					this.SendPropertyChanged("adress");
					this.OnadressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(255)")]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_telephone", DbType="VarChar(15)")]
		public string telephone
		{
			get
			{
				return this._telephone;
			}
			set
			{
				if ((this._telephone != value))
				{
					this.OntelephoneChanging(value);
					this.SendPropertyChanging();
					this._telephone = value;
					this.SendPropertyChanged("telephone");
					this.OntelephoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_filiere", DbType="Int")]
		public System.Nullable<int> id_filiere
		{
			get
			{
				return this._id_filiere;
			}
			set
			{
				if ((this._id_filiere != value))
				{
					if (this._Filiere.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_filiereChanging(value);
					this.SendPropertyChanging();
					this._id_filiere = value;
					this.SendPropertyChanged("id_filiere");
					this.Onid_filiereChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_level", DbType="Int")]
		public System.Nullable<int> id_level
		{
			get
			{
				return this._id_level;
			}
			set
			{
				if ((this._id_level != value))
				{
					if (this._Level.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_levelChanging(value);
					this.SendPropertyChanging();
					this._id_level = value;
					this.SendPropertyChanged("id_level");
					this.Onid_levelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Filiere_Etudiant", Storage="_Filiere", ThisKey="id_filiere", OtherKey="id", IsForeignKey=true)]
		public Filiere Filiere
		{
			get
			{
				return this._Filiere.Entity;
			}
			set
			{
				Filiere previousValue = this._Filiere.Entity;
				if (((previousValue != value) 
							|| (this._Filiere.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Filiere.Entity = null;
						previousValue.Etudiants.Remove(this);
					}
					this._Filiere.Entity = value;
					if ((value != null))
					{
						value.Etudiants.Add(this);
						this._id_filiere = value.id;
					}
					else
					{
						this._id_filiere = default(Nullable<int>);
					}
					this.SendPropertyChanged("Filiere");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Level_Etudiant", Storage="_Level", ThisKey="id_level", OtherKey="id", IsForeignKey=true)]
		public Level Level
		{
			get
			{
				return this._Level.Entity;
			}
			set
			{
				Level previousValue = this._Level.Entity;
				if (((previousValue != value) 
							|| (this._Level.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Level.Entity = null;
						previousValue.Etudiants.Remove(this);
					}
					this._Level.Entity = value;
					if ((value != null))
					{
						value.Etudiants.Add(this);
						this._id_level = value.id;
					}
					else
					{
						this._id_level = default(Nullable<int>);
					}
					this.SendPropertyChanged("Level");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Filieres")]
	public partial class Filiere : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _Nom_filiere;
		
		private EntitySet<Etudiant> _Etudiants;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnNom_filiereChanging(string value);
    partial void OnNom_filiereChanged();
    #endregion
		
		public Filiere()
		{
			this._Etudiants = new EntitySet<Etudiant>(new Action<Etudiant>(this.attach_Etudiants), new Action<Etudiant>(this.detach_Etudiants));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nom_filiere", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Nom_filiere
		{
			get
			{
				return this._Nom_filiere;
			}
			set
			{
				if ((this._Nom_filiere != value))
				{
					this.OnNom_filiereChanging(value);
					this.SendPropertyChanging();
					this._Nom_filiere = value;
					this.SendPropertyChanged("Nom_filiere");
					this.OnNom_filiereChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Filiere_Etudiant", Storage="_Etudiants", ThisKey="id", OtherKey="id_filiere")]
		public EntitySet<Etudiant> Etudiants
		{
			get
			{
				return this._Etudiants;
			}
			set
			{
				this._Etudiants.Assign(value);
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
		
		private void attach_Etudiants(Etudiant entity)
		{
			this.SendPropertyChanging();
			entity.Filiere = this;
		}
		
		private void detach_Etudiants(Etudiant entity)
		{
			this.SendPropertyChanging();
			entity.Filiere = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[Level]")]
	public partial class Level : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<Etudiant> _Etudiants;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Level()
		{
			this._Etudiants = new EntitySet<Etudiant>(new Action<Etudiant>(this.attach_Etudiants), new Action<Etudiant>(this.detach_Etudiants));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Level_Etudiant", Storage="_Etudiants", ThisKey="id", OtherKey="id_level")]
		public EntitySet<Etudiant> Etudiants
		{
			get
			{
				return this._Etudiants;
			}
			set
			{
				this._Etudiants.Assign(value);
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
		
		private void attach_Etudiants(Etudiant entity)
		{
			this.SendPropertyChanging();
			entity.Level = this;
		}
		
		private void detach_Etudiants(Etudiant entity)
		{
			this.SendPropertyChanging();
			entity.Level = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _login;
		
		private string _password;
		
		private System.Nullable<bool> _admin;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnloginChanging(string value);
    partial void OnloginChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnadminChanging(System.Nullable<bool> value);
    partial void OnadminChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_login", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string login
		{
			get
			{
				return this._login;
			}
			set
			{
				if ((this._login != value))
				{
					this.OnloginChanging(value);
					this.SendPropertyChanging();
					this._login = value;
					this.SendPropertyChanged("login");
					this.OnloginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin", DbType="Bit")]
		public System.Nullable<bool> admin
		{
			get
			{
				return this._admin;
			}
			set
			{
				if ((this._admin != value))
				{
					this.OnadminChanging(value);
					this.SendPropertyChanging();
					this._admin = value;
					this.SendPropertyChanged("admin");
					this.OnadminChanged();
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
}
#pragma warning restore 1591
