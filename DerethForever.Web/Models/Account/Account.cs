using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DerethForever.Web.Models.Account
{
	[Table("account")]
    public class Account
    {
		[Key]
		[Column("accountId")]
		public int Id { get; set; }

		[Column("accountGiud")]
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

//CREATE TABLE `account` (
//  `accountId` int (10) unsigned NOT NULL AUTO_INCREMENT,
//  `accountGuid` binary(16) NOT NULL,
//  `accountName` varchar(50) NOT NULL,
//  `displayName` varchar(50) NOT NULL,
//  `passwordHash` varchar(88) NOT NULL COMMENT 'base64 encoded version of the hashed passwords.  88 characters are needed to base64 encode SHA512 output.',
//  `passwordSalt` varchar(88) NOT NULL COMMENT 'base64 encoded version of the password salt.  512 byte salts (88 characters when base64 encoded) are recommend for SHA512.',
//  `email` varchar(280) DEFAULT NULL,
//  `numContributions` int (11) DEFAULT NULL,
//   PRIMARY KEY(`accountId`),
//  UNIQUE KEY `accountName_uidx` (`accountName`),
//  UNIQUE KEY `accountGuid_uidx` (`accountGuid`)
//) ENGINE=InnoDB AUTO_INCREMENT = 2 DEFAULT CHARSET = utf8;
