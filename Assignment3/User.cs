using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
	public partial class User : IIdentity
	{
		public User(string firstName, string lastName)
		{
			_FirstName = firstName;
			_LastName = lastName;
			this._UserAccounts = new EntitySet<UserAccount>(new Action<UserAccount>(this.attach_UserAccounts), new Action<UserAccount>(this.detach_UserAccounts));
			this._Trainer = default(EntityRef<Trainer>);
			this._Student = default(EntityRef<Student>);
			OnCreated();
		}

		public override string ToString()
		{
			return $"User[{ID}] {FirstName} {LastName} {(Student == null ? "(Trainer)" : "(Student)")}";
		}
	}
}
