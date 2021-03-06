﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace DevSpace.Common {
	[DataContract]
	[KnownType( typeof(Tag))]
	public class Session : ISession {
		private Session() {
			this._tags = new List<Tag>();
		}

		#region ISession
		[DataMember]public string Abstract { get; private set; }
		[DataMember]public bool Accepted { get; private set; }
		[DataMember]public int Id { get; private set; }
		[DataMember]public string Notes { get; private set; }
		[DataMember]public string Title { get; private set; }
		[DataMember]	public int UserId { get; private set; }

		[DataMember( Name = "Tags" )]private List<Tag> _tags;
		public ImmutableList<ITag> Tags {
			get {
				return ImmutableList<ITag>.Empty.AddRange( _tags );
			}
		}

		public ISession UpdateAbstract( string value ) {
			Session newSession = this.Clone();
			newSession.Abstract = value;
			return newSession;
		}

		public ISession UpdateAccepted( bool value ) {
			Session newSession = this.Clone();
			newSession.Accepted = value;
			return newSession;
		}

		public ISession UpdateId( int value ) {
			Session newSession = this.Clone();
			newSession.Id = value;
			return newSession;
		}

		public ISession UpdateNotes( string value ) {
			Session newSession = this.Clone();
			newSession.Notes = value;
			return newSession;
		}

		public ISession UpdateTitle( string value ) {
			Session newSession = this.Clone();
			newSession.Title = value;
			return newSession;
		}

		public ISession UpdateUserId( int value ) {
			Session newSession = this.Clone();
			newSession.UserId = value;
			return newSession;
		}

		public ISession AddTag( ITag value ) {
			Session newSession = this.Clone();
			newSession._tags.Add( new Tag( value ) );
			return newSession;
		}

		public ISession RemoveTag( ITag value ) {
			Session newSession = this.Clone();
			newSession._tags.Remove( new Tag( value ) );
			return newSession;
		}
		#endregion

		private Session Clone() {
			Session cloned = new Session {
				Id = this.Id,
				UserId = this.UserId,
				Title = string.Copy( this.Title ),
				Abstract = string.Copy( this.Abstract ),
				Accepted = this.Accepted
			};

			if( !string.IsNullOrWhiteSpace( this.Notes ) )
				cloned.Notes = string.Copy( this.Notes );

			foreach( ITag tag in this._tags ) {
				cloned._tags.Add( new Tag( tag ) );
			}

			return cloned;
		}
	}
}
