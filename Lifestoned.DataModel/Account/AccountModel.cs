using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lifestoned.DataModel.Account
{
    [Table("account")]
    public class AccountModel
    {
        [Key]
        [Column("accountId")]
        public uint Id { get; set; }

        [Column("accountGuid")]
        public Guid Gid { get; set; }

        [Column("accountName")]
        public string Name { get; set; }

        [Column("displayName")]
        public string DisplayName { get; set; }

        [Column("passwordHash")]
        public string PasswordHash { get; set; }

        [Column("passwordSalt")]
        public string PasswordSalt { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("numContributions")]
        public int? Contributions { get; set; }
    }
}
