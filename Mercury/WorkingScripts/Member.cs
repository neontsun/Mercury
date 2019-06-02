using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.WorkingScripts
{
    public class Member
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        internal int MemberID { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        internal string Email { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Email">Email</param>
        /// <param name="MemberID">ID</param>
        public Member(string Email, int MemberID)
        {
            this.Email = Email;
            this.MemberID = MemberID;
        }
    }
}
